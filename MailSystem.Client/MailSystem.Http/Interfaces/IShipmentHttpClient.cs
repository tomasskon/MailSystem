using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MailSystem.Contracts.Shipment;

namespace MailSystem.Http.Interfaces
{
    public interface IShipmentHttpClient
    {
        Task<IEnumerable<ShipmentContract>> GetUserShipments(Guid userId);

        Task<string> RegisterShipment(RegisterShipmentContract registerShipmentContract);

        Task<Stream> GetPdf(Guid shipmentId);
    }
}