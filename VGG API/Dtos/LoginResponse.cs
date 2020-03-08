using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Dtos
{
    public class LoginResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public LoginResponseData ResponseData { get; set; }
    }

    public class LoginResponseData
    {
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
