namespace JomedAPIForms.Forms
{
    partial class Form_Login
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
            Gpb_Campos = new GroupBox();
            Lbl_Message = new Label();
            Btn_Sair = new Button();
            Btn_Cadastrar = new Button();
            Btn_Entrar = new Button();
            Txt_Senha = new TextBox();
            Lbl_Senha = new Label();
            Txt_Email = new TextBox();
            Lbl_Email = new Label();
            Pic_Login = new PictureBox();
            Gpb_Campos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Login).BeginInit();
            SuspendLayout();
            // 
            // Gpb_Campos
            // 
            Gpb_Campos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Gpb_Campos.Controls.Add(Lbl_Message);
            Gpb_Campos.Controls.Add(Btn_Sair);
            Gpb_Campos.Controls.Add(Btn_Cadastrar);
            Gpb_Campos.Controls.Add(Btn_Entrar);
            Gpb_Campos.Controls.Add(Txt_Senha);
            Gpb_Campos.Controls.Add(Lbl_Senha);
            Gpb_Campos.Controls.Add(Txt_Email);
            Gpb_Campos.Controls.Add(Lbl_Email);
            Gpb_Campos.Location = new Point(12, 233);
            Gpb_Campos.Name = "Gpb_Campos";
            Gpb_Campos.Size = new Size(395, 224);
            Gpb_Campos.TabIndex = 0;
            Gpb_Campos.TabStop = false;
            // 
            // Lbl_Message
            // 
            Lbl_Message.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Lbl_Message.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Message.ForeColor = Color.Red;
            Lbl_Message.Location = new Point(6, 146);
            Lbl_Message.Name = "Lbl_Message";
            Lbl_Message.Size = new Size(381, 45);
            Lbl_Message.TabIndex = 1;
            Lbl_Message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Btn_Sair
            // 
            Btn_Sair.Location = new Point(314, 195);
            Btn_Sair.Name = "Btn_Sair";
            Btn_Sair.Size = new Size(75, 23);
            Btn_Sair.TabIndex = 5;
            Btn_Sair.TabStop = false;
            Btn_Sair.Text = "Sair";
            Btn_Sair.UseVisualStyleBackColor = true;
            Btn_Sair.Click += Btn_Sair_Click;
            // 
            // Btn_Cadastrar
            // 
            Btn_Cadastrar.Location = new Point(6, 195);
            Btn_Cadastrar.Name = "Btn_Cadastrar";
            Btn_Cadastrar.Size = new Size(75, 23);
            Btn_Cadastrar.TabIndex = 4;
            Btn_Cadastrar.TabStop = false;
            Btn_Cadastrar.Text = "Cadastrar";
            Btn_Cadastrar.UseVisualStyleBackColor = true;
            Btn_Cadastrar.Click += Btn_Cadastrar_Click;
            // 
            // Btn_Entrar
            // 
            Btn_Entrar.Location = new Point(6, 120);
            Btn_Entrar.Name = "Btn_Entrar";
            Btn_Entrar.Size = new Size(75, 23);
            Btn_Entrar.TabIndex = 3;
            Btn_Entrar.Text = "Entrar";
            Btn_Entrar.UseVisualStyleBackColor = true;
            Btn_Entrar.Click += Btn_Entrar_Click;
            // 
            // Txt_Senha
            // 
            Txt_Senha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Senha.Location = new Point(6, 91);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.Size = new Size(383, 23);
            Txt_Senha.TabIndex = 2;
            Txt_Senha.UseSystemPasswordChar = true;
            // 
            // Lbl_Senha
            // 
            Lbl_Senha.AutoSize = true;
            Lbl_Senha.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Senha.Location = new Point(6, 68);
            Lbl_Senha.Name = "Lbl_Senha";
            Lbl_Senha.Size = new Size(47, 20);
            Lbl_Senha.TabIndex = 0;
            Lbl_Senha.Text = "Senha";
            // 
            // Txt_Email
            // 
            Txt_Email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Email.Location = new Point(6, 42);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.Size = new Size(383, 23);
            Txt_Email.TabIndex = 1;
            Txt_Email.Tag = "";
            // 
            // Lbl_Email
            // 
            Lbl_Email.AutoSize = true;
            Lbl_Email.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Email.Location = new Point(6, 19);
            Lbl_Email.Name = "Lbl_Email";
            Lbl_Email.Size = new Size(46, 20);
            Lbl_Email.TabIndex = 0;
            Lbl_Email.Text = "E-mail";
            // 
            // Pic_Login
            // 
            Pic_Login.Image = Properties.Resources.login;
            Pic_Login.Location = new Point(12, 12);
            Pic_Login.Name = "Pic_Login";
            Pic_Login.Size = new Size(395, 215);
            Pic_Login.SizeMode = PictureBoxSizeMode.Zoom;
            Pic_Login.TabIndex = 1;
            Pic_Login.TabStop = false;
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(419, 469);
            Controls.Add(Pic_Login);
            Controls.Add(Gpb_Campos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JomedAPI Login";
            Gpb_Campos.ResumeLayout(false);
            Gpb_Campos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Login).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Gpb_Campos;
        private Label Lbl_Email;
        private Button Btn_Sair;
        private Button Btn_Cadastrar;
        private Button Btn_Entrar;
        private TextBox Txt_Senha;
        private Label Lbl_Senha;
        private TextBox Txt_Email;
        private Label Lbl_Message;
        private PictureBox Pic_Login;
    }
}