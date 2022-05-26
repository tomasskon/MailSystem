using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSystem.Domain.Models;
using MailSystem.Exception;
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

        public async Task<IEnumerable<Courier>> GetAll()
        {
            return await _courierRepository.GetAll();
        }

        public async Task<Guid> Create(Courier courier)
        {
            if (await _courierRepository.CheckIfEmailAlreadyUsed(courier.Email))
                throw new CourierEmailAlreadyUsedException($"Courier email already used: {courier.Email}");
            
            return await _courierRepository.Create(courier);
        }

        public async Task<Courier> Get(Guid courierId)
        {
            var courier = await _courierRepository.Get(courierId);
            
            if (courier is null)
                throw new CourierNotFoundException($"Courier not found. Courier id: {courierId}");

            return courier;
        }

        public async Task Update(Courier courier)
        {
            var existingCourier = await _courierRepository.Get(courier.Id);

            if (existingCourier is null)
                throw new CourierNotFoundException($"Courier not found. Courier id: {courier.Id}");
            
            await CheckEmailValidity(existingCourier, courier.Email);
            
            await _courierRepository.Update(courier);
        }

        public async Task Delete(Guid courierId)
        {
            if (!await _courierRepository.CheckIfExists(courierId))
                throw new CourierNotFoundException($"Courier not found. Courier id: {courierId}");
            
            await _courierRepository.Delete(courierId);
        }

        public async Task<Courier> GetByEmail(string email)
        {
            var courier = await _courierRepository.GetByEmail(email);
            
            if(courier is null)
                throw new CourierNotFoundException($"Courier not found. Courier email: {email}");

            return courier;
        }

        private async Task CheckEmailValidity(Courier existingCourier, string emailToChange)
        {
            if (existingCourier.Email != emailToChange && await _courierRepository.CheckIfEmailAlreadyUsed(emailToChange))
                throw new CourierEmailAlreadyUsedException($"Courier email already used: {existingCourier.Email}");
        }
        
    }
}