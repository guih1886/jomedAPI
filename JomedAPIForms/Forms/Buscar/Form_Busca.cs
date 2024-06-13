using jomedAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace JomedAPIForms.Forms.Buscar;

public partial class Form_Busca : Form
{
    private List<Paciente> _lista;
    private List<Paciente>? _listaAux;
    public DataGridViewRow? selecionado { get; set; }
    public Form_Busca(List<Paciente> lista, string nomeIdentificador)
    {
        _lista = lista;
        InitializeComponent();
        ConfiguraDataGridView(lista, nomeIdentificador);
        Lbl_Identificador.Text = nomeIdentificador;
    }

    private void Btn_Buscar_Click(object sender, EventArgs e)
    {
        List<Paciente> novaLista = new List<Paciente>();
        int id = 0;
        if (!Txt_Id.Text.IsNullOrEmpty()) id = Int32.Parse(Txt_Id.Text);
        if (id == 0)
        {
            Dgv_Busca.DataSource = _lista.Where(p => p.Cpf.Contains(Txt_CPF.Text) && p.Email.Contains(Txt_Email.Text) && p.Nome.Contains(Txt_Nome.Text)).ToList();
        }
        else
        {
            novaLista = _lista.Where(p => p.Id == id).ToList();
            Dgv_Busca.DataSource = novaLista;
        }
    }
    private void Btn_Selecionar_Click(object sender, EventArgs e)
    {
        selecionado = Dgv_Busca.SelectedRows[0];
        DialogResult = DialogResult.OK;
        this.Close();
    }
    private void Btn_Cancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void ConfiguraDataGridView(List<Paciente> lista, string nomeIdentificador)
    {
        Dgv_Busca.DataSource = lista.Where(p => p.Ativo == true).ToList();
        Dgv_Busca.Columns["Endereco"].Visible = false;
        Dgv_Busca.Columns["Telefone"].Visible = false;
        //Redimencionar as colunas
        Dgv_Busca.Columns["Id"].Width = 50;
        Dgv_Busca.Columns["Nome"].Width = 250;
        Dgv_Busca.Columns["Email"].Width = 250;
        Dgv_Busca.Columns[nomeIdentificador].Width = 150;
        Dgv_Busca.Columns["Ativo"].Width = 50;
    }
    private void Ckb_Ativo_CheckedChanged(object sender, EventArgs e)
    {
        if (Ckb_Ativo.CheckState == CheckState.Unchecked)
        {
            _listaAux = _lista;
            ConfiguraDataGridView(_lista.Where(p => p.Ativo == false).ToList(), "");
        }
        if (Ckb_Ativo.CheckState == CheckState.Checked)
        {
            ConfiguraDataGridView(_listaAux!.Where(p => p.Ativo == true).ToList(), "");
        }
    }
}