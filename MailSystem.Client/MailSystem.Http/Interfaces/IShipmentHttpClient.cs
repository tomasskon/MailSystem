using System.Threading.Tasks;
using MailSystem.Contracts.Shipment;

namespace MailSystem.Http.Interfaces
{
    public interface IShipmentHttpClient
    {
        Task<string> RegisterShipment(RegisterShipmentContract registerShipmentContract);
    }
}