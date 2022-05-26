using System;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Task<Guid> Create(Shipment shipment);
    }
}