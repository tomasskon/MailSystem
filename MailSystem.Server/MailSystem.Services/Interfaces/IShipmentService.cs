using System;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentService
    {
        string CreateShipment(Shipment shipment);
    }
}