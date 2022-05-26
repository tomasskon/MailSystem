using System;
using System.Collections.Generic;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentSizeRepository
    {
        IEnumerable<ShipmentSize> GetAll();

        bool CheckIfExists(Guid shipmentSizeId);
    }
}