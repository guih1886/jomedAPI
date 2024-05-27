using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace JomedAPI.Data.Interfaces.Controllers;

public interface IPacienteController
{
    ObjectResult CadastrarPaciente(CreatePacienteDto pacienteDto);
    ObjectResult ListarPacientes();
    ObjectResult BuscarPacientePorId(int id);
    ObjectResult AtualizarPaciente(int id, UpdatePacienteDto pacienteDto);
    ObjectResult AtualizarEndereco(int id, UpdateEnderecoDto endereco);
    ObjectResult DeletarPaciente(int id);
    ObjectResult InativarPaciente(int id);
}