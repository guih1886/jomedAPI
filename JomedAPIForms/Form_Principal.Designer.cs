namespace JomedAPIForms
{
    partial class Form_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Principal));
            toolStrip1 = new ToolStrip();
            toolStripConsultas = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMedicos = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripPacientes = new ToolStripButton();
            menuStrip1 = new MenuStrip();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            cadastroDeConsultasToolStripMenuItem = new ToolStripMenuItem();
            médicosToolStripMenuItem = new ToolStripMenuItem();
            cadastroDeMédicosToolStripMenuItem = new ToolStripMenuItem();
            pacientesToolStripMenuItem = new ToolStripMenuItem();
            cadastroDePacientesToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusRole = new ToolStripStatusLabel();
            toolStripStatusEmail = new ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripConsultas, toolStripSeparator1, toolStripMedicos, toolStripSeparator2, toolStripPacientes });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(934, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripConsultas
            // 
            toolStripConsultas.CheckOnClick = true;
            toolStripConsultas.Image = Properties.Resources.consulta;
            toolStripConsultas.ImageTransparentColor = Color.Magenta;
            toolStripConsultas.Margin = new Padding(6, 1, 0, 2);
            toolStripConsultas.Name = "toolStripConsultas";
            toolStripConsultas.Size = new Size(79, 22);
            toolStripConsultas.Text = "Consultas";
            toolStripConsultas.Click += toolStripConsultas_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripMedicos
            // 
            toolStripMedicos.Image = Properties.Resources.medico;
            toolStripMedicos.ImageTransparentColor = Color.Magenta;
            toolStripMedicos.Name = "toolStripMedicos";
            toolStripMedicos.Size = new Size(72, 22);
            toolStripMedicos.Text = "Médicos";
            toolStripMedicos.Click += toolStripMedicos_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripPacientes
            // 
            toolStripPacientes.Image = Properties.Resources.paciente;
            toolStripPacientes.ImageTransparentColor = Color.Magenta;
            toolStripPacientes.Name = "toolStripPacientes";
            toolStripPacientes.Size = new Size(77, 22);
            toolStripPacientes.Text = "Pacientes";
            toolStripPacientes.ToolTipText = "Abre a tela de gerenciamento de cadastro de pacientes";
            toolStripPacientes.Click += toolStripPacientes_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { consultasToolStripMenuItem, médicosToolStripMenuItem, pacientesToolStripMenuItem, sairToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(934, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastroDeConsultasToolStripMenuItem });
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(71, 20);
            consultasToolStripMenuItem.Text = "Consultas";
            // 
            // cadastroDeConsultasToolStripMenuItem
            // 
            cadastroDeConsultasToolStripMenuItem.Image = Properties.Resources.consulta;
            cadastroDeConsultasToolStripMenuItem.Name = "cadastroDeConsultasToolStripMenuItem";
            cadastroDeConsultasToolStripMenuItem.Size = new Size(192, 22);
            cadastroDeConsultasToolStripMenuItem.Text = "Cadastro de Consultas";
            cadastroDeConsultasToolStripMenuItem.Click += cadastroDeConsultasToolStripMenuItem_Click;
            // 
            // médicosToolStripMenuItem
            // 
            médicosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastroDeMédicosToolStripMenuItem });
            médicosToolStripMenuItem.Name = "médicosToolStripMenuItem";
            médicosToolStripMenuItem.Size = new Size(64, 20);
            médicosToolStripMenuItem.Text = "Médicos";
            // 
            // cadastroDeMédicosToolStripMenuItem
            // 
            cadastroDeMédicosToolStripMenuItem.Image = Properties.Resources.medico;
            cadastroDeMédicosToolStripMenuItem.Name = "cadastroDeMédicosToolStripMenuItem";
            cadastroDeMédicosToolStripMenuItem.Size = new Size(185, 22);
            cadastroDeMédicosToolStripMenuItem.Text = "Cadastro de Médicos";
            cadastroDeMédicosToolStripMenuItem.Click += cadastroDeMédicosToolStripMenuItem_Click;
            // 
            // pacientesToolStripMenuItem
            // 
            pacientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastroDePacientesToolStripMenuItem });
            pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            pacientesToolStripMenuItem.Size = new Size(69, 20);
            pacientesToolStripMenuItem.Text = "Pacientes";
            // 
            // cadastroDePacientesToolStripMenuItem
            // 
            cadastroDePacientesToolStripMenuItem.Image = Properties.Resources.paciente;
            cadastroDePacientesToolStripMenuItem.Name = "cadastroDePacientesToolStripMenuItem";
            cadastroDePacientesToolStripMenuItem.Size = new Size(190, 22);
            cadastroDePacientesToolStripMenuItem.Text = "Cadastro de Pacientes";
            cadastroDePacientesToolStripMenuItem.Click += cadastroDePacientesToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(38, 20);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusRole, toolStripStatusEmail });
            statusStrip1.Location = new Point(0, 569);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(934, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusRole
            // 
            toolStripStatusRole.Name = "toolStripStatusRole";
            toolStripStatusRole.Size = new Size(30, 17);
            toolStripStatusRole.Text = "Role";
            // 
            // toolStripStatusEmail
            // 
            toolStripStatusEmail.Name = "toolStripStatusEmail";
            toolStripStatusEmail.Size = new Size(41, 17);
            toolStripStatusEmail.Text = "E-Mail";
            // 
            // Form_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 591);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JomedAPI - Principal";
            WindowState = FormWindowState.Maximized;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripConsultas;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private ToolStripMenuItem médicosToolStripMenuItem;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusRole;
        private ToolStripStatusLabel toolStripStatusEmail;
        private ToolStripButton toolStripMedicos;
        private ToolStripButton toolStripPacientes;
        private ToolStripMenuItem cadastroDeConsultasToolStripMenuItem;
        private ToolStripMenuItem cadastroDeMédicosToolStripMenuItem;
        private ToolStripMenuItem cadastroDePacientesToolStripMenuItem;
    }
}