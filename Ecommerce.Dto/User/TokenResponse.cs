using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Dto.User
{
    public class TokenResponse
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        public string[] Roles { get; set; }

        public string Token { get; set; }
    }
}
