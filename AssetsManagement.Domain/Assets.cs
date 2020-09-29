using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetsManagement.Domain
{ 
    public class Assets
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        [MinLength(2)]
        public string Description { get; set; }
        
        [Required]
        public Brand Brand { get; set; }
        [Required]
        public int AssetNumber { get; set; }

    }
}
