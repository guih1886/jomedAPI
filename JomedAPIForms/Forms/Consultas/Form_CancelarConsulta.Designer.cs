namespace JomedAPIForms.Forms.Consultas
{
    partial class Form_CancelarConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CancelarConsulta));
            Grp_Motivo = new GroupBox();
            Lbl_Motivo = new Label();
            Cmb_Motivo = new ComboBox();
            Gpb_Botoes = new GroupBox();
            Btn_Voltar = new Button();
            Btn_Cancelar = new Button();
            Grp_Motivo.SuspendLayout();
            Gpb_Botoes.SuspendLayout();
            SuspendLayout();
            // 
            // Grp_Motivo
            // 
            Grp_Motivo.Controls.Add(Lbl_Motivo);
            Grp_Motivo.Controls.Add(Cmb_Motivo);
            Grp_Motivo.Location = new Point(12, 12);
            Grp_Motivo.Name = "Grp_Motivo";
            Grp_Motivo.Size = new Size(496, 137);
            Grp_Motivo.TabIndex = 0;
            Grp_Motivo.TabStop = false;
            // 
            // Lbl_Motivo
            // 
            Lbl_Motivo.AutoSize = true;
            Lbl_Motivo.Location = new Point(6, 32);
            Lbl_Motivo.Name = "Lbl_Motivo";
            Lbl_Motivo.Size = new Size(139, 15);
            Lbl_Motivo.TabIndex = 1;
            Lbl_Motivo.Text = "Motivo de cancelamento";
            // 
            // Cmb_Motivo
            // 
            Cmb_Motivo.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Motivo.FormattingEnabled = true;
            Cmb_Motivo.Location = new Point(6, 50);
            Cmb_Motivo.Name = "Cmb_Motivo";
            Cmb_Motivo.Size = new Size(484, 23);
            Cmb_Motivo.TabIndex = 0;
            // 
            // Gpb_Botoes
            // 
            Gpb_Botoes.Controls.Add(Btn_Voltar);
            Gpb_Botoes.Controls.Add(Btn_Cancelar);
            Gpb_Botoes.Location = new Point(12, 155);
            Gpb_Botoes.Name = "Gpb_Botoes";
            Gpb_Botoes.Size = new Size(496, 50);
            Gpb_Botoes.TabIndex = 1;
            Gpb_Botoes.TabStop = false;
            // 
            // Btn_Voltar
            // 
            Btn_Voltar.Location = new Point(415, 18);
            Btn_Voltar.Name = "Btn_Voltar";
            Btn_Voltar.Size = new Size(75, 23);
            Btn_Voltar.TabIndex = 1;
            Btn_Voltar.Text = "Voltar";
            Btn_Voltar.UseVisualStyleBackColor = true;
            Btn_Voltar.Click += Btn_Voltar_Click;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Location = new Point(334, 18);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(75, 23);
            Btn_Cancelar.TabIndex = 0;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Form_CancelarConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(520, 208);
            Controls.Add(Gpb_Botoes);
            Controls.Add(Grp_Motivo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_CancelarConsulta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cancelamento de Consultas";
            Grp_Motivo.ResumeLayout(false);
            Grp_Motivo.PerformLayout();
            Gpb_Botoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Grp_Motivo;
        private ComboBox Cmb_Motivo;
        private GroupBox Gpb_Botoes;
        private Label Lbl_Motivo;
        private Button Btn_Voltar;
        private Button Btn_Cancelar;
    }
}