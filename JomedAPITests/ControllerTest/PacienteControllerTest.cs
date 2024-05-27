using jomedAPI.Models;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Paciente;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPITests.ServiceProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace JomedAPITests.ControllerTest;

public class PacienteControllerTest
{
    private IPacienteController _pacienteController;
    private ITestOutputHelper _output;

    public PacienteControllerTest(ITestOutputHelper output)
    {
        _pacienteController = new PacienteControllerServiceProvider().AdicionarServico();
        _output = output;
    }

    [Fact]
    public void CadastraPacienteCorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = CriarPaciente();
        Paciente paciente = DeserializarObjeto<Paciente>(resposta);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Paciente>(paciente);
        DeletarPaciente(paciente.Id);
    }
    [Fact]
    public void NaoCadastraPacienteIncorretoCorretoTest()
    {
        //Arrange
        Endereco endereco = new Endereco("", "Com sucesso", "1300-00", "Para", "OS", 1, "Testes");
        CreatePacienteDto paciente = new CreatePacienteDto("", "joseemail.com", "12das900", "145-6235", endereco);
        //Act
        IList<ValidationResult> validaPaciente = ValidarModelo(paciente);
        //Assert
        Assert.NotEmpty(validaPaciente);
    }
    [Fact]
    public void ListarPacientesTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _pacienteController.ListarPacientes();
        List<Paciente> paciente = DeserializarObjeto<List<Paciente>>(resposta);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<List<Paciente>>(paciente);
    }
    [Fact]
    public void BuscarPacientePorIdTest()
    {
        //Arrange
        ObjectResult respostaCriar = CriarPaciente();
        Paciente paciente = DeserializarObjeto<Paciente>(respostaCriar);
        //Act
        ObjectResult resposta = _pacienteController.BuscarPacientePorId(paciente.Id);
        Paciente pacienteBuscado = DeserializarObjeto<Paciente>(resposta);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Paciente>(pacienteBuscado);
        DeletarPaciente(paciente.Id);
    }
    [Fact]
    public void NaoBuscaPacientePorIdIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _pacienteController.BuscarPacientePorId(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Paciente não encontrado.", resposta.Value);
    }
    [Fact]
    public void AlterarPacienteCorretoTest()
    {
        //Arrange
        ObjectResult respostaPaciente = CriarPaciente();
        UpdatePacienteDto pacienteAlterado = new UpdatePacienteDto(nome: "Paciente Alterado", email: "novoEmail@exemple.com");

        Paciente paciente = DeserializarObjeto<Paciente>(respostaPaciente);

        //Act
        ObjectResult resposta = _pacienteController.AtualizarPaciente(paciente.Id, pacienteAlterado);
        Paciente novoPaciente = DeserializarObjeto<Paciente>(resposta);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Equal("Paciente Alterado", novoPaciente.Nome);
        Assert.IsType<Paciente>(novoPaciente);
        DeletarPaciente(paciente.Id);
    }
    [Fact]
    public void NaoAlteraPacienteIncorretoTest()
    {
        //Arrange
        UpdatePacienteDto pacienteAlterado = new UpdatePacienteDto(nome: "Paciente Alterado", email: "novoEmail@exemple.com");
        //Act
        ObjectResult resposta = _pacienteController.AtualizarPaciente(0, pacienteAlterado);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Paciente não encontrado.", resposta.Value);
    }
    [Fact]
    public void AlteraEnderecoPacienteCorretoTest()
    {
        //Arrange
        ObjectResult respostaCriar = CriarPaciente();
        Paciente pacienteCriado = DeserializarObjeto<Paciente>(respostaCriar);
        UpdateEnderecoDto novoEndereco = new UpdateEnderecoDto(cidade: "Vinhedo", uf: "MG");
        //Act
        ObjectResult resposta = _pacienteController.AtualizarEndereco(pacienteCriado.Id, novoEndereco);
        Paciente pacienteAtualizado = DeserializarObjeto<Paciente>(resposta);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Paciente>(pacienteAtualizado);
        Assert.Equal("Vinhedo", pacienteAtualizado.Endereco!.Cidade);
        DeletarPaciente(pacienteCriado.Id);
    }
    [Fact]
    public void NaoAlteraEnderecoIncorretoTest()
    {
        //Arrange
        //Act
        UpdateEnderecoDto novoEndereco = new UpdateEnderecoDto(logradouro: "asd", cep: "1326ade", uf: "1G");
        IList<ValidationResult> resposta = ValidarModelo(novoEndereco);
        //Assert
        Assert.NotEmpty(resposta);
    }
    [Fact]
    public void NaoAlteraEnderecoPacienteIncorretoTest()
    {
        //Arrange
        //Act
        UpdateEnderecoDto novoEndereco = new UpdateEnderecoDto(logradouro: "Rua Alterado", cep: "1373265", uf: "MG");
        var resposta = _pacienteController.AtualizarEndereco(0, novoEndereco);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Paciente não encontrado.", resposta.Value);
    }
    [Fact]
    public void DeletarPacienteCorretoTest()
    {
        //Arrange
        ObjectResult resposta = CriarPaciente();
        Paciente paciente = DeserializarObjeto<Paciente>(resposta);
        ObjectResult respostaDeletar = _pacienteController.DeletarPaciente(paciente.Id);
        //Act
        //Assert
        Assert.Equal(204, respostaDeletar.StatusCode);
        DeletarPaciente(paciente.Id);
    }
    [Fact]
    public void NaoDeletaPacienteIncorretoTest()
    {
        //Arrange
        ObjectResult respostaDeletar = _pacienteController.DeletarPaciente(0);
        //Act
        //Assert
        Assert.Equal(404, respostaDeletar.StatusCode);
        Assert.Equal("Paciente não encontrado.", respostaDeletar.Value);
    }
    [Fact]
    public void InativaPacienteCorretoTest()
    {
        //Arrange
        ObjectResult resposta = CriarPaciente();
        Paciente paciente = DeserializarObjeto<Paciente>(resposta);
        ObjectResult respostaDeletar = _pacienteController.InativarPaciente(paciente.Id);
        //Act
        //Assert
        Assert.Equal(204, respostaDeletar.StatusCode);
    }
    [Fact]
    public void NaoInativaPacienteIncorretoTest()
    {
        //Arrange
        ObjectResult respostaDeletar = _pacienteController.InativarPaciente(0);
        //Act
        //Assert
        Assert.Equal(404, respostaDeletar.StatusCode);
        Assert.Equal("Paciente não encontrado.", respostaDeletar.Value);
    }
    [Fact]
    public void AtivarPacienteCorretoTest()
    {
        //Arrange
        ObjectResult criarPaciente = CriarPaciente();
        Paciente paciente = DeserializarObjeto<Paciente>(criarPaciente);
        //Act
        _ = _pacienteController.InativarPaciente(paciente.Id);
        ObjectResult resposta = _pacienteController.AtivarPaciente(paciente.Id);
        Paciente pacienteAtivo = DeserializarObjeto<Paciente>(resposta);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Paciente>(pacienteAtivo);
        DeletarPaciente(paciente.Id);
    }
    [Fact]
    public void NaoAtivaPacienteJaAtivoTest()
    {
        //Arrange
        ObjectResult criarPaciente = CriarPaciente();
        Paciente paciente = DeserializarObjeto<Paciente>(criarPaciente);
        //Act
        ObjectResult resposta = _pacienteController.AtivarPaciente(paciente.Id);
        //Assert
        Assert.Equal(400, resposta.StatusCode);
        Assert.Equal("Paciente já está ativo.", resposta.Value);
        DeletarPaciente(paciente.Id);
    }
    [Fact]
    public void NaoAtivaPacienteIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _pacienteController.AtivarPaciente(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Paciente não encontrado.", resposta.Value);
    }


    private ObjectResult CriarPaciente()
    {
        Endereco endereco = new Endereco("Endereco criado", "Com sucesso", "13000-000", "Para", "OS", 1, "Testes");
        CreatePacienteDto paciente = new CreatePacienteDto("José Silva", "jose@email.com", "12345678900", "1998245-6235", endereco);
        ObjectResult resposta = _pacienteController.CadastrarPaciente(paciente);
        Paciente pacientecriado = JsonConvert.DeserializeObject<Paciente>(resposta.Value!.ToString()!)!;
        _output.WriteLine($"Paciente {pacientecriado.Id} criado com sucesso.");
        return resposta;
    }
    private void DeletarPaciente(int id)
    {
        _pacienteController.DeletarPaciente(id);
        _output.WriteLine($"Paciente {id} deletado com sucesso.");
    }
    private T DeserializarObjeto<T>(ObjectResult obj)
    {
        T resposta = JsonConvert.DeserializeObject<T>(obj.Value!.ToString()!)!;
        return resposta;
    }
    private IList<ValidationResult> ValidarModelo(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}
