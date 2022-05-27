using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<List<DetailedShipment>> GetUserShipments(Guid userId);
        Task<string> CreateShipment(Shipment shipment);
        Task<Shipment> Get(Guid shipmentId);
    }
}