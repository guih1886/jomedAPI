using jomedAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace JomedAPIForms.Forms.Buscar;

public partial class Form_Busca : Form
{
    private List<Paciente> _lista;
    private string _identificador;
    private int status = 0;
    public DataGridViewRow? selecionado { get; set; }
    public Form_Busca(List<Paciente> lista, string nomeIdentificador)
    {
        _lista = lista;
        _identificador = nomeIdentificador;
        InitializeComponent();
        Cmb_Status.SelectedIndex = 0;
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
            if (status == 0)
            {
                Dgv_Busca.DataSource = _lista.Where(p => p.Email!.Contains(Txt_Email.Text) && p.Nome!.Contains(Txt_Nome.Text) && p.Cpf!.Contains(Txt_Identificador.Text)).ToList();
            }
            else
            {
                bool situacao = status == 1 ? true : false;
                Dgv_Busca.DataSource = _lista.Where(p => p.Ativo == situacao && p.Email!.Contains(Txt_Email.Text) && p.Nome!.Contains(Txt_Nome.Text)).ToList();
            }
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
        Dgv_Busca.DataSource = lista;
        Dgv_Busca.Columns["Endereco"].Visible = false;
        Dgv_Busca.Columns["Telefone"].Visible = false;
        //Redimencionar as colunas
        Dgv_Busca.Columns["Id"].Width = 50;
        Dgv_Busca.Columns["Nome"].Width = 250;
        Dgv_Busca.Columns["Email"].Width = 250;
        Dgv_Busca.Columns[nomeIdentificador].Width = 150;
        Dgv_Busca.Columns["Ativo"].Width = 55;
    }
    private void Cmb_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Cmb_Status.SelectedIndex == 0) status = 0;
        if (Cmb_Status.SelectedIndex == 1) status = 1;
        if (Cmb_Status.SelectedIndex == 2) status = 2;
    }
    private void Btn_Limpar_Click(object sender, EventArgs e)
    {
        ConfiguraDataGridView(_lista, _identificador);
        Cmb_Status.SelectedIndex = 0;
        Txt_Id.Text = string.Empty;
        Txt_Nome.Text = string.Empty;
        Txt_Identificador.Text = string.Empty;
        Txt_Email.Text = string.Empty;
    }
}