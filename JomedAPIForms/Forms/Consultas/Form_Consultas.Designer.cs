namespace JomedAPIForms.Forms.Consultas
{
    partial class Form_Consultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Consultas));
            toolStrip1 = new ToolStrip();
            toolStripNovo = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripBuscar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripEditar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSalvar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripExcluir = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripCancelar = new ToolStripButton();
            Dgv_Consultas = new DataGridView();
            idConsultaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            crmDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            especialidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeMedicoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfPacienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomePacienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            consultaFormatadaBindingSource = new BindingSource(components);
            Gpb_Consulta = new GroupBox();
            Gpb_Paciente = new GroupBox();
            Gpb_Medico = new GroupBox();
            cmb_NomeMedico = new ComboBox();
            Lbl_NomeMedico = new Label();
            Cmb_Especialidade = new ComboBox();
            Lbl_Especialidade = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Consultas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)consultaFormatadaBindingSource).BeginInit();
            Gpb_Consulta.SuspendLayout();
            Gpb_Medico.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripNovo, toolStripSeparator1, toolStripBuscar, toolStripSeparator2, toolStripEditar, toolStripSeparator3, toolStripSalvar, toolStripSeparator4, toolStripExcluir, toolStripSeparator5, toolStripCancelar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1171, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNovo
            // 
            toolStripNovo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripNovo.Image = Properties.Resources.novo;
            toolStripNovo.ImageTransparentColor = Color.Magenta;
            toolStripNovo.Name = "toolStripNovo";
            toolStripNovo.Padding = new Padding(6, 0, 0, 0);
            toolStripNovo.Size = new Size(26, 22);
            toolStripNovo.Text = "toolStripButton1";
            toolStripNovo.ToolTipText = "Adicionar novo médico";
            toolStripNovo.Click += toolStripNovo_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripBuscar
            // 
            toolStripBuscar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripBuscar.Image = Properties.Resources.buscar;
            toolStripBuscar.ImageTransparentColor = Color.Magenta;
            toolStripBuscar.Name = "toolStripBuscar";
            toolStripBuscar.Size = new Size(23, 22);
            toolStripBuscar.Text = "toolStripButton4";
            toolStripBuscar.ToolTipText = "Buscar o cadastro do médico";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripEditar
            // 
            toolStripEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripEditar.Enabled = false;
            toolStripEditar.Image = Properties.Resources.editar;
            toolStripEditar.ImageTransparentColor = Color.Magenta;
            toolStripEditar.Name = "toolStripEditar";
            toolStripEditar.Size = new Size(23, 22);
            toolStripEditar.Text = "toolStripButton2";
            toolStripEditar.ToolTipText = "Editar o cadastro do médico";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripSalvar
            // 
            toolStripSalvar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSalvar.Enabled = false;
            toolStripSalvar.Image = Properties.Resources.salvar;
            toolStripSalvar.ImageTransparentColor = Color.Magenta;
            toolStripSalvar.Name = "toolStripSalvar";
            toolStripSalvar.Size = new Size(23, 22);
            toolStripSalvar.Text = "toolStripButton3";
            toolStripSalvar.ToolTipText = "Salvar";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // toolStripExcluir
            // 
            toolStripExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripExcluir.Enabled = false;
            toolStripExcluir.Image = Properties.Resources.excluir;
            toolStripExcluir.ImageTransparentColor = Color.Magenta;
            toolStripExcluir.Name = "toolStripExcluir";
            toolStripExcluir.Size = new Size(23, 22);
            toolStripExcluir.Text = "toolStripButton1";
            toolStripExcluir.ToolTipText = "Excluir o cadastro do médico";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // toolStripCancelar
            // 
            toolStripCancelar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripCancelar.Enabled = false;
            toolStripCancelar.Image = Properties.Resources.cancelar;
            toolStripCancelar.ImageTransparentColor = Color.Magenta;
            toolStripCancelar.Name = "toolStripCancelar";
            toolStripCancelar.Size = new Size(23, 22);
            toolStripCancelar.Text = "toolStripButton1";
            toolStripCancelar.ToolTipText = "Cancelar";
            // 
            // Dgv_Consultas
            // 
            Dgv_Consultas.AllowUserToAddRows = false;
            Dgv_Consultas.AllowUserToDeleteRows = false;
            Dgv_Consultas.AllowUserToResizeColumns = false;
            Dgv_Consultas.AllowUserToResizeRows = false;
            Dgv_Consultas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Dgv_Consultas.AutoGenerateColumns = false;
            Dgv_Consultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Consultas.Columns.AddRange(new DataGridViewColumn[] { idConsultaDataGridViewTextBoxColumn, dataDataGridViewTextBoxColumn, crmDataGridViewTextBoxColumn, especialidadeDataGridViewTextBoxColumn, nomeMedicoDataGridViewTextBoxColumn, cpfPacienteDataGridViewTextBoxColumn, nomePacienteDataGridViewTextBoxColumn });
            Dgv_Consultas.DataSource = consultaFormatadaBindingSource;
            Dgv_Consultas.Location = new Point(12, 28);
            Dgv_Consultas.MultiSelect = false;
            Dgv_Consultas.Name = "Dgv_Consultas";
            Dgv_Consultas.ReadOnly = true;
            Dgv_Consultas.ScrollBars = ScrollBars.Vertical;
            Dgv_Consultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Consultas.Size = new Size(1147, 312);
            Dgv_Consultas.TabIndex = 2;
            Dgv_Consultas.TabStop = false;
            // 
            // idConsultaDataGridViewTextBoxColumn
            // 
            idConsultaDataGridViewTextBoxColumn.DataPropertyName = "IdConsulta";
            idConsultaDataGridViewTextBoxColumn.HeaderText = "Id Consulta";
            idConsultaDataGridViewTextBoxColumn.Name = "idConsultaDataGridViewTextBoxColumn";
            idConsultaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            dataDataGridViewTextBoxColumn.HeaderText = "Data";
            dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            dataDataGridViewTextBoxColumn.ReadOnly = true;
            dataDataGridViewTextBoxColumn.Width = 200;
            // 
            // crmDataGridViewTextBoxColumn
            // 
            crmDataGridViewTextBoxColumn.DataPropertyName = "Crm";
            crmDataGridViewTextBoxColumn.HeaderText = "Crm";
            crmDataGridViewTextBoxColumn.Name = "crmDataGridViewTextBoxColumn";
            crmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // especialidadeDataGridViewTextBoxColumn
            // 
            especialidadeDataGridViewTextBoxColumn.DataPropertyName = "Especialidade";
            especialidadeDataGridViewTextBoxColumn.HeaderText = "Especialidade";
            especialidadeDataGridViewTextBoxColumn.Name = "especialidadeDataGridViewTextBoxColumn";
            especialidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeMedicoDataGridViewTextBoxColumn
            // 
            nomeMedicoDataGridViewTextBoxColumn.DataPropertyName = "NomeMedico";
            nomeMedicoDataGridViewTextBoxColumn.HeaderText = "Nome Medico";
            nomeMedicoDataGridViewTextBoxColumn.Name = "nomeMedicoDataGridViewTextBoxColumn";
            nomeMedicoDataGridViewTextBoxColumn.ReadOnly = true;
            nomeMedicoDataGridViewTextBoxColumn.Width = 220;
            // 
            // cpfPacienteDataGridViewTextBoxColumn
            // 
            cpfPacienteDataGridViewTextBoxColumn.DataPropertyName = "CpfPaciente";
            cpfPacienteDataGridViewTextBoxColumn.HeaderText = "Cpf Paciente";
            cpfPacienteDataGridViewTextBoxColumn.Name = "cpfPacienteDataGridViewTextBoxColumn";
            cpfPacienteDataGridViewTextBoxColumn.ReadOnly = true;
            cpfPacienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // nomePacienteDataGridViewTextBoxColumn
            // 
            nomePacienteDataGridViewTextBoxColumn.DataPropertyName = "NomePaciente";
            nomePacienteDataGridViewTextBoxColumn.HeaderText = "Nome Paciente";
            nomePacienteDataGridViewTextBoxColumn.Name = "nomePacienteDataGridViewTextBoxColumn";
            nomePacienteDataGridViewTextBoxColumn.ReadOnly = true;
            nomePacienteDataGridViewTextBoxColumn.Width = 220;
            // 
            // consultaFormatadaBindingSource
            // 
            consultaFormatadaBindingSource.DataSource = typeof(Models.ConsultaFormatada);
            // 
            // Gpb_Consulta
            // 
            Gpb_Consulta.Controls.Add(Gpb_Paciente);
            Gpb_Consulta.Controls.Add(Gpb_Medico);
            Gpb_Consulta.Location = new Point(12, 346);
            Gpb_Consulta.Name = "Gpb_Consulta";
            Gpb_Consulta.Size = new Size(1147, 305);
            Gpb_Consulta.TabIndex = 4;
            Gpb_Consulta.TabStop = false;
            // 
            // Gpb_Paciente
            // 
            Gpb_Paciente.Location = new Point(589, 22);
            Gpb_Paciente.Name = "Gpb_Paciente";
            Gpb_Paciente.Size = new Size(552, 277);
            Gpb_Paciente.TabIndex = 1;
            Gpb_Paciente.TabStop = false;
            Gpb_Paciente.Text = "Paciente";
            // 
            // Gpb_Medico
            // 
            Gpb_Medico.Controls.Add(cmb_NomeMedico);
            Gpb_Medico.Controls.Add(Lbl_NomeMedico);
            Gpb_Medico.Controls.Add(Cmb_Especialidade);
            Gpb_Medico.Controls.Add(Lbl_Especialidade);
            Gpb_Medico.Location = new Point(6, 22);
            Gpb_Medico.Name = "Gpb_Medico";
            Gpb_Medico.Size = new Size(552, 123);
            Gpb_Medico.TabIndex = 0;
            Gpb_Medico.TabStop = false;
            Gpb_Medico.Text = "Médico";
            // 
            // cmb_NomeMedico
            // 
            cmb_NomeMedico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_NomeMedico.Enabled = false;
            cmb_NomeMedico.FormattingEnabled = true;
            cmb_NomeMedico.Location = new Point(6, 88);
            cmb_NomeMedico.Name = "cmb_NomeMedico";
            cmb_NomeMedico.Size = new Size(540, 23);
            cmb_NomeMedico.TabIndex = 3;
            // 
            // Lbl_NomeMedico
            // 
            Lbl_NomeMedico.AutoSize = true;
            Lbl_NomeMedico.Font = new Font("Arial Narrow", 10F);
            Lbl_NomeMedico.Location = new Point(6, 68);
            Lbl_NomeMedico.Name = "Lbl_NomeMedico";
            Lbl_NomeMedico.Size = new Size(93, 17);
            Lbl_NomeMedico.TabIndex = 2;
            Lbl_NomeMedico.Text = "Nome do Médico";
            // 
            // Cmb_Especialidade
            // 
            Cmb_Especialidade.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Especialidade.Enabled = false;
            Cmb_Especialidade.FormattingEnabled = true;
            Cmb_Especialidade.Location = new Point(6, 39);
            Cmb_Especialidade.Name = "Cmb_Especialidade";
            Cmb_Especialidade.Size = new Size(180, 23);
            Cmb_Especialidade.TabIndex = 1;
            Cmb_Especialidade.SelectedIndexChanged += Cmb_Especialidade_SelectedIndexChanged;
            // 
            // Lbl_Especialidade
            // 
            Lbl_Especialidade.AutoSize = true;
            Lbl_Especialidade.Font = new Font("Arial Narrow", 10F);
            Lbl_Especialidade.Location = new Point(6, 19);
            Lbl_Especialidade.Name = "Lbl_Especialidade";
            Lbl_Especialidade.Size = new Size(76, 17);
            Lbl_Especialidade.TabIndex = 0;
            Lbl_Especialidade.Text = "Especialidade";
            // 
            // Form_Consultas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1171, 663);
            Controls.Add(Gpb_Consulta);
            Controls.Add(toolStrip1);
            Controls.Add(Dgv_Consultas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Consultas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Consultas";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Consultas).EndInit();
            ((System.ComponentModel.ISupportInitialize)consultaFormatadaBindingSource).EndInit();
            Gpb_Consulta.ResumeLayout(false);
            Gpb_Medico.ResumeLayout(false);
            Gpb_Medico.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripNovo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripBuscar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripEditar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripSalvar;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripExcluir;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripCancelar;
        private DataGridView Dgv_Consultas;
        private BindingSource consultaFormatadaBindingSource;
        private DataGridViewTextBoxColumn idConsultaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn crmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn especialidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeMedicoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfPacienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomePacienteDataGridViewTextBoxColumn;
        private GroupBox Gpb_Consulta;
        private GroupBox Gpb_Paciente;
        private GroupBox Gpb_Medico;
        private Label Lbl_Especialidade;
        private ComboBox Cmb_Especialidade;
        private ComboBox cmb_NomeMedico;
        private Label Lbl_NomeMedico;
    }
}