using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ControladorFinanceiro.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUsuarioService, UsuarioService>();
            
            return services;
        }
    }
}