using jomedAPI.Data.DTO.Login;
using JomedAPIForms.Classes;
using JomedAPIForms.Classes.Interfaces;
using JomedAPIForms.Forms.Login;

namespace JomedAPIForms.Forms;

public partial class Form_Login : Form
{
    private IHttpClientBuilder _httpClientBuilder;
    public string? Jwt { get; set; }
    public Form_Login(IHttpClientBuilder httpClient)
    {
        _httpClientBuilder = httpClient;
        InitializeComponent();
    }

    private void Btn_Sair_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private async void Btn_Entrar_Click(object sender, EventArgs e)
    {
        LoginDto login = new LoginDto(Txt_Email.Text, Txt_Senha.Text);
        HttpResponseMessage resposta = await _httpClientBuilder.PostRequisition("/Login", login);
        string msg = await ValidaRequisicoes.ValidarErrosRequisicao(resposta);
        if (resposta.IsSuccessStatusCode)
        {
            Jwt = await resposta.Content.ReadAsStringAsync();
            DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            Lbl_Message.Text = msg;
        }
    }
    private void Btn_Cadastrar_Click(object sender, EventArgs e)
    {
        Form_Cadastrar cadastro = new Form_Cadastrar(_httpClientBuilder, this);
        this.Hide();
        DialogResult response = cadastro.ShowDialog();
        if (response == DialogResult.OK)
        {
            Lbl_Message.Text = "";
            Txt_Email.Text = cadastro.Email;
            Txt_Senha.Focus();
        }
        else
        {
            Txt_Email.Focus();
        }
    }
}
