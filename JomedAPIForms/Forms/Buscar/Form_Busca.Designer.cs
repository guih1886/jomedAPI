namespace JomedAPIForms.Forms.Buscar
{
    partial class Form_Busca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Busca));
            Dgv_Busca = new DataGridView();
            pacienteBindingSource = new BindingSource(components);
            Gpb_Dados = new GroupBox();
            Txt_Idenficador = new TextBox();
            Ckb_Ativo = new CheckBox();
            Lbl_Identificador = new Label();
            Txt_Email = new TextBox();
            Lbl_Email = new Label();
            Txt_Nome = new TextBox();
            Lbl_Nome = new Label();
            Txt_Id = new TextBox();
            Lbl_Id = new Label();
            Btn_Cancelar = new Button();
            Btn_Selecionar = new Button();
            Btn_Buscar = new Button();
            ((System.ComponentModel.ISupportInitialize)Dgv_Busca).BeginInit();
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
            Dgv_Busca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            // pacienteBindingSource
            // 
            pacienteBindingSource.DataSource = typeof(jomedAPI.Models.Paciente);
            // 
            // Gpb_Dados
            // 
            Gpb_Dados.Controls.Add(Txt_Idenficador);
            Gpb_Dados.Controls.Add(Ckb_Ativo);
            Gpb_Dados.Controls.Add(Lbl_Identificador);
            Gpb_Dados.Controls.Add(Txt_Email);
            Gpb_Dados.Controls.Add(Lbl_Email);
            Gpb_Dados.Controls.Add(Txt_Nome);
            Gpb_Dados.Controls.Add(Lbl_Nome);
            Gpb_Dados.Controls.Add(Txt_Id);
            Gpb_Dados.Controls.Add(Lbl_Id);
            Gpb_Dados.Location = new Point(12, 330);
            Gpb_Dados.Name = "Gpb_Dados";
            Gpb_Dados.Size = new Size(813, 114);
            Gpb_Dados.TabIndex = 2;
            Gpb_Dados.TabStop = false;
            // 
            // Txt_Idenficador
            // 
            Txt_Idenficador.Location = new Point(172, 33);
            Txt_Idenficador.Name = "Txt_Idenficador";
            Txt_Idenficador.Size = new Size(216, 23);
            Txt_Idenficador.TabIndex = 11;
            // 
            // Ckb_Ativo
            // 
            Ckb_Ativo.AutoSize = true;
            Ckb_Ativo.Checked = true;
            Ckb_Ativo.CheckState = CheckState.Checked;
            Ckb_Ativo.Location = new Point(6, 22);
            Ckb_Ativo.Name = "Ckb_Ativo";
            Ckb_Ativo.Size = new Size(54, 19);
            Ckb_Ativo.TabIndex = 10;
            Ckb_Ativo.TabStop = false;
            Ckb_Ativo.Text = "Ativo";
            Ckb_Ativo.UseVisualStyleBackColor = true;
            Ckb_Ativo.CheckedChanged += Ckb_Ativo_CheckedChanged;
            // 
            // Lbl_Identificador
            // 
            Lbl_Identificador.AutoSize = true;
            Lbl_Identificador.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Identificador.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            Lbl_Identificador.Location = new Point(172, 14);
            Lbl_Identificador.Name = "Lbl_Identificador";
            Lbl_Identificador.Size = new Size(63, 16);
            Lbl_Identificador.TabIndex = 6;
            Lbl_Identificador.Text = "Identificador";
            // 
            // Txt_Email
            // 
            Txt_Email.Location = new Point(394, 33);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.Size = new Size(413, 23);
            Txt_Email.TabIndex = 4;
            // 
            // Lbl_Email
            // 
            Lbl_Email.AutoSize = true;
            Lbl_Email.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Email.Location = new Point(394, 14);
            Lbl_Email.Name = "Lbl_Email";
            Lbl_Email.Size = new Size(36, 16);
            Lbl_Email.TabIndex = 4;
            Lbl_Email.Text = "E-mail";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(6, 71);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(801, 23);
            Txt_Nome.TabIndex = 3;
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Nome.Location = new Point(6, 52);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(35, 16);
            Lbl_Nome.TabIndex = 2;
            Lbl_Nome.Text = "Nome";
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(66, 33);
            Txt_Id.Name = "Txt_Id";
            Txt_Id.Size = new Size(100, 23);
            Txt_Id.TabIndex = 1;
            // 
            // Lbl_Id
            // 
            Lbl_Id.AutoSize = true;
            Lbl_Id.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Id.Location = new Point(66, 14);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(18, 16);
            Lbl_Id.TabIndex = 0;
            Lbl_Id.Text = "ID";
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Location = new Point(750, 461);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(75, 23);
            Btn_Cancelar.TabIndex = 3;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Btn_Selecionar
            // 
            Btn_Selecionar.Location = new Point(669, 461);
            Btn_Selecionar.Name = "Btn_Selecionar";
            Btn_Selecionar.Size = new Size(75, 23);
            Btn_Selecionar.TabIndex = 4;
            Btn_Selecionar.Text = "Selecionar";
            Btn_Selecionar.UseVisualStyleBackColor = true;
            Btn_Selecionar.Click += Btn_Selecionar_Click;
            // 
            // Btn_Buscar
            // 
            Btn_Buscar.Location = new Point(588, 461);
            Btn_Buscar.Name = "Btn_Buscar";
            Btn_Buscar.Size = new Size(75, 23);
            Btn_Buscar.TabIndex = 5;
            Btn_Buscar.Text = "Buscar";
            Btn_Buscar.UseVisualStyleBackColor = true;
            Btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // Form_Busca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(837, 496);
            Controls.Add(Btn_Buscar);
            Controls.Add(Btn_Selecionar);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Gpb_Dados);
            Controls.Add(Dgv_Busca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Busca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar";
            ((System.ComponentModel.ISupportInitialize)Dgv_Busca).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            Gpb_Dados.ResumeLayout(false);
            Gpb_Dados.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_Busca;
        private DataGridViewCheckBoxColumn ativoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private BindingSource pacienteBindingSource;
        private GroupBox Gpb_Dados;
        private CheckBox Ckb_Ativo;
        private TextBox Txt_CPF;
        private Label Lbl_Identificador;
        private TextBox Txt_Email;
        private TextBox Txt_Identificador;
        private Label Lbl_Email;
        private TextBox Txt_Nome;
        private Label Lbl_Nome;
        private TextBox Txt_Id;
        private Label Lbl_Id;
        private Button Btn_Cancelar;
        private Button Btn_Selecionar;
        private TextBox Txt_Idenficador;
        private Button Btn_Buscar;
    }
}