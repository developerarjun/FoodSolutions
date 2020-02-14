using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodSolutions.Model.USER.PUBLIC;
using foodSolutions.Services.ADMIN.PUBLIC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foodSolutions.Controllers.ADMIN.PUBLIC
{
    [Route("admin/vieworder")]
    [ApiController]
    public class ViewOrderController : ControllerBase
    {
        private readonly IViewOrderServices _services;
        public ViewOrderController(IViewOrderServices services)
        {
            _services = services;
        }
        [HttpGet]
        public ActionResult<Orders> getOrderByAdmin()
        {
            var ordersList = _services.getOrderByAdmin();
            if (ordersList != null)
            {
                return Ok(ordersList);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult<List<Orders>> viewSalesReport(SalesReport sales)
        {
            var ordersList = _services.getSalesReport(sales);
            if (ordersList != null)
            {
                return Ok(ordersList);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}