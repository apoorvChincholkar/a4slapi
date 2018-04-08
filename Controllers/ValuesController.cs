using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using Newtonsoft.Json;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ValuesController(webapiDbContext context)
        {
            _context = context;
        }

        private webapiDbContext _context;
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var sites = _context
            .SiteMaster
            .Include(x => x.InverterMaster);
            return new JsonResult(sites, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(string value)
        {
            int a = 5;
            if (a == 5)
            {
                a = 6;
            }
        }

        [HttpPost]
        [Route("/api/[controller]/Create")]
        public IActionResult Create([FromBody] AlertData item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            int a = 5;
            if (a == 5)
            {
                a = 6;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
