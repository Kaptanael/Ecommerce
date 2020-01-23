using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ecommerce.Data.UnitOfWork;
using Ecommerce.Dto.User;
using Ecommerce.Model;
using Ecommerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IAuthService _authService;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secret;

        public AuthController(IConfiguration configuration, IUnitOfWork uow, ILogger<AuthController> logger, IAuthService authService)
        {
            _configuration = configuration;
            _issuer = _configuration.GetSection("AppSettings:Issuer").Value;
            _audience = _configuration.GetSection("AppSettings:Audience").Value;
            _secret = _configuration.GetSection("AppSettings:Token").Value;
            _logger = logger;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterRequest userForRegisterRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _authService.GetUserByEmail(userForRegisterRequest.Email);

                if (user != null)
                {
                    return Conflict(HttpStatusCode.Conflict);
                }

                var createdUser = await _authService.Register(userForRegisterRequest);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]        
        public async Task<IActionResult> Login([FromBody]UserForLoginRequest userForLoginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _authService.Login(userForLoginRequest);

                if (user == null)
                {
                    return Unauthorized();
                }

                var token = await _authService.GenerateToken(userForLoginRequest, _secret, _issuer, _audience);

                var tokenResponse = new TokenResponse { Id = user.Id, FullName = user.FirstName + " " + user.LastName, Token = token.ToString() };

                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("validateToken")]
        public IActionResult ValidateToken([FromBody] string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secret))
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

                var jwtSecurityToken = validatedToken as JwtSecurityToken;

                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }

                return Ok(validatedToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Unauthorized();
            }
        }

        public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }
    }
}
