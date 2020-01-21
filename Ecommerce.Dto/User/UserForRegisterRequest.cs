using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Dto.User
{
    public class UserForRegisterRequest
    {
        [Required, MaxLength(64)]
        public string FirstName { get; set; }

        [Required, MaxLength(64)]
        public string LastName { get; set; }

        [Required, MaxLength(64), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(4), MaxLength(8)]
        public string Password { get; set; }

    }
}
