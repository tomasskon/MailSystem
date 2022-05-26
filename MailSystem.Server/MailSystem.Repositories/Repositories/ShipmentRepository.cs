using AutoMapper;
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
    }
}