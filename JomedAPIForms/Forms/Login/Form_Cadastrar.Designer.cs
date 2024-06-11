﻿namespace JomedAPIForms.Forms.Login
{
    partial class Form_Cadastrar
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
            Txt_ConfirmSenha = new TextBox();
            Lbl_ConfirmSenha = new Label();
            Btn_Voltar = new Button();
            Btn_Cadastrar = new Button();
            Txt_Senha = new TextBox();
            Lbl_Senha = new Label();
            Txt_Email = new TextBox();
            Lbl_Email = new Label();
            Lbl_Message = new Label();
            Gpb_Campos.SuspendLayout();
            SuspendLayout();
            // 
            // Gpb_Campos
            // 
            Gpb_Campos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Gpb_Campos.Controls.Add(Txt_ConfirmSenha);
            Gpb_Campos.Controls.Add(Lbl_ConfirmSenha);
            Gpb_Campos.Controls.Add(Btn_Voltar);
            Gpb_Campos.Controls.Add(Btn_Cadastrar);
            Gpb_Campos.Controls.Add(Txt_Senha);
            Gpb_Campos.Controls.Add(Lbl_Senha);
            Gpb_Campos.Controls.Add(Txt_Email);
            Gpb_Campos.Controls.Add(Lbl_Email);
            Gpb_Campos.Location = new Point(12, 88);
            Gpb_Campos.Name = "Gpb_Campos";
            Gpb_Campos.Size = new Size(393, 208);
            Gpb_Campos.TabIndex = 1;
            Gpb_Campos.TabStop = false;
            // 
            // Txt_ConfirmSenha
            // 
            Txt_ConfirmSenha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_ConfirmSenha.Location = new Point(6, 140);
            Txt_ConfirmSenha.Name = "Txt_ConfirmSenha";
            Txt_ConfirmSenha.Size = new Size(381, 23);
            Txt_ConfirmSenha.TabIndex = 3;
            Txt_ConfirmSenha.UseSystemPasswordChar = true;
            // 
            // Lbl_ConfirmSenha
            // 
            Lbl_ConfirmSenha.AutoSize = true;
            Lbl_ConfirmSenha.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_ConfirmSenha.Location = new Point(6, 117);
            Lbl_ConfirmSenha.Name = "Lbl_ConfirmSenha";
            Lbl_ConfirmSenha.Size = new Size(144, 20);
            Lbl_ConfirmSenha.TabIndex = 6;
            Lbl_ConfirmSenha.Text = "Confirmação da Senha";
            // 
            // Btn_Voltar
            // 
            Btn_Voltar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Btn_Voltar.Location = new Point(312, 179);
            Btn_Voltar.Name = "Btn_Voltar";
            Btn_Voltar.Size = new Size(75, 23);
            Btn_Voltar.TabIndex = 5;
            Btn_Voltar.TabStop = false;
            Btn_Voltar.Text = "Voltar";
            Btn_Voltar.UseVisualStyleBackColor = true;
            Btn_Voltar.Click += Btn_Voltar_Click;
            // 
            // Btn_Cadastrar
            // 
            Btn_Cadastrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Btn_Cadastrar.Location = new Point(6, 179);
            Btn_Cadastrar.Name = "Btn_Cadastrar";
            Btn_Cadastrar.Size = new Size(75, 23);
            Btn_Cadastrar.TabIndex = 4;
            Btn_Cadastrar.Text = "Cadastrar";
            Btn_Cadastrar.UseVisualStyleBackColor = true;
            Btn_Cadastrar.Click += Btn_Cadastrar_Click;
            // 
            // Txt_Senha
            // 
            Txt_Senha.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Senha.Location = new Point(6, 91);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.Size = new Size(381, 23);
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
            Txt_Email.Size = new Size(381, 23);
            Txt_Email.TabIndex = 1;
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
            // Lbl_Message
            // 
            Lbl_Message.Location = new Point(12, 299);
            Lbl_Message.Name = "Lbl_Message";
            Lbl_Message.Size = new Size(393, 45);
            Lbl_Message.TabIndex = 2;
            Lbl_Message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form_Cadastrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 361);
            Controls.Add(Lbl_Message);
            Controls.Add(Gpb_Campos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form_Cadastrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JomedAPI Cadastrar";
            Gpb_Campos.ResumeLayout(false);
            Gpb_Campos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Gpb_Campos;
        private Button Btn_Voltar;
        private Button Btn_Cadastrar;
        private TextBox Txt_Senha;
        private Label Lbl_Senha;
        private TextBox Txt_Email;
        private Label Lbl_Email;
        private TextBox Txt_ConfirmSenha;
        private Label Lbl_ConfirmSenha;
        private Label Lbl_Message;
    }
}