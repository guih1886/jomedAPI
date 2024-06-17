using jomedAPI.Models;
using jomedAPI.Models.Enum;
using JomedAPI.Data.DTO.Consulta;
using JomedAPIForms.Classes;
using JomedAPIForms.Forms.Buscar;
using JomedAPIForms.Models;
using Newtonsoft.Json;

namespace JomedAPIForms.Forms.Consultas
{
    public partial class Form_Consultas : Form
    {
        private HttpClientBuilder _httpClientBuilder;
        private List<Consulta> listaConsultas;
        private List<Medico> listaMedicos;
        private List<Paciente> listaPacientes;
        public Form_Consultas(HttpClientBuilder httpClientBuilder, List<Consulta> listaConsultas, List<Medico> listaMedicos, List<Paciente> listaPacientes)
        {
            _httpClientBuilder = httpClientBuilder;
            this.listaConsultas = listaConsultas;
            this.listaMedicos = listaMedicos;
            this.listaPacientes = listaPacientes;
            InitializeComponent();
            PreencheDataGrid(listaConsultas, listaMedicos, listaPacientes);
            PreencheComboBoxEspecialidade();
            Dtp_Horario.Text = "00:00";
        }

        private void toolStripNovo_Click(object sender, EventArgs e)
        {
            AtivarFormulario();
            AtivarMenuModoEdicao();
            toolStripEditar.Enabled = false;
            toolStripExcluir.Enabled = false;
        }
        private void Btn_BuscarPaciente_Click(object sender, EventArgs e)
        {
            Form_Busca buscar = new Form_Busca(listaPacientes, "Cpf");
            DialogResult resposta = buscar.ShowDialog();
            if (resposta == DialogResult.OK)
            {
                Txt_IdPaciente.Text = buscar.selecionado!.Cells[0].Value.ToString();
                Txt_Nome.Text = buscar.selecionado.Cells[1].Value.ToString();
                Txt_CpfPaciente.Text = buscar.selecionado.Cells[3].Value.ToString();
            }
        }
        private void toolStripEditar_Click(object sender, EventArgs e)
        {

        }
        private async void toolStripSalvar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja incluir a nova consulta?", "Agendamento de consultas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {
                int medicoId = 0;
                int pacienteId = 0;
                if (!string.IsNullOrEmpty(cmb_NomeMedico.Text)) medicoId = Int32.Parse(cmb_NomeMedico.Text.Trim().Split("-")[0]);
                if (!string.IsNullOrEmpty(Txt_IdPaciente.Text)) pacienteId = Int32.Parse(Txt_IdPaciente.Text);
                DateTime data = Dtp_Data.Value.Date;
                TimeSpan hora = Dtp_Horario.Value.TimeOfDay;
                data = data.Add(hora);
                CreateConsultaDto novaConsulta = new CreateConsultaDto(medicoId, pacienteId, data);
                HttpResponseMessage response = await _httpClientBuilder.PostRequisition("/Consultas", novaConsulta);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Consulta cadastrada com sucesso.", "Agendamento de consultas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DesativarFormulario();
                    DesativarMenuModoEdicao();
                    AtualizarDataGrid();
                }
                else
                {
                    string msg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(msg, "Agendamento de consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void toolStripExcluir_Click(object sender, EventArgs e)
        {

        }
        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            DesativarFormulario();
            DesativarMenuModoEdicao();
        }


        //DataGrid
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
        private async void AtualizarDataGrid()
        {
            HttpResponseMessage respostaConsultas = await _httpClientBuilder.GetRequisition("/Consultas");
            HttpResponseMessage respostaMedicos = await _httpClientBuilder.GetRequisition("/Medicos");
            HttpResponseMessage respostaPacientes = await _httpClientBuilder.GetRequisition("/Pacientes");
            List<Consulta> listaConsultas = JsonConvert.DeserializeObject<List<Consulta>>(await respostaConsultas.Content.ReadAsStringAsync())!;
            List<Medico> listaMedicos = JsonConvert.DeserializeObject<List<Medico>>(await respostaMedicos.Content.ReadAsStringAsync())!;
            List<Paciente> listaPacientes = JsonConvert.DeserializeObject<List<Paciente>>(await respostaPacientes.Content.ReadAsStringAsync())!;
            PreencheDataGrid(listaConsultas, listaMedicos, listaPacientes);
        }
        //Formulários e menu
        private void AtivarFormulario()
        {
            Cmb_Especialidade.Enabled = true;
            cmb_NomeMedico.Enabled = true;
            Dtp_Horario.Enabled = true;
            Dtp_Data.Enabled = true;
            Btn_BuscarPaciente.Enabled = true;
            Cmb_Especialidade.Focus();
        }
        private void DesativarFormulario()
        {
            LimparFormulario();
            Cmb_Especialidade.Enabled = false;
            cmb_NomeMedico.Enabled = false;
            Dtp_Horario.Enabled = false;
            Dtp_Data.Enabled = false;
            Btn_BuscarPaciente.Enabled = false;
        }
        private void LimparFormulario()
        {
            Cmb_Especialidade.Text = string.Empty;
            Txt_IdPaciente.Text = string.Empty;
            Txt_CpfPaciente.Text = string.Empty;
            Txt_Nome.Text = string.Empty;
            Dtp_Data.Text = DateTime.Today.ToString();
            Dtp_Horario.Text = "00:00";
        }
        private void AtivarMenuModoEdicao()
        {
            toolStripNovo.Enabled = false;
            toolStripBuscar.Enabled = false;
            toolStripEditar.Enabled = true;
            toolStripSalvar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Enabled = true;
        }
        private void DesativarMenuModoEdicao()
        {
            toolStripNovo.Enabled = true;
            toolStripBuscar.Enabled = true;
            toolStripEditar.Enabled = false;
            toolStripSalvar.Enabled = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Enabled = false;
        }
        //Outros
        private void PreencheComboBoxEspecialidade()
        {
            Cmb_Especialidade.Items.Add("");
            foreach (var item in Enum.GetValues(typeof(Especialidade)))
            {
                Cmb_Especialidade.Items.Add(item);
            }
            Cmb_Especialidade.SelectedIndex = 0;
        }
        private void Cmb_Especialidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Especialidade.SelectedIndex != 0)
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
                    foreach (var item in listaMedicos)
                    {
                        cmb_NomeMedico.Items.Add($"{item.Id} - {item.Nome}");
                    }
                    cmb_NomeMedico.SelectedIndex = 0;
                }
            }
            else
            {
                cmb_NomeMedico.Items.Clear();
                cmb_NomeMedico.Items.Add("");
                cmb_NomeMedico.SelectedIndex = 0;
            }
        }
    }
}