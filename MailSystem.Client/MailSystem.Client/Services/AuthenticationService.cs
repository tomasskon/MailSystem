using System;
using System.Threading.Tasks;
using MailSystem.Client.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MailSystem.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string JwtTokenField = "user_jwt";
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public AuthenticationService(
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<string> GetJWTToken()
        {
            return await _localStorageService.GetItem(JwtTokenField);
        }

        public async Task<bool> OnlyAuthenticated()
        {
            if (await IsAuthenticated()) 
                return true;

            _navigationManager.NavigateTo("login");

            return false;
        }

        public async Task<bool> OnlyGuest()
        {
            if (!await IsAuthenticated())
                return true;
            
            _navigationManager.NavigateTo("/");

            return false;
        }

        public async Task<bool> IsAuthenticated()
        {
            var jwtToken = await GetJWTToken();
            return jwtToken != null;
        }

        public async Task Login(string username, string password)
        {
            // User = await _httpService.Post<User>("/users/authenticate", new { username, password });
            // User.AuthData = $"{username}:{password}".EncodeBase64();
            await _localStorageService.SetItem(JwtTokenField, "test");
        }
        
        public async Task Logout()
        {
            await _localStorageService.RemoveItem(JwtTokenField);
            _navigationManager.NavigateTo("login");
        }
    }
}