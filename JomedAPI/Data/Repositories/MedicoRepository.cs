using AutoMapper;
using jomedAPI.Data;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Medico;
using JomedAPI.Data.Interfaces.Repositories;

namespace JomedAPI.Data.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private JomedContext _jomedContext;
    private IMapper _mapper;

    public MedicoRepository(JomedContext jomedContext, IMapper mapper)
    {
        _jomedContext = jomedContext;
        _mapper = mapper;
    }
    public Medico? BuscarMedicoPorId(int medicoId)
    {
        return _jomedContext.Medicos.Where(m => m.Ativo == true).FirstOrDefault(m => m.Id == medicoId);
    }
    public List<Medico> ListarMedicos()
    {
        return _jomedContext.Medicos.Where(m => m.Ativo == true).ToList();
    }
    public Medico CadastrarMedico(CreateMedicoDto medicoDto)
    {
        Medico medico = _mapper.Map<Medico>(medicoDto);
        medico.Ativo = true;
        _jomedContext.Medicos.Add(medico);
        _jomedContext.SaveChanges();
        return medico;
    }
    public Medico AtualizarMedico(Medico medico, UpdateMedicoDto medicoAlterado)
    {
        Medico resp = _mapper.Map(medicoAlterado, medico);
        _jomedContext.SaveChanges();
        return resp;
    }
    public bool DeletarMedico(Medico medico)
    {
        try
        {
            _jomedContext.Medicos.Remove(medico);
            _jomedContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool InativarMedico(Medico medico)
    {
        try
        {
            medico.Ativo = false;
            _jomedContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public Medico AtualizarEndereco(Medico medico, UpdateEnderecoDto endereco)
    {
        Endereco? enderecoAlterado = _mapper.Map(endereco, medico.Endereco);
        medico.Endereco = enderecoAlterado;
        _jomedContext.SaveChanges();
        return medico;
    }
}