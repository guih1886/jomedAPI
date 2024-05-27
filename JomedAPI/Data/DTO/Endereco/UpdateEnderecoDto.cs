using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Enderecos;

public class UpdateEnderecoDto
{
    public UpdateEnderecoDto(string? logradouro = null, string? bairro = null, string? cep = null, string? cidade = null, string? uf = null, int? numero = null, string? complemento = null)
    {
        Logradouro = logradouro;
        Bairro = bairro;
        Cep = cep;
        Cidade = cidade;
        Uf = uf;
        Numero = numero;
        Complemento = complemento;
    }

    [JsonPropertyName("logradouro")]
    [MinLength(10, ErrorMessage = "Nome da rua muito pequeno.")]
    public string? Logradouro { get; set; }
    [JsonPropertyName("bairro")]
    public string? Bairro { get; set; }
    [RegularExpression("^\\d{5}-?\\d{3}$", ErrorMessage = "Cep inválido.")]
    [JsonPropertyName("cep")]
    public string? Cep { get; set; }
    [JsonPropertyName("cidade")]
    public string? Cidade { get; set; }
    [RegularExpression("^[a-zA-Z]{2}$", ErrorMessage = "UF deve ser apenas 2 caracteres.")]
    [JsonPropertyName("uf")]
    public string? Uf { get; set; }
    [JsonPropertyName("numero")]
    public int? Numero { get; set; }
    [JsonPropertyName("complemento")]
    public string? Complemento { get; set; }
}
