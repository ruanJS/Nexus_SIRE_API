using Moq;
using SIRE_API._1___Application.Controllers;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using SIRE_API._0___Presentation.SIRE.API.Controllers;

namespace SIRE_API.Test.SIRE.Tests.ApplicationTests
{
    public class RelatorioControllerTests
    {
        private readonly Mock<IRelatorioRepository> _mockRepository;
        private readonly RelatorioController _controller;

        public RelatorioControllerTests()
        {
            // Mock do repositório
            _mockRepository = new Mock<IRelatorioRepository>();
            // Instanciando o controlador
            _controller = new RelatorioController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllRelatorios_ShouldReturnOkResult_WithListOfRelatorios()
        {
            // Arrange: Lista de relatórios mockada
            var relatorios = new List<Relatorio>
            {
                new Relatorio { Id = 1, Titulo = "Relatório 1" },
                new Relatorio { Id = 2, Titulo = "Relatório 2" }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(relatorios);

            // Act: Chama o método GetAllRelatorios
            var result = await _controller.GetAllRelatoriosAsync();

            // Assert: Verifica se o retorno é um OkResult com a lista de relatórios
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Relatorio>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task AddRelatorio_ShouldReturnCreatedAtActionResult_WhenValid()
        {
            // Arrange: Relatório a ser adicionado
            var newRelatorio = new Relatorio { Id = 3, Titulo = "Relatório 3" };
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Relatorio>())).Returns(Task.CompletedTask);

            // Act: Chama o método AddRelatorio
            var result = await _controller.AddRelatorio(newRelatorio);

            // Assert: Verifica se o retorno é um CreatedAtActionResult
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetRelatorio", actionResult.ActionName);  // Verifique se o nome da ação está correto
            Assert.Equal(newRelatorio, actionResult.Value);  // Verifique se o valor retornado é o relatório criado
        }

        [Fact]
        public async Task GetRelatorio_ShouldReturnNotFound_WhenRelatorioNotExists()
        {
            // Arrange: Relatório com ID que não existe no repositório
            int nonExistentId = 999;
            _mockRepository.Setup(repo => repo.GetByIdAsync(nonExistentId)).ReturnsAsync((Relatorio)null);

            // Act: Chama o método GetRelatorio
            var result = await _controller.GetRelatorio(nonExistentId);

            // Assert: Verifica se o retorno é um NotFoundResult
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

