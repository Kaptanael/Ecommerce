using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Name { get; set; }        

        [Required, MaxLength(64)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
