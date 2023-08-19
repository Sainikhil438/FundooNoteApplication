using CommonLayer.Models;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        public UserEntity UserRegistration(UserRegistrationModel userRegistrationModel);
        public string UserLogin(UserLoginModel userLoginModel);
        public string ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        public bool ResetPassword(string Email, string NewPassword, string ConfirmPassword);
    }
}
