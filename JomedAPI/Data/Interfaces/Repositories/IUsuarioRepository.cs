using jomedAPI.Models;
using JomedAPI.Data.DTO.Usuario;

namespace JomedAPI.Data.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario? BuscarUsuarioPorEmail(string email);
    Usuario? BuscarUsuarioPorId(int id);
    Usuario CadastrarUsuario(CreateUsuarioDto novoUsuario);
    bool DeletarUsuario(Usuario usuario);
}