using Moq;
using SIRE_API._1___Application.DTOs;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Entities;
using SIRE_API._2___Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SIRE.Tests.ConsumoServiceTests
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
        public async Task GetConsumo_ShouldReturnListOfConsumos()
        {
            // Arrange
            var consumos = new List<Consumo>
            {
                new() { Id = 1, Nome = "Consumo 1", Valor = 100, Data = DateTime.Parse("2024-01-01") },
                new() { Id = 2, Nome = "Consumo 2", Valor = 200, Data = DateTime.Parse("2024-01-02") }
            };

            // Mocking da chamada GetAllAsync para retornar a lista de consumos
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(consumos);

            // Act
            var result = await _service.GetAllConsumos();  // Alterado para o método correto que retorna List<ConsumoDTO>

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());  // Verifica o número correto de itens retornados
            Assert.Equal("Consumo 1", result.First().Nome); // Verifica o nome do primeiro consumo
        }

        [Fact]
        public async Task AddConsumo_ShouldInvokeRepositoryOnce()
        {
            // Arrange
            var consumoDTO = new ConsumoDTO { Id = 1, Nome = "Novo Consumo", Valor = 150, Data = DateTime.Parse("2024-01-03") };

            // Mocking da chamada AddAsync para simular uma execução bem-sucedida
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Consumo>())).Returns(Task.CompletedTask);

            // Act
            await _service.AddConsumo(consumoDTO);  // O método AddConsumo agora chama AddAsync no repositório

            // Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Consumo>()), Times.Once);  // Verifica se AddAsync foi chamado uma vez
        }
    }
}
