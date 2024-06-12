using jomedAPI.Models;
using JomedAPIForms.Classes.Interfaces;

namespace JomedAPIForms.Forms.Medicos;

public partial class Form_Medicos : Form
{
    private IHttpClientBuilder _httpClientBuilder;
    private List<Medico> _listaMedicos;
    public Form_Medicos(IHttpClientBuilder httpClientBuilder, List<Medico> listaMedicos)
    {
        _httpClientBuilder = httpClientBuilder;
        _listaMedicos = listaMedicos;
        InitializeComponent();
        Dgv_Medicos.DataSource = listaMedicos;
    }

    private void toolStripNovo_Click(object sender, EventArgs e)
    {
        AtivarFormulario();
    }
    private void toolStripEditar_Click(object sender, EventArgs e)
    {
        AtivarFormulario();
    }
    private void toolStripSalvar_Click(object sender, EventArgs e)
    {

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

    private void AtivarFormulario()
    {
        toolStripNovo.Enabled = false;
        toolStripBuscar.Enabled = false;
        toolStripEditar.Enabled = true;
        toolStripSalvar.Enabled = true;
        toolStripExcluir.Enabled = true;
        toolStripCancelar.Enabled = true;
        Txt_Id.Enabled = true;
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
        Txt_Id.Focus();
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
        Txt_Email.Enabled = false;
        Txt_Telefone.Enabled = false;
        Cmb_Especialidade.Enabled = false;
        Txt_Logradouro.Enabled = false;
        Txt_Numero.Enabled = false;
        Txt_Bairro.Enabled = false;
        Txt_Complemento.Enabled = false;
        Txt_CEP.Enabled = false;
        Txt_Cidade.Enabled = false;
        Cmb_UF.Enabled = false;
        Dgv_Medicos.Focus();
    }
    private void LimparFormulario()
    {
        Txt_Id.Enabled = true;
        Txt_CRM.Enabled = true;
        Ckb_Ativo.CheckState = CheckState.Unchecked;
        Txt_Nome.Enabled = false;
        Txt_Email.Enabled = false;
        Txt_Telefone.Enabled = false;
        Cmb_Especialidade.SelectedIndex = -1;
        Txt_Logradouro.Enabled = false;
        Txt_Numero.Enabled = false;
        Txt_Bairro.Enabled = false;
        Txt_Complemento.Enabled = false;
        Txt_CEP.Enabled = false;
        Txt_Cidade.Enabled = false;
        Cmb_UF.SelectedIndex = -1;
    }
}
