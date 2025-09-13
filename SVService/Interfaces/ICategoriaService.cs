using SV_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVServices.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> Lista(string buscar = "");
        Task<string> Crear(Categoria Objeto);
        Task<string> Editar(Categoria Objeto);
    }
}
