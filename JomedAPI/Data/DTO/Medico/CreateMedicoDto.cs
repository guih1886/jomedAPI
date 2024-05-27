using jomedAPI.Models.Enum;
using jomedAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Medico;

public class CreateMedicoDto
{
    public CreateMedicoDto(string nome, string email, string telefone, string crm, Especialidade especialidade, Endereco endereco)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Crm = crm;
        Especialidade = especialidade;
        Endereco = endereco;
    }

    [Required(ErrorMessage = "O nome não pode estar vazio.")]
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O e-mail não pode estar vazio.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O telefone não pode estar vazio.")]
    [RegularExpression("^\\d{7}-?\\d{4}$", ErrorMessage = "Telefone inválido.")]
    [JsonPropertyName("telefone")]
    public string Telefone { get; set; }
    [Required(ErrorMessage = "O crm não pode estar vazio.")]
    [JsonPropertyName("crm")]
    public string Crm { get; set; }
    [Required(ErrorMessage = "A especialidade não pode estar vazio.")]
    [JsonPropertyName("especialidade")]
    public Especialidade Especialidade { get; set; }
    [Required(ErrorMessage = "O endereço não pode estar vazio.")]
    [JsonPropertyName("endereco")]
    public Endereco Endereco { get; set; }
}
