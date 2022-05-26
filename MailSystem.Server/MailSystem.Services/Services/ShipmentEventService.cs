using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class ShipmentEventService : IShipmentEventService
    {
        private readonly IShipmentEventRepository _shipmentEventRepository;

        public ShipmentEventService(IShipmentEventRepository shipmentEventRepository)
        {
            _shipmentEventRepository = shipmentEventRepository;
        }
    }
}