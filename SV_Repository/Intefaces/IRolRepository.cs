
using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> Lista();
    }
}
