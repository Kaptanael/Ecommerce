using Ecommerce.Dto.User;
using Ecommerce.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public interface IAuthService
    {
        Task<int> Register(UserForRegisterRequest userForRegisterRequest, CancellationToken cancellationToken = default(CancellationToken));

        Task<UserForListResponse> Login(UserForLoginRequest userForLoginRequest, CancellationToken cancellationToken = default(CancellationToken));

        Task<string> GenerateToken(UserForLoginRequest userForLoginRequest, string secret, string issuer, string audience, CancellationToken cancellationToken = default(CancellationToken));

        Task<UserForListResponse> GetUserByEmail(string email, CancellationToken cancellationToken = default(CancellationToken));
    }
}
