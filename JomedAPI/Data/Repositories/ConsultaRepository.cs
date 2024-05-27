using AutoMapper;
using jomedAPI.Data;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Consulta;
using JomedAPI.Data.Interfaces.Repositories;

namespace JomedAPI.Data.Repositories;

public class ConsultaRepository : IConsultaRepository
{
    private JomedContext _jomedContext;
    private IMapper _mapper;

    public ConsultaRepository(JomedContext jomedContext, IMapper mapper)
    {
        _jomedContext = jomedContext;
        _mapper = mapper;
    }
    public Consulta? BuscarConsultaPorId(int id)
    {
        return _jomedContext.Consultas.Where(c => c.Cancelado == false).FirstOrDefault(c => c.Id == id);
    }
    public List<ReadConsultaDto> BuscarConsultas()
    {
        List<ReadConsultaDto> lista = new List<ReadConsultaDto>();
        foreach (var item in _jomedContext.Consultas.Where(c=> c.Cancelado == false))
        {
            lista.Add(_mapper.Map<ReadConsultaDto>(item));
        }
        return lista;
    }
    public ReadConsultaDto CadastrarConsulta(CreateConsultaDto consulta)
    {
        Consulta consultaCriada = _mapper.Map<Consulta>(consulta);
        consultaCriada.Cancelado = false;
        _jomedContext.Consultas.Add(consultaCriada);
        _jomedContext.SaveChanges();
        return _mapper.Map<ReadConsultaDto>(consultaCriada);
    }
    public bool DeletarConsulta(Consulta consulta, DeleteConsultaDto motivoCancelamento)
    {
        try
        {
            consulta.Cancelado = true;
            consulta.MotivoCancelamento = motivoCancelamento.MotivoCancelamento;
            _jomedContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
