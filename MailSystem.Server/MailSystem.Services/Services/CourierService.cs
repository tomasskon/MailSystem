using System;
using System.Collections.Generic;
using MailSystem.Domain.Exceptions;
using MailSystem.Domain.Models;
using MailSystem.Repositories.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;

        public CourierService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public IEnumerable<Courier> GetAll()
        {
            return _courierRepository.GetAll();
        }

        public Guid Create(Courier courier)
        {
            if (_courierRepository.CheckIfEmailAlreadyUsed(courier.Email))
                throw new CourierEmailAlreadyUsedException($"Courier email already used: {courier.Email}");
            
            return _courierRepository.Create(courier);
        }

        public Courier Get(Guid courierId)
        {
            var courier = _courierRepository.Get(courierId);
            
            if (courier is null)
                throw new CourierNotFoundException($"Courier not found. Courier id: {courierId}");

            return courier;
        }

        public void Update(Courier courier)
        {
            var existingCourier = _courierRepository.Get(courier.Id);

            if (existingCourier is null)
                throw new CourierNotFoundException($"Courier not found. Courier id: {courier.Id}");
            
            CheckEmailValidity(courier, courier.Email);
            
            _courierRepository.Update(courier);
        }

        public void Delete(Guid courierId)
        {
            if (!_courierRepository.CheckIfExists(courierId))
                throw new CourierNotFoundException($"Courier not found. Courier id: {courierId}");
            
            _courierRepository.Delete(courierId);
        }

        private void CheckEmailValidity(Courier courier, string email)
        {
            if (courier.Email != email && !_courierRepository.CheckIfEmailAlreadyUsed(email))
                throw new CourierEmailAlreadyUsedException($"Courier email already used: {courier.Email}");
        }
        
    }
}