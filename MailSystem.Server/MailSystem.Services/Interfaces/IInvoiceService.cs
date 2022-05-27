using System;
using System.Threading.Tasks;
using MailSystem.Domain.Models;

namespace MailSystem.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<byte[]> GenerateInvoice(Guid shipmentId);
    }
}