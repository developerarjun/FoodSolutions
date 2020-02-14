using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Model.USER.PUBLIC
{
    public class FoodOrders
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int foodId { get; set; }
        public string foodName { get; set; }
        public string quantity {get; set;}
        public Double price { get; set; }
    }
}
