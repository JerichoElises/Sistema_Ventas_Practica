
using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface IMedidaRepository
    {
       Task<List<Medida>> Lista();
    }
}
