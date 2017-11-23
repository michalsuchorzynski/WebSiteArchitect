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
    public class SiteController : Controller
    {
        private readonly DataContext _context;

        public SiteController(DataContext context)
        {
            _context = context;

            if (_context.Sites.Count() == 0)
            {
                _context.Sites.Add(new Site());
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Site> GetAll()
        {
            return _context.Sites.ToList();
        }

        [HttpGet("{id}", Name = "GetSite")]
        public IActionResult GetById(long id)
        {
            var item = _context.Sites.FirstOrDefault(s => s.SiteId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("{name}", Name = "GetSiteByName")]
        [Route("byName/{name}")]
        public IActionResult GetByName(string name)
        {
            var item = _context.Sites.FirstOrDefault(s => s.Name == name);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Site item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Sites.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetSite", new { id = item.SiteId }, item);
        }
    }
}