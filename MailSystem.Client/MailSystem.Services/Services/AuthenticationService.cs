using System.Threading.Tasks;
using MailSystem.Contracts.Enums;
using MailSystem.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MailSystem.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly NavigationManager _navigationManager;
        private readonly IStorageService _storageService;

        public AuthenticationService(NavigationManager navigationManager, IStorageService storageService)
        {
            _navigationManager = navigationManager;
            _storageService = storageService;
        }

        public async Task OnlyAuthenticated()
        {
            if (await _storageService.GetJwtToken() == null) 
                _navigationManager.NavigateTo("login");
        }

        public async Task OnlyUser()
        {
            if (await _storageService.GetUserType() != UserType.User) 
                _navigationManager.NavigateTo("/");
        }

        public async Task OnlyCourier()
        {
            if (await _storageService.GetUserType() != UserType.Courier) 
                _navigationManager.NavigateTo("/");
        }

        public async Task OnlyGuest()
        {
            if (await _storageService.GetJwtToken() != null)
                _navigationManager.NavigateTo("/");
        }

        public async Task Login(string jwtToken)
        {
            await _storageService.SetJwtToken(jwtToken);
            _navigationManager.NavigateTo("/");
        }

        public async Task Logout()
        {
            await _storageService.RemoveJwtToken();
            await _storageService.RemoveUserInfo();
            _navigationManager.NavigateTo("login", forceLoad: true);
        }
    }
}