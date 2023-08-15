﻿using BusinessLayer.Interface;
using CommonLayer.Models;
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
    }
}
