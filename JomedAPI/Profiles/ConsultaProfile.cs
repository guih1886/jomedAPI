using AutoMapper;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Consulta;

namespace JomedAPI.Profiles;

public class ConsultaProfile : Profile
{
    public ConsultaProfile()
    {
        CreateMap<CreateConsultaDto, Consulta>();
        CreateMap<Consulta, ReadConsultaDto>();
    }
}
