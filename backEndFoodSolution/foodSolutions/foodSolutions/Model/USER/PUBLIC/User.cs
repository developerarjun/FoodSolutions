using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Model.USER.PUBLIC
{
    public class User
    {
        public int _id { get; set; }
        [Required]
        public string email { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string shift { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

    }
}
