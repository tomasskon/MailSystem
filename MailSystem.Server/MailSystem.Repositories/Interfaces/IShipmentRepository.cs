using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Task<List<DetailedShipment>> GetUserShipments(Guid userId);

        Task<Guid> Create(Shipment shipment);
        Task<Shipment> Get(Guid shipmentId);
    }
}