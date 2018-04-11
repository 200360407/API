
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/companies")]
    public class companiesController : Controller
    {
        private readonly CompanyModel _context;

        public companiesController(CompanyModel context)
        {
            _context = context;
        }

        // GET: api/companies
        [HttpGet]
        public IEnumerable<company> Getcompany()
        {
            return _context.company;
        }

        // GET: api/companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getcompany([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.company.SingleOrDefaultAsync(m => m.color == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcompany([FromRoute] string id, [FromBody] company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.color)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!companyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/companies
        [HttpPost]
        public async Task<IActionResult> Postcompany([FromBody] company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.company.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcompany", new { id = company.color }, company);
        }

        // DELETE: api/companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecompany([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = await _context.company.SingleOrDefaultAsync(m => m.color == id);
            if (company == null)
            {
                return NotFound();
            }

            _context.company.Remove(company);
            await _context.SaveChangesAsync();

            return Ok(company);
        }

        private bool companyExists(string id)
        {
            return _context.company.Any(e => e.color == id);
        }
    }
}