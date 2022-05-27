using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace MailSystem.Repositories.Repositories
{
    public class ShipmentSizeRepository : IShipmentSizeRepository
    {
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public ShipmentSizeRepository(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipmentSize>> GetAll()
        {
            var shipmentSizeEntities = await _session.Query<ShipmentSizeEntity>().ToListAsync();

            return _mapper.Map<List<ShipmentSize>>(shipmentSizeEntities);
        }
        
        public Task<bool> CheckIfExists(Guid shipmentSizeId)
        {
            return _session.Query<ShipmentSizeEntity>().AnyAsync(x => x.Id == shipmentSizeId);
        }
    }
}
