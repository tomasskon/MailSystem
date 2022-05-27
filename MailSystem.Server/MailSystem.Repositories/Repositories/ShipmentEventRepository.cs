using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace MailSystem.Repositories.Repositories
{
    public class ShipmentEventRepository : IShipmentEventRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;
        
        public ShipmentEventRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<List<DetailedShipmentEvent>> GetAllByTrackingId(string trackingId)
        {
            var shipmentEventEntities =
                await _session.Query<ShipmentEventEntity>().Where(x => x.Shipment.TrackingId == trackingId).ToListAsync();

            return _mapper.Map<List<DetailedShipmentEvent>>(shipmentEventEntities);
        }

        public async Task<Guid> Create(ShipmentEvent shipmentEvent)
        {
            using var transaction = _session.BeginTransaction();

            var shipmentEventEntity = _mapper.Map<ShipmentEventEntity>(shipmentEvent);
            shipmentEventEntity.Shipment = new ShipmentEntity {Id = shipmentEvent.ShipmentId};
            shipmentEventEntity.Mailbox = shipmentEvent.MailboxId.HasValue ? new MailboxEntity {Id = shipmentEvent.MailboxId.Value} : null;
            shipmentEventEntity.EventDate = DateTime.UtcNow;
            await _session.SaveAsync(shipmentEventEntity);
            
            await transaction.CommitAsync();

            return shipmentEventEntity.Id;
        }
    }
}