using JomedAPIForms.Forms.Buscar;

namespace JomedAPIForms.Forms.Consultas
{
    partial class Form_BuscarConsulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BuscarConsulta));
            Dgv_Busca = new DataGridView();
            idConsultaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            crmDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            especialidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeMedicoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfPacienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomePacienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            consultaFormatadaBindingSource = new BindingSource(components);
            pacienteBindingSource = new BindingSource(components);
            Gpb_Dados = new GroupBox();
            Txt_CpfPaciente = new TextBox();
            Lbl_CpfPaciente = new Label();
            Txt_NomePaciente = new TextBox();
            Lbl_NomePaciente = new Label();
            Txt_NomeMedico = new TextBox();
            Lbl_NomeMedico = new Label();
            Lbl_Especialidade = new Label();
            Cmb_Especialidade = new ComboBox();
            Lbl_Data = new Label();
            Dtp_Data = new DateTimePicker();
            Btn_Cancelar = new Button();
            Btn_Selecionar = new Button();
            Btn_Buscar = new Button();
            Btn_Limpar = new Button();
            ((System.ComponentModel.ISupportInitialize)Dgv_Busca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)consultaFormatadaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).BeginInit();
            Gpb_Dados.SuspendLayout();
            SuspendLayout();
            // 
            // Dgv_Busca
            // 
            Dgv_Busca.AllowUserToAddRows = false;
            Dgv_Busca.AllowUserToDeleteRows = false;
            Dgv_Busca.AllowUserToResizeColumns = false;
            Dgv_Busca.AllowUserToResizeRows = false;
            Dgv_Busca.AutoGenerateColumns = false;
            Dgv_Busca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Busca.Columns.AddRange(new DataGridViewColumn[] { idConsultaDataGridViewTextBoxColumn, dataDataGridViewTextBoxColumn, crmDataGridViewTextBoxColumn, especialidadeDataGridViewTextBoxColumn, nomeMedicoDataGridViewTextBoxColumn, cpfPacienteDataGridViewTextBoxColumn, nomePacienteDataGridViewTextBoxColumn });
            Dgv_Busca.DataSource = consultaFormatadaBindingSource;
            Dgv_Busca.Location = new Point(12, 12);
            Dgv_Busca.MultiSelect = false;
            Dgv_Busca.Name = "Dgv_Busca";
            Dgv_Busca.ReadOnly = true;
            Dgv_Busca.ScrollBars = ScrollBars.Vertical;
            Dgv_Busca.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Busca.Size = new Size(813, 312);
            Dgv_Busca.TabIndex = 1;
            Dgv_Busca.TabStop = false;
            // 
            // idConsultaDataGridViewTextBoxColumn
            // 
            idConsultaDataGridViewTextBoxColumn.DataPropertyName = "IdConsulta";
            idConsultaDataGridViewTextBoxColumn.HeaderText = "Id Consulta";
            idConsultaDataGridViewTextBoxColumn.Name = "idConsultaDataGridViewTextBoxColumn";
            idConsultaDataGridViewTextBoxColumn.ReadOnly = true;
            idConsultaDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            dataDataGridViewTextBoxColumn.HeaderText = "Data";
            dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            dataDataGridViewTextBoxColumn.ReadOnly = true;
            dataDataGridViewTextBoxColumn.Width = 120;
            // 
            // crmDataGridViewTextBoxColumn
            // 
            crmDataGridViewTextBoxColumn.DataPropertyName = "Crm";
            crmDataGridViewTextBoxColumn.HeaderText = "Crm";
            crmDataGridViewTextBoxColumn.Name = "crmDataGridViewTextBoxColumn";
            crmDataGridViewTextBoxColumn.ReadOnly = true;
            crmDataGridViewTextBoxColumn.Visible = false;
            // 
            // especialidadeDataGridViewTextBoxColumn
            // 
            especialidadeDataGridViewTextBoxColumn.DataPropertyName = "Especialidade";
            especialidadeDataGridViewTextBoxColumn.HeaderText = "Especialidade";
            especialidadeDataGridViewTextBoxColumn.Name = "especialidadeDataGridViewTextBoxColumn";
            especialidadeDataGridViewTextBoxColumn.ReadOnly = true;
            especialidadeDataGridViewTextBoxColumn.Width = 120;
            // 
            // nomeMedicoDataGridViewTextBoxColumn
            // 
            nomeMedicoDataGridViewTextBoxColumn.DataPropertyName = "NomeMedico";
            nomeMedicoDataGridViewTextBoxColumn.HeaderText = "Nome Médico";
            nomeMedicoDataGridViewTextBoxColumn.Name = "nomeMedicoDataGridViewTextBoxColumn";
            nomeMedicoDataGridViewTextBoxColumn.ReadOnly = true;
            nomeMedicoDataGridViewTextBoxColumn.Width = 210;
            // 
            // cpfPacienteDataGridViewTextBoxColumn
            // 
            cpfPacienteDataGridViewTextBoxColumn.DataPropertyName = "CpfPaciente";
            cpfPacienteDataGridViewTextBoxColumn.HeaderText = "Cpf Paciente";
            cpfPacienteDataGridViewTextBoxColumn.Name = "cpfPacienteDataGridViewTextBoxColumn";
            cpfPacienteDataGridViewTextBoxColumn.ReadOnly = true;
            cpfPacienteDataGridViewTextBoxColumn.Width = 110;
            // 
            // nomePacienteDataGridViewTextBoxColumn
            // 
            nomePacienteDataGridViewTextBoxColumn.DataPropertyName = "NomePaciente";
            nomePacienteDataGridViewTextBoxColumn.HeaderText = "Nome Paciente";
            nomePacienteDataGridViewTextBoxColumn.Name = "nomePacienteDataGridViewTextBoxColumn";
            nomePacienteDataGridViewTextBoxColumn.ReadOnly = true;
            nomePacienteDataGridViewTextBoxColumn.Width = 210;
            // 
            // consultaFormatadaBindingSource
            // 
            consultaFormatadaBindingSource.DataSource = typeof(Models.ConsultaFormatada);
            // 
            // pacienteBindingSource
            // 
            pacienteBindingSource.DataSource = typeof(jomedAPI.Models.Paciente);
            // 
            // Gpb_Dados
            // 
            Gpb_Dados.Controls.Add(Txt_CpfPaciente);
            Gpb_Dados.Controls.Add(Lbl_CpfPaciente);
            Gpb_Dados.Controls.Add(Txt_NomePaciente);
            Gpb_Dados.Controls.Add(Lbl_NomePaciente);
            Gpb_Dados.Controls.Add(Txt_NomeMedico);
            Gpb_Dados.Controls.Add(Lbl_NomeMedico);
            Gpb_Dados.Controls.Add(Lbl_Especialidade);
            Gpb_Dados.Controls.Add(Cmb_Especialidade);
            Gpb_Dados.Controls.Add(Lbl_Data);
            Gpb_Dados.Controls.Add(Dtp_Data);
            Gpb_Dados.Location = new Point(12, 330);
            Gpb_Dados.Name = "Gpb_Dados";
            Gpb_Dados.Size = new Size(813, 110);
            Gpb_Dados.TabIndex = 2;
            Gpb_Dados.TabStop = false;
            // 
            // Txt_CpfPaciente
            // 
            Txt_CpfPaciente.Location = new Point(6, 78);
            Txt_CpfPaciente.Name = "Txt_CpfPaciente";
            Txt_CpfPaciente.Size = new Size(278, 23);
            Txt_CpfPaciente.TabIndex = 9;
            // 
            // Lbl_CpfPaciente
            // 
            Lbl_CpfPaciente.AutoSize = true;
            Lbl_CpfPaciente.Font = new Font("Arial Narrow", 10F);
            Lbl_CpfPaciente.Location = new Point(6, 58);
            Lbl_CpfPaciente.Name = "Lbl_CpfPaciente";
            Lbl_CpfPaciente.Size = new Size(89, 17);
            Lbl_CpfPaciente.TabIndex = 8;
            Lbl_CpfPaciente.Text = "CPF do paciente";
            // 
            // Txt_NomePaciente
            // 
            Txt_NomePaciente.Location = new Point(290, 78);
            Txt_NomePaciente.Name = "Txt_NomePaciente";
            Txt_NomePaciente.Size = new Size(517, 23);
            Txt_NomePaciente.TabIndex = 7;
            // 
            // Lbl_NomePaciente
            // 
            Lbl_NomePaciente.AutoSize = true;
            Lbl_NomePaciente.Font = new Font("Arial Narrow", 10F);
            Lbl_NomePaciente.Location = new Point(290, 58);
            Lbl_NomePaciente.Name = "Lbl_NomePaciente";
            Lbl_NomePaciente.Size = new Size(96, 17);
            Lbl_NomePaciente.TabIndex = 6;
            Lbl_NomePaciente.Text = "Nome do paciente";
            // 
            // Txt_NomeMedico
            // 
            Txt_NomeMedico.Location = new Point(290, 32);
            Txt_NomeMedico.Name = "Txt_NomeMedico";
            Txt_NomeMedico.Size = new Size(517, 23);
            Txt_NomeMedico.TabIndex = 5;
            // 
            // Lbl_NomeMedico
            // 
            Lbl_NomeMedico.AutoSize = true;
            Lbl_NomeMedico.Font = new Font("Arial Narrow", 10F);
            Lbl_NomeMedico.Location = new Point(290, 12);
            Lbl_NomeMedico.Name = "Lbl_NomeMedico";
            Lbl_NomeMedico.Size = new Size(92, 17);
            Lbl_NomeMedico.TabIndex = 4;
            Lbl_NomeMedico.Text = "Nome do médico";
            // 
            // Lbl_Especialidade
            // 
            Lbl_Especialidade.AutoSize = true;
            Lbl_Especialidade.Font = new Font("Arial Narrow", 10F);
            Lbl_Especialidade.Location = new Point(118, 12);
            Lbl_Especialidade.Name = "Lbl_Especialidade";
            Lbl_Especialidade.Size = new Size(76, 17);
            Lbl_Especialidade.TabIndex = 3;
            Lbl_Especialidade.Text = "Especialidade";
            // 
            // Cmb_Especialidade
            // 
            Cmb_Especialidade.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Especialidade.FormattingEnabled = true;
            Cmb_Especialidade.Location = new Point(118, 32);
            Cmb_Especialidade.Name = "Cmb_Especialidade";
            Cmb_Especialidade.Size = new Size(166, 23);
            Cmb_Especialidade.TabIndex = 2;
            // 
            // Lbl_Data
            // 
            Lbl_Data.AutoSize = true;
            Lbl_Data.Font = new Font("Arial Narrow", 10F);
            Lbl_Data.Location = new Point(6, 12);
            Lbl_Data.Name = "Lbl_Data";
            Lbl_Data.Size = new Size(30, 17);
            Lbl_Data.TabIndex = 1;
            Lbl_Data.Text = "Data";
            // 
            // Dtp_Data
            // 
            Dtp_Data.CustomFormat = "dd/MM/yyyy";
            Dtp_Data.Format = DateTimePickerFormat.Custom;
            Dtp_Data.Location = new Point(6, 32);
            Dtp_Data.Name = "Dtp_Data";
            Dtp_Data.Size = new Size(106, 23);
            Dtp_Data.TabIndex = 0;
            Dtp_Data.Value = new DateTime(2024, 6, 18, 13, 48, 53, 0);
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Location = new Point(750, 446);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(75, 23);
            Btn_Cancelar.TabIndex = 7;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Btn_Selecionar
            // 
            Btn_Selecionar.Location = new Point(669, 446);
            Btn_Selecionar.Name = "Btn_Selecionar";
            Btn_Selecionar.Size = new Size(75, 23);
            Btn_Selecionar.TabIndex = 6;
            Btn_Selecionar.Text = "Selecionar";
            Btn_Selecionar.UseVisualStyleBackColor = true;
            Btn_Selecionar.Click += Btn_Selecionar_Click;
            // 
            // Btn_Buscar
            // 
            Btn_Buscar.Location = new Point(588, 446);
            Btn_Buscar.Name = "Btn_Buscar";
            Btn_Buscar.Size = new Size(75, 23);
            Btn_Buscar.TabIndex = 5;
            Btn_Buscar.Text = "Buscar";
            Btn_Buscar.UseVisualStyleBackColor = true;
            Btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // Btn_Limpar
            // 
            Btn_Limpar.Location = new Point(12, 446);
            Btn_Limpar.Name = "Btn_Limpar";
            Btn_Limpar.Size = new Size(75, 23);
            Btn_Limpar.TabIndex = 0;
            Btn_Limpar.TabStop = false;
            Btn_Limpar.Text = "Limpar";
            Btn_Limpar.UseVisualStyleBackColor = true;
            Btn_Limpar.Click += Btn_Limpar_Click;
            // 
            // Form_BuscarConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(837, 474);
            Controls.Add(Btn_Limpar);
            Controls.Add(Btn_Buscar);
            Controls.Add(Btn_Selecionar);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Gpb_Dados);
            Controls.Add(Dgv_Busca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_BuscarConsulta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Consulta";
            ((System.ComponentModel.ISupportInitialize)Dgv_Busca).EndInit();
            ((System.ComponentModel.ISupportInitialize)consultaFormatadaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            Gpb_Dados.ResumeLayout(false);
            Gpb_Dados.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_Busca;
        private BindingSource pacienteBindingSource;
        private GroupBox Gpb_Dados;
        private Button Btn_Cancelar;
        private Button Btn_Selecionar;
        private Button Btn_Buscar;
        private Button Btn_Limpar;
        private BindingSource consultaFormatadaBindingSource;
        private DataGridViewTextBoxColumn idConsultaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn crmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn especialidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeMedicoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfPacienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomePacienteDataGridViewTextBoxColumn;
        private DateTimePicker Dtp_Data;
        private Label Lbl_Data;
        private Label Lbl_Especialidade;
        private ComboBox Cmb_Especialidade;
        private TextBox Txt_CpfPaciente;
        private Label Lbl_CpfPaciente;
        private TextBox Txt_NomePaciente;
        private Label Lbl_NomePaciente;
        private TextBox Txt_NomeMedico;
        private Label Lbl_NomeMedico;
    }
}