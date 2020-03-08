using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Dtos
{
    public class ActionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ActionResponseData ResponseData { get; set; }
    }

    public class ActionsResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<ProjectResponseData> ResponseData { get; set; }
    }
    public class ActionResponseData
    {
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
