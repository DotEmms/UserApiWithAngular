using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.DTO
{
    public class LoginDTO
    {
        //can't be empty => required
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
