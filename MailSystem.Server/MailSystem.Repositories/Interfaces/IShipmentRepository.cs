using System;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Guid Create(Shipment shipment);
    }
}