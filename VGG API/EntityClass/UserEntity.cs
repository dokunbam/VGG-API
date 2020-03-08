using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        private readonly AppSettings appSetting;

        public UserEntity(UserManager<User> _userManager, ApiContext _apiContext, AppSettings _appSetting)

        {
            userManager = _userManager;
            apiContext = _apiContext;
            appSetting = _appSetting;
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

        public async Task<String> IsUserLoggedin(LoginModel Login) 
        {
            try
            {
                var user = await userManager.FindByNameAsync(Login.UserName);
                if (user != null && await userManager.CheckPasswordAsync(user, Login.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.UserName )
                    }),

                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSetting.JWT_Secret)), SecurityAlgorithms.HmacSha256)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    return token;
                }
                else
                {
                    return "Username or password incorrect";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

