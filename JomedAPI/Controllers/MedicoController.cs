using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Medico;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Data.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JomedAPI.Controllers;

[ApiController]
[Route("Medicos")]
public class MedicoController : ControllerBase, IMedicoController
{
    private ObjectResult httpResponse = new ObjectResult("");
    private IMedicoRepository _medicoRepository;

    public MedicoController(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    [HttpPost]
    [Authorize]
    public ObjectResult CadastrarMedico([FromBody] CreateMedicoDto medicoDto)
    {
        Medico medico = _medicoRepository.CadastrarMedico(medicoDto);
        string json = JsonConvert.SerializeObject(medico);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpPost("{id}/ativar")]
    [Authorize]
    public ObjectResult AtivarMedico(int id)
    {
        Medico? medico = _medicoRepository.BuscarMedicoAtivoOuInativo(id);
        if (medico == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        if (medico.Ativo == true)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Médico já está ativo.";
            return httpResponse;
        }
        Medico medicoAtivo = _medicoRepository.AtivarMedico(medico);
        string json = JsonConvert.SerializeObject(medicoAtivo);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpGet]
    public ObjectResult ListarMedicos()
    {
        List<Medico> medico = _medicoRepository.ListarMedicos();
        string json = JsonConvert.SerializeObject(medico);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpGet("{id}")]
    public ObjectResult BuscarMedicoPorId(int id)
    {
        Medico? medico = _medicoRepository.BuscarMedicoPorId(id);
        if (medico == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(medico);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpPut("{id}")]
    [Authorize]
    public ObjectResult AtualizarMedico(int id, UpdateMedicoDto medicoAlterado)
    {
        Medico? medico = _medicoRepository.BuscarMedicoPorId(id);
        if (medico == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        Medico medicoAtualizado = _medicoRepository.AtualizarMedico(medico, medicoAlterado);
        if (medicoAtualizado == null)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Erro ao atualizar médico.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(medicoAtualizado);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpPut("{id}/atualizarEndereco")]
    [Authorize]
    public ObjectResult AtualizarEndereco(int id, UpdateEnderecoDto endereco)
    {
        Medico? medico = _medicoRepository.BuscarMedicoPorId(id);
        if (medico == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        Medico medicoAlterado = _medicoRepository.AtualizarEndereco(medico, endereco);
        string json = JsonConvert.SerializeObject(medicoAlterado);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public ObjectResult DeletarMedico(int id)
    {
        Medico? medico = _medicoRepository.BuscarMedicoPorId(id);
        if (medico == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        if (!_medicoRepository.DeletarMedico(medico))
        {
            httpResponse.StatusCode = 500;
            httpResponse.Value = "Ocorreu um erro ao deletar o médico.";
            return httpResponse;
        }
        httpResponse.StatusCode = 204;
        return httpResponse;
    }
    [HttpDelete("{id}/inativar")]
    [Authorize(Roles = "Administrador")]
    public ObjectResult InativarMedico(int id)
    {
        Medico? medico = _medicoRepository.BuscarMedicoPorId(id);
        if (medico == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Médico não encontrado.";
            return httpResponse;
        }
        if (!_medicoRepository.InativarMedico(medico))
        {
            httpResponse.StatusCode = 500;
            httpResponse.Value = "Ocorreu um erro ao deletar o médico.";
            return httpResponse;
        }
        httpResponse.StatusCode = 204;
        return httpResponse;
    }
}