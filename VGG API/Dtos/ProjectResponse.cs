using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Dtos
{
        public class ProjectResponse
        {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ProjectResponseData ResponseData { get; set; }
        }

    public class ProjectsResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<ProjectResponseData> ResponseData { get; set; }
    }

        public class ProjectResponseData
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string Flag { get; internal set; }
    }
    
}
