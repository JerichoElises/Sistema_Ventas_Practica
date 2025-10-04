

using SV_Repository.Entities;
using SV_Repository.Intefaces;
using SVServices.Interfaces;

namespace SVServices.Implementation
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public Task<List<Rol>> Lista()
        {
            return _rolRepository.Lista();
        }
    }
}
