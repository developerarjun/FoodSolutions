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
    [Route("menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _services;
        public MenuController(IMenuServices services)
        {
            _services = services;
        }
        [HttpPost]
        public ActionResult<Menu> saveMenu(List<Menu> menu)
        {
            if (_services.savemenu(menu))
            {
                return Ok("Successfully saved");
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<List<Menu>> getMenu() {
            var _menu = _services.getMenu();
            if (_menu.Count != 0)
            {
                return Ok(_menu);
            }
            else {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult deletemenu(int id)
        {
            if (_services.deleteMenu(id))
            {
                return Ok("Delete Succesfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}