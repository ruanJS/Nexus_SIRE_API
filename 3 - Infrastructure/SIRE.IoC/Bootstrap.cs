using Microsoft.Extensions.DependencyInjection;
using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._3___Infrastructure.Repositories;

namespace SIRE_API._4___IoC
{
    public static class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registro dos repositórios
            services.AddScoped<IDispositivoRepository, DispositivoRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IConsumoRepository, ConsumoRepository>();

            // Registro dos serviços
            services.AddScoped<DispositivoService>();
            services.AddScoped<RelatorioService>();
            services.AddScoped<ConsumoService>();
        }
    }
}
