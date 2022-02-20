using System;
using System.Collections.Generic;
using System.Text;
using ProjectN.Application.Models.Authentication;
using System.Threading.Tasks;

namespace ProjectN.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
