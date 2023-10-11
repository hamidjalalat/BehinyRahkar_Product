using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Models
{
    public class User : Base.Entity
    {
        public User() : base()
        {
        }

         
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string FirstName { get; set; }
         

         
        [System.ComponentModel.DataAnnotations.Required]
        public string EmailAddress { get; set; }
         

        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Services { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Role { get; set; }


    }
}
