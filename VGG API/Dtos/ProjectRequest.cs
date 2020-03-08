using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Dtos
{
    public class ProjectRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
