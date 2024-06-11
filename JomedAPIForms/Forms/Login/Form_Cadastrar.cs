﻿using JomedAPI.Data.DTO.Usuario;
using JomedAPIForms.Classes;
using JomedAPIForms.Classes.Interfaces;

namespace JomedAPIForms.Forms.Login;

public partial class Form_Cadastrar : Form
{
    private IHttpClientBuilder _httpClientBuilder;
    public string? Email { get; set; }
    public Form_Cadastrar(IHttpClientBuilder httpClientBuilder)
    {
        _httpClientBuilder = httpClientBuilder;
        InitializeComponent();
    }

    private void Btn_Voltar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private async void Btn_Cadastrar_Click(object sender, EventArgs e)
    {
        CreateUsuarioDto usuario = new CreateUsuarioDto(Txt_Email.Text, Txt_Senha.Text, Txt_ConfirmSenha.Text);
        HttpResponseMessage resposta = await _httpClientBuilder.PostRequisition("/Usuarios", usuario);
        string msg = await ValidaRequisicoes.ValidaCadastroUsuarioReq(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            DialogResult = DialogResult.OK;
            Email = Txt_Email.Text;
            MessageBox.Show("Usuário cadastrado com sucesso.", "Cadastro de Usuários", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            Lbl_Message.Text = msg;
        }
    }
}
