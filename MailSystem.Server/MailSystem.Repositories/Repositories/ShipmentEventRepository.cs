using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;

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

        public List<DetailedShipmentEvent> GetAllByTrackingId(string trackingId)
        {
            using var session = _sessionFactory.OpenSession();

            var shipmentEventEntities =
                session.Query<ShipmentEventEntity>().Where(x => x.TrackingId == trackingId).ToList();

            return _mapper.Map<List<DetailedShipmentEvent>>(shipmentEventEntities);
        }

        public Guid Create(ShipmentEvent shipmentEvent)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var shipmentEventEntity = _mapper.Map<ShipmentEventEntity>(shipmentEvent);
            shipmentEventEntity.Mailbox = new MailboxEntity {Id = shipmentEvent.MailboxId};
            shipmentEventEntity.EventDate = DateTime.UtcNow;
            session.Save(shipmentEventEntity);
            
            transaction.Commit();

            return shipmentEventEntity.Id;
        }
    }
}