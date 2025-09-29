
using SV_Repository.Entities;

namespace SVServices.Interfaces
{
    public interface INegocioService
    {
        Task<Negocio> obtener();
        Task Editar(Negocio Objeto);
    }
}
