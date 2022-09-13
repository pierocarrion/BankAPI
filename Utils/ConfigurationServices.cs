
using Test_Backend.Services.ClienteService;
using Test_Backend.Repositories.ClienteRepository;
using Test_Backend.Services.CuentaService;
using Test_Backend.Services.MovimientoService;
using Test_Backend.Repositories.CuentaRepository;
using Test_Backend.Repositories.MovimientoRepository;
using Test_Backend.Services.ReporteService;

namespace Test_Backend.Services.Utils
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services)
        {
            ConfigureRepositories(services);
            ConfigureServices(services);
            return services;
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteServiceImpl>();
            services.AddScoped<ICuentaService, CuentaServiceImpl>();
            services.AddScoped<IMovimientoService, MovimientoServiceImpl>();
            services.AddScoped<IReporteService, ReporteServiceImpl>();
        }
        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepositoryImpl>();
            services.AddScoped<ICuentaRepository, CuentaRepositoryImpl>();
            services.AddScoped<IMovimientoRepository, MovimientoRepositoryImpl>();
        }
    }
}
