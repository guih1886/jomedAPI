using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Paciente;

public class UpdatePacienteDto
{
    public UpdatePacienteDto(string? nome = null, string? email = null, string? cpf = null, string? telefone = null)
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Telefone = telefone;
    }

    [JsonPropertyName("nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("email")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string? Email { get; set; }

    [JsonPropertyName("cpf")]
    [RegularExpression("^\\d{3}\\.?\\d{3}\\.?\\d{3}-?\\d{2}$", ErrorMessage = "Cpf inválido.")]
    public string? Cpf { get; set; }

    [JsonPropertyName("telefone")]
    [RegularExpression("^\\d{7}-?\\d{4}$", ErrorMessage = "Telefone inválido.")]
    public string? Telefone { get; set; }
}