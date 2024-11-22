using Moq;
using SIRE_API._1___Application.Controllers;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using SIRE_API._0___Presentation.SIRE.API.Controllers;

namespace SIRE_API.Test.SIRE.Tests.RelatorioControllerTests
{
    public class RelatorioControllerTests
    {
        private readonly Mock<IRelatorioRepository> _mockRepository;
        private readonly RelatorioController _controller;

        public RelatorioControllerTests()
        {
            _mockRepository = new Mock<IRelatorioRepository>();
            _controller = new RelatorioController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllRelatorios_ShouldReturnOkResult_WithListOfRelatorios()
        {
            var relatorios = new List<Relatorio>
            {
                new() { Id = 1, Titulo = "Relatório 1" },
                new() { Id = 2, Titulo = "Relatório 2" }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(relatorios);

            var result = await _controller.GetAllRelatoriosAsync();

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Relatorio>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task AddRelatorio_ShouldReturnCreatedAtActionResult_WhenValid()
        {
            var newRelatorio = new Relatorio { Id = 3, Titulo = "Relatório 3" };
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Relatorio>())).Returns(Task.CompletedTask);

            var result = await _controller.AddRelatorio(newRelatorio);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetRelatorio", actionResult.ActionName);  // Certifique-se de que o nome da ação está correto
            Assert.Equal(newRelatorio, actionResult.Value);  // Verifique se o valor retornado é o relatório criado
        }

        [Fact]
        public async Task GetRelatorio_ShouldReturnNotFound_WhenRelatorioNotExists()
        {
            int nonExistentId = 999;

            // Aqui, retornamos explicitamente 'null' para Relatorio?
            _mockRepository.Setup(repo => repo.GetByIdAsync(nonExistentId)).ReturnsAsync((Relatorio?)null);

            var result = await _controller.GetRelatorio(nonExistentId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
