using Blazored.LocalStorage;
using PracticeShoppingApp.UI.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using PracticeShoppingApp.Application.Models.Authentication;
using PracticeShoppingApp.UI.Services.Contracts;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PracticeShoppingApp.UI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private HttpClient _httpClient;
        private ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpclient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _httpClient = httpclient;
            _localStorage = localStorage;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthenticationRequest authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
                var response = await _httpClient.PostAsJsonAsync($"api/Account/authenticate",authenticationRequest);

                if (response.IsSuccessStatusCode)
                {
                    var authenticationResponse = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await _httpClient.PostAsJsonAsync($"api/Account/register", registrationRequest);
            if (response.IsSuccessStatusCode)
            {
                var registrationResponse = await response.Content.ReadFromJsonAsync<RegistrationResponse>();
                if (!string.IsNullOrEmpty(registrationResponse.UserId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
