using JomedAPIForms.Classes;

namespace JomedAPIForms
{
    public partial class Form_Principal : Form
    {
        private HttpClientBuilder _httpClientBuilder;
        public Form_Principal()
        {
            _httpClientBuilder = new HttpClientBuilder("https://localhost:7185", "");
            InitializeComponent();
        }
    }
}
