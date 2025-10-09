
using SV_Repository.Entities;
using SV_Repository.Intefaces;
using SVServices.Interfaces;

namespace SVServices.Implementation
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }
        public async Task<string> Registrar(string ventaXml)
        {
            return await _ventaRepository.Registrar(ventaXml);
        }
        public async Task<Venta> Obtener(string numeroVenta)
        {
           return await _ventaRepository.Obtener(numeroVenta);
        }

        public async Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta)
        {
           return await _ventaRepository.ObtenerDetalle(numeroVenta);
        }

        
    }
}
