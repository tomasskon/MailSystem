using System;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentService
    {
        Guid CreateShipment(Shipment shipment);
    }
}