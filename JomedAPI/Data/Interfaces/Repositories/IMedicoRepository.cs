using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Medico;

namespace JomedAPI.Data.Interfaces.Repositories;

public interface IMedicoRepository
{
    Medico AtualizarMedico(Medico medico, UpdateMedicoDto medicoAlterado);
    Medico? BuscarMedicoPorId(int medicoId);
    Medico CadastrarMedico(CreateMedicoDto medicoDto);
    List<Medico> ListarMedicos();
    bool DeletarMedico(Medico medico);
    bool InativarMedico(Medico medico);
    Medico AtualizarEndereco(Medico medico, UpdateEnderecoDto endereco);
}
