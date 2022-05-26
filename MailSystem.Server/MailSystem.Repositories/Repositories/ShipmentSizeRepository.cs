using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Entities;
using MailSystem.Repositories.Interfaces;
using NHibernate;

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

        public IEnumerable<ShipmentSize> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            var shipmentSizeEntities = session.Query<ShipmentSizeEntity>().ToList();

            return _mapper.Map<List<ShipmentSize>>(shipmentSizeEntities);
        }
    }
}
