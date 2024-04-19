using PracticeShoppingApp.Application.Models.Authentication;

namespace PracticeShoppingApp.Application.Contracts.Identity
{
    public interface ICustomAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
