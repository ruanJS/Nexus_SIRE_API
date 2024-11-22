using Moq;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._2___Domain.Entities;
using Xunit;
using NPOI.SS.Formula.Functions;

namespace SIRE.Tests.ApplicationTests
{
    public class ConsumoServiceTests
    {
        private readonly Mock<IConsumoRepository> _mockRepository;
        private readonly ConsumoService _service;

        public ConsumoServiceTests()
        {
            _mockRepository = new Mock<IConsumoRepository>();
            _service = new ConsumoService(_mockRepository.Object);
        }

        [Fact]
        public void GetConsumo_ShouldReturnListOfConsumos()
        {
            // Arrange
            var consumos = new List<Consumo> { new() { Id = 1, Nome = "Test" } };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(consumos);

            // Act
            var result = _service.GetConsumo();

            // Assert
            Assert.NotNull(result);
            Assert.Single((IAsyncEnumerable<T>)result);
        }

        [Fact]
        public void AddConsumo_ShouldCallRepositoryOnce()
        {
            // Arrange
            var consumo = new Consumo { Id = 1, Nome = "Test" };

            // Act
            _service.AddConsumo(consumo);

            // Assert
            _mockRepository.Verify(repo => repo.Add(consumo), Times.Once);
        }
    }
}
