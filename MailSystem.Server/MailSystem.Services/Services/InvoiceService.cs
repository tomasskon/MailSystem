using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using MailSystem.Domain.Models;
using MailSystem.Services.Interfaces;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using System.Drawing.Imaging;
using static ZXing.BarcodeFormat;

namespace MailSystem.Services.Services
{
    public class InvoiceService : IInvoiceService
    {

        private readonly IShipmentService _shipmentService;
        private readonly IConverter _converter;
        
        public InvoiceService(IShipmentService shipmentService, IConverter converter)
        {
            _shipmentService = shipmentService;
            _converter = converter;
        }
        
        private static string GetShipmentHtmlString(Shipment shipment, string trackingId)
        {
            var writer = new BarcodeWriter{
                Format = CODE_128,
                Options = new EncodingOptions {
                    Height = 400,
                    Width = 800,
                    PureBarcode = false,
                    Margin = 10,
                },
                Renderer = new BitmapRenderer(),
            };
            
            var bitmap = writer.Write(trackingId);
            var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            var byteImage = ms.ToArray();
            var bmpBase64= Convert.ToBase64String(byteImage); 
            ms.Close();

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Shipment</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Tracking ID</th>
                                        <th>Receiver</th>
                                        <th>Email</th>
                                        <th>Phone number</th>
                                    </tr>");

            sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                             </tr>", trackingId, shipment.ReceiverFullName, shipment.ReceiverEmail, shipment.ReceiverPhoneNumber);
            sb.Append($@"
                                </table>
                            <table><tr><td width='300'><img src='data:image/png;base64,{bmpBase64}' /></td></tr></table>
                                                     </body>
                </html>");
            return sb.ToString();
        }
        
        public async Task<byte[]> GenerateInvoice(Guid shipmentId)
        {
            var shipment = await _shipmentService.Get(shipmentId);
            var globalSettings = new GlobalSettings
            {
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Shipment report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetShipmentHtmlString(shipment, shipment.TrackingId),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory()) },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            return file;
        }
    }
}