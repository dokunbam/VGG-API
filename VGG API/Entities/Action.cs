using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Entities
{
    public class Action
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Note { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Project Project { get; set; }
    }
}
