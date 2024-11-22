using SIRE_API._2___Domain.Entities;
using Xunit;

namespace SIRE.Tests.DomainTests
{
    public class DispositivoTests
    {
        [Fact]
        public void Dispositivo_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var dispositivo = new Dispositivo
            {
                Id = 1,
                Nome = "Dispositivo Teste"
            };

            // Act & Assert
            Assert.Equal(1, dispositivo.Id);
            Assert.Equal("Dispositivo Teste", dispositivo.Nome);
        }
    }
}
