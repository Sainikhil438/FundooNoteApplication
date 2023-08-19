using BusinessLayer.Interface;
using CommonLayer.Models;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepo _UserRepo;
        public UserBusiness(IUserRepo UserRepo)
        {
            _UserRepo = UserRepo;
        }

        public UserEntity UserRegistration(UserRegistrationModel Model)
        {
            try
            {
                return _UserRepo.UserRegistration(Model);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string UserLogin(UserLoginModel userLoginModel)
        {
            try
            {
                return _UserRepo.UserLogin(userLoginModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            try
            {
                return _UserRepo.ForgotPassword(forgotPasswordModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
