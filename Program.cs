using Microsoft.EntityFrameworkCore;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._3___Infrastructure.Data;
using SIRE_API._3___Infrastructure.Repositories;
using SIRE_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do banco de dados com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de Repositórios (Injeção de Dependência)
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<IConsumoRepository, ConsumoRepository>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();

// Registro de Serviços (Injeção de Dependência)
builder.Services.AddScoped<DispositivoService>();
builder.Services.AddScoped<ConsumoService>();

// Testador de Conexão com Banco de Dados
builder.Services.AddSingleton<DatabaseConnectionTester>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var logger = provider.GetRequiredService<ILogger<DatabaseConnectionTester>>();
    return new DatabaseConnectionTester(
        connectionString: configuration.GetConnectionString("DefaultConnection"),
        logger: logger
    );
});

// Construção do App
var app = builder.Build();

// Configuração do Pipeline de execução
if (app.Environment.IsDevelopment())
{
    // Ativando Swagger em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirecionamento para HTTPS
app.UseAuthorization();    // Middleware de autorização
app.MapControllers();      // Mapeamento dos controllers para as rotas

app.Run(); // Executa o aplicativo
