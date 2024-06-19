using jomedAPI.Models;
using jomedAPI.Models.Enum;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Medico;
using JomedAPIForms.Classes;
using JomedAPIForms.Classes.Interfaces;
using JomedAPIForms.Models;
using Newtonsoft.Json;

namespace JomedAPIForms.Forms.Medicos;

public partial class Form_Medicos : Form
{
    private IHttpClientBuilder _httpClientBuilder;
    private List<Medico> _listaMedicos;
    private int? _medicoId;
    private string? _medicoNome;
    private DataGridViewRow? _medicoSelecionado;
    public Form_Medicos(IHttpClientBuilder httpClientBuilder, List<Medico> listaMedicos, string usuarioRole)
    {
        _httpClientBuilder = httpClientBuilder;
        _listaMedicos = listaMedicos;
        InitializeComponent();
        Dgv_Medicos.DataSource = listaMedicos;
        PreencheComboBoxUF();
        PreencheComboBoxEspecialidade();
        VerificaFuncaoDoUsuario(usuarioRole);
    }

    private void toolStripNovo_Click(object sender, EventArgs e)
    {
        AtivarFormulario();
        toolStripEditar.Enabled = false;
        toolStripExcluir.Enabled = false;
        toolStripSalvar.Enabled = true;
        Ckb_Ativo.CheckState = CheckState.Checked;
        Ckb_Ativo.Enabled = false;
        Cmb_Especialidade.SelectedIndex = 1;
    }
    private async void toolStripEditar_Click(object sender, EventArgs e)
    {
        int numero = !string.IsNullOrEmpty(Txt_Numero.Text) ? Int32.Parse(Txt_Numero.Text) : 0;
        Especialidade especialidade = (Especialidade)Cmb_Especialidade.SelectedItem!;
        UpdateMedicoDto medicoAlterado = new UpdateMedicoDto(Txt_Nome.Text, Txt_Email.Text, Txt_Telefone.Text, Txt_CRM.Text, especialidade);
        UpdateEnderecoDto novoEndereco = new UpdateEnderecoDto(Txt_Logradouro.Text, Txt_Bairro.Text, Txt_CEP.Text, Txt_Cidade.Text, Cmb_UF.Text, numero, Txt_Complemento.Text);
        HttpResponseMessage resposta = await _httpClientBuilder.PutRequisition($"/Medicos/{_medicoId}", medicoAlterado);
        HttpResponseMessage respostaEndereco = await _httpClientBuilder.PutRequisition($"/Medicos/{_medicoId}/atualizarEndereco", novoEndereco);
        string msg = await ValidaRequisicoes.ValidarErrosRequisicao(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            if (respostaEndereco.IsSuccessStatusCode)
            {
                AtivaOuDesativaMedico();
                MessageBox.Show("Médico atualizado com sucesso.", "Cadastro de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizaMedicos();
                LimparFormulario();
                DesativarFormulario();
            }
            else
            {
                string msgEndereco = await ValidaRequisicoes.ValidarErrosRequisicao(respostaEndereco);
                MessageBox.Show(msgEndereco, "Cadastro de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show(msg, "Cadastro de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void toolStripSalvar_Click(object sender, EventArgs e)
    {
        int numero = !string.IsNullOrEmpty(Txt_Numero.Text) ? Int32.Parse(Txt_Numero.Text) : 0;
        Endereco endereco = new Endereco(Txt_Logradouro.Text, Txt_Bairro.Text, Txt_CEP.Text, Txt_Cidade.Text, Cmb_UF.Text, numero, Txt_Complemento.Text);
        Especialidade especialidade = (Especialidade)Cmb_Especialidade.SelectedItem!;
        CreateMedicoDto novoMedico = new CreateMedicoDto(Txt_Nome.Text, Txt_Email.Text, Txt_Telefone.Text, Txt_CRM.Text, especialidade, endereco);
        HttpResponseMessage resposta = await _httpClientBuilder.PostRequisition("/Medicos", novoMedico);
        string msg = await ValidaRequisicoes.ValidarErrosRequisicao(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            MessageBox.Show("Médico criado com sucesso.", "Cadastro de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AtualizaMedicos();
            LimparFormulario();
            DesativarFormulario();
        }
        else
        {
            MessageBox.Show(msg, "Cadastro de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void toolStripBuscar_Click(object sender, EventArgs e)
    {
        Form_BuscaMedicos buscar = new Form_BuscaMedicos(_listaMedicos);
        DialogResult resposta = buscar.ShowDialog();
        if (resposta == DialogResult.OK)
        {
            PreencheFormComBuscar(buscar.selecionado!);
        }
    }
    private async void toolStripExcluir_Click(object sender, EventArgs e)
    {
        DialogResult resposta = MessageBox.Show($"Deseja mesmo excluir o cadastro do médico {_medicoNome}?", "Exclusão de Médicos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        if (resposta == DialogResult.OK)
        {
            HttpResponseMessage response = await _httpClientBuilder.DeleteRequisition($"/Medicos/{_medicoId}", "");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Médico excluído com sucesso.", "Exclusão de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFormulario();
                DesativarFormulario();
                AtualizaMedicos();
            }
            else
            {
                //Não chegará aqui, mas caso o botão de exclusão esteja ativo, a API devolverá o http 403
                MessageBox.Show("Usuário sem autorização para executar a ação.", "Exclusão de Médicos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
    private void toolStripCancelar_Click(object sender, EventArgs e)
    {
        LimparFormulario();
        DesativarFormulario();
    }
    private void Dgv_Medicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        LimparFormulario();
        DataGridViewRow linha = Dgv_Medicos.SelectedRows[0];
        _medicoSelecionado = linha;
        PreencheFormComDataGridView(_medicoSelecionado);
    }

    private void AtivarFormulario()
    {
        toolStripNovo.Enabled = false;
        toolStripBuscar.Enabled = false;
        toolStripEditar.Enabled = true;
        toolStripExcluir.Enabled = true;
        toolStripCancelar.Enabled = true;
        Txt_CRM.Enabled = true;
        Ckb_Ativo.Enabled = true;
        Txt_Nome.Enabled = true;
        Txt_Email.Enabled = true;
        Txt_Telefone.Enabled = true;
        Cmb_Especialidade.Enabled = true;
        Txt_Logradouro.Enabled = true;
        Txt_Numero.Enabled = true;
        Txt_Bairro.Enabled = true;
        Txt_Complemento.Enabled = true;
        Txt_CEP.Enabled = true;
        Txt_Cidade.Enabled = true;
        Cmb_UF.Enabled = true;
        Txt_CRM.Focus();
        Dgv_Medicos.Enabled = false;
    }
    private void DesativarFormulario()
    {
        toolStripNovo.Enabled = true;
        toolStripBuscar.Enabled = true;
        toolStripEditar.Enabled = false;
        toolStripSalvar.Enabled = false;
        toolStripExcluir.Enabled = false;
        toolStripCancelar.Enabled = false;
        Txt_Id.Enabled = false;
        Txt_CRM.Enabled = false;
        Ckb_Ativo.Enabled = false;
        Txt_Nome.Enabled = false;
        Cmb_Especialidade.Enabled = false;
        Txt_Email.Enabled = false;
        Txt_Telefone.Enabled = false;
        Txt_Logradouro.Enabled = false;
        Txt_Numero.Enabled = false;
        Txt_Bairro.Enabled = false;
        Txt_Complemento.Enabled = false;
        Txt_CEP.Enabled = false;
        Txt_Cidade.Enabled = false;
        Cmb_UF.Enabled = false;
        Dgv_Medicos.Focus();
        Dgv_Medicos.Enabled = true;
        Cmb_Especialidade.SelectedIndex = 0;
    }
    private void LimparFormulario()
    {
        Txt_Id.Text = "";
        Txt_CRM.Text = "";
        Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Nome.Text = "";
        Txt_Email.Text = "";
        Txt_Telefone.Text = "";
        Txt_Logradouro.Text = "";
        Txt_Numero.Text = "";
        Txt_Bairro.Text = "";
        Txt_Complemento.Text = "";
        Txt_CEP.Text = "";
        Txt_Cidade.Text = "";
        Cmb_UF.SelectedIndex = -1;
    }
    private void PreencheFormComDataGridView(DataGridViewRow linha)
    {
        _medicoId = Int32.Parse(linha.Cells[1].Value.ToString()!);
        _medicoNome = linha.Cells[2].Value.ToString();
        AtivarFormulario();
        Txt_Id.Enabled = false;
        toolStripSalvar.Enabled = false;
        if (linha.Cells[0].Value.ToString() == "True") Ckb_Ativo.CheckState = CheckState.Checked;
        if (linha.Cells[0].Value.ToString() == "False") Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Id.Text = linha.Cells[1].Value.ToString();
        Txt_Nome.Text = linha.Cells[2].Value.ToString();
        Txt_Email.Text = linha.Cells[3].Value.ToString();
        Txt_CRM.Text = linha.Cells[4].Value.ToString();
        Txt_Telefone.Text = linha.Cells[5].Value.ToString();
        Endereco endereco = (Endereco)linha.Cells[7].Value;
        Cmb_Especialidade.SelectedIndex = Cmb_Especialidade.FindStringExact(linha.Cells[6].Value.ToString());
        Txt_Logradouro.Text = endereco.Logradouro;
        Txt_Numero.Text = endereco.Numero.ToString();
        Txt_Bairro.Text = endereco.Bairro;
        Txt_Complemento.Text = endereco.Complemento;
        Txt_CEP.Text = endereco.Cep;
        Txt_Cidade.Text = endereco.Cidade;
        Cmb_UF.SelectedIndex = Cmb_UF.FindStringExact(endereco.Uf);
    }
    private void PreencheFormComBuscar(DataGridViewRow linha)
    {
        _medicoId = Int32.Parse(linha.Cells[0].Value.ToString()!);
        _medicoNome = linha.Cells[1].Value.ToString();
        AtivarFormulario();
        Txt_Id.Enabled = false;
        toolStripSalvar.Enabled = false;
        if (linha.Cells[7].Value.ToString() == "True") Ckb_Ativo.CheckState = CheckState.Checked;
        if (linha.Cells[7].Value.ToString() == "False") Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Id.Text = linha.Cells[0].Value.ToString();
        Txt_CRM.Text = linha.Cells[4].Value.ToString();
        Txt_Nome.Text = linha.Cells[1].Value.ToString();
        Txt_Email.Text = linha.Cells[2].Value.ToString();
        Txt_Telefone.Text = linha.Cells[3].Value.ToString();
        Cmb_Especialidade.SelectedIndex = Cmb_Especialidade.FindStringExact(linha.Cells[5].Value.ToString());
        Endereco endereco = (Endereco)linha.Cells[6].Value;
        Txt_Logradouro.Text = endereco.Logradouro;
        Txt_Numero.Text = endereco.Numero.ToString();
        Txt_Bairro.Text = endereco.Bairro;
        Txt_Complemento.Text = endereco.Complemento;
        Txt_CEP.Text = endereco.Cep;
        Txt_Cidade.Text = endereco.Cidade;
        Cmb_UF.SelectedIndex = Cmb_UF.FindStringExact(endereco.Uf);
    }
    private void PreencheComboBoxUF()
    {
        Cmb_UF.Items.AddRange(["AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP", "SE", "TO"]);
    }
    private void PreencheComboBoxEspecialidade()
    {
        Cmb_Especialidade.Items.Add("");
        foreach (var item in Enum.GetValues(typeof(Especialidade)))
        {
            Cmb_Especialidade.Items.Add(item);
        }
        Cmb_Especialidade.SelectedIndex = 0;
    }
    private void VerificaFuncaoDoUsuario(string usuarioRole)
    {
        if (usuarioRole != "Administrador")
        {
            Ckb_Ativo.Visible = false;
            toolStripExcluir.Visible = false;
            toolStripSeparator5.Visible = false;
        }
    }
    private async void AtualizaMedicos()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetRequisition("/Medicos");
        List<Medico> lista = JsonConvert.DeserializeObject<List<Medico>>(await resposta.Content.ReadAsStringAsync())!;
        _listaMedicos = lista;
        Dgv_Medicos.DataSource = lista;
    }
    private async void AtivaOuDesativaMedico()
    {
        if (Ckb_Ativo.CheckState == CheckState.Unchecked)
        {
            await _httpClientBuilder.DeleteRequisition($"/Medicos/{_medicoId}/inativar", "");
        }
        if (Ckb_Ativo.CheckState == CheckState.Checked)
        {
            await _httpClientBuilder.PostRequisition($"/Medicos/{_medicoId}/ativar", "");
        }
    }

    private async void Txt_CEP_Leave(object sender, EventArgs e)
    {
        if (Txt_CEP.Text != string.Empty)
        {
            HttpResponseMessage resposta = await _httpClientBuilder.GetExternal($"https://viacep.com.br/ws/{Txt_CEP.Text}/json/");
            if (resposta.IsSuccessStatusCode)
            {
                BuscarEndereco endereco = JsonConvert.DeserializeObject<BuscarEndereco>(await resposta.Content.ReadAsStringAsync())!;
                Txt_Logradouro.Text = endereco.Logradouro;
                Txt_Bairro.Text = endereco.Bairro;
                Txt_Complemento.Text = endereco.Complemento;
                Txt_Cidade.Text = endereco.Localidade;
                Cmb_UF.SelectedIndex = Cmb_UF.FindStringExact(endereco.Uf);
            }
        }
    }
}
