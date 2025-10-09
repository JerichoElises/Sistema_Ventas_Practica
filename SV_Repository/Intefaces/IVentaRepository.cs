
using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface IVentaRepository
    {
        Task<string> Registrar(string ventaXml);
        Task<Venta> Obtener(string numeroVenta);
        Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta);
    }
}
