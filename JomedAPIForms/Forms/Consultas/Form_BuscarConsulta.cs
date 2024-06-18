using jomedAPI.Models;
using jomedAPI.Models.Enum;
using JomedAPIForms.Models;

namespace JomedAPIForms.Forms.Consultas
{
    public partial class Form_BuscarConsulta : Form
    {
        private List<Consulta> listaConsultas;
        private List<Medico> listaMedicos;
        private List<Paciente> listaPacientes;
        public DataGridViewRow? selecionado { get; set; }

        public Form_BuscarConsulta(List<Consulta> listaConsultas, List<Medico> listaMedicos, List<Paciente> listaPacientes)
        {
            this.listaConsultas = listaConsultas;
            this.listaMedicos = listaMedicos;
            this.listaPacientes = listaPacientes;
            InitializeComponent();
            PreencheComboBoxEspecialidade();
            PreencheDataGrid(listaConsultas, listaMedicos, listaPacientes);
            Dtp_Data.Value = DateTime.Today;
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            DateTime data = Dtp_Data.Value.Date;
            if (Cmb_Especialidade.SelectedIndex == 0)
            {
                PreencheDataGrid(
                    listaConsultas.Where(c => c.Data.Date == Dtp_Data.Value.Date).ToList(),
                    listaMedicos.Where(m => m.Nome!.Contains(Txt_NomeMedico.Text)).ToList(),
                    listaPacientes.Where(p => p.Cpf!.Contains(Txt_CpfPaciente.Text) && p.Nome!.Contains(Txt_NomePaciente.Text)).ToList()
                    );
            }
            else
            {
                PreencheDataGrid(
                    listaConsultas.Where(c => c.Data.Date == Dtp_Data.Value.Date).ToList(),
                    listaMedicos.Where(m => m.Nome!.Contains(Txt_NomeMedico.Text) && m.Especialidade == (Especialidade)Cmb_Especialidade.SelectedItem!).ToList(),
                    listaPacientes.Where(p => p.Cpf!.Contains(Txt_CpfPaciente.Text) && p.Nome!.Contains(Txt_NomePaciente.Text)).ToList()
                    );
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
        private void PreencheDataGrid(List<Consulta> listaConsultas, List<Medico> listaMedicos, List<Paciente> listaPacientes)
        {
            Cursor = Cursors.WaitCursor;
            List<ConsultaFormatada> listaFormatada = new List<ConsultaFormatada>();
            foreach (var item in listaConsultas)
            {
                //Dados do médico
                Medico? medico = listaMedicos.FirstOrDefault(m => m.Id == item.MedicoId);
                //Dados do paciente
                Paciente? paciente = listaPacientes.FirstOrDefault(p => p.Id == item.PacienteId);
                if (!(medico == null || paciente == null))
                {
                    ConsultaFormatada lista = new ConsultaFormatada(item.Id, medico.Especialidade!.Value, medico.Crm!, medico.Nome!, paciente.Cpf!, paciente.Nome!, item.Data);
                    listaFormatada.Add(lista);
                }
            }
            Dgv_Busca.DataSource = listaFormatada;
            Cursor = Cursors.Default;
        }
        private void Btn_Limpar_Click(object sender, EventArgs e)
        {
            Dtp_Data.Value = DateTime.Today;
            Cmb_Especialidade.SelectedIndex = 0;
            Txt_NomeMedico.Text = string.Empty;
            Txt_CpfPaciente.Text = string.Empty;
            Txt_NomePaciente.Text = string.Empty;
            PreencheDataGrid(listaConsultas, listaMedicos, listaPacientes);
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
