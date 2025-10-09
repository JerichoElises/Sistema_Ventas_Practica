using SV_Repository.Entities;

namespace SVServices.Interfaces
{
    public interface IVentaService
    {
        Task<string> Registrar(string ventaXml);
        Task<Venta> Obtener(string numeroVenta);
        Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta);
    }
}
