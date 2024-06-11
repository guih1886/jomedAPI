using JomedAPIForms.Classes;
using JomedAPIForms.Forms;
using Microsoft.Extensions.Configuration;

namespace JomedAPIForms
{
    public partial class Form_Principal : Form
    {
        private HttpClientBuilder _httpClientBuilder;
        private string urlBase = "";
        private string jwt = "";
        public Form_Principal()
        {
            InitializeComponent();
            ValidaUrlBase();
            LoginForm();
            _httpClientBuilder = new HttpClientBuilder(urlBase, jwt);
        }

        private void LoginForm()
        {
            Form_Login login = new Form_Login();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                jwt = login.Jwt!;
            }
            else
            {
                Application.Exit();
            }
        }
        private void ValidaUrlBase()
        {
            IConfigurationRoot configuration = Configuration.GetIConfiguration();
            urlBase = configuration["UrlBase"]!;
        }
    }
}
