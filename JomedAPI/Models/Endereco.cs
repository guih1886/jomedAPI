using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace jomedAPI.Models;

[Owned]
public class Endereco
{
    public Endereco(string logradouro, string bairro, string cep, string cidade, string uf, int numero, string complemento)
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
    [Required(ErrorMessage = "O nome da rua deve ser informado.")]
    [MinLength(10, ErrorMessage = "Nome da rua muito pequeno.")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O nome do bairro deve ser informado.")]
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "O cep deve ser informado.")]
    [RegularExpression("^\\d{5}-?\\d{3}$", ErrorMessage = "Cep inválido.")]
    [JsonPropertyName("cep")]
    public string Cep { get; set; }
    [Required(ErrorMessage = "A cidade deve ser informada.")]
    [JsonPropertyName("cidade")]
    public string Cidade { get; set; }
    [Required(ErrorMessage = "O UF deve ser informado.")]
    [RegularExpression("^[a-zA-Z]{2}$", ErrorMessage = "UF deve ser apenas 2 caracteres.")]
    [JsonPropertyName("uf")]
    public string Uf { get; set; }
    [JsonPropertyName("numero")]
    public int Numero { get; set; }
    [JsonPropertyName("complemento")]
    public string Complemento { get; set; }
}