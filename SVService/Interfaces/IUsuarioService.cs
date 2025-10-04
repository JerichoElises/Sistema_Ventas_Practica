
using SV_Repository.Entities;

namespace SVServices.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> Lista(string buscar = "");
        Task<string> Crear(Usuario Objeto);
        Task<string> Editar(Usuario Objeto);
    }
}
