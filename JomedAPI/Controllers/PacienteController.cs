﻿using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Paciente;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Data.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JomedAPI.Controllers
{
    [ApiController]
    [Route("Pacientes")]
    public class PacienteController : IPacienteController
    {
        private IPacienteRepository _pacienteRepository;
        private ObjectResult httpResponse = new ObjectResult("");

        public PacienteController(IPacienteRepository pacienteController)
        {
            _pacienteRepository = pacienteController;
        }
        [HttpPost]
        public ObjectResult CadastrarPaciente([FromBody] CreatePacienteDto pacienteDto)
        {
            Paciente paciente = _pacienteRepository.CadastrarPaciente(pacienteDto);
            string json = JsonConvert.SerializeObject(paciente);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }

        [HttpGet]
        public ObjectResult ListarPacientes()
        {
            List<Paciente> pacientes = _pacienteRepository.ListarPacientes();
            string json = JsonConvert.SerializeObject(pacientes);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }

        [HttpGet("{id}")]
        public ObjectResult BuscarPacientePorId(int id)
        {
            Paciente? paciente = _pacienteRepository.BuscarPacientePorId(id);
            if (paciente == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Paciente não encontrado.";
                return httpResponse;
            }
            string json = JsonConvert.SerializeObject(paciente);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }

        [HttpPut("{id}")]
        public ObjectResult AtualizarPaciente(int id, UpdatePacienteDto pacienteDto)
        {
            Paciente? paciente = _pacienteRepository.BuscarPacientePorId(id);
            if (paciente == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Paciente não encontrado.";
                return httpResponse;
            }
            Paciente novoPaciente = _pacienteRepository.AtualizarPaciente(paciente, pacienteDto);
            string json = JsonConvert.SerializeObject(novoPaciente);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }

        [HttpPut("{id}/atualizarEndereco")]
        public ObjectResult AtualizarEndereco(int id, UpdateEnderecoDto endereco)
        {
            Paciente? paciente = _pacienteRepository.BuscarPacientePorId(id);
            if (paciente == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Paciente não encontrado.";
                return httpResponse;
            }
            paciente = _pacienteRepository.AtualizarEndereco(paciente, endereco);
            string json = JsonConvert.SerializeObject(paciente);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }

        [HttpDelete("{id}")]
        public ObjectResult DeletarPaciente(int id)
        {
            Paciente? paciente = _pacienteRepository.BuscarPacientePorId(id);
            if (paciente == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Paciente não encontrado.";
                return httpResponse;
            }
            if (_pacienteRepository.DeletarPaciente(paciente))
            {
                httpResponse.StatusCode = 204;
                return httpResponse;
            }
            httpResponse.StatusCode = 500;
            httpResponse.Value = "Ocorreu um erro ao inativar o paciente.";
            return httpResponse;
        }

        [HttpDelete("{id}/inativar")]
        public ObjectResult InativarPaciente(int id)
        {
            Paciente? paciente = _pacienteRepository.BuscarPacientePorId(id);
            if (paciente == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Paciente não encontrado.";
                return httpResponse;
            }
            if (_pacienteRepository.InativarPaciente(paciente))
            {
                httpResponse.StatusCode = 204;
                return httpResponse;
            }
            httpResponse.StatusCode = 500;
            httpResponse.Value = "Ocorreu um erro ao inativar o paciente.";
            return httpResponse;
        }
    }
}