

using ClosedXML.Excel;
using SV_Repository.Intefaces;
using SVPresentation.Utilidades;
using SVPresentation.ViewModels;
using SVServices.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace SVPresentation.Formularios
{
    public partial class frmReporteVenta : Form
    {
        private readonly IVentaService _ventaService;
        public frmReporteVenta(IVentaService ventaService)
        {
            InitializeComponent();
            _ventaService = ventaService;
        }

        private void frmReporteVenta_Load(object sender, EventArgs e)
        {
            dgvReporte.ImplementarConfiguracion();

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var lista = await _ventaService.Reporte(
                  dtpFechaInicio.Value.ToString("dd/MM/yyyy"),
                  dtpFechaFin.Value.ToString("dd/MM/yyyy")
              );

            var listaVM = lista.Select(item => new ReporteVentaVM
            {
                NumeroVenta = item.RefVenta.NumeroVenta,
                NombreUsuario = item.RefVenta.UsuarioRegistro.NombreUsuario,
                FechaRegistro = item.RefVenta.FechaRegistro,
                Producto = item.RefProducto.Descripcion,
                PrecioCompra = item.RefProducto.PrecioCompra,
                PrecioVenta = item.PrecioVenta,
                Cantidad = item.Cantidad,
                PrecioTotal = item.PrecioTotal
            }).ToList();

            dgvReporte.DataSource = listaVM;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }

            DataTable table = new DataTable();
            List<ReporteVentaVM> detalle = (List<ReporteVentaVM>)dgvReporte.DataSource;

            foreach (DataGridViewColumn column in dgvReporte.Columns)
                table.Columns.Add(column.HeaderText, typeof(string));

            foreach (var item in detalle)
            {
                table.Rows.Add(
                item.NumeroVenta,
                item.NombreUsuario,
                item.FechaRegistro,
                item.Producto,
                item.PrecioCompra,
                item.PrecioVenta,
                item.Cantidad,
                item.PrecioTotal
                );
            }

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.FileName = $"Reporte_Venta_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xlsx";
                saveFile.Filter = "Excel Files|*.xlsx";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(table, "ReporteVenta");  
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte generado correctamente", "Mensaje",MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje",MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
