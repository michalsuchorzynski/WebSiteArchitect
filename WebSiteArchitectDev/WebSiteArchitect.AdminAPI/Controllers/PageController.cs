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
    public class PageController : Controller
    {
        private readonly DataContext _context;

        public PageController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Page> GetAll()
        {
            return _context.Pages.ToList();
        }

        [HttpGet("{id}", Name = "GetPage")]
        public IActionResult GetById(long id)
        {
            var item = _context.Pages.FirstOrDefault(t => t.PageId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("{name}", Name = "GetPagesByName")]
        [Route("byName/{name}")]
        public IEnumerable<Page> GetByName(string name)
        {
            return _context.Pages.Where(p => p.Name == name).ToList();
        }


        [HttpPost]
        public IActionResult Create([FromBody] Page item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Pages.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPage", new { id = item.PageId }, item);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePageRequest page)
        {

            if (page == null)
            {
                return BadRequest();
            }

            var pageToUpdate = _context.Pages.FirstOrDefault(p => p.PageId == page.Id);
            if (pageToUpdate == null)
            {
                return NotFound();
            }
            pageToUpdate.ModDate = DateTime.Now;
            pageToUpdate.ControlsJson = page.Controls;
            pageToUpdate.XamlPageString = page.XamlSchema;

            _context.Pages.Update(pageToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var page = _context.Pages.FirstOrDefault(p => p.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            _context.Pages.Remove(page);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}