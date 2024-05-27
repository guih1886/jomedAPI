using jomedAPI.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Medico;

public class UpdateMedicoDto
{
    public UpdateMedicoDto(string? nome = null, string? email = null, string? telefone = null, string? crm = null, Especialidade? especialidade = null)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Crm = crm;
        Especialidade = especialidade;
    }

    [JsonPropertyName("nome")]
    public string? Nome { get; set; }

    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [RegularExpression("^\\d{7}-?\\d{4}$", ErrorMessage = "Telefone inválido.")]
    [JsonPropertyName("telefone")]
    public string? Telefone { get; set; }

    [JsonPropertyName("crm")]
    public string? Crm { get; set; }

    [JsonPropertyName("especialidade")]
    public Especialidade? Especialidade { get; set; }
}
