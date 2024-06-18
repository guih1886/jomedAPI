using jomedAPI.Models.Enum;
using JomedAPIForms.Classes;
using JomedAPIForms.Models;

namespace JomedAPIForms.Forms.Consultas
{
    public partial class Form_CancelarConsulta : Form
    {
        private HttpClientBuilder _httpClientBuilder;
        private DataGridViewRow consultaSelecionada;

        public Form_CancelarConsulta(HttpClientBuilder httpClientBuilder, DataGridViewRow consultaSelecionada)
        {
            _httpClientBuilder = httpClientBuilder;
            this.consultaSelecionada = consultaSelecionada;
            InitializeComponent();
            PreencheComboBox();
        }

        private void Btn_Voltar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private async void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            MotivoDeCancelamento motivo = new MotivoDeCancelamento((MotivoCancelamento)Cmb_Motivo.SelectedIndex);
            DialogResult resposta = MessageBox.Show($"Deseja mesmo excluir a consulta {consultaSelecionada!.Cells[0].Value}?", "Cancelamento de consultas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resposta == DialogResult.OK)
            {
                HttpResponseMessage response = await _httpClientBuilder.DeleteRequisition($"/Consultas/{consultaSelecionada!.Cells[0].Value.ToString()}", motivo);
                if (response.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string msg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao cancelar a consulta. {msg}", "Cancelamento de consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void PreencheComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(MotivoCancelamento)))
            {
                Cmb_Motivo.Items.Add(item);
            }
            Cmb_Motivo.SelectedIndex = 0;
        }
    }
}