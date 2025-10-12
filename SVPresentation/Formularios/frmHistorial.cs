

using Microsoft.Extensions.DependencyInjection;
using SV_Repository.Entities;
using SVPresentation.Utilidades;
using SVPresentation.ViewModels;
using SVServices.Interfaces;
using System.Threading.Tasks;

namespace SVPresentation.Formularios
{
    public partial class frmHistorial : Form
    {
        private readonly IVentaService _ventaService;
        private readonly IServiceProvider _serviceProvider;
        public frmHistorial(IVentaService ventaService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _serviceProvider = serviceProvider;
        }

        private async Task MostrarVenta()
        {
            var listaVenta = await _ventaService.Lista(
                dtpFechaInicio.Value.ToString("dd/MM/yyyy"),
                dtpFechaFin.Value.ToString("dd/MM/yyyy"),
                txbEncontrar.Text.Trim()
            );

            var listaVM = listaVenta.Select(item => new VentaVM
            {
                FechaRegistro = item.FechaRegistro,
                NumeroVenta = item.NumeroVenta,
                Usuario = item.UsuarioRegistro.NombreUsuario,
                Cliente = item.NombreCliente,
                Total = item.PrecioTotal
            }).ToList();

            dgvVenta.DataSource = listaVM;
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            dgvVenta.ImplementarConfiguracion("ver");
            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarVenta();
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVenta.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var filaSeleccionada = (VentaVM)dgvVenta.CurrentRow.DataBoundItem;

                var _formDetalle = _serviceProvider.GetRequiredService<frmDetalleVenta1>();
                _formDetalle._numeroVenta = filaSeleccionada.NumeroVenta;
                _formDetalle.ShowDialog();

            }
        }
    }
}
