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
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;
        
        public ShipmentEventRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public async Task<List<DetailedShipmentEvent>> GetAllByTrackingId(string trackingId)
        {
            using var session = _sessionFactory.OpenSession();

            var shipmentEventEntities =
                await session.Query<ShipmentEventEntity>().Where(x => x.Shipment.TrackingId == trackingId).ToListAsync();

            return _mapper.Map<List<DetailedShipmentEvent>>(shipmentEventEntities);
        }

        public async Task<Guid> Create(ShipmentEvent shipmentEvent)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var shipmentEventEntity = _mapper.Map<ShipmentEventEntity>(shipmentEvent);
            shipmentEventEntity.Shipment = new ShipmentEntity {Id = shipmentEvent.ShipmentId};
            shipmentEventEntity.Mailbox = shipmentEvent.MailboxId.HasValue ? new MailboxEntity {Id = shipmentEvent.MailboxId.Value} : null;
            shipmentEventEntity.EventDate = DateTime.UtcNow;
            await session.SaveAsync(shipmentEventEntity);
            
            await transaction.CommitAsync();

            return shipmentEventEntity.Id;
        }
    }
}