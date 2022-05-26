using AutoMapper;
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
    }
}