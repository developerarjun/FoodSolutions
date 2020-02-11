using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Model.USER.PUBLIC
{
    public class LoginUser
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        public bool isLogin { get; set; }
        public string userFullName { get; internal set; }
    }
}
