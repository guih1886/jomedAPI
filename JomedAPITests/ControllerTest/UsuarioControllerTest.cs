using jomedAPI.Models;
using JomedAPI.Data.DTO.Usuario;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPITests.ServiceProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JomedAPITests.ControllerTest
{
    public class UsuarioControllerTest
    {
        private IUsuarioController _usuarioController;

        public UsuarioControllerTest()
        {
            _usuarioController = new UsuarioControllerServiceProvider().AdicionarServico();
        }

        [Fact]
        public void CadastraUsuarioCorretoTest()
        {
            //Arrange
            //Act
            ObjectResult resposta = CriarUsuario();
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(resposta.Value!.ToString()!)!;
            //Assert
            Assert.Equal(200, resposta.StatusCode);
            Assert.IsType<Usuario>(usuario);
            DeletarUsuario(usuario.Id);
        }
        [Fact]
        public void NaoCadastraUsuarioIncorretoTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("", "d3a6", "12345");
            //Act
            var valida = ValidarModelo(novoUsuario);
            //Assert
            Assert.NotEmpty(valida);
        }
        [Fact]
        public void NaoCadastraEmailJaCadastradoTest()
        {
            //Arrange

            //Act
            ObjectResult user = CriarUsuario();
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(user.Value!.ToString()!)!;
            ObjectResult resposta = CriarUsuario();
            //Assert
            Assert.Equal(400, resposta.StatusCode);
            Assert.Equal("Usuário já cadastrado.", resposta.Value);
            DeletarUsuario(usuario.Id);
        }
        [Fact]
        public void NaoDeletaUsuarioIncorreto()
        {
            //Arrange
            //Act
            ObjectResult resposta = _usuarioController.DeletarUsuario(0);
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Usuário não encontrado.", resposta.Value);
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
}
