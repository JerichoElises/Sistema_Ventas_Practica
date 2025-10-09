

using SV_Repository.Entities;
using System.Security.Cryptography;
using System.Text;

using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using MimeKit;

namespace SVPresentation.Utilidades
{
    public static class Util
    {
        public static string GenerateCode()
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 6);
            return guid;
        }
        public static string CovertToSha256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static byte[] GeneratePDFVenta(Negocio oNegocio, Venta oVenta, Stream imageLogo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var arrayPDF = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);
                    page.Header().ShowOnce().Row(row => 
                    { 
                        row.AutoItem().Height(60).Image(imageLogo,ImageScaling.FitArea);

                        row.RelativeItem().Column(col => 
                        {
                            col.Item().AlignCenter().Text(oNegocio.RazonSocial).Bold().FontSize(14);
                            col.Item().AlignCenter().Text(oNegocio.Direccion).FontSize(9);
                            col.Item().AlignCenter().Text(oNegocio.Celular).FontSize(9);
                            col.Item().AlignCenter().Text(oNegocio.Correo).FontSize(9);
                        });

                        row.ConstantItem(140).Column(col => 
                        { 
                            col.Item().Border(1).BorderColor("#54118128").AlignCenter().Text($"RUC{oNegocio.RUC}");
                            col.Item().Background("54118128").Border(1).BorderColor("#54118128").AlignCenter()
                            .Text("Boleto de Venta").FontColor("#fff");
                            col.Item().Border(1).BorderColor("#54118128").AlignCenter().Text(oVenta.NumeroVenta);
                        });
                    });

                    page.Content().PaddingVertical(15).Column(col1 => 
                    {
                        col1.Spacing(10);
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Row(row => 
                        {
                            row.RelativeItem().Text(txt => 
                            {
                                txt.Span("Cliente: ").SemiBold().FontSize(10);
                                txt.Span(oVenta.NombreCliente).FontSize(10);
                            });
                            row.RelativeItem().Text(txt =>
                            {
                                txt.Span("Fecha Emisión: ").SemiBold().FontSize(10);
                                txt.Span(oVenta.FechaRegistro).FontSize(10);
                            });
                        });

                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Table(tabla => 
                        {
                            tabla.ColumnsDefinition(colums => 
                            {
                                colums.RelativeColumn(3);
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                            });

                            tabla.Header(header => 
                            {
                                header.Cell().Background("#54118128").Padding(2).Text("Producto").FontColor("#fff");
                                header.Cell().Background("#54118128").Padding(2).Text("Precio").FontColor("#fff");
                                header.Cell().Background("#54118128").Padding(2).Text("Cantidad").FontColor("#fff");
                                header.Cell().Background("#54118128").Padding(2).Text("Total").FontColor("#fff");
                            });

                            foreach (DetalleVenta item in oVenta.RefDetalleVenta) 
                            {
                                decimal cantidad = Convert.ToDecimal(item.Cantidad)/ Convert.ToDecimal(item.RefProducto.refCategoria.RefMedida.Valor);
                                string abreviatura = item.RefProducto.refCategoria.RefMedida.Abreviatura;

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2)
                                .Text(item.RefProducto.Descripcion).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2)
                                .Text($"{oNegocio.SimboloMoneda}{item.PrecioVenta.ToString("0.00") }").FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2)
                                .Text($"{cantidad.ToString()}{abreviatura}").FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2)
                                .Text($"{oNegocio.SimboloMoneda}{item.PrecioTotal.ToString("0.00")}").FontSize(10);
                            }
                        });

                        col1.Item().AlignRight().Text($"{oNegocio.SimboloMoneda} {oVenta.PrecioTotal.ToString("0.00")}").FontSize(10);

                    });

                    page.Footer().AlignRight().Text(txt => 
                    {
                        txt.Span("Pagina").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span("de").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });

                });
            }).GeneratePdf();

            return arrayPDF;
        


        }

    }
}

