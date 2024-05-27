using JomedAPI.Data.DTO.Consulta;
using Microsoft.AspNetCore.Mvc;

namespace JomedAPI.Data.Interfaces.Controllers;

public interface IConsultaController
{
    ObjectResult BuscarConsultas();
    ObjectResult CadastrarConsulta(CreateConsultaDto consulta);
    ObjectResult DeletarConsulta(int id, DeleteConsultaDto motivoCancelamento);
}
