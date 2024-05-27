using AutoMapper;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Usuario;

namespace JomedAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
