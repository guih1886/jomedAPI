using jomedAPI.Models;
using JomedAPI.Data.DTO.Paciente;
using JomedAPIForms.Classes;
using JomedAPIForms.Classes.Interfaces;
using JomedAPIForms.Models;
using Newtonsoft.Json;

namespace JomedAPIForms.Forms.Pacientes;

public partial class Form_Pacientes : Form
{
    private IHttpClientBuilder _httpClientBuilder;
    private List<Paciente> _listaPacientes;
    private int? _pacienteId;
    public Form_Pacientes(IHttpClientBuilder httpClientBuilder, List<Paciente> listaPacientes)
    {
        _httpClientBuilder = httpClientBuilder;
        _listaPacientes = listaPacientes;
        InitializeComponent();
        Dgv_Pacientes.DataSource = listaPacientes;
        PreencheComboBoxUF();
    }

    private void toolStripNovo_Click(object sender, EventArgs e)
    {
        AtivarFormulario();
        toolStripEditar.Enabled = false;
        toolStripSalvar.Enabled = true;
        Ckb_Ativo.CheckState = CheckState.Checked;
        Ckb_Ativo.Enabled = false;
    }
    private async void toolStripEditar_Click(object sender, EventArgs e)
    {
        UpdatePacienteDto pacienteAlterado = new UpdatePacienteDto(Txt_Nome.Text, Txt_Email.Text, Txt_CPF.Text, Txt_Telefone.Text);
        HttpResponseMessage resposta = await _httpClientBuilder.PutRequisition($"/Pacientes/{_pacienteId}", pacienteAlterado);
        ValidaRequisicoes.Teste(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            MessageBox.Show("Paciente atualizado com sucesso.", "Cadastros de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AtualizaPacientes();
            LimparFormulario();
            DesativarFormulario();
        }
    }
    private async void toolStripSalvar_Click(object sender, EventArgs e)
    {
        int numero = !string.IsNullOrEmpty(Txt_Numero.Text) ? Int32.Parse(Txt_Numero.Text) : 0;
        Endereco endereco = new Endereco(Txt_Logradouro.Text, Txt_Bairro.Text, Txt_CEP.Text, Txt_Cidade.Text, Cmb_UF.Text, numero, Txt_Complemento.Text);
        CreatePacienteDto novoPaciente = new CreatePacienteDto(Txt_Nome.Text, Txt_Email.Text, Txt_CPF.Text, Txt_Telefone.Text, endereco);
        HttpResponseMessage resposta = await _httpClientBuilder.PostRequisition("/Pacientes", novoPaciente);
        ValidaRequisicoes.Teste(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            MessageBox.Show("Paciente atualizado com sucesso.", "Cadastros de Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AtualizaPacientes();
            LimparFormulario();
            DesativarFormulario();
        }
    }
    private void toolStripBuscar_Click(object sender, EventArgs e)
    {

    }
    private void toolStripExcluir_Click(object sender, EventArgs e)
    {

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
        AtivarFormulario();
        Txt_Id.Enabled = false;
        toolStripSalvar.Enabled = false;
        if (linha.Cells[1].Value.ToString() == "1") Ckb_Ativo.CheckState = CheckState.Checked;
        if (linha.Cells[1].Value.ToString() == "0") Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Id.Text = linha.Cells[1].Value.ToString();
        _pacienteId = (Int32)linha.Cells[1].Value;
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
    private void PreencheComboBoxUF()
    {
        Cmb_UF.Items.AddRange(["AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP", "SE", "TO"]);
    }
    private async void AtualizaPacientes()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetRequisition("/Pacientes");
        List<Paciente> lista = JsonConvert.DeserializeObject<List<Paciente>>(await resposta.Content.ReadAsStringAsync())!;
        Dgv_Pacientes.DataSource = lista;
    }

    private async void Txt_CEP_Leave(object sender, EventArgs e)
    {
        if (Txt_CEP.Text != string.Empty)
        {
            HttpResponseMessage resposta = await _httpClientBuilder.GetExternal($"https://viacep.com.br/ws/{Txt_CEP.Text}/json/");
            BuscarEndereco endereco = JsonConvert.DeserializeObject<BuscarEndereco>(await resposta.Content.ReadAsStringAsync())!;
            Txt_Logradouro.Text = endereco.Logradouro;
            Txt_Bairro.Text = endereco.Bairro;
            Txt_Complemento.Text = endereco.Complemento;
            Txt_Cidade.Text = endereco.Localidade;
            Cmb_UF.SelectedIndex = Cmb_UF.FindStringExact(endereco.Uf);
        }
    }
}
