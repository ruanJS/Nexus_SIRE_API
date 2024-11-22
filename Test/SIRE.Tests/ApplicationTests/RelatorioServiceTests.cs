using Moq;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._1___Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SIRE.Tests.ApplicationTests
{
    public class RelatorioServiceTests
    {
        private readonly Mock<IRelatorioRepository> _mockRepository;
        private readonly RelatorioService _service;

        public RelatorioServiceTests()
        {
            _mockRepository = new Mock<IRelatorioRepository>();
            _service = new RelatorioService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllRelatoriosAsync_ShouldReturnListOfRelatorios()
        {
            var relatorios = new List<Relatorio>
            {
                new() { Id = 1, Titulo = "Relatório 1" },
                new() { Id = 2, Titulo = "Relatório 2" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(relatorios);

            var result = await _service.GetAllRelatoriosAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Use Count() em vez de Count para garantir que estamos contando corretamente.
        }


        [Fact]
        public async Task AddRelatorioAsync_ShouldInvokeRepositoryOnce()
        {
            var relatorio = new Relatorio { Id = 1, Titulo = "Novo Relatório" };

            await _service.AddRelatorioAsync(relatorio);

            _mockRepository.Verify(repo => repo.AddAsync(relatorio), Times.Once);
        }
    }
}
