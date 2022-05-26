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
    public class ShipmentSizeRepository : IShipmentSizeRepository
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IMapper _mapper;

        public ShipmentSizeRepository(ISessionFactory sessionFactory, IMapper mapper)
        {
            _sessionFactory = sessionFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipmentSize>> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var shipmentSizeEntities = await session.Query<ShipmentSizeEntity>().ToListAsync();

            return _mapper.Map<List<ShipmentSize>>(shipmentSizeEntities);
        }
        
        public Task<bool> CheckIfExists(Guid shipmentSizeId)
        {
            using var session = _sessionFactory.OpenSession();

            return session.Query<ShipmentSizeEntity>().AnyAsync(x => x.Id == shipmentSizeId);
        }
    }
}
