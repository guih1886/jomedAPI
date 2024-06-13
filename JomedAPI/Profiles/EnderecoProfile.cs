using AutoMapper;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;

namespace JomedAPI.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<UpdateEnderecoDto, Endereco>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !(srcMember is string str && string.IsNullOrWhiteSpace(str))));
    }
}
