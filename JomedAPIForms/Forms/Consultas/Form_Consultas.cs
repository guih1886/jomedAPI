using jomedAPI.Models;
using jomedAPI.Models.Enum;
using JomedAPIForms.Models;

namespace JomedAPIForms.Forms.Consultas
{
    public partial class Form_Consultas : Form
    {
        private List<Consulta> listaConsultas;
        private List<Medico> listaMedicos;
        private List<Paciente> listaPacientes;

        public Form_Consultas(List<Consulta> listaConsultas, List<Medico> listaMedicos, List<Paciente> listaPacientes)
        {
            this.listaConsultas = listaConsultas;
            this.listaMedicos = listaMedicos;
            this.listaPacientes = listaPacientes;
            InitializeComponent();
            PreencheDataGrid(listaConsultas, listaMedicos, listaPacientes);
            PreencheComboBoxEspecialidade();
        }
        private void toolStripNovo_Click(object sender, EventArgs e)
        {
            Cmb_Especialidade.Enabled = true;
            Cmb_Especialidade.Focus();
        }

        private void PreencheDataGrid(List<Consulta> listaConsultas, List<Medico> listaMedicos, List<Paciente> listaPacientes)
        {
            Cursor = Cursors.WaitCursor;
            List<ConsultaFormatada> listaFormatada = new List<ConsultaFormatada>();
            foreach (var item in listaConsultas)
            {
                //Dados do médico
                Especialidade especialidade = listaMedicos.Find(m => m.Id == item.MedicoId)!.Especialidade!.Value;
                string crm = listaMedicos.Find(m => m.Id == item.MedicoId)!.Crm!;
                string nomeMedico = listaMedicos.Find(m => m.Id == item.MedicoId)!.Nome!;
                //Dados do paciente
                string cpfPaciente = listaPacientes.Find(p => p.Id == item.PacienteId)!.Cpf!;
                string nomePaciente = listaPacientes.Find(p => p.Id == item.PacienteId)!.Nome!;
                ConsultaFormatada lista = new ConsultaFormatada(item.Id, especialidade, crm, nomeMedico, cpfPaciente, nomePaciente, item.Data);
                listaFormatada.Add(lista);
            }
            Dgv_Consultas.DataSource = listaFormatada;
            Cursor = Cursors.Default;
        }
        private void PreencheComboBoxEspecialidade()
        {
            foreach (var item in Enum.GetValues(typeof(Especialidade)))
            {
                Cmb_Especialidade.Items.Add(item);
            }
        }
        private void Cmb_Especialidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_NomeMedico.Enabled = true;
            cmb_NomeMedico.Items.Clear();
            Especialidade especialidadeSelecionada = (Especialidade)Cmb_Especialidade.SelectedItem!;
            List<Medico> listaMedicos = this.listaMedicos.Where(m => m.Especialidade == especialidadeSelecionada).ToList();
            if (listaMedicos.Count == 0)
            {
                cmb_NomeMedico.Items.Add("Sem médicos cadastrados.");
                cmb_NomeMedico.SelectedIndex = 0;
                cmb_NomeMedico.Enabled = false;
            }
            else
            {
                cmb_NomeMedico.Enabled = true;
                foreach (var item in listaMedicos)
                {
                    cmb_NomeMedico.Items.Add($"Id: {item.Id} - {item.Nome}");
                }
                cmb_NomeMedico.SelectedIndex = 0;
            }
        }
    }
}