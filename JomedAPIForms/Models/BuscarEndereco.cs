using System.Text.Json.Serialization;

namespace JomedAPIForms.Models;

public class BuscarEndereco
{
    [JsonPropertyName("logradouro")]
    public string Logradouro { get; set; }

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; }

    [JsonPropertyName("cep")]
    public string Cep { get; set; }

    [JsonPropertyName("localidade")]
    public string Localidade { get; set; }

    [JsonPropertyName("uf")]
    public string Uf { get; set; }

    [JsonPropertyName("complemento")]
    public string Complemento { get; set; }
}
