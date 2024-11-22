using Microsoft.EntityFrameworkCore;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._3___Infrastructure.Data;
using SIRE_API._3___Infrastructure.Repositories;
using SIRE_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura��o dos Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do banco de dados com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de Reposit�rios (Inje��o de Depend�ncia)
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<IConsumoRepository, ConsumoRepository>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();

// Registro de Servi�os (Inje��o de Depend�ncia)
builder.Services.AddScoped<DispositivoService>();
builder.Services.AddScoped<ConsumoService>();

// Testador de Conex�o com Banco de Dados
builder.Services.AddSingleton<DatabaseConnectionTester>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var logger = provider.GetRequiredService<ILogger<DatabaseConnectionTester>>();
    return new DatabaseConnectionTester(
        connectionString: configuration.GetConnectionString("DefaultConnection"),
        logger: logger
    );
});

// Constru��o do App
var app = builder.Build();

// Configura��o do Pipeline de execu��o
if (app.Environment.IsDevelopment())
{
    // Ativando Swagger em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirecionamento para HTTPS
app.UseAuthorization();    // Middleware de autoriza��o
app.MapControllers();      // Mapeamento dos controllers para as rotas

app.Run(); // Executa o aplicativo
