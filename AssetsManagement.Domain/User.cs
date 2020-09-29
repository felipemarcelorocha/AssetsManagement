using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetsManagement.Domain
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }        
    }
}
