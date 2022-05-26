using System;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;

namespace MailSystem.Repositories.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public ShipmentRepository(IMapper mapper, ISessionFactory sessionFactory)
        {
            _mapper = mapper;
            _sessionFactory = sessionFactory;
        }

        public Guid Create(Shipment shipment)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var shipmentEntity = _mapper.Map<ShipmentEntity>(shipment);
            shipmentEntity.User = new UserEntity {Id = shipment.UserId};
            shipmentEntity.ShipmentSize = new ShipmentSizeEntity {Id = shipment.ShipmentSizeId};
            shipmentEntity.MailBox = new MailboxEntity {Id = shipment.MailBoxId};

            session.Save(shipmentEntity);
            transaction.Commit();

            return shipmentEntity.Id;
        }
    }
}