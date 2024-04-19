using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Http;


namespace PracticeShoppingApp.UI.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationMiddleware(RequestDelegate next, ILocalStorageService localStorage)
        {
            _next = next;
            _localStorage = localStorage;
        }

        public async Task Invoke(HttpContext context)
        {
            if (await _localStorage.ContainKeyAsync("token"))
            {
                context.Request.Headers.Add("Authorization", $"Bearer {await _localStorage.GetItemAsync<string>("token")}");
            }

            await _next(context);
        }
    }
}
