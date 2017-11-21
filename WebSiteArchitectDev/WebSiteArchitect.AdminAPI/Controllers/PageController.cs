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

        [HttpPost]
        public IActionResult Create([FromBody] Page item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.Pages.Add(item);
            _context.SaveChanges();

            return null;// CreatedAtRoute("GetPage", new { id = item.PageId }, item);
        }
    }
}