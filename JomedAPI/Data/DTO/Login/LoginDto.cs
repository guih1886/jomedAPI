using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace jomedAPI.Data.DTO.Login;

public class LoginDto
{
    public LoginDto(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    [JsonPropertyName("email")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [Required(ErrorMessage = "E-mail não pode estar vazio.")]
    public string Email { get; set; }
    [JsonPropertyName("senha")]
    [Required(ErrorMessage = "Senha não pode estar vazio.")]
    public string Senha { get; set; }
}