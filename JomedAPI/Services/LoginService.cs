using jomedAPI.Data.DTO.Login;
using jomedAPI.Models;
using JomedAPI.Data.Interfaces.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace jomedAPI.Services;

public class LoginService
{
    private IUsuarioRepository _usuarioRepository;
    private IConfiguration _configuration;

    public LoginService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public string GerarToken(LoginDto login)
    {
        Usuario usuarioDB = _usuarioRepository.BuscarUsuarioPorEmail(login.Email)!;
        //Faz a configuração o jwt
        SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        string issuer = _configuration["Jwt:Issuer"]!;
        string audience = _configuration["Jwt:Audience"]!;
        SigningCredentials credenciais = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //Opções do token
        var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new[]
            {
                new Claim(type: "id", usuarioDB.Id.ToString()),
                new Claim(type: "email", usuarioDB.Email.ToString()),
                new Claim(type: "role", usuarioDB.Role.ToString()),
            },
            expires: DateTime.Now.AddHours(12),
            signingCredentials: credenciais
            );
        //Geração do token
        string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return token;
    }
}