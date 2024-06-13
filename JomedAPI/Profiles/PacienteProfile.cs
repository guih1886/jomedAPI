using AutoMapper;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Paciente;

namespace JomedAPI.Profiles;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<CreatePacienteDto, Paciente>();
        CreateMap<UpdatePacienteDto, Paciente>().ForAllMembers(m => m.Condition((src, dest, srcMember) => srcMember.ToString() != string.Empty));
    }
}
