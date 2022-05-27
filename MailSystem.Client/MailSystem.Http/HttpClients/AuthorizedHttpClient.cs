using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MailSystem.Contracts;
using MailSystem.Http.Exceptions;
using MailSystem.Http.Interfaces;

namespace MailSystem.Http.HttpClients
{
    public class AuthorizedHttpClient : IAuthorizedHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public AuthorizedHttpClient(
            IHttpClientFactory httpClientFactory,
            ILocalStorageService localStorageService
        )
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<HttpClient> CreateHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient("Server");
            var jwtToken = await _localStorageService.GetItemAsStringAsync("jwt");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            return httpClient;
        }

        public async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();

            throw await HandleError(response);
        }
        public async Task<string> HandleStringResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw await HandleError(response);
        }

        public async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw await HandleError(response);
        }

        private async Task<System.Exception> HandleError(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return new UnauthorizedException();

            var errorResponse = await response.Content.ReadFromJsonAsync<StandardExceptionResponse>();

            return new ServerRequestException(errorResponse?.Exception, errorResponse?.Message);
        }
    }
}