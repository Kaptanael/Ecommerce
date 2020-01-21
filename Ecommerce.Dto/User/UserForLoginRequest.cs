using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Dto.User
{
    public class UserForLoginRequest
    {
        [Required, MaxLength(64)]
        public string Email { get; set; }

        [Required, MinLength(4), MaxLength(8)]
        public string Password { get; set; }
    }
}
