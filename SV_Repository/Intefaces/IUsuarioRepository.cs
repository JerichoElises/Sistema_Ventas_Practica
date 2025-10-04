

using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Lista(string buscar = "");
        Task<string> Crear(Usuario Objeto);
        Task<string> Editar(Usuario Objeto);
    }
}
