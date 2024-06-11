using JomedAPIForms.Classes;
using JomedAPIForms.Forms;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace JomedAPIForms
{
    public partial class Form_Principal : Form
    {
        private HttpClientBuilder _httpClientBuilder;
        private IConfigurationRoot _configuration;
        private string urlBase;
        private string jwt = "";
        private string key;
        private int? usuarioId;
        private string? usuarioEmail;
        private string? usuarioRole;
        public Form_Principal()
        {
            _configuration = Configuration.GetIConfiguration();
            urlBase = _configuration["UrlBase"]!;
            key = _configuration["Jwt:Key"]!;
            InitializeComponent();
            _httpClientBuilder = new HttpClientBuilder(urlBase, "");
            LoginForm();
            PreencheDadosDoUsuario();
        }


        private void PreencheDadosDoUsuario()
        {
            ClaimsPrincipal? dados = DeserializeJwt.JwtClaims(jwt, key);
            if (dados != null)
            {
                List<Claim> listaClaims = dados.Claims.ToList();
                usuarioId = Int32.Parse(listaClaims[0].Value);
                usuarioEmail = listaClaims[1].Value;
                usuarioRole = listaClaims[2].Value;

                toolStripStatusRole.Text = usuarioRole;
                toolStripStatusEmail.Text = usuarioEmail;
            }
        }
        private void LoginForm()
        {
            Form_Login login = new Form_Login(_httpClientBuilder);
            DialogResult loginResponse = login.ShowDialog();
            if (loginResponse == DialogResult.OK)
            {
                jwt = login.Jwt!;
                _httpClientBuilder = new HttpClientBuilder(urlBase, jwt);
            }
            else
            {
                this.Close();
            }
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
