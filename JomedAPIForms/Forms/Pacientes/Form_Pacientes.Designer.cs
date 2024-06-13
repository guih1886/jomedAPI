﻿namespace JomedAPIForms.Forms.Pacientes
{
    partial class Form_Pacientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Pacientes));
            Dgv_Pacientes = new DataGridView();
            ativoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Endereco = new DataGridViewTextBoxColumn();
            pacienteBindingSource = new BindingSource(components);
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
            Gpb_DadosPaciente = new GroupBox();
            Gpb_Endereco = new GroupBox();
            Cmb_UF = new ComboBox();
            Lbl_UF = new Label();
            Lbl_Logradouro = new Label();
            Txt_Logradouro = new TextBox();
            Txt_Cidade = new TextBox();
            Lbl_Cidade = new Label();
            Txt_CEP = new TextBox();
            Lbl_CEP = new Label();
            Txt_Complemento = new TextBox();
            Lbl_Complemento = new Label();
            Txt_Bairro = new TextBox();
            Lbl_Bairro = new Label();
            Txt_Numero = new TextBox();
            Lbl_Numero = new Label();
            Gpb_Dados = new GroupBox();
            Ckb_Ativo = new CheckBox();
            Txt_Telefone = new TextBox();
            Lbl_Telefone = new Label();
            Txt_CPF = new TextBox();
            Lbl_CPF = new Label();
            Txt_Email = new TextBox();
            Lbl_Email = new Label();
            Txt_Nome = new TextBox();
            Lbl_Nome = new Label();
            Txt_Id = new TextBox();
            Lbl_Id = new Label();
            ((System.ComponentModel.ISupportInitialize)Dgv_Pacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            Gpb_DadosPaciente.SuspendLayout();
            Gpb_Endereco.SuspendLayout();
            Gpb_Dados.SuspendLayout();
            SuspendLayout();
            // 
            // Dgv_Pacientes
            // 
            Dgv_Pacientes.AllowUserToAddRows = false;
            Dgv_Pacientes.AllowUserToDeleteRows = false;
            Dgv_Pacientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Dgv_Pacientes.AutoGenerateColumns = false;
            Dgv_Pacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Pacientes.Columns.AddRange(new DataGridViewColumn[] { ativoDataGridViewCheckBoxColumn, idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, cpfDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, Endereco });
            Dgv_Pacientes.DataSource = pacienteBindingSource;
            Dgv_Pacientes.Location = new Point(12, 28);
            Dgv_Pacientes.MultiSelect = false;
            Dgv_Pacientes.Name = "Dgv_Pacientes";
            Dgv_Pacientes.ReadOnly = true;
            Dgv_Pacientes.ScrollBars = ScrollBars.Vertical;
            Dgv_Pacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Pacientes.Size = new Size(1147, 312);
            Dgv_Pacientes.TabIndex = 0;
            Dgv_Pacientes.TabStop = false;
            Dgv_Pacientes.CellDoubleClick += Dgv_Pacientes_CellDoubleClick;
            // 
            // ativoDataGridViewCheckBoxColumn
            // 
            ativoDataGridViewCheckBoxColumn.DataPropertyName = "Ativo";
            ativoDataGridViewCheckBoxColumn.HeaderText = "Ativo";
            ativoDataGridViewCheckBoxColumn.Name = "ativoDataGridViewCheckBoxColumn";
            ativoDataGridViewCheckBoxColumn.ReadOnly = true;
            ativoDataGridViewCheckBoxColumn.Width = 54;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 350;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 350;
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
            cpfDataGridViewTextBoxColumn.HeaderText = "Cpf";
            cpfDataGridViewTextBoxColumn.Name = "cpfDataGridViewTextBoxColumn";
            cpfDataGridViewTextBoxColumn.ReadOnly = true;
            cpfDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            telefoneDataGridViewTextBoxColumn.Width = 150;
            // 
            // Endereco
            // 
            Endereco.DataPropertyName = "Endereco";
            Endereco.HeaderText = "Endereco";
            Endereco.Name = "Endereco";
            Endereco.ReadOnly = true;
            Endereco.Visible = false;
            // 
            // pacienteBindingSource
            // 
            pacienteBindingSource.DataSource = typeof(jomedAPI.Models.Paciente);
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripNovo, toolStripSeparator1, toolStripBuscar, toolStripSeparator2, toolStripEditar, toolStripSeparator3, toolStripSalvar, toolStripSeparator4, toolStripExcluir, toolStripSeparator5, toolStripCancelar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1171, 25);
            toolStrip1.TabIndex = 1;
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
            toolStripNovo.ToolTipText = "Adicionar novo paciente";
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
            toolStripBuscar.ToolTipText = "Buscar o paciente";
            toolStripBuscar.Click += toolStripBuscar_Click;
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
            toolStripEditar.ToolTipText = "Editar o cadastro do paciente";
            toolStripEditar.Click += toolStripEditar_Click;
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
            toolStripSalvar.Click += toolStripSalvar_Click;
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
            toolStripExcluir.ToolTipText = "Excluir o cadastro do paciente ";
            toolStripExcluir.Click += toolStripExcluir_Click;
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
            toolStripCancelar.Click += toolStripCancelar_Click;
            // 
            // Gpb_DadosPaciente
            // 
            Gpb_DadosPaciente.Controls.Add(Gpb_Endereco);
            Gpb_DadosPaciente.Controls.Add(Gpb_Dados);
            Gpb_DadosPaciente.Location = new Point(12, 346);
            Gpb_DadosPaciente.Name = "Gpb_DadosPaciente";
            Gpb_DadosPaciente.Size = new Size(1147, 305);
            Gpb_DadosPaciente.TabIndex = 2;
            Gpb_DadosPaciente.TabStop = false;
            Gpb_DadosPaciente.Text = "Dados do Paciente";
            // 
            // Gpb_Endereco
            // 
            Gpb_Endereco.Controls.Add(Cmb_UF);
            Gpb_Endereco.Controls.Add(Lbl_UF);
            Gpb_Endereco.Controls.Add(Lbl_Logradouro);
            Gpb_Endereco.Controls.Add(Txt_Logradouro);
            Gpb_Endereco.Controls.Add(Txt_Cidade);
            Gpb_Endereco.Controls.Add(Lbl_Cidade);
            Gpb_Endereco.Controls.Add(Txt_CEP);
            Gpb_Endereco.Controls.Add(Lbl_CEP);
            Gpb_Endereco.Controls.Add(Txt_Complemento);
            Gpb_Endereco.Controls.Add(Lbl_Complemento);
            Gpb_Endereco.Controls.Add(Txt_Bairro);
            Gpb_Endereco.Controls.Add(Lbl_Bairro);
            Gpb_Endereco.Controls.Add(Txt_Numero);
            Gpb_Endereco.Controls.Add(Lbl_Numero);
            Gpb_Endereco.Location = new Point(6, 168);
            Gpb_Endereco.Name = "Gpb_Endereco";
            Gpb_Endereco.Size = new Size(1135, 125);
            Gpb_Endereco.TabIndex = 1;
            Gpb_Endereco.TabStop = false;
            // 
            // Cmb_UF
            // 
            Cmb_UF.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_UF.Enabled = false;
            Cmb_UF.FormattingEnabled = true;
            Cmb_UF.Location = new Point(712, 77);
            Cmb_UF.Name = "Cmb_UF";
            Cmb_UF.Size = new Size(205, 23);
            Cmb_UF.TabIndex = 12;
            // 
            // Lbl_UF
            // 
            Lbl_UF.AutoSize = true;
            Lbl_UF.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_UF.Location = new Point(710, 58);
            Lbl_UF.Name = "Lbl_UF";
            Lbl_UF.Size = new Size(22, 16);
            Lbl_UF.TabIndex = 16;
            Lbl_UF.Text = "UF";
            // 
            // Lbl_Logradouro
            // 
            Lbl_Logradouro.AutoSize = true;
            Lbl_Logradouro.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Logradouro.Location = new Point(183, 13);
            Lbl_Logradouro.Name = "Lbl_Logradouro";
            Lbl_Logradouro.Size = new Size(63, 16);
            Lbl_Logradouro.TabIndex = 4;
            Lbl_Logradouro.Text = "Logradouro";
            // 
            // Txt_Logradouro
            // 
            Txt_Logradouro.Enabled = false;
            Txt_Logradouro.Location = new Point(183, 32);
            Txt_Logradouro.Name = "Txt_Logradouro";
            Txt_Logradouro.Size = new Size(531, 23);
            Txt_Logradouro.TabIndex = 7;
            // 
            // Txt_Cidade
            // 
            Txt_Cidade.Enabled = false;
            Txt_Cidade.Location = new Point(359, 77);
            Txt_Cidade.Name = "Txt_Cidade";
            Txt_Cidade.Size = new Size(347, 23);
            Txt_Cidade.TabIndex = 11;
            // 
            // Lbl_Cidade
            // 
            Lbl_Cidade.AutoSize = true;
            Lbl_Cidade.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Cidade.Location = new Point(359, 58);
            Lbl_Cidade.Name = "Lbl_Cidade";
            Lbl_Cidade.Size = new Size(41, 16);
            Lbl_Cidade.TabIndex = 14;
            Lbl_Cidade.Text = "Cidade";
            // 
            // Txt_CEP
            // 
            Txt_CEP.Enabled = false;
            Txt_CEP.Location = new Point(6, 32);
            Txt_CEP.MaxLength = 9;
            Txt_CEP.Name = "Txt_CEP";
            Txt_CEP.Size = new Size(171, 23);
            Txt_CEP.TabIndex = 6;
            Txt_CEP.Leave += Txt_CEP_Leave;
            // 
            // Lbl_CEP
            // 
            Lbl_CEP.AutoSize = true;
            Lbl_CEP.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_CEP.Location = new Point(6, 13);
            Lbl_CEP.Name = "Lbl_CEP";
            Lbl_CEP.Size = new Size(29, 16);
            Lbl_CEP.TabIndex = 12;
            Lbl_CEP.Text = "CEP";
            // 
            // Txt_Complemento
            // 
            Txt_Complemento.Enabled = false;
            Txt_Complemento.Location = new Point(6, 77);
            Txt_Complemento.Name = "Txt_Complemento";
            Txt_Complemento.Size = new Size(347, 23);
            Txt_Complemento.TabIndex = 10;
            // 
            // Lbl_Complemento
            // 
            Lbl_Complemento.AutoSize = true;
            Lbl_Complemento.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Complemento.Location = new Point(6, 58);
            Lbl_Complemento.Name = "Lbl_Complemento";
            Lbl_Complemento.Size = new Size(71, 16);
            Lbl_Complemento.TabIndex = 10;
            Lbl_Complemento.Text = "Complemento";
            // 
            // Txt_Bairro
            // 
            Txt_Bairro.Enabled = false;
            Txt_Bairro.Location = new Point(806, 32);
            Txt_Bairro.Name = "Txt_Bairro";
            Txt_Bairro.Size = new Size(323, 23);
            Txt_Bairro.TabIndex = 9;
            // 
            // Lbl_Bairro
            // 
            Lbl_Bairro.AutoSize = true;
            Lbl_Bairro.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Bairro.Location = new Point(806, 13);
            Lbl_Bairro.Name = "Lbl_Bairro";
            Lbl_Bairro.Size = new Size(36, 16);
            Lbl_Bairro.TabIndex = 8;
            Lbl_Bairro.Text = "Bairro";
            // 
            // Txt_Numero
            // 
            Txt_Numero.Enabled = false;
            Txt_Numero.Location = new Point(720, 32);
            Txt_Numero.Name = "Txt_Numero";
            Txt_Numero.Size = new Size(80, 23);
            Txt_Numero.TabIndex = 8;
            // 
            // Lbl_Numero
            // 
            Lbl_Numero.AutoSize = true;
            Lbl_Numero.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Numero.Location = new Point(720, 13);
            Lbl_Numero.Name = "Lbl_Numero";
            Lbl_Numero.Size = new Size(45, 16);
            Lbl_Numero.TabIndex = 6;
            Lbl_Numero.Text = "Número";
            // 
            // Gpb_Dados
            // 
            Gpb_Dados.Controls.Add(Ckb_Ativo);
            Gpb_Dados.Controls.Add(Txt_Telefone);
            Gpb_Dados.Controls.Add(Lbl_Telefone);
            Gpb_Dados.Controls.Add(Txt_CPF);
            Gpb_Dados.Controls.Add(Lbl_CPF);
            Gpb_Dados.Controls.Add(Txt_Email);
            Gpb_Dados.Controls.Add(Lbl_Email);
            Gpb_Dados.Controls.Add(Txt_Nome);
            Gpb_Dados.Controls.Add(Lbl_Nome);
            Gpb_Dados.Controls.Add(Txt_Id);
            Gpb_Dados.Controls.Add(Lbl_Id);
            Gpb_Dados.Location = new Point(6, 22);
            Gpb_Dados.Name = "Gpb_Dados";
            Gpb_Dados.Size = new Size(1135, 146);
            Gpb_Dados.TabIndex = 0;
            Gpb_Dados.TabStop = false;
            // 
            // Ckb_Ativo
            // 
            Ckb_Ativo.AutoSize = true;
            Ckb_Ativo.Enabled = false;
            Ckb_Ativo.Location = new Point(359, 29);
            Ckb_Ativo.Name = "Ckb_Ativo";
            Ckb_Ativo.Size = new Size(54, 19);
            Ckb_Ativo.TabIndex = 10;
            Ckb_Ativo.TabStop = false;
            Ckb_Ativo.Text = "Ativo";
            Ckb_Ativo.UseVisualStyleBackColor = true;
            // 
            // Txt_Telefone
            // 
            Txt_Telefone.Enabled = false;
            Txt_Telefone.Location = new Point(6, 117);
            Txt_Telefone.MaxLength = 11;
            Txt_Telefone.Name = "Txt_Telefone";
            Txt_Telefone.Size = new Size(347, 23);
            Txt_Telefone.TabIndex = 5;
            // 
            // Lbl_Telefone
            // 
            Lbl_Telefone.AutoSize = true;
            Lbl_Telefone.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Telefone.Location = new Point(6, 97);
            Lbl_Telefone.Name = "Lbl_Telefone";
            Lbl_Telefone.Size = new Size(48, 16);
            Lbl_Telefone.TabIndex = 8;
            Lbl_Telefone.Text = "Telefone";
            // 
            // Txt_CPF
            // 
            Txt_CPF.Enabled = false;
            Txt_CPF.Location = new Point(112, 29);
            Txt_CPF.MaxLength = 11;
            Txt_CPF.Name = "Txt_CPF";
            Txt_CPF.Size = new Size(241, 23);
            Txt_CPF.TabIndex = 2;
            // 
            // Lbl_CPF
            // 
            Lbl_CPF.AutoSize = true;
            Lbl_CPF.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_CPF.Location = new Point(112, 10);
            Lbl_CPF.Name = "Lbl_CPF";
            Lbl_CPF.Size = new Size(29, 16);
            Lbl_CPF.TabIndex = 6;
            Lbl_CPF.Text = "CPF";
            // 
            // Txt_Email
            // 
            Txt_Email.Enabled = false;
            Txt_Email.Location = new Point(570, 71);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.Size = new Size(559, 23);
            Txt_Email.TabIndex = 4;
            // 
            // Lbl_Email
            // 
            Lbl_Email.AutoSize = true;
            Lbl_Email.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Email.Location = new Point(570, 52);
            Lbl_Email.Name = "Lbl_Email";
            Lbl_Email.Size = new Size(36, 16);
            Lbl_Email.TabIndex = 4;
            Lbl_Email.Text = "E-mail";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Enabled = false;
            Txt_Nome.Location = new Point(6, 71);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(559, 23);
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
            Txt_Id.Enabled = false;
            Txt_Id.Location = new Point(6, 29);
            Txt_Id.Name = "Txt_Id";
            Txt_Id.Size = new Size(100, 23);
            Txt_Id.TabIndex = 1;
            // 
            // Lbl_Id
            // 
            Lbl_Id.AutoSize = true;
            Lbl_Id.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Id.Location = new Point(6, 10);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(18, 16);
            Lbl_Id.TabIndex = 0;
            Lbl_Id.Text = "ID";
            // 
            // Form_Pacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1171, 663);
            Controls.Add(Gpb_DadosPaciente);
            Controls.Add(toolStrip1);
            Controls.Add(Dgv_Pacientes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Pacientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Pacientes";
            ((System.ComponentModel.ISupportInitialize)Dgv_Pacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            Gpb_DadosPaciente.ResumeLayout(false);
            Gpb_Endereco.ResumeLayout(false);
            Gpb_Endereco.PerformLayout();
            Gpb_Dados.ResumeLayout(false);
            Gpb_Dados.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Dgv_Pacientes;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripNovo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripEditar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripSalvar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripBuscar;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripExcluir;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripCancelar;
        private BindingSource pacienteBindingSource;
        private GroupBox Gpb_DadosPaciente;
        private GroupBox Gpb_Endereco;
        private GroupBox Gpb_Dados;
        private TextBox Txt_Id;
        private Label Lbl_Id;
        private TextBox Txt_Email;
        private Label Lbl_Email;
        private TextBox Txt_Nome;
        private Label Lbl_Nome;
        private TextBox Txt_Telefone;
        private Label Lbl_Telefone;
        private TextBox Txt_CPF;
        private Label Lbl_CPF;
        private TextBox Txt_Cidade;
        private Label Lbl_Cidade;
        private TextBox Txt_CEP;
        private Label Lbl_CEP;
        private TextBox Txt_Complemento;
        private Label Lbl_Complemento;
        private TextBox Txt_Bairro;
        private Label Lbl_Bairro;
        private TextBox Txt_Numero;
        private Label Lbl_Numero;
        private TextBox Txt_Logradouro;
        private Label Lbl_Logradouro;
        private ComboBox Cmb_UF;
        private Label Lbl_UF;
        private CheckBox Ckb_Ativo;
        private DataGridViewCheckBoxColumn ativoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Endereco;
    }
}