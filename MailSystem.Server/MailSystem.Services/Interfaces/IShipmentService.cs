using System;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IShipmentService
    {
        Task<string> CreateShipment(Shipment shipment);
    }
}