using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;

        }
        [HttpPost]
        [Route("Register")]

        public IActionResult Registration(UserRegistrationModel userRegistrationModel)
        {
            var result = _userBusiness.UserRegistration(userRegistrationModel);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "User Registration Successful", data = result });

            }
            else
            {
                return this.BadRequest(new { success = false, message = "User Registration UnSuccessful", data = result });
            }
        }
        [HttpPost]
        [Route("Login")]

        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var result = _userBusiness.UserLogin(userLoginModel);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "User Login Successful", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "User Login UnSuccessful", data = result });

            }
        }

        [HttpPost]
        [Route("ForgotPassword")]

        public IActionResult ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var result = _userBusiness.ForgotPassword(forgotPasswordModel);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Token sent Successfully"});
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Token sending Failed"});
            }
        }

        [Authorize]
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword1(string newPassword, string confirmPassword)
        {
            var email = User.FindFirst(x => x.Type == "Email").Value;
            if (email != null)
            {
                var result = _userBusiness.ResetPassword(email, newPassword, confirmPassword);
                if (result == true)
                {
                    return Ok(new { success = true, message = "Reset Password Successfully" });
                }
                else
                {
                    return Unauthorized(new { success = false, message = "Invalid Credentials Reset Password Unsuccessful" });
                }
            }
            return null;
        }
    }
}
