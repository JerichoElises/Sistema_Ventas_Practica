
using SV_Repository.Entities;
using SV_Repository.Intefaces;
using SVServices.Interfaces;

namespace SVServices.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriarepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriarepository = categoriaRepository;
        }

        public async Task<List<Categoria>> Lista(string buscar = "")
        {
            return await _categoriarepository.Lista(buscar);
        }

        public async Task<string> Crear(Categoria Objeto)
        {
            return await _categoriarepository.Crear(Objeto);
        }

        public async Task<string> Editar(Categoria Objeto)
        {
            return await _categoriarepository.Editar(Objeto);
        }

        
    }
}
