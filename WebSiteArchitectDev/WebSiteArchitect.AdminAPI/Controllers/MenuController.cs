using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSiteArchitect.EntityModel;

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

            if (_context.Menus.Count() == 0)
            {
                _context.Menus.Add(new Menu());
                _context.SaveChanges();
            }
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
    }
}
