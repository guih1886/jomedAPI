using JomedAPI.Data.DTO.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace JomedAPI.Data.Interfaces.Controllers;

public interface IUsuarioController
{
    ObjectResult CadastrarUsuario(CreateUsuarioDto novoUsuario);
    ObjectResult DeletarUsuario(int id);
}
