
using Microsoft.Extensions.DependencyInjection;
using SV_Repository.Implementation;
using SV_Repository.Intefaces;
using SVServices.Implementation;
using SVServices.Interfaces;

namespace SVServices
{
    public static class DependencyInjection
    {
        public static void RegisterServicesDepencies(this IServiceCollection services)
        {
            services.AddTransient<IMedidaService, MedidaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
        }
    }
}
