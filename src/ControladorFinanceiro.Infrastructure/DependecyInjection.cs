using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;

using ControladorFinanceiro.Infrastructure.DB;
using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Infrastructure.Repositories;

namespace ControladorFinanceiro.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ControladorFinanceiroDB");
            services.AddDbContext<BDContext>(options =>
                    options.UseNpgsql(connectionString));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            return services;
        }
    }
}