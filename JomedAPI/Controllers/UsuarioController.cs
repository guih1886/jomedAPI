using jomedAPI.Models;
using JomedAPI.Data.DTO.Usuario;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Data.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JomedAPI.Controllers
{
    [ApiController]
    [Route("Usuarios")]
    public class UsuarioController : ControllerBase, IUsuarioController
    {
        private IUsuarioRepository _usuarioRepository;
        private ObjectResult httpResponse = new ObjectResult("");

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public ObjectResult CadastrarUsuario(CreateUsuarioDto novoUsuario)
        {
            Usuario? usuario = _usuarioRepository.BuscarUsuarioPorEmail(novoUsuario.Email);
            if (usuario != null)
            {
                httpResponse.StatusCode = 400;
                httpResponse.Value = "Usuário já cadastrado.";
                return httpResponse;
            }
            Usuario usuarioCriado = _usuarioRepository.CadastrarUsuario(novoUsuario);
            string json = JsonConvert.SerializeObject(usuarioCriado);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }
        [HttpDelete("{id}")]
        public ObjectResult DeletarUsuario(int id)
        {
            Usuario? usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Usuário não encontrado.";
                return httpResponse;
            }
            if (_usuarioRepository.DeletarUsuario(usuario))
            {
                httpResponse.StatusCode = 204;
                return httpResponse;
            }
            httpResponse.StatusCode = 500;
            httpResponse.Value = "Erro ao deletar o usuário.";
            return httpResponse;
        }
    }
}
