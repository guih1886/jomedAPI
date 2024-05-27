using AutoMapper;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Medico;

namespace JomedAPI.Profiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<CreateMedicoDto, Medico>();
            CreateMap<UpdateMedicoDto, Medico>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}