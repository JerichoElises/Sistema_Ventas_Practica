 using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SV_Repository;
using SV_Repository.Implementation;
using SV_Repository.Intefaces;
using SVPresentation.Formularios;
using SVServices;
using SVServices.Implementation;
using SVServices.Interfaces;


namespace SVPresentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            var formService = host.Services.GetRequiredService<frmReporteVenta>();


            Application.Run(formService);
        }

        static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((Context,config) => {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.RegisterRepositoryDepencies();

                services.RegisterServicesDepencies();

                services.AddTransient<FrmCategoria>();
                services.AddTransient<frmProducto>();
                services.AddTransient<frmNegocio>();
                services.AddTransient<frmUsuario>();
                services.AddTransient<frmVenta>();
                services.AddTransient<frmBuscarProductos>();
                services.AddTransient<frmHistorial>();
                services.AddTransient<frmDetalleVenta1>();
                services.AddTransient<frmReporteVenta>();

                
            });

    }
}