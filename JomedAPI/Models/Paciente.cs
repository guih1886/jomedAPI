using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace jomedAPI.Models;

public class Paciente
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("cpf")]
    public string? Cpf { get; set; }
    [JsonPropertyName("telefone")]
    public string? Telefone { get; set; }
    [Required]
    [JsonPropertyName("endereco")]
    public Endereco? Endereco { get; set; }
    [JsonPropertyName("ativo")]
    public bool Ativo { get; set; }
}
