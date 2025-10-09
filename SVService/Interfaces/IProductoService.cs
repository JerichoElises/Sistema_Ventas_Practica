
using SV_Repository.Entities;


namespace SVServices.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> Lista(string buscar = "");
        Task<string> Crear(Producto Objeto);
        Task<string> Editar(Producto Objeto);
        Task<Producto> Obtener(string codigo);
    }
}
