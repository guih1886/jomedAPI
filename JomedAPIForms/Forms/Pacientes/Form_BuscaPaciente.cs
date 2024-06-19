using jomedAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace JomedAPIForms.Forms.Buscar;

public partial class Form_BuscaPaciente : Form
{
    private List<Paciente> _lista;
    private int status = 0;
    public DataGridViewRow? selecionado { get; set; }
    public Form_BuscaPaciente(List<Paciente> lista)
    {
        _lista = lista;
        InitializeComponent();
        Cmb_Status.SelectedIndex = 0;
        ConfiguraDataGridView(lista);
    }

    private void Btn_Buscar_Click(object sender, EventArgs e)
    {
        List<Paciente> novaLista = new List<Paciente>();
        int id = 0;
        try
        {
            if (!Txt_Id.Text.IsNullOrEmpty()) id = Int32.Parse(Txt_Id.Text);
        }
        catch (Exception)
        {
            MessageBox.Show("Id não é um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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

            novaLista = _lista.Where(p => p.Id.Equals(id)).ToList();
            Dgv_Busca.DataSource = novaLista;
        }
    }
    private void Btn_Selecionar_Click(object sender, EventArgs e)
    {
        try
        {
            selecionado = Dgv_Busca.SelectedRows[0];
            DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("Erro ao selecionar paciente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void Btn_Cancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void ConfiguraDataGridView(List<Paciente> lista)
    {
        Dgv_Busca.DataSource = lista;
        Dgv_Busca.Columns["Endereco"].Visible = false;
        Dgv_Busca.Columns["Telefone"].Visible = false;
        //Redimencionar as colunas
        Dgv_Busca.Columns["Id"].Width = 50;
        Dgv_Busca.Columns["Nome"].Width = 250;
        Dgv_Busca.Columns["Email"].Width = 250;
        Dgv_Busca.Columns["CPF"].Width = 150;
        Dgv_Busca.Columns["Ativo"].Width = 70;
    }
    private void Cmb_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Cmb_Status.SelectedIndex == 0) status = 0;
        if (Cmb_Status.SelectedIndex == 1) status = 1;
        if (Cmb_Status.SelectedIndex == 2) status = 2;
    }
    private void Btn_Limpar_Click(object sender, EventArgs e)
    {
        ConfiguraDataGridView(_lista);
        Cmb_Status.SelectedIndex = 0;
        Txt_Id.Text = string.Empty;
        Txt_Nome.Text = string.Empty;
        Txt_Identificador.Text = string.Empty;
        Txt_Email.Text = string.Empty;
    }
}