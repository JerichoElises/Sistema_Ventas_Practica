

namespace SV_Repository.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria refCategoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public int Activo { get; set; }

    }
}
