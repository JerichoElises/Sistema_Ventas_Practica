

using Microsoft.Data.SqlClient;
using SV_Repository.DB;
using SV_Repository.Entities;
using SV_Repository.Intefaces;
using System.Data;

namespace SV_Repository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexion _conexion;
        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<List<Usuario>> Lista(string buscar = "")
        {
            List<Usuario> lista = new List<Usuario>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaUsuario", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {

                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            RefRol = new Rol
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Nombre = dr["NombreRol"].ToString()
                            },
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Activo = Convert.ToInt32(dr["Activo"])
                        });
                    }
                }

            }
            return lista;
        }
        

        public async Task<string> Crear(Usuario Objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();

                var cmd = new SqlCommand("sp_CrearUsuario", con);
                cmd.Parameters.AddWithValue("@IdRol", Objeto.RefRol.IdRol);
                cmd.Parameters.AddWithValue("@NombreCompleto", Objeto.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", Objeto.Correo);
                cmd.Parameters.AddWithValue("@NombreUsuario", Objeto.NombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", Objeto.Clave);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;

                }
                catch
                {
                    respuesta = "Error(rp): no se pudo procesar";
                }

            }
            return respuesta;
        }
        

        public async Task<string> Editar(Usuario Objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();

                var cmd = new SqlCommand("sp_editarUsuario", con);
                cmd.Parameters.AddWithValue("@IdUsuario", Objeto.IdUsuario);
                cmd.Parameters.AddWithValue("@IdRol", Objeto.RefRol.IdRol);
                cmd.Parameters.AddWithValue("@NombreCompleto", Objeto.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", Objeto.Correo);
                cmd.Parameters.AddWithValue("@NombreUsuario", Objeto.NombreUsuario);
                cmd.Parameters.AddWithValue("@Activo", Objeto.Activo);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;

                }
                catch
                {
                    respuesta = "Error(rp): no se pudo procesar";
                }

            }
            return respuesta;
        }
    }  
}

