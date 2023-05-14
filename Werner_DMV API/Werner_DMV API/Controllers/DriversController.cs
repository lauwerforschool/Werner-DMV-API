using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Werner_DMV_API.Models;

namespace Werner_DMV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DMV_APIContext _context;

        public DriversController(DMV_APIContext context)
        {
            _context = context;
        }
        [Authorize]

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDrivers()
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            return await _context.Drivers.ToListAsync();
        }

        [Authorize]
        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drivers>> GetDrivers(string id)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var drivers = await _context.Drivers.FindAsync(id);

            if (drivers == null)
            {
                return NotFound();
            }

            return drivers;
        }

        [Authorize]
        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrivers(string id, Drivers drivers)
        {
            if (id != drivers.DriverID)
            {
                return BadRequest();
            }

            _context.Entry(drivers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversExists(id))
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
        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drivers>> PostDrivers(Drivers drivers)
        {
            if (_context.Drivers == null)
            {
                return Problem("Entity set 'DMV_APIContext.Drivers'  is null.");
            }
            _context.Drivers.Add(drivers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriversExists(drivers.DriverID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDrivers", new { id = drivers.DriverID }, drivers);
        }

        [Authorize]
        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrivers(string id)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(drivers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriversExists(string id)
        {
            return (_context.Drivers?.Any(e => e.DriverID == id)).GetValueOrDefault();
        }
    }
}
