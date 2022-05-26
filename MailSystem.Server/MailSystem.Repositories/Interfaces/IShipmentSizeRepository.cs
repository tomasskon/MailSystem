using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentSizeRepository
    {
        Task<IEnumerable<ShipmentSize>> GetAll();

        Task<bool> CheckIfExists(Guid shipmentSizeId);
    }
}