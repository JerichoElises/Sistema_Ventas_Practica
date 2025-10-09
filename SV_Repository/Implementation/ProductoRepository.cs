
using Microsoft.Data.SqlClient;
using SV_Repository.DB;
using SV_Repository.Entities;
using SV_Repository.Intefaces;
using System.Data;

namespace SV_Repository.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly Conexion _conexion;
        public ProductoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<List<Producto>> Lista(string buscar = "")
        {

            List<Producto> lista = new List<Producto>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaProducto", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {

                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Producto
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            refCategoria = new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Nombre = dr["NombreCategoria"].ToString()
                            },
                            Codigo = dr["Codigo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Activo = Convert.ToInt32(dr["Activo"]),
                        });
                    }
                }

            }
            return lista;
        }
        public async Task<string> Crear(Producto Objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_CrearProducto", con);
                cmd.Parameters.AddWithValue("@IdCategoria", Objeto.refCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Codigo", Objeto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", Objeto.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", Objeto.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", Objeto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad", Objeto.Cantidad);
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
        public async Task<string> Editar(Producto Objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_EditarProducto", con);
                cmd.Parameters.AddWithValue("@IdProducto", Objeto.IdProducto);
                cmd.Parameters.AddWithValue("@IdCategoria", Objeto.refCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Codigo", Objeto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", Objeto.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", Objeto.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", Objeto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad", Objeto.Cantidad);
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

        public async Task<Producto> Obtener(string codigo)
        {
            Producto objeto= new Producto();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerProducto", con);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Producto
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            refCategoria = new Categoria
                            {
                                Nombre = dr["NombreCategoria"].ToString(),
                                RefMedida = new Medida
                                {
                                    Equivalente = dr["Equivalente"].ToString(),
                                    Valor = Convert.ToInt32(dr["Valor"])
                                }
                            },
                            Codigo = dr["Codigo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"])
                        };
                    }
                }

            }
            return objeto;
        }
    }
}
