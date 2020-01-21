using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Model
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public long CreatedBy { get; set; } = 1;
        public long? ModifiedBy { get; set; } = 2;
    }
}
