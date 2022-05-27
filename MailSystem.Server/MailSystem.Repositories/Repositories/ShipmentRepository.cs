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
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public ShipmentRepository(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _session = session;
        }

        public async Task<List<DetailedShipment>> GetUserShipments(Guid userId)
        {
            var shipmentEntities =
                await _session.Query<ShipmentEntity>().Where(x => x.User.Id == userId).ToListAsync();

            return _mapper.Map<List<DetailedShipment>>(shipmentEntities);
        }

        public async Task<Guid> Create(Shipment shipment)
        {
            using var transaction = _session.BeginTransaction();
            
            var shipmentEntity = _mapper.Map<ShipmentEntity>(shipment);
            shipmentEntity.User = new UserEntity {Id = shipment.UserId};
            shipmentEntity.ShipmentSize = new ShipmentSizeEntity {Id = shipment.ShipmentSizeId};
            shipmentEntity.MailBox = new MailboxEntity {Id = shipment.MailBoxId};

            await _session.SaveAsync(shipmentEntity);
            await transaction.CommitAsync();

            return shipmentEntity.Id;
        }
        
        public async Task<Shipment> Get(Guid shipmentId)
        {
            var shipmentEntity = await _session.GetAsync<ShipmentEntity>(shipmentId);

            return _mapper.Map<Shipment>(shipmentEntity);
        }
    }
}