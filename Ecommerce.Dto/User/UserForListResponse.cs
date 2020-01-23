using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Dto.User
{
    public class UserForListResponse
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
    }
}
