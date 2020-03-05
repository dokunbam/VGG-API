
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VGG_API.Data;
using VGG_API.Dtos;
using VGG_API.Entities;
using VGG_API.EntityClass;

namespace BusinessLayer
{
    
    public class UserClass
    {
        private readonly UserEntity userEntity;
        private UserResponseData userResponseData;
        public UserClass(UserEntity _userEntity)
        {
            userEntity = _userEntity;
        }

        public async Task<UserResponseData> Register(UserModel user) 
        {
            try
            {
                var RegisterResult = await userEntity.IsUserRegistered(user);

                if(RegisterResult.UserName == null ) 
                {
                    userResponseData = new UserResponseData
                    {
                        Message = RegisterResult.Message
                    };
                   return userResponseData;
                }
                else 
                {
                    userResponseData = new UserResponseData
                    {
                        UserName = RegisterResult.UserName,
                        Email = RegisterResult.Email,
                        Password = RegisterResult.PasswordHash,
                        DateCreated = RegisterResult.DateCreated
                        
                    };

                    return userResponseData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

    }
}
