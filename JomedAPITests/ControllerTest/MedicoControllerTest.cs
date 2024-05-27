using jomedAPI.Models;
using jomedAPI.Models.Enum;
using JomedAPI.Data.DTO.Enderecos;
using JomedAPI.Data.DTO.Medico;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPITests.ServiceProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace JomedAPITests.ControllerTest;

public class MedicoControllerTest
{
    private IMedicoController _medicoController;
    private ITestOutputHelper _outputHelper;

    public MedicoControllerTest(ITestOutputHelper outputHelper)
    {
        _medicoController = new MedicoControllerServiceProvider().AdicionarServico();
        _outputHelper = outputHelper;
    }

    [Fact]
    public void CadastraMedicoCorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(resposta.Value!.ToString()!)!;
        //Asert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Medico>(medico);
        DeletarMedico(medico);
    }
    [Fact]
    public void NaoCadastraMedicoIncorretoTest()
    {
        //Arrange
        Endereco endereco = new Endereco("", "", "12-106", "", "h3", 1, "");
        CreateMedicoDto medicoDto = new CreateMedicoDto("", "guilheemail.com", "1365dad", "", Especialidade.CARDIOLOGIA, endereco);
        IList<ValidationResult> medicoDtoResult = ValidarModelo(medicoDto);
        IList<ValidationResult> enderecoResult = ValidarModelo(endereco);
        //Act
        //Asert
        Assert.NotEmpty(medicoDtoResult);
        Assert.NotEmpty(enderecoResult);
    }
    [Fact]
    public void AtualizaEnderecoCorretoTest()
    {
        //Arrange
        ObjectResult medicoResult = CriarMedico();
        Medico medicoCriado = JsonConvert.DeserializeObject<Medico>(medicoResult.Value!.ToString()!)!;
        UpdateEnderecoDto endereco = new UpdateEnderecoDto("Rua Alterada", "Bairro Alterado", "13000-000", "Campinas", "SP", 1, "");
        IList<ValidationResult> validaEndereco = ValidarModelo(endereco);
        //Act
        ObjectResult resposta = _medicoController.AtualizarEndereco(medicoCriado.Id, endereco);
        Medico medico = JsonConvert.DeserializeObject<Medico>(resposta.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Equal("Rua Alterada", medico.Endereco.Logradouro);
        Assert.Empty(validaEndereco);
        Assert.IsType<Medico>(medico);
        DeletarMedico(medicoCriado);
    }
    [Fact]
    public void NaoAtualizaEnderecoIncorretoTest()
    {
        //Arrange
        UpdateEnderecoDto endereco = new UpdateEnderecoDto("", "", "000-0", "Campinas", "SPG", 1, "");
        IList<ValidationResult> validaEndereco = ValidarModelo(endereco);
        //Act
        //Assert
        Assert.NotEmpty(validaEndereco);
    }
    [Fact]
    public void NaoAtualizaEnderecoMedicoIncorretoTest()
    {
        //Arrange
        UpdateEnderecoDto endereco = new UpdateEnderecoDto("", "", "000-0", "Campinas", "SPG", 1, "");
        //Act
        ObjectResult resposta = _medicoController.AtualizarEndereco(0, endereco);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
    }
    [Fact]
    public void ListarMedicosTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _medicoController.ListarMedicos();
        List<Medico> medicos = JsonConvert.DeserializeObject<List<Medico>>(resposta.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<List<Medico>>(medicos);
    }
    [Fact]
    public void BuscaMedicoPorIdTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(resposta.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Medico>(medico);
        DeletarMedico(medico);
    }
    [Fact]
    public void NaoBuscaMedicoPorIdIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _medicoController.BuscarMedicoPorId(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
    }
    [Fact]
    public void AlterarMedicoTest()
    {
        //Arrange
        ObjectResult criarMedico = CriarMedico();
        Medico medicoCriado = JsonConvert.DeserializeObject<Medico>(criarMedico.Value!.ToString()!)!;
        UpdateMedicoDto medicoAlterado = new UpdateMedicoDto(nome: "Medico Alterado", crm: "13265");
        //Act
        ObjectResult resposta = _medicoController.AtualizarMedico(medicoCriado.Id, medicoAlterado);
        Medico medicoAlteradoMed = JsonConvert.DeserializeObject<Medico>(resposta.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Equal("Medico Alterado", medicoAlteradoMed.Nome);
        Assert.IsType<Medico>(medicoAlteradoMed);
        DeletarMedico(medicoCriado);
    }
    [Fact]
    public void NaoAlteraMedicoIncorretoTest()
    {
        //Arrange
        UpdateMedicoDto medicoAlterado = new UpdateMedicoDto(nome: "Medico Alterado", crm: "13265");
        //Act
        ObjectResult resposta = _medicoController.AtualizarMedico(0, medicoAlterado);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
    }
    [Fact]
    public void DeletarMedicoTest()
    {
        //Arrange
        ObjectResult respostaMedico = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(respostaMedico.Value!.ToString()!)!;
        //Act
        ObjectResult resposta = _medicoController.DeletarMedico(medico.Id);
        //Assert
        Assert.Equal(204, resposta.StatusCode);
        DeletarMedico(medico);
    }
    [Fact]
    public void NaoDeletaMedicoIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _medicoController.DeletarMedico(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
    }
    [Fact]
    public void InativarMedicoTest()
    {
        //Arrange
        ObjectResult respostaMedico = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(respostaMedico.Value!.ToString()!)!;
        //Act
        ObjectResult resposta = _medicoController.InativarMedico(medico.Id);
        //Assert
        Assert.Equal(204, resposta.StatusCode);
        DeletarMedico(medico);
    }
    [Fact]
    public void NaoInativaMedicoIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _medicoController.InativarMedico(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
    }
    [Fact]
    public void NaoInativaMedicoJaInativoTest()
    {
        //Arrange
        ObjectResult respostaMedico = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(respostaMedico.Value!.ToString()!)!;
        //Act
        _medicoController.InativarMedico(medico.Id);
        ObjectResult resposta = _medicoController.InativarMedico(medico.Id);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
        DeletarMedico(medico);
    }
    [Fact]
    public void AtivaMedicoCorretoTest()
    {
        //Arrange
        ObjectResult criarResposta = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(criarResposta.Value!.ToString()!)!;
        //Act
        _ = _medicoController.InativarMedico(medico.Id);
        ObjectResult resposta = _medicoController.AtivarMedico(medico.Id);
        Medico medicoAtivo = JsonConvert.DeserializeObject<Medico>(resposta.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<Medico>(medicoAtivo);
        DeletarMedico(medico);
    }
    [Fact]
    public void NaoAtivaMedicoJaAtivoTest()
    {
        //Arrange
        ObjectResult criarResposta = CriarMedico();
        Medico medico = JsonConvert.DeserializeObject<Medico>(criarResposta.Value!.ToString()!)!;
        //Act
        ObjectResult resposta = _medicoController.AtivarMedico(medico.Id);
        //Assert
        Assert.Equal(400, resposta.StatusCode);
        Assert.Equal("Médico já está ativo.", resposta.Value);
        DeletarMedico(medico);
    }
    [Fact]
    public void NaoAtivaMedicoIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _medicoController.AtivarMedico(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Médico não encontrado.", resposta.Value);
    }

    private ObjectResult CriarMedico()
    {
        Endereco endereco = new Endereco("Rua Vitório Randi", "Jardim Alto da Boa Vista", "13272-106", "Valinhos", "SP", 106, "sem complemento");
        CreateMedicoDto medicoDto = new CreateMedicoDto("Guilherme", "guilherme@email.com", "1998221-0064", "123456", Especialidade.CARDIOLOGIA, endereco);
        //Act
        ObjectResult resposta = _medicoController.CadastrarMedico(medicoDto);
        Medico medico = JsonConvert.DeserializeObject<Medico>(resposta.Value!.ToString()!)!;
        _outputHelper.WriteLine($"Médico {medico.Id} criado com sucesso.");
        return resposta;
    }
    private void DeletarMedico(Medico medico)
    {
        _medicoController.DeletarMedico(medico.Id);
        _outputHelper.WriteLine($"Médico {medico.Id} deletado com sucesso.");
    }
    private IList<ValidationResult> ValidarModelo(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}
