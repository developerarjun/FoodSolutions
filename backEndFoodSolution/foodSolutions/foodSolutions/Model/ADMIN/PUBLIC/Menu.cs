using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Model.ADMIN.PUBLIC
{
    public class Menu
    {
        public int? _id { get; set; }
        [Required]
        public string menuName { get; set; }
        [Required]
        public Double price { get; set; }
        [Required]
        public bool isAvailable { get; set; }
        public string stock { get; set; }
    }
}
