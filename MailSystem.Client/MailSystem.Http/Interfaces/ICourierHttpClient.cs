using System;
using System.Threading.Tasks;
using MailSystem.Contracts.Couriers;

namespace MailSystem.Http.Interfaces
{
    public interface ICourierHttpClient
    {
        Task<CourierContract> GetCourier(Guid courierId);

        Task UpdateCourier(CourierContract user);
    }
}