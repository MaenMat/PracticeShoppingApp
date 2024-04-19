using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace PracticeShoppingApp.UI.Auth
{
    public class AddHeadersDelegatingHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;

        public AddHeadersDelegatingHandler(ILocalStorageService localStorageService) : base(new HttpClientHandler())
        {
            _localStorageService = localStorageService;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorageService.GetItemAsync<string>("token");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}