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
        public float totalPrice { get; set; }
        public List<FoodOrders> foodOrders { get; set; }
    }
}
