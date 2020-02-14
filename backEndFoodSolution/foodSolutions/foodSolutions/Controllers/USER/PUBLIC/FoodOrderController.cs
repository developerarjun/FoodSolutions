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
    [Route("users/foodorders")]
    [ApiController]

    public class FoodOrderController : ControllerBase
    {
        private readonly IFoodOrdersServices _services;
        public FoodOrderController(IFoodOrdersServices services)
        {
            _services = services;
        }
        [HttpPost]
        public ActionResult<Orders> saveFood(Orders food)
        {
            var order = _services.saveFoodOrder(food);
            if (order != null) return Ok(food);
            return BadRequest();
        }
        [HttpGet("{userid}")]
        public ActionResult<List<Orders>> getFoodOrderHistory(string userid)
        {
            var order = _services.getFoodHistory(userid);
            if (order != null) return Ok(order);
            return BadRequest();
        }
    }
}