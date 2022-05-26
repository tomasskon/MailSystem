using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentSizeService
    {
        Task<IEnumerable<ShipmentSize>> GetAll();

        Task CheckIfShipmentSizeExists(Guid shipmentSizeId);
    }
}