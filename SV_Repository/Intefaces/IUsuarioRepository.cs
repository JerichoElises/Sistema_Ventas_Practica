

using SV_Repository.Entities;

namespace SV_Repository.Intefaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Lista(string buscar = "");
        Task<string> Crear(Usuario Objeto);
        Task<string> Editar(Usuario Objeto);
        Task<Usuario> Login(string usuario, string clave);
        Task<int>VerificarCorreo(string correo);
        Task ActualizarClave(int idUsuario, string nuevaClave, int resetear);

    }
}
