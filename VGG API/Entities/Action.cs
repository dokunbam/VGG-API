using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Entities
{
    public class Action
    {
        public int Id { get; set; }
        [Required]
        public int Project_Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Note { get; set; }

    }
}
