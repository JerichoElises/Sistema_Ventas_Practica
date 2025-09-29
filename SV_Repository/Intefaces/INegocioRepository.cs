

using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface INegocioRepository
    {
        Task<Negocio> obtener();
        Task Editar(Negocio Objeto);
    }
}
