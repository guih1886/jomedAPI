using jomedAPI.Models;
using jomedAPI.Models.Enum;

namespace JomedAPIForms.Forms.Medicos
{
    public partial class Form_BuscaMedicos : Form
    {
        private List<Medico> listaMedicos;
        private int status = 0;
        public DataGridViewRow? selecionado { get; set; }

        public Form_BuscaMedicos(List<Medico> listaMedicos)
        {
            this.listaMedicos = listaMedicos;
            InitializeComponent();
            Cmb_Status.SelectedIndex = 0;
            ConfiguraDataGridView(listaMedicos);
            PreencheComboBoxEspecialidade();
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            List<Medico> novaLista = new List<Medico>();
            int id = 0;
            try
            {
                if (!string.IsNullOrEmpty(Txt_Id.Text)) id = Int32.Parse(Txt_Id.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Id não é um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (id == 0)
            {
                if (status == 0)
                {
                    if (Cmb_Especialidade.SelectedIndex == 0)
                    {
                        Dgv_Busca.DataSource = listaMedicos.Where(p => p.Nome!.Contains(Txt_Nome.Text) && p.Crm!.Contains(Txt_CRM.Text)).ToList();
                    }
                    else
                    {
                        Especialidade especialidade = (Especialidade)Cmb_Especialidade.SelectedItem!;
                        Dgv_Busca.DataSource = listaMedicos.Where(p => p.Nome!.Contains(Txt_Nome.Text) && p.Crm!.Contains(Txt_CRM.Text) && p.Especialidade.Equals(especialidade)).ToList();
                    }
                }
                else
                {
                    bool situacao = status == 1 ? true : false;
                    if (Cmb_Especialidade.SelectedIndex == 0)
                    {
                        Dgv_Busca.DataSource = listaMedicos.Where(p => p.Ativo == situacao && p.Nome!.Contains(Txt_Nome.Text)).ToList();
                    }
                    else
                    {
                        Especialidade especialidade = (Especialidade)Cmb_Especialidade.SelectedItem!;
                        Dgv_Busca.DataSource = listaMedicos.Where(p => p.Ativo == situacao && p.Nome!.Contains(Txt_Nome.Text) && p.Especialidade.Equals(especialidade)).ToList();
                    }
                }
            }
            else
            {
                novaLista = listaMedicos.Where(p => p.Id.Equals(id)).ToList();
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
                MessageBox.Show("Erro ao selecionar médico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfiguraDataGridView(List<Medico> lista)
        {
            Dgv_Busca.DataSource = lista;
            Dgv_Busca.Columns["Endereco"].Visible = false;
            Dgv_Busca.Columns["Email"].Visible = false;
            Dgv_Busca.Columns["Telefone"].Visible = false;
            //Redimencionar as colunas
            Dgv_Busca.Columns["Id"].Width = 50;
            Dgv_Busca.Columns["Nome"].Width = 340;
            Dgv_Busca.Columns["Especialidade"].Width = 150;
            Dgv_Busca.Columns["CRM"].Width = 150;
            Dgv_Busca.Columns["Ativo"].Width = 80;
        }
        private void Cmb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Status.SelectedIndex == 0) status = 0;
            if (Cmb_Status.SelectedIndex == 1) status = 1;
            if (Cmb_Status.SelectedIndex == 2) status = 2;
        }
        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            ConfiguraDataGridView(listaMedicos);
            Cmb_Status.SelectedIndex = 0;
            Txt_Id.Text = string.Empty;
            Txt_Nome.Text = string.Empty;
            Txt_CRM.Text = string.Empty;
            Cmb_Especialidade.SelectedIndex = 0;
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
    }
}