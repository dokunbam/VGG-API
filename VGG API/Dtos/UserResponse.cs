using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGG_API.Dtos
{

    public class UserResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public UserResponseData ResponseData { get; set; }
    }

    public class UserResponseData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateCreated { get; set; }
        public string Message { get; set; }
    }
}
