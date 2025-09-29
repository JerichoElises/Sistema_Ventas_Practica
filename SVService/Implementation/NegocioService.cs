
using SV_Repository.Entities;
using SV_Repository.Implementation;
using SV_Repository.Intefaces;
using SVServices.Interfaces;

namespace SVServices.Implementation
{
    public class NegocioService : INegocioService
    {
        private readonly INegocioRepository _negocioRepository;
        public NegocioService(INegocioRepository negocioRepository)
        {
            _negocioRepository = negocioRepository;
        }
        public async Task<Negocio> obtener()
        {
            return await _negocioRepository.obtener();
        }

        public async Task Editar(Negocio Objeto)
        {
            await _negocioRepository.Editar(Objeto);
        }

        
    }
}
