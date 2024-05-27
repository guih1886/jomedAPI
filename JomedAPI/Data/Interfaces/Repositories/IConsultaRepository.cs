using jomedAPI.Models;
using JomedAPI.Data.DTO.Consulta;

namespace JomedAPI.Data.Interfaces.Repositories;

public interface IConsultaRepository
{
    Consulta? BuscarConsultaPorId(int id);
    List<ReadConsultaDto> BuscarConsultas();
    ReadConsultaDto CadastrarConsulta(CreateConsultaDto consulta);
    bool DeletarConsulta(Consulta consulta, DeleteConsultaDto motivoCancelamento);
}
