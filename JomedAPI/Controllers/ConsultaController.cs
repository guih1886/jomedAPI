using jomedAPI.Models;
using JomedAPI.Data.DTO.Consulta;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Data.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JomedAPI.Controllers;
[ApiController]
[Route("Consultas")]
public class ConsultaController : ControllerBase, IConsultaController
{
    private IConsultaRepository _consultaRepository;
    private IPacienteRepository _pacienteRepository;
    private IMedicoRepository _medicoRepository;
    private ObjectResult httpResponse = new ObjectResult("");

    public ConsultaController(IConsultaRepository consultaRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository)
    {
        _consultaRepository = consultaRepository;
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
    }

    [HttpGet]
    public ObjectResult BuscarConsultas()
    {
        List<ReadConsultaDto> consultas = _consultaRepository.BuscarConsultas();
        string json = JsonConvert.SerializeObject(consultas);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpPost]
    [Authorize]
    public ObjectResult CadastrarConsulta(CreateConsultaDto consulta)
    {
        if (_medicoRepository.BuscarMedicoPorId(consulta.MedicoId) == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        if (_pacienteRepository.BuscarPacientePorId(consulta.PacienteId) == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Paciente não encontrado.";
            return httpResponse;
        }
        if (consulta.Data < DateTime.Now)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "A data deve ser futura.";
            return httpResponse;
        }
        if (!ValidaData(consulta.Data))
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "A data deve ser um dia da semana entre as 7h e 18h";
            return httpResponse;
        }
        ReadConsultaDto consultaCriada = _consultaRepository.CadastrarConsulta(consulta);
        string json = JsonConvert.SerializeObject(consultaCriada);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public ObjectResult DeletarConsulta(int id, [FromBody] DeleteConsultaDto motivoCancelamento)
    {
        Consulta? consulta = _consultaRepository.BuscarConsultaPorId(id);
        if (consulta == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Consulta não encontrada.";
            return httpResponse;
        }
        if (_consultaRepository.DeletarConsulta(consulta, motivoCancelamento))
        {
            httpResponse.StatusCode = 204;
            return httpResponse;
        }
        httpResponse.StatusCode = 500;
        httpResponse.Value = "Erro ao deletar a consulta.";
        return httpResponse;
    }
    private bool ValidaData(DateTime data)
    {
        int hora = data.Hour;
        DayOfWeek diaDaSemana = data.DayOfWeek;
        if ((hora >= 7 && hora <= 18) && (diaDaSemana != DayOfWeek.Saturday && diaDaSemana != DayOfWeek.Sunday)) return true;
        return false;
    }
}