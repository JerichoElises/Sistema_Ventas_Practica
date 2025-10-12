
using SVPresentation.Utilidades;
using SVPresentation.ViewModels;
using SVServices.Interfaces;
using System.Diagnostics;

namespace SVPresentation.Formularios
{
    public partial class frmDetalleVenta1 : Form
    {
        private readonly IVentaService _ventaService;
        private readonly INegocioService _negocioService;
        public string _numeroVenta { get; set; } = null!;
        public frmDetalleVenta1(IVentaService ventaService, INegocioService negocioService)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _negocioService = negocioService;
        }

        private async void frmDetalleVenta1_Load(object sender, EventArgs e)
        {
            dgvDetalleVenta.ImplementarConfiguracion();
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var detalleVenta = await _ventaService.ObtenerDetalle(_numeroVenta);

            var listaVM = detalleVenta.Select(item => new DetalleVentaVM
            {
                Producto = item.RefProducto.Descripcion,
                Precio = item.PrecioVenta,
                CantidadTexto = string.Concat(item.Cantidad, " ", item.RefProducto.refCategoria.RefMedida.Equivalente),
                Total = item.PrecioTotal
            }).ToList();

            lblNumeroVenta.Text = _numeroVenta;

            dgvDetalleVenta.DataSource = listaVM;
            dgvDetalleVenta.Columns["IdProducto"].Visible = false;
            dgvDetalleVenta.Columns["CantidadValor"].Visible = false;

        }

        private async void btnVerPDF_Click(object sender, EventArgs e)
        {
            var oNegocio = await _negocioService.obtener();
            var oVenta = await _ventaService.Obtener(_numeroVenta);
            var oDetalleVenta = await _ventaService.ObtenerDetalle(_numeroVenta);
            oVenta.RefDetalleVenta = oDetalleVenta;

            MemoryStream imageLogo;
            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(oNegocio.UrlLogo);
                imageLogo = new MemoryStream(imageBytes);
            }

            var arrayPDF = Util.GeneratePDFVenta(oNegocio, oVenta, imageLogo);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files(*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar PDF";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = $"{_numeroVenta}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await File.WriteAllBytesAsync(saveFileDialog.FileName, arrayPDF);
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}
