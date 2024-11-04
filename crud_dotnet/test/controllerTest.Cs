using Xunit;
using Microsoft.AspNetCore.Mvc;
using crud_dotnet.Controllers;
using crud_dotnet.Services;
using Moq;
using crud_dotnet.Interface;
using crud_dotnet.entitys;

namespace crud_dotnet.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserServices> _userServicesMock;

        public UserControllerTests()
        {
            _userServicesMock = new Mock<IUserServices>();
        }

        [Fact]
        public async Task CreateUserAsync_RetornaOkResult_QuandoModelStateEhValido()
        {
            // Arrange
            var request = new CreateUserRequest();
            var controller = new UserController(_userServicesMock.Object);
            controller.ModelState.AddModelError("FakeError", "FakeErrorMessage");

            // Act
            var resultado = await controller.CreateUserAsync(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task CreateUserAsync_RetornaOkResult_QuandoModelStateEhValidoEServicoCriaUsuarioComSucesso()
        {
            // Arrange
            var request = new CreateUserRequest();
            _userServicesMock.Setup(s => s.CreateUserAsync(request)).Returns(Task.FromResult(true));
            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.CreateUserAsync(request);

            // Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task CreateUserAsync_RetornaInternalServerError_QuandoServicoLancaExcecao()
        {
            // Arrange
            var request = new CreateUserRequest();
            _userServicesMock.Setup(s => s.CreateUserAsync(request)).Throws<Exception>();
            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.CreateUserAsync(request);

            // Assert
            Assert.IsType<ObjectResult>(resultado);
            Assert.Equal(500, ((ObjectResult)resultado).StatusCode);
        }

        [Fact]
        public async Task GetAllAsync_RetornaOkResult_QuandoServicoRetornaUsuarios()
        {
            // Arrange
            var usuarios = new List<User>();
            _userServicesMock.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<User>
            {
                new User { Id = Guid.NewGuid(), Nome = "Usuario 1" },
                new User { Id = Guid.NewGuid(), Nome = "Usuario 2" }
            });
            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task GetAllAsync_RetornaOkResult_QuandoServicoRetornaUsuariosVazios()
        {
            // Arrange
            var usuarios = new List<User>();
            _userServicesMock.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<User>());
            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task GetAllAsync_RetornaInternalServerError_QuandoServicoLancaExcecao()
        {
            // Arrange
            _userServicesMock.Setup(s => s.GetAllAsync()).Throws<Exception>();
            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.GetAllAsync();

            // Assert
            Assert.IsType<ObjectResult>(resultado);
            Assert.Equal(500, ((ObjectResult)resultado).StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_RetornaOkResult_QuandoServicoRetornaUsuario()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var usuario = new User { Id = usuarioId, Nome = "Usuario 1" };

            _userServicesMock.Setup(s => s.GetByIdAsync(usuarioId)).ReturnsAsync(usuario);

            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.GetByIdAsync(usuarioId);

            // Assert
            Assert.IsType<OkObjectResult>(resultado);
            var okResultado = (OkObjectResult)resultado;
            Assert.NotNull(okResultado.Value);
            var usuarioRetornado = (User)okResultado.Value;
            Assert.Equal(usuarioId, usuarioRetornado.Id);
            Assert.Equal("Usuario 1", usuarioRetornado.Nome);
        }

        [Fact]
        public async Task GetByIdAsync_RetornaNotFoundResult_QuandoServicoNaoRetornaUsuario()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();

            _userServicesMock.Setup(s => s.GetByIdAsync(usuarioId)).ReturnsAsync((User)null);

            var controller = new UserController(_userServicesMock.Object);

            // Act
            var resultado = await controller.GetByIdAsync(usuarioId);
        }
    }
}

// Assertdotnet test
