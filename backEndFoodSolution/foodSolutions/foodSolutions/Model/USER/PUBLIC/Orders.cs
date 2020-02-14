using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Model.USER.PUBLIC
{
    public class Orders
    {
        public int id { get; set; }
        public string orderBy {get; set;}
        public string orderAt { get; set; }
        public string full_name { get; set; }
        public bool is_ready { get; set; }
        public Double totalPrice { get; set; }
        public List<FoodOrders> foodOrders { get; set; }
    }
}
