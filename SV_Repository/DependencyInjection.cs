using Microsoft.Extensions.DependencyInjection;
using SV_Repository.DB;
using SV_Repository.Implementation;
using SV_Repository.Intefaces;


namespace SV_Repository
{
    public static class DependencyInjection
    {
        public static void RegisterRepositoryDepencies(this IServiceCollection services) {

            services.AddSingleton<Conexion>();

            services.AddTransient<IMedidaRepository, MedidaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<INegocioRepository, NegocioRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IVentaRepository, VentaRepository>();
        }
    }
}
