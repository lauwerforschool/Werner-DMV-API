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
    public class LicensesController : ControllerBase
    {
        private readonly DMV_APIContext _context;

        public LicensesController(DMV_APIContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: api/Licenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Licenses>>> GetLicenses()
        {
          if (_context.Licenses == null)
          {
              return NotFound();
          }
            return await _context.Licenses.ToListAsync();
        }

        [Authorize]

        // GET: api/Licenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Licenses>> GetLicenses(string id)
        {
          if (_context.Licenses == null)
          {
              return NotFound();
          }
            var licenses = await _context.Licenses.FindAsync(id);

            if (licenses == null)
            {
                return NotFound();
            }

            return licenses;
        }

        [Authorize]

        // PUT: api/Licenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenses(string id, Licenses licenses)
        {
            if (id != licenses.LicenseID)
            {
                return BadRequest();
            }

            _context.Entry(licenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicensesExists(id))
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
        // POST: api/Licenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Licenses>> PostLicenses(Licenses licenses)
        {
          if (_context.Licenses == null)
          {
              return Problem("Entity set 'DMV_APIContext.Licenses'  is null.");
          }
            _context.Licenses.Add(licenses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LicensesExists(licenses.LicenseID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLicenses", new { id = licenses.LicenseID }, licenses);
        }
        [Authorize]

        // DELETE: api/Licenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenses(string id)
        {
            if (_context.Licenses == null)
            {
                return NotFound();
            }
            var licenses = await _context.Licenses.FindAsync(id);
            if (licenses == null)
            {
                return NotFound();
            }

            _context.Licenses.Remove(licenses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LicensesExists(string id)
        {
            return (_context.Licenses?.Any(e => e.LicenseID == id)).GetValueOrDefault();
        }
    }
}
