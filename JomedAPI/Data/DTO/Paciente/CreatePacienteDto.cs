using jomedAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Paciente;

public class CreatePacienteDto
{
    public CreatePacienteDto(string nome, string email, string cpf, string telefone, Endereco endereco)
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
    }

    [JsonPropertyName("nome")]
    [Required(ErrorMessage = "O nome não pode estar vazio.")]
    public string Nome { get; set; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "O e-mail não pode estar vazio.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    [JsonPropertyName("cpf")]
    [Required(ErrorMessage = "O CPF não pode estar vazio.")]
    [RegularExpression("^\\d{3}\\.?\\d{3}\\.?\\d{3}-?\\d{2}$", ErrorMessage = "Cpf inválido.")]
    public string Cpf { get; set; }

    [JsonPropertyName("telefone")]
    [Required(ErrorMessage = "O telefone não pode estar vazio.")]
    [RegularExpression("^\\d{7}-?\\d{4}$", ErrorMessage = "Telefone inválido.")]
    public string Telefone { get; set; }

    [JsonPropertyName("endereco")]
    [Required(ErrorMessage = "O endereço não pode estar vazio.")]
    public Endereco Endereco { get; set; }
}