using SIRE_API._2___Domain.Entities;
using Xunit;

namespace SIRE.Tests.DomainTests
{
    public class ConsumoTests
    {
        [Fact]
        public void Consumo_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var consumo = new Consumo
            {
                Id = 1,
                Nome = "Teste de Consumo"
            };

            // Act & Assert
            Assert.Equal(1, consumo.Id);
            Assert.Equal("Teste de Consumo", consumo.Nome);
        }
    }
}
