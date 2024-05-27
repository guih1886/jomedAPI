using AutoMapper;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Usuario;
using JomedAPI.Data.Interfaces.Repositories;

namespace jomedAPI.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private JomedContext _jomedContext;
    private IMapper _mapper;

    public UsuarioRepository(JomedContext jomedContext, IMapper mapper)
    {
        _jomedContext = jomedContext;
        _mapper = mapper;
    }

    public Usuario? BuscarUsuarioPorEmail(string email)
    {
        return _jomedContext.Usuarios.FirstOrDefault(x => x.Email == email);
    }

    public Usuario? BuscarUsuarioPorId(int id)
    {
        return _jomedContext.Usuarios.FirstOrDefault(x => x.Id == id);
    }

    public Usuario CadastrarUsuario(CreateUsuarioDto novoUsuario)
    {
        Usuario usuario = _mapper.Map<Usuario>(novoUsuario);
        _jomedContext.Usuarios.Add(usuario);
        _jomedContext.SaveChanges();
        return usuario;
    }

    public bool DeletarUsuario(Usuario usuario)
    {
        try
        {
            _jomedContext.Usuarios.Remove(usuario);
            _jomedContext.SaveChanges(true);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
