﻿using System;
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
    [Route("api/children")]
    public class childrenController : Controller
    {
        private readonly CompanyModel _context;

        public childrenController(CompanyModel context)
        {
            _context = context;
        }

        // GET: api/children
        [HttpGet]
        public IEnumerable<child> Getchild()
        {
            return _context.child;
        }

        // GET: api/children/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getchild([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var child = await _context.child.SingleOrDefaultAsync(m => m.color2 == id);

            if (child == null)
            {
                return NotFound();
            }

            return Ok(child);
        }

        // PUT: api/children/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putchild([FromRoute] string id, [FromBody] child child)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != child.color2)
            {
                return BadRequest();
            }

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!childExists(id))
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

        // POST: api/children
        [HttpPost]
        public async Task<IActionResult> Postchild([FromBody] child child)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.child.Add(child);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getchild", new { id = child.color2 }, child);
        }

        // DELETE: api/children/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletechild([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var child = await _context.child.SingleOrDefaultAsync(m => m.color2 == id);
            if (child == null)
            {
                return NotFound();
            }

            _context.child.Remove(child);
            await _context.SaveChangesAsync();

            return Ok(child);
        }

        private bool childExists(string id)
        {
            return _context.child.Any(e => e.color2 == id);
        }
    }
}