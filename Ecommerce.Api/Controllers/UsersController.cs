using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ecommerce.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<AuthController> logger;

        public UsersController(IUnitOfWork uow, ILogger<AuthController> logger)
        {
            this.uow = uow;
            this.logger = logger;
        }

        [Route("emailExist")]
        [HttpGet]
        public async Task<IActionResult> IsEmailExist(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest(ModelState);
                }
                if (await uow.AppUsers.UserExists(email))
                {
                    return Conflict(HttpStatusCode.Conflict);
                }
                return Ok(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}