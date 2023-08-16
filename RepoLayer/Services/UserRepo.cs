using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly FundooContext _fundooContext;
        private readonly IConfiguration configuration;

        public UserRepo(FundooContext _fundooContext, IConfiguration configuration)
        {
            this._fundooContext = _fundooContext;
            this.configuration = configuration;
        }

        public UserEntity UserRegistration(UserRegistrationModel userRegisterModel)
        {
            try
            {
                UserEntity users = new UserEntity();
                users.FirstName = userRegisterModel.FirstName;
                users.LastName = userRegisterModel.LastName;
                users.Email = userRegisterModel.Email;
                users.Password = userRegisterModel.Password;
                users.DateOfBirth = userRegisterModel.DateOfBirth;
                _fundooContext.UsersTable.Add(users);
                _fundooContext.SaveChanges();
                if (users != null)
                {
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UserLogin(UserLoginModel model)
        {
            try
            {

                var userEntity = _fundooContext.UsersTable.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (userEntity != null)
                {

                    // return userEntity.Email;
                    return "Login Successful";
                }
                else
                {
                    return "Enter valid credentias";
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
    }
}
