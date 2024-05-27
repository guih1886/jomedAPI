using jomedAPI.Models;
using JomedAPI.Data.DTO.Medico;
using jomedAPI.Models.Enum;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPITests.ServiceProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JomedAPI.Data.DTO.Paciente;
using JomedAPI.Data.DTO.Consulta;

namespace JomedAPITests.ControllerTest
{
    public class ConsultaControllerTest
    {
        private IConsultaController _consultaController;
        private IMedicoController _medicoController;
        private IPacienteController _pacienteController;

        public ConsultaControllerTest()
        {
            _consultaController = new ConsultaControllerServiceProvider().AdicionarServico();
            _medicoController = new MedicoControllerServiceProvider().AdicionarServico();
            _pacienteController = new PacienteControllerServiceProvider().AdicionarServico();
        }

        [Fact]
        public void CadastrarConsultaCorretoTest()
        {
            //Arrange
            //Act
            ObjectResult resposta = CriarConsulta();
            ReadConsultaDto consulta = JsonConvert.DeserializeObject<ReadConsultaDto>(resposta.Value!.ToString()!)!;
            //Assert
            Assert.Equal(200, resposta.StatusCode);
            Assert.IsType<ReadConsultaDto>(consulta);
            DeletarConsulta(consulta);
        }
        [Fact]
        public void NaoCadastraConsultaComDataDoPassadoTest()
        {
            //Arrange
            Endereco endereco = new Endereco("Rua Vitório Randi", "Jardim Alto da Boa Vista", "13272-106", "Valinhos", "SP", 106, "sem complemento");
            CreateMedicoDto medicoDto = new CreateMedicoDto("Guilherme", "guilherme@email.com", "1998221-0064", "123456", Especialidade.CARDIOLOGIA, endereco);
            ObjectResult criarMedico = _medicoController.CadastrarMedico(medicoDto);
            Medico medico = JsonConvert.DeserializeObject<Medico>(criarMedico.Value!.ToString()!)!;
            CreatePacienteDto pacienteDto = new CreatePacienteDto("José Silva", "jose@email.com", "12345678900", "1998245-6235", endereco);
            ObjectResult criarPaciente = _pacienteController.CadastrarPaciente(pacienteDto);
            Paciente paciente = JsonConvert.DeserializeObject<Paciente>(criarPaciente.Value!.ToString()!)!;
            CreateConsultaDto consulta = new CreateConsultaDto(medico.Id, paciente.Id, DateTime.Now);
            //Act
            ObjectResult resposta = _consultaController.CadastrarConsulta(consulta);
            //Assert
            Assert.Equal(400, resposta.StatusCode);
            Assert.Equal("A data deve ser futura.", resposta.Value);
            _medicoController.DeletarMedico(consulta.MedicoId);
            _pacienteController.DeletarPaciente(consulta.PacienteId);
        }
        [Fact]
        public void NaoCadastraConsultaComMedicoIncorretoTest()
        {
            //Arrange
            CreateConsultaDto consulta = new CreateConsultaDto(0, 0, DateTime.Now);
            //Act
            ObjectResult resposta = _consultaController.CadastrarConsulta(consulta);
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Médico não encontrado.", resposta.Value);
        }
        [Fact]
        public void NaoCadastraConsultaComPacienteIncorretoTest()
        {
            //Arrange
            Endereco endereco = new Endereco("Rua Vitório Randi", "Jardim Alto da Boa Vista", "13272-106", "Valinhos", "SP", 106, "sem complemento");
            CreateMedicoDto medicoDto = new CreateMedicoDto("Guilherme", "guilherme@email.com", "1998221-0064", "123456", Especialidade.CARDIOLOGIA, endereco);
            ObjectResult criarMedico = _medicoController.CadastrarMedico(medicoDto);
            Medico medico = JsonConvert.DeserializeObject<Medico>(criarMedico.Value!.ToString()!)!;
            CreateConsultaDto consulta = new CreateConsultaDto(medico.Id, 0, DateTime.Now);
            //Act
            ObjectResult resposta = _consultaController.CadastrarConsulta(consulta);
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Paciente não encontrado.", resposta.Value);
            _medicoController.DeletarMedico(medico.Id);
        }
        [Fact]
        public void NaoCadastraConsultaComDataForaDoHorarioTest()
        {
            //Arrange
            Endereco endereco = new Endereco("Rua Vitório Randi", "Jardim Alto da Boa Vista", "13272-106", "Valinhos", "SP", 106, "sem complemento");
            CreateMedicoDto medicoDto = new CreateMedicoDto("Guilherme", "guilherme@email.com", "1998221-0064", "123456", Especialidade.CARDIOLOGIA, endereco);
            ObjectResult criarMedico = _medicoController.CadastrarMedico(medicoDto);
            Medico medico = JsonConvert.DeserializeObject<Medico>(criarMedico.Value!.ToString()!)!;
            //Paciente
            CreatePacienteDto pacienteDto = new CreatePacienteDto("José Silva", "jose@email.com", "12345678900", "1998245-6235", endereco);
            ObjectResult criarPaciente = _pacienteController.CadastrarPaciente(pacienteDto);
            Paciente paciente = JsonConvert.DeserializeObject<Paciente>(criarPaciente.Value!.ToString()!)!;
            DateTime dataInvalida = DateTime.Parse("2044-05-27T19:00:58.000Z").ToUniversalTime();
            //Act
            CreateConsultaDto consulta = new CreateConsultaDto(medico.Id, paciente.Id, dataInvalida);
            ObjectResult resposta = _consultaController.CadastrarConsulta(consulta);
            //Assert
            Assert.Equal(400, resposta.StatusCode);
            Assert.Equal("A data deve ser um dia da semana entre as 7h e 18h", resposta.Value);
            _medicoController.DeletarMedico(medico.Id);
            _pacienteController.DeletarPaciente(paciente.Id);
        }
        [Fact]
        public void NaoCadastraConsultaComODiaForaDoHorarioTest()
        {
            //Arrange
            Endereco endereco = new Endereco("Rua Vitório Randi", "Jardim Alto da Boa Vista", "13272-106", "Valinhos", "SP", 106, "sem complemento");
            CreateMedicoDto medicoDto = new CreateMedicoDto("Guilherme", "guilherme@email.com", "1998221-0064", "123456", Especialidade.CARDIOLOGIA, endereco);
            ObjectResult criarMedico = _medicoController.CadastrarMedico(medicoDto);
            Medico medico = JsonConvert.DeserializeObject<Medico>(criarMedico.Value!.ToString()!)!;
            //Paciente
            CreatePacienteDto pacienteDto = new CreatePacienteDto("José Silva", "jose@email.com", "12345678900", "1998245-6235", endereco);
            ObjectResult criarPaciente = _pacienteController.CadastrarPaciente(pacienteDto);
            Paciente paciente = JsonConvert.DeserializeObject<Paciente>(criarPaciente.Value!.ToString()!)!;
            //Data será um domingo
            DateTime dataInvalida = DateTime.Parse("2044-05-28T10:00:58.000Z").ToUniversalTime();
            //Act
            CreateConsultaDto consulta = new CreateConsultaDto(medico.Id, paciente.Id, dataInvalida);
            ObjectResult resposta = _consultaController.CadastrarConsulta(consulta);
            //Assert
            Assert.Equal(400, resposta.StatusCode);
            Assert.Equal("A data deve ser um dia da semana entre as 7h e 18h", resposta.Value);
            _medicoController.DeletarMedico(medico.Id);
            _pacienteController.DeletarPaciente(paciente.Id);
        }
        [Fact]
        public void BuscaConsultasTest()
        {
            //Arrange
            //Act
            ObjectResult resposta = _consultaController.BuscarConsultas();
            List<ReadConsultaDto> consultas = JsonConvert.DeserializeObject<List<ReadConsultaDto>>(resposta.Value!.ToString()!)!;
            //Assert
            Assert.Equal(200, resposta.StatusCode);
            Assert.IsType<List<ReadConsultaDto>>(consultas);
        }
        [Fact]
        public void DeletarConsultaCorreto()
        {
            //Arrange
            ObjectResult criarResposta = CriarConsulta();
            DeleteConsultaDto motivo = new DeleteConsultaDto(MotivoCancelamento.OUTROS);
            ReadConsultaDto consulta = JsonConvert.DeserializeObject<ReadConsultaDto>(criarResposta.Value!.ToString()!)!;
            //Act
            ObjectResult resposta = _consultaController.DeletarConsulta(consulta.Id, motivo);
            //Assert
            Assert.Equal(204, resposta.StatusCode);
            DeletarConsulta(consulta);
        }
        [Fact]
        public void DeletarConsultaIncorreto()
        {
            //Arrange
            DeleteConsultaDto motivo = new DeleteConsultaDto(MotivoCancelamento.OUTROS);
            //Act
            ObjectResult resposta = _consultaController.DeletarConsulta(0, motivo);
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Consulta não encontrada.", resposta.Value);
        }


        private ObjectResult CriarConsulta()
        {
            //Criações
            //Médico
            Endereco endereco = new Endereco("Rua Vitório Randi", "Jardim Alto da Boa Vista", "13272-106", "Valinhos", "SP", 106, "sem complemento");
            CreateMedicoDto medicoDto = new CreateMedicoDto("Guilherme", "guilherme@email.com", "1998221-0064", "123456", Especialidade.CARDIOLOGIA, endereco);
            ObjectResult criarMedico = _medicoController.CadastrarMedico(medicoDto);
            Medico medico = JsonConvert.DeserializeObject<Medico>(criarMedico.Value!.ToString()!)!;
            //Paciente
            CreatePacienteDto pacienteDto = new CreatePacienteDto("José Silva", "jose@email.com", "12345678900", "1998245-6235", endereco);
            ObjectResult criarPaciente = _pacienteController.CadastrarPaciente(pacienteDto);
            Paciente paciente = JsonConvert.DeserializeObject<Paciente>(criarPaciente.Value!.ToString()!)!;
            //Consulta
            CreateConsultaDto consulta = new CreateConsultaDto(medico.Id, paciente.Id, DateTime.Now.AddDays(1));
            ObjectResult resposta = _consultaController.CadastrarConsulta(consulta);
            return resposta;
        }
        private void DeletarConsulta(ReadConsultaDto consulta)
        {
            DeleteConsultaDto motivo = new DeleteConsultaDto(MotivoCancelamento.OUTROS);
            _medicoController.DeletarMedico(consulta.MedicoId);
            _pacienteController.DeletarPaciente(consulta.PacienteId);
            _consultaController.DeletarConsulta(consulta.Id, motivo);
        }
    }
}
