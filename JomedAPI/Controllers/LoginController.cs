using jomedAPI.Data.DTO.Login;
using jomedAPI.Models;
using jomedAPI.Services;
using JomedAPI.Data.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace jomedAPI.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        ObjectResult objectResult = new ObjectResult("");
        private LoginService _loginService;
        private IUsuarioRepository _usuarioReposity;

        public LoginController(LoginService loginService, IUsuarioRepository usuarioReposity)
        {
            _loginService = loginService;
            _usuarioReposity = usuarioReposity;
        }

        [HttpPost]
        public ObjectResult Login([FromBody] LoginDto login)
        {
            Usuario? usuario = _usuarioReposity.BuscarUsuarioPorEmail(login.Email);
            if (usuario == null)
            {
                objectResult.StatusCode = 404;
                objectResult.Value = "Usuário não encontrado.";
                return objectResult;
            }
            if (usuario.Senha != login.Senha)
            {
                objectResult.StatusCode = 400;
                objectResult.Value = "Senha incorreta.";
                return objectResult;
            }
            string token = _loginService.GerarToken(login);
            objectResult.StatusCode = 200;
            objectResult.Value = token;
            return objectResult;
        }
    }
}
