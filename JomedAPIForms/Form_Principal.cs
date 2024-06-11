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
            _httpClientBuilder = new HttpClientBuilder(urlBase, "");
            LoginForm();
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
        private void ValidaUrlBase()
        {
            IConfigurationRoot configuration = Configuration.GetIConfiguration();
            urlBase = configuration["UrlBase"]!;
        }
    }
}
