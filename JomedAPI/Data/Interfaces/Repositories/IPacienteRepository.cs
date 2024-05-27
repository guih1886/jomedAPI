using JomedAPI.Data.DTO.Enderecos;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Paciente;

namespace JomedAPI.Data.Interfaces.Repositories;

public interface IPacienteRepository
{
    Paciente AtualizarPaciente(Paciente paciente, UpdatePacienteDto novoPaciente);
    Paciente AtualizarEndereco(Paciente paciente, UpdateEnderecoDto endereco);
    Paciente? BuscarPacientePorId(int id);
    Paciente CadastrarPaciente(CreatePacienteDto pacienteDto);
    List<Paciente> ListarPacientes();
    bool DeletarPaciente(Paciente paciente);
    bool InativarPaciente(Paciente paciente);
}