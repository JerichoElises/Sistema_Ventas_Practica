
using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> Lista(string buscar ="");
        Task<string> Crear(Categoria Objeto);
        Task<string> Editar(Categoria Objeto);
    }
}
