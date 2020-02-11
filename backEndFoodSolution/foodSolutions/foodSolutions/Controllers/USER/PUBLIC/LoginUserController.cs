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
    [Route("login/user")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly ILoginUserServices _services;
        public LoginUserController(ILoginUserServices services)
        {
            _services = services;
        }
        [HttpPost]
        public ActionResult<LoginUser> LoginIn(LoginUser user)
        {
            var login = _services.checkUser(user);
            if (login.isLogin) return Ok(user);
            return BadRequest();
        }
    }
}