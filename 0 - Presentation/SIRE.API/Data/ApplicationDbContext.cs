using Microsoft.EntityFrameworkCore;
using SIRE_API._2___Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    // DbSets that represent database tables
    public DbSet<Dispositivo> Dispositivos { get; set; }
    public DbSet<Relatorio> Relatorios { get; set; }
    public DbSet<Consumo> Consumos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define explicitamente o esquema
        modelBuilder.HasDefaultSchema("RM551096");

    }
}
