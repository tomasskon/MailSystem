using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Contracts.ShipmentSizes;

namespace MailSystem.Http.Interfaces
{
    public interface IShipmentSizeHttpClient
    {
        Task<IEnumerable<ShipmentSizeContract>> GetShipmentSizes();
    }
}