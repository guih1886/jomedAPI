using AutoMapper;
using jomedAPI.Data;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Paciente;
using JomedAPI.Data.Interfaces.Repositories;

namespace JomedAPI.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private JomedContext _jomedContext;
        private IMapper _mapper;

        public PacienteRepository(JomedContext jomedContext, IMapper mapper)
        {
            _jomedContext = jomedContext;
            _mapper = mapper;
        }

        public Paciente AtualizarEndereco(Paciente paciente, UpdateEnderecoDto endereco)
        {
            paciente.Endereco = _mapper.Map(endereco, paciente.Endereco);
            _jomedContext.SaveChanges();
            return paciente;
        }
        public Paciente AtualizarPaciente(Paciente paciente, UpdatePacienteDto novoPaciente)
        {
            Paciente pacienteAlterado = _mapper.Map(novoPaciente, paciente);
            _jomedContext.SaveChanges();
            return pacienteAlterado;
        }
        public Paciente? BuscarPacientePorId(int id)
        {
            return _jomedContext.Pacientes.Where(p => p.Ativo == true).FirstOrDefault(p => p.Id == id);
        }
        public Paciente? BuscarPacienteAtivoOuInativo(int id)
        {
            return _jomedContext.Pacientes.FirstOrDefault(p => p.Id == id);
        }
        public Paciente CadastrarPaciente(CreatePacienteDto pacienteDto)
        {
            Paciente novoPaciente = _mapper.Map<Paciente>(pacienteDto);
            novoPaciente.Ativo = true;
            _jomedContext.Pacientes.Add(novoPaciente);
            _jomedContext.SaveChanges();
            return novoPaciente;
        }
        public bool DeletarPaciente(Paciente paciente)
        {
            try
            {
                _jomedContext.Pacientes.Remove(paciente);
                _jomedContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InativarPaciente(Paciente paciente)
        {
            try
            {
                paciente.Ativo = false;
                _jomedContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Paciente? AtivarPaciente(Paciente paciente)
        {
            paciente.Ativo = true;
            _jomedContext.SaveChanges();
            return paciente;
        }
        public List<Paciente> ListarPacientes()
        {
            return _jomedContext.Pacientes.Where(p => p.Ativo == true).ToList();
        }
    }
}
