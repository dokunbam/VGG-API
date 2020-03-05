using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    class Users
    {
        public int Id { get; set; }
        [Required]
        public string  Username { get; set; }
        public string Password { get; set; }

    }
}
