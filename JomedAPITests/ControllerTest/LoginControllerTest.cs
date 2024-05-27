using jomedAPI.Controllers;
using jomedAPI.Data.DTO.Login;
using jomedAPI.Models;
using JomedAPI.Data.DTO.Usuario;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPITests.ServiceProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JomedAPITests.ControllerTest;

public class LoginControllerTest
{
    private LoginController _controller;
    private IUsuarioController _usuarioController;

    public LoginControllerTest()
    {
        _controller = new LoginControllerServiceProvider().AdicionarServico();
        _usuarioController = new UsuarioControllerServiceProvider().AdicionarServico();
    }

    [Fact]
    public void FazLoginCorretoTest()
    {
        //Assert
        ObjectResult usuario = CriarUsuario();
        Usuario usuarioCriado = JsonConvert.DeserializeObject<Usuario>(usuario.Value!.ToString()!)!;
        LoginDto loginDto = new LoginDto(usuarioCriado.Email, usuarioCriado.Senha);
        //Act
        ObjectResult resposta = _controller.Login(loginDto);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Contains("eyJhbGciOiJIU", resposta.Value!.ToString());
        DeletarUsuario(usuarioCriado.Id);
    }
    [Fact]
    public void NaoFazLoginIncorretoTest()
    {
        //Assert
        LoginDto loginDto = new LoginDto("", "");
        //Act
        IList<ValidationResult> valida = ValidarModelo(loginDto);
        //Assert
        Assert.NotEmpty(valida);
    }
    [Fact]
    public void NaoFazLoginComLoginIncorreto()
    {
        //Assert
        LoginDto loginDto = new LoginDto("dsaefa@email", "12345");
        //Act
        ObjectResult resposta = _controller.Login(loginDto);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Usuário não encontrado.", resposta.Value);
    }
    [Fact]
    public void NaoFazLoginComSenhaIncorretaTest()
    {
        //Assert
        ObjectResult usuario = CriarUsuario();
        Usuario usuarioCriado = JsonConvert.DeserializeObject<Usuario>(usuario.Value!.ToString()!)!;
        LoginDto loginDto = new LoginDto(usuarioCriado.Email, "d6e9af");
        //Act
        ObjectResult resposta = _controller.Login(loginDto);
        //Assert
        Assert.Equal(400, resposta.StatusCode);
        Assert.Equal("Senha incorreta.", resposta.Value);
        DeletarUsuario(usuarioCriado.Id);
    }

    private ObjectResult CriarUsuario()
    {
        CreateUsuarioDto novoUsuario = new CreateUsuarioDto("guilherme@email.com", "12345", "12345");
        ObjectResult resposta = _usuarioController.CadastrarUsuario(novoUsuario);
        return resposta;
    }
    private IList<ValidationResult> ValidarModelo(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
    private void DeletarUsuario(int id)
    {
        _usuarioController.DeletarUsuario(id);
    }
}
