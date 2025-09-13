using SV_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVServices.Interfaces
{
    public interface IMedidaService
    {
        Task<List<Medida>> Lista();
    }
}
