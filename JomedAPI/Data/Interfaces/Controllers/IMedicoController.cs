using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Medico;
using Microsoft.AspNetCore.Mvc;

namespace JomedAPI.Data.Interfaces.Controllers;

public interface IMedicoController
{
    ObjectResult CadastrarMedico(CreateMedicoDto medicoDto);
    ObjectResult ListarMedicos();
    ObjectResult BuscarMedicoPorId(int id);
    ObjectResult AtualizarMedico(int id, UpdateMedicoDto medicoAlterado);
    ObjectResult DeletarMedico(int id);
    ObjectResult InativarMedico(int id);
    ObjectResult AtualizarEndereco(int id, UpdateEnderecoDto endereco);
}
