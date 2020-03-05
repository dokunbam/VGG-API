using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VGG_API.Entities
{
    public class User : IdentityUser
    {
        public string DateCreated { get; set; }
        public string Message { get; set; }
    }
}
