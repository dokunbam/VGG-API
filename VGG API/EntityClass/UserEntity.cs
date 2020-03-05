using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGG_API.Data;
using VGG_API.Entities;

namespace VGG_API.EntityClass
{
    public class UserEntity
    {
        
        private readonly UserManager<User> userManager;
        private readonly ApiContext apiContext;
        //private SignInManager<User> signInManager;
        //private readonly ApplicationSettings _appSetting;

        public UserEntity(UserManager<User> _userManager, ApiContext _apiContext)

        {
            userManager = _userManager;
            apiContext = _apiContext;
        }

        public async Task<User> IsUserRegistered(UserModel user)
        {
            try
            {
                var users = await userManager.FindByNameAsync(user.UserName);

                if (users == null)
                {
                    var NewUser = new User
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF")

                    };

                    var result = await userManager.CreateAsync(NewUser, user.Password);

                    return NewUser;
                }
                else
                {
                    var NewUser = new User
                    {
                        Message = "Username already Taken "
                    };

                    return NewUser;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

