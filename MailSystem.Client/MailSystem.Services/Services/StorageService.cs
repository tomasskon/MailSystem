using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MailSystem.Contracts.Couriers;
using MailSystem.Contracts.Enums;
using MailSystem.Contracts.JWT;
using MailSystem.Contracts.Users;
using MailSystem.Http.Interfaces;
using MailSystem.Services.Interfaces;

namespace MailSystem.Services.Services
{
    public class StorageService : IStorageService
    {
        private const string UserInfoField = "user";
        private const string JwtTokenField = "jwt";

        private readonly ILocalStorageService _localStorageService;
        private readonly IUserHttpClient _userHttpClient;
        private readonly ICourierHttpClient _courierHttpClient;

        public StorageService(
            ILocalStorageService localStorageService,
            IUserHttpClient userHttpClient, 
            ICourierHttpClient courierHttpClient)
        {
            _localStorageService = localStorageService;
            _userHttpClient = userHttpClient;
            _courierHttpClient = courierHttpClient;
        }

        public async Task<string> GetJwtToken()
        {
            return await _localStorageService.GetItemAsStringAsync(JwtTokenField);
        }

        public async Task SetJwtToken(string jwtToken)
        {
            await _localStorageService.SetItemAsStringAsync(JwtTokenField, jwtToken);
        }

        public async Task RemoveJwtToken()
        {
            await _localStorageService.RemoveItemAsync(JwtTokenField);
        }

        public async Task<UserType?> GetUserType()
        {
            return JwtParser.GetUserType(await GetJwtToken());
        }

        public async Task<Guid?> GetUserId()
        {
            return JwtParser.GetUserId(await GetJwtToken());
        }

        public async Task<UserContract> GetUserInfo()
        {
            return await _localStorageService.GetItemAsync<UserContract>(UserInfoField);
        }

        public async Task<CourierContract> GetCourierInfo()
        {
            return await _localStorageService.GetItemAsync<CourierContract>(UserInfoField);
        }

        public async Task UpdateUserInfo()
        {
            var userId = await GetUserId();
            var userType = await GetUserType();

            if (userId.HasValue)
            {
                if (userType is UserType.User)
                {
                    await _localStorageService.SetItemAsync(UserInfoField, await _userHttpClient.GetUser(userId.Value));
                }
                else
                {
                    await _localStorageService.SetItemAsync(UserInfoField, await _courierHttpClient.GetCourier(userId.Value));
                }
            }
        }

        public async Task RemoveUserInfo()
        {
            await _localStorageService.RemoveItemAsync(UserInfoField);
        }
    }
}