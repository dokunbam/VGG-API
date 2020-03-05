using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VGG_API.Dtos;
using VGG_API.Entities;

namespace VGG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserClass userClass;
        private UserManager<User> userManager;
        //private SignInManager<User> signInManager;
        private UserResponse userResponse;

        public UserController(UserManager<User> _userManager, UserClass _userClass)
        {
            userManager = _userManager;
           // signInManager = _signInManager;
            userClass = _userClass;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<UserResponse>> CreateUser(UserModel User)
        {
            var result =  await userClass.Register(User);
            try
            {
                if(result.UserName == null) 
                {
                    userResponse = new UserResponse
                    {
                        StatusCode = 400,
                        Message = result.Message
                    };

                    return userResponse;
                }
                else
                {
                    userResponse = new UserResponse
                    {
                        StatusCode = 200,
                        Message = "Successful Created",
                        ResponseData = result
                    };

                    return userResponse;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}