using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Dtos
{
    public class ActionRequest
    {
        public int ProjectId { get; internal set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
