using AutoMapper;
using Ecommerce.Data.UnitOfWork;
using Ecommerce.Dto.User;
using Ecommerce.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<int> Register(UserForRegisterRequest userForRegisterRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(userForRegisterRequest.Password, out passwordHash, out passwordSalt);

            var userToCreate = new User
            {
                FirstName = userForRegisterRequest.FirstName,
                LastName = userForRegisterRequest.LastName,
                Email = userForRegisterRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _uow.AppUsers.AddAsync(userToCreate, cancellationToken);

            return await _uow.SaveAsync(cancellationToken);
        }

        public async Task<UserForListResponse> Login(UserForLoginRequest userForLoginRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userFromRepo = await _uow.AppUsers.GetUserByEmail(userForLoginRequest.Email, cancellationToken);

            if (userFromRepo == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(userForLoginRequest.Password, userFromRepo.PasswordHash, userFromRepo.PasswordSalt))
            {
                return null;
            }

            var userToReturn = _mapper.Map<UserForListResponse>(userFromRepo);

            return userToReturn;
        }
        public async Task<SecurityToken> GenerateToken(UserForLoginRequest userForLoginRequest, string secret, string issuer, string audience, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userFromRepo = await _uow.AppUsers.GetUserByEmail(userForLoginRequest.Email, cancellationToken);

            var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name,userFromRepo.FirstName + " " + userFromRepo.LastName)
                };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha512)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }

        public async Task<UserForListResponse> GetUserByEmail(string email, CancellationToken cancellationToken = default(CancellationToken)) 
        {
            var userFromRepo = await _uow.AppUsers.GetUserByEmail(email, cancellationToken);
            var userToReturn = _mapper.Map<UserForListResponse>(userFromRepo);
            return userToReturn;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
