using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JomedAPI.Data.DTO.Usuario
{
    public class CreateUsuarioDto
    {
        public CreateUsuarioDto(string email, string senha, string confirmarSenha)
        {
            Email = email;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
        }

        [JsonPropertyName("email")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "O e-mail deve ser informado.")]
        public string Email { get; set; }
        [JsonPropertyName("senha")]
        [Required(ErrorMessage = "A senha deve ser informada.")]
        public string Senha { get; set; }
        [JsonPropertyName("confirmarSenha")]
        [Required(ErrorMessage = "A confirmação de senha deve ser informada.")]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmarSenha { get; set; }
    }
}
