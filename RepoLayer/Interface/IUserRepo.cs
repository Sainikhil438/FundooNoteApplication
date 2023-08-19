﻿using CommonLayer.Models;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRepo
    {
        public UserEntity UserRegistration(UserRegistrationModel userRegisterModel);
        public string UserLogin(UserLoginModel userLoginModel);
        public string ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        public bool ResetPassword(string Email, string NewPassword, string ConfirmPassword);
    }
}
