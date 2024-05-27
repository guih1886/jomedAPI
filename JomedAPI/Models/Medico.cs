using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using jomedAPI.Models.Enum;

namespace jomedAPI.Models;

public class Medico
{
    public Medico() { }
    public Medico(int id, string nome, string email, string telefone, string crm, Especialidade especialidade, Endereco endereco, bool ativo)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Crm = crm;
        Especialidade = especialidade;
        Endereco = endereco;
        Ativo = ativo;
    }

    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("telefone")]
    public string? Telefone { get; set; }
    [JsonPropertyName("crm")]
    public string? Crm { get; set; }
    [JsonPropertyName("especialidade")]
    public Especialidade? Especialidade { get; set; }
    [Required]
    [JsonPropertyName("endereco")]
    public Endereco? Endereco { get; set; }
    [JsonPropertyName("ativo")]
    public bool Ativo { get; set; }
}
