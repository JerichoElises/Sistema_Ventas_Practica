

using Microsoft.Data.SqlClient;
using SV_Repository.DB;
using SV_Repository.Entities;
using SV_Repository.Intefaces;
using System.Data;

namespace SV_Repository.Implementation
{
    public class NegocioRepository : INegocioRepository
    {
        private readonly Conexion _conexion;
        public NegocioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<Negocio> obtener()
        {
            Negocio objeto = new Negocio();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerNegocio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Negocio()
                        {
                            RazonSocial = dr["RazonSocial"].ToString(),
                            RUC = dr["RUC"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Celular = dr["Celular"].ToString(),
                            Correo  = dr["Correo"].ToString(),
                            SimboloMoneda = dr["SimboloMoneda"].ToString(),
                            NombreLogo = dr["NombreLogo"].ToString(),
                            UrlLogo = dr["UrlLogo"].ToString(),

                        };
                    }
                }

            }
            return objeto;
        }
        public async Task Editar(Negocio Objeto)
        {
          

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();

                var cmd = new SqlCommand("sp_editarNegocio", con);
                cmd.Parameters.AddWithValue("@RazonSocial", Objeto.RazonSocial);
                cmd.Parameters.AddWithValue("@Ruc", Objeto.RUC);
                cmd.Parameters.AddWithValue("@Direccion", Objeto.Direccion);
                cmd.Parameters.AddWithValue("@Celular", Objeto.Celular);
                cmd.Parameters.AddWithValue("@Correo", Objeto.Correo);
                cmd.Parameters.AddWithValue("@SimboloMoneda", Objeto.SimboloMoneda);
                cmd.Parameters.AddWithValue("@NombreLogo", Objeto.NombreLogo);
                cmd.Parameters.AddWithValue("@UrlLogo", Objeto.UrlLogo);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch
                {
                    throw;
                }

            }
        }

        
    }
}
