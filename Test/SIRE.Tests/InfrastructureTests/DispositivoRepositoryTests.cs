using Moq;
using Microsoft.EntityFrameworkCore;
using SIRE_API._2___Domain.Entities;
using SIRE_API._3___Infrastructure.Repositories;
using Xunit;
using SIRE_API._3___Infrastructure.Data;
using NPOI.SS.Formula.Functions;

namespace SIRE.Tests.DispositivoRepositoryTests { 
    public class DispositivoRepositoryTests

    {
        [Fact]
        public async Task AddAsync_ShouldAddDispositivo()
        {
            // Arrange
            var dispositivo = new Dispositivo { Id = 1, Nome = "Novo Dispositivo" };

            // Criando um mock de DbSet
            var mockSet = new Mock<DbSet<Dispositivo>>();

            // Criando um mock de ApplicationContext
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(ctx => ctx.Dispositivos).Returns(mockSet.Object);

            var repository = new DispositivoRepository(mockContext.Object);

            // Act
            await repository.AddAsync(dispositivo);

            // Assert
            mockSet.Verify(set => set.AddAsync(dispositivo, default), Times.Once);
            mockContext.Verify(ctx => ctx.SaveChangesAsync(default), Times.Once);
        }
    }
}
