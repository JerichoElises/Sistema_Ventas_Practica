using SV_Repository.Entities;


namespace SV_Repository.Intefaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> Lista(string buscar = "");
        Task<string> Crear(Producto Objeto);
        Task<string> Editar(Producto Objeto);

    }
}
