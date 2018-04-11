using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/children")]
    public class childrenController : Controller
    {
        private CompanyModel db;

        public childrenController(CompanyModel db) {
            this.db = db;
        }

        // GET: api/children
        [HttpGet]
        public IEnumerable<child> Get()
        {
            return db.children.ToList();
        }

        // GET: api/children/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/children
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/children/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
