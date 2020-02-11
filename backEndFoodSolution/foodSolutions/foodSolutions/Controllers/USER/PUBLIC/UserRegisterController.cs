using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodSolutions.Model.USER.PUBLIC;
using foodSolutions.Services.USER.PUBLIC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foodSolutions.Controllers.USER.PUBLIC
{
    [Route("users")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserRegisterServices _services;
        public UserRegisterController(IUserRegisterServices services)
        {
            _services = services;
        }
        [HttpPost]
        public ActionResult<User> LoginIn(User user)
        {
            if (_services.saveUserDetails(user)) return Ok(user);
            return BadRequest();
        }
    }
}