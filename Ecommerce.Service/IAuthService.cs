using Ecommerce.Dto.User;
using Ecommerce.Model;
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

        Task<UserForLoginRequest> Login(UserForLoginRequest userForLoginRequest);
    }
}
