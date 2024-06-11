using JomedAPI.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace jomedAPI.Models;

public class Usuario
{
    public Usuario(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("login")]
    public string Email { get; set; }
    [JsonPropertyName("senha")]
    public string Senha { get; set; }
    [JsonPropertyName("role")]
    public Roles Role { get; set; }
}
