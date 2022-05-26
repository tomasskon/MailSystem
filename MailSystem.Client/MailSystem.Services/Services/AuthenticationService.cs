using System.Threading.Tasks;
using MailSystem.Contracts.Enums;
using MailSystem.Contracts.JWT;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MailSystem.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string JwtTokenField = "jwt";
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public AuthenticationService(NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<string> GetJwtToken()
        {
            return await _localStorageService.GetItem(JwtTokenField);
        }

        public async Task OnlyAuthenticated()
        {
            if (await GetJwtToken() == null) 
                _navigationManager.NavigateTo("login");
        }

        public async Task OnlyUser()
        {
            var jwtToken = await GetJwtToken();

            if (JwtParser.GetUserType(jwtToken) != UserType.User) 
                _navigationManager.NavigateTo("/");
        }

        public async Task OnlyCourier()
        {
            var jwtToken = await GetJwtToken();

            if (JwtParser.GetUserType(jwtToken) != UserType.Courier) 
                _navigationManager.NavigateTo("/");
        }

        public async Task OnlyGuest()
        {
            if (await GetJwtToken() != null)
                _navigationManager.NavigateTo("/");
        }

        public async Task Login(string jwtToken)
        {
            await _localStorageService.SetItem(JwtTokenField, jwtToken);
            _navigationManager.NavigateTo("/");
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItem(JwtTokenField);
            _navigationManager.NavigateTo("login");
        }
    }
}