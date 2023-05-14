using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Werner_DMV_API.Models;

namespace Werner_DMV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfractionsController : ControllerBase
    {
        private readonly DMV_APIContext _context;

        public InfractionsController(DMV_APIContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: api/Infractions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infractions>>> GetInfractions()
        {
          if (_context.Infractions == null)
          {
              return NotFound();
          }
            return await _context.Infractions.ToListAsync();
        }

        [Authorize]
        // GET: api/Infractions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Infractions>> GetInfractions(string id)
        {
          if (_context.Infractions == null)
          {
              return NotFound();
          }
            var infractions = await _context.Infractions.FindAsync(id);

            if (infractions == null)
            {
                return NotFound();
            }

            return infractions;
        }

        [Authorize]

        // PUT: api/Infractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfractions(string id, Infractions infractions)
        {
            if (id != infractions.InfractionID)
            {
                return BadRequest();
            }

            _context.Entry(infractions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfractionsExists(id))
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

        [Authorize]
        // POST: api/Infractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Infractions>> PostInfractions(Infractions infractions)
        {
          if (_context.Infractions == null)
          {
              return Problem("Entity set 'DMV_APIContext.Infractions'  is null.");
          }
            _context.Infractions.Add(infractions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfractionsExists(infractions.InfractionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfractions", new { id = infractions.InfractionID }, infractions);
        }

        [Authorize]
        // DELETE: api/Infractions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfractions(string id)
        {
            if (_context.Infractions == null)
            {
                return NotFound();
            }
            var infractions = await _context.Infractions.FindAsync(id);
            if (infractions == null)
            {
                return NotFound();
            }

            _context.Infractions.Remove(infractions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfractionsExists(string id)
        {
            return (_context.Infractions?.Any(e => e.InfractionID == id)).GetValueOrDefault();
        }
    }
}
