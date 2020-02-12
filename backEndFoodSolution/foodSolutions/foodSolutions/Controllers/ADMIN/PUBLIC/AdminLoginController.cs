using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodSolutions.Model.ADMIN.PUBLIC;
using foodSolutions.Services.ADMIN.PUBLIC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foodSolutions.Controllers.ADMIN.PUBLIC
{
    [Route("AdminLogin")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly IAdminLoginServices _services;
        public AdminLoginController(IAdminLoginServices services) {
            _services = services;
        }
        [HttpPost]
        public ActionResult<AdminLogin> LoginIn(AdminLogin admin) {
            var adminLogin = _services.LoginIn(admin);
            if (adminLogin.isLogin) {
                HttpContext.Session.SetString("username", adminLogin.userName);
                HttpContext.Session.SetString("userFullName", adminLogin.userFullName);
                return Ok(adminLogin);
            }
            return NotFound();
        }
        
    }
}