
using SV_Repository.Entities;
using SV_Repository.Intefaces;
using SVServices.Interfaces;

namespace SVServices.Implementation
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<Producto>> Lista(string buscar = "")
        {
            return await _productoRepository.Lista(buscar);
        }
        public async Task<string> Crear(Producto Objeto)
        {
            return await _productoRepository.Crear(Objeto);
        }

        public async Task<string> Editar(Producto Objeto)
        {
            return await _productoRepository.Editar(Objeto);
        }

        
    }
}
