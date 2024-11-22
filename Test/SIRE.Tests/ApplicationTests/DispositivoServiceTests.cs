using Moq;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIRE.Tests.ApplicationTests
{
    public class DispositivoServiceTests
    {
        private readonly Mock<IDispositivoRepository> _mockRepository;
        private readonly DispositivoService _service;

        public DispositivoServiceTests()
        {
            _mockRepository = new Mock<IDispositivoRepository>();
            _service = new DispositivoService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetDispositivo_ShouldReturnListOfDispositivos()
        {
            // Arrange
            var dispositivos = new List<Dispositivo>
            {
                new() { Id = 1, Nome = "Dispositivo 1" },
                new() { Id = 2, Nome = "Dispositivo 2" }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(dispositivos);

            // Act
            var result = await _service.GetDispositivo();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AddDispositivo_ShouldInvokeRepositoryOnce()
        {
            // Arrange
            var dispositivo = new Dispositivo { Id = 1, Nome = "Novo Dispositivo" };

            // Act
            await _service.AddDispositivo(dispositivo);

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(dispositivo), Times.Once);
        }
    }
}
