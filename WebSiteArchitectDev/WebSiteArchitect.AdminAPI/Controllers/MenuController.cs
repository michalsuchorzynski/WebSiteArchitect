using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSiteArchitect.AdminAPI.Model;
using WebSiteArchitect.WebModel.Helpers;

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

        [HttpGet("{name}", Name = "GetMenusByName")]
        [Route("byName/{name}")]
        public IEnumerable<Menu> GetByName(string name)
        {
            return _context.Menus.Where(m => m.Name == name).ToList();
        }

        [HttpGet("{id}", Name = "GetMenusForSite")]
        [Route("forSite/{id}")]
        public IEnumerable<Menu> GetMenusForSite(int id)
        {
            return _context.Menus.Where(m => m.SiteId == id).ToList();
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

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePageRequest menu)
        {

            if (menu == null)
            {
                return BadRequest();
            }

            var menuToUpdate = _context.Menus.FirstOrDefault(m => m.MenuId == menu.Id);
            if (menuToUpdate == null)
            {
                return NotFound();
            }
            menuToUpdate.ModDate = DateTime.Now;
            menuToUpdate.ControlsJson = menu.Controls;
            menuToUpdate.XamlPageString = menu.XamlSchema;

            _context.Menus.Update(menuToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var menu = _context.Menus.FirstOrDefault(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
