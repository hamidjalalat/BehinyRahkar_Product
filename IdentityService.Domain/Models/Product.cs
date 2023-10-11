using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Models
{
    public class Product : Base.Entity
    {
        public Product() : base()
        {
        }

         
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string Categories { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string Price { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }
         

        public string Description { get; set; }
         
         
    }
}
