using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSiteArchitect.AdminAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSiteArchitect.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;

        public MenuController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Menu> GetAll()
        {
            return _context.Menus.ToList();
        }

        [HttpGet("{id}", Name = "GetMenu")]
        public IActionResult GetById(long id)
        {
            var item = _context.Menus.FirstOrDefault(t => t.MenuId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Menu item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Menus.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMenu", new { id = item.MenuId }, item);
        }

    }
}
