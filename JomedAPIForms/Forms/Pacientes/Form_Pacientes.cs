using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Paciente;
using JomedAPIForms.Classes;
using JomedAPIForms.Classes.Interfaces;
using JomedAPIForms.Forms.Buscar;
using JomedAPIForms.Models;
using Newtonsoft.Json;

namespace JomedAPIForms.Forms.Pacientes;

public partial class Form_Pacientes : Form
{
    private IHttpClientBuilder _httpClientBuilder;
    private List<Paciente> _listaPacientes;
    private int? _pacienteId;
    private string? _pacienteNome;
    private DataGridViewRow? _pacienteSelecionado;
    public Form_Pacientes(IHttpClientBuilder httpClientBuilder, List<Paciente> listaPacientes, string usuarioRole)
    {
        _httpClientBuilder = httpClientBuilder;
        _listaPacientes = listaPacientes;
        InitializeComponent();
        Dgv_Pacientes.DataSource = listaPacientes;
        PreencheComboBoxUF();
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
    }
    private async void toolStripEditar_Click(object sender, EventArgs e)
    {
        int numero = !string.IsNullOrEmpty(Txt_Numero.Text) ? Int32.Parse(Txt_Numero.Text) : 0;
        UpdatePacienteDto pacienteAlterado = new UpdatePacienteDto(Txt_Nome.Text, Txt_Email.Text, Txt_CPF.Text, Txt_Telefone.Text);
        UpdateEnderecoDto novoEndereco = new UpdateEnderecoDto(Txt_Logradouro.Text, Txt_Bairro.Text, Txt_CEP.Text, Txt_Cidade.Text, Cmb_UF.Text, numero, Txt_Complemento.Text);
        HttpResponseMessage resposta = await _httpClientBuilder.PutRequisition($"/Pacientes/{_pacienteId}", pacienteAlterado);
        HttpResponseMessage respostaEndereco = await _httpClientBuilder.PutRequisition($"/Pacientes/{_pacienteId}/atualizarEndereco", novoEndereco);
        string msg = await ValidaRequisicoes.ValidarErrosRequisicao(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            if (respostaEndereco.IsSuccessStatusCode)
            {
                AtivaOuDesativaPaciente();
                MessageBox.Show("Paciente atualizado com sucesso.", "Cadastro de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizaPacientes();
                LimparFormulario();
                DesativarFormulario();
            }
            else
            {
                string msgEndereco = await ValidaRequisicoes.ValidarErrosRequisicao(respostaEndereco);
                MessageBox.Show(msgEndereco, "Cadastro de Pacientess", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show(msg, "Cadastro de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void toolStripSalvar_Click(object sender, EventArgs e)
    {
        int numero = !string.IsNullOrEmpty(Txt_Numero.Text) ? Int32.Parse(Txt_Numero.Text) : 0;
        Endereco endereco = new Endereco(Txt_Logradouro.Text, Txt_Bairro.Text, Txt_CEP.Text, Txt_Cidade.Text, Cmb_UF.Text, numero, Txt_Complemento.Text);
        CreatePacienteDto novoPaciente = new CreatePacienteDto(Txt_Nome.Text, Txt_Email.Text, Txt_CPF.Text, Txt_Telefone.Text, endereco);
        HttpResponseMessage resposta = await _httpClientBuilder.PostRequisition("/Pacientes", novoPaciente);
        string msg = await ValidaRequisicoes.ValidarErrosRequisicao(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            MessageBox.Show("Paciente atualizado com sucesso.", "Cadastro de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AtualizaPacientes();
            LimparFormulario();
            DesativarFormulario();
        }
        else
        {
            MessageBox.Show(msg, "Cadastro de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void toolStripBuscar_Click(object sender, EventArgs e)
    {
        Form_Busca buscar = new Form_Busca(_listaPacientes, "CPF");
        DialogResult resposta = buscar.ShowDialog();
        if (resposta == DialogResult.OK)
        {
            PreencheFormComBuscar(buscar.selecionado!);
        }
    }
    private async void toolStripExcluir_Click(object sender, EventArgs e)
    {
        DialogResult resposta = MessageBox.Show($"Deseja mesmo excluir o cadastro do paciente {_pacienteNome}?", "Exclusão de Pacientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        if (resposta == DialogResult.OK)
        {
            HttpResponseMessage response = await _httpClientBuilder.DeleteRequisition($"/Pacientes/{_pacienteId}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Paciente excluído com sucesso.", "Exclusão de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFormulario();
                DesativarFormulario();
                AtualizaPacientes();
            }
            else
            {
                //Não chegará aqui, mas caso o botão de exclusão esteja ativo, a API devolverá o http 403
                MessageBox.Show("Usuário sem autorização para executar a ação.", "Exclusão de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
    private void toolStripCancelar_Click(object sender, EventArgs e)
    {
        LimparFormulario();
        DesativarFormulario();
    }
    private void Dgv_Pacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        LimparFormulario();
        DataGridViewRow linha = Dgv_Pacientes.SelectedRows[0];
        _pacienteSelecionado = linha;
        PreencheFormComDataGridView(linha);
    }

    private void AtivarFormulario()
    {
        toolStripNovo.Enabled = false;
        toolStripBuscar.Enabled = false;
        toolStripEditar.Enabled = true;
        toolStripExcluir.Enabled = true;
        toolStripCancelar.Enabled = true;
        Txt_CPF.Enabled = true;
        Ckb_Ativo.Enabled = true;
        Txt_Nome.Enabled = true;
        Txt_Email.Enabled = true;
        Txt_Telefone.Enabled = true;
        Txt_Logradouro.Enabled = true;
        Txt_Numero.Enabled = true;
        Txt_Bairro.Enabled = true;
        Txt_Complemento.Enabled = true;
        Txt_CEP.Enabled = true;
        Txt_Cidade.Enabled = true;
        Cmb_UF.Enabled = true;
        Txt_CPF.Focus();
        Dgv_Pacientes.Enabled = false;
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
        Txt_CPF.Enabled = false;
        Ckb_Ativo.Enabled = false;
        Txt_Nome.Enabled = false;
        Txt_Email.Enabled = false;
        Txt_Telefone.Enabled = false;
        Txt_Logradouro.Enabled = false;
        Txt_Numero.Enabled = false;
        Txt_Bairro.Enabled = false;
        Txt_Complemento.Enabled = false;
        Txt_CEP.Enabled = false;
        Txt_Cidade.Enabled = false;
        Cmb_UF.Enabled = false;
        Dgv_Pacientes.Focus();
        Dgv_Pacientes.Enabled = true;
    }
    private void LimparFormulario()
    {
        Txt_Id.Text = "";
        Txt_CPF.Text = "";
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
        _pacienteId = (Int32)linha.Cells[1].Value;
        _pacienteNome = linha.Cells[2].Value.ToString();
        AtivarFormulario();
        Txt_Id.Enabled = false;
        toolStripSalvar.Enabled = false;
        if (linha.Cells[0].Value.ToString() == "True") Ckb_Ativo.CheckState = CheckState.Checked;
        if (linha.Cells[0].Value.ToString() == "False") Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Id.Text = linha.Cells[1].Value.ToString();
        Txt_Nome.Text = linha.Cells[2].Value.ToString();
        Txt_Email.Text = linha.Cells[3].Value.ToString();
        Txt_CPF.Text = linha.Cells[4].Value.ToString();
        Txt_Telefone.Text = linha.Cells[5].Value.ToString();
        Endereco endereco = (Endereco)linha.Cells[6].Value;
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
        _pacienteId = (Int32)linha.Cells[0].Value;
        _pacienteNome = linha.Cells[1].Value.ToString();
        AtivarFormulario();
        Txt_Id.Enabled = false;
        toolStripSalvar.Enabled = false;
        if (linha.Cells[6].Value.ToString() == "True") Ckb_Ativo.CheckState = CheckState.Checked;
        if (linha.Cells[6].Value.ToString() == "False") Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Id.Text = linha.Cells[0].Value.ToString();
        Txt_Nome.Text = linha.Cells[1].Value.ToString();
        Txt_Email.Text = linha.Cells[2].Value.ToString();
        Txt_CPF.Text = linha.Cells[3].Value.ToString();
        Txt_Telefone.Text = linha.Cells[4].Value.ToString();
        Endereco endereco = (Endereco)linha.Cells[5].Value;
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
    private void VerificaFuncaoDoUsuario(string usuarioRole)
    {
        if (usuarioRole != "Administrador")
        {
            Ckb_Ativo.Visible = false;
            toolStripExcluir.Visible = false;
            toolStripSeparator5.Visible = false;
        }
    }
    private async void AtualizaPacientes()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetRequisition("/Pacientes");
        List<Paciente> lista = JsonConvert.DeserializeObject<List<Paciente>>(await resposta.Content.ReadAsStringAsync())!;
        _listaPacientes = lista;
        Dgv_Pacientes.DataSource = lista;
    }
    private async void AtivaOuDesativaPaciente()
    {
        if (Ckb_Ativo.CheckState == CheckState.Unchecked)
        {
            await _httpClientBuilder.DeleteRequisition($"/Pacientes/{_pacienteId}/inativar");
        }
        if (Ckb_Ativo.CheckState == CheckState.Checked)
        {
            await _httpClientBuilder.PostRequisition($"/Pacientes/{_pacienteId}/ativar", "");
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