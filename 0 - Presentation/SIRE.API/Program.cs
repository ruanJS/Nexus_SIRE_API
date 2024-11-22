using SIRE_API._1___Application.Services;
using SIRE_API._2___Domain.Interfaces;
using SIRE_API._3___Infrastructure.Repositories;


namespace SIRE_API._0___Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        // Adiciona os serviços necessários para a aplicação
                        services.AddControllers(); // Para habilitar os controllers

                        // Registra o DispositivoService e o repositório no contêiner de DI
                        services.AddScoped<DispositivoService>();
                        services.AddScoped<IDispositivoRepository, DispositivoRepository>();
                    });

                    webBuilder.Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");
                            app.UseHsts();
                        }

                        app.UseHttpsRedirection();
                        app.UseRouting();
                        app.UseAuthorization();

                        // Configura o mapeamento dos controllers
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers(); // Mapeamento correto dos controllers
                        });
                    });
                });
    }
}
