using Microsoft.EntityFrameworkCore;
using Moq;
using SIRE_API._2___Domain.Entities;
using SIRE_API._3___Infrastructure.Data;
using SIRE_API._3___Infrastructure.Repositories;
using Xunit;

namespace SIRE.Tests.InfrastructureTests
{
    public class ConsumoRepositoryTests
    {
        [Fact]
        public void Add_ShouldAddConsumo()
        {
            // Arrange
            var consumo = new Consumo { Id = 1, Nome = "Novo Consumo" };

            // Cria um mock para o DbSet<Consumo>
            var mockSet = new Mock<DbSet<Consumo>>();

            // Cria um mock para o ApplicationDbContext
            var mockContext = new Mock<ApplicationDbContext>();

            // Configura o mock para retornar o mockSet quando Consumos for acessado
            mockContext.Setup(ctx => ctx.Consumos).Returns(mockSet.Object);

            // Passa o mockContext para o ConsumoRepository
            var repository = new ConsumoRepository(mockContext.Object);

            // Act
            repository.Add(consumo);

            // Assert
            mockSet.Verify(set => set.Add(consumo), Times.Once);
            mockContext.Verify(ctx => ctx.SaveChanges(), Times.Once);
        }
    }
}
