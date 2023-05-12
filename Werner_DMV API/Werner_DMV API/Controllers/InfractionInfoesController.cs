using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Werner_DMV_API.Models;

namespace Werner_DMV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfractionInfoesController : ControllerBase
    {
        private readonly DMV_APIContext _context;

        public InfractionInfoesController(DMV_APIContext context)
        {
            _context = context;
        }

        // GET: api/InfractionInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfractionInfo>>> GetInfractionInfo()
        {
          if (_context.InfractionInfo == null)
          {
              return NotFound();
          }
            return await _context.InfractionInfo.ToListAsync();
        }

        // GET: api/InfractionInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfractionInfo>> GetInfractionInfo(string id)
        {
          if (_context.InfractionInfo == null)
          {
              return NotFound();
          }
            var infractionInfo = await _context.InfractionInfo.FindAsync(id);

            if (infractionInfo == null)
            {
                return NotFound();
            }

            return infractionInfo;
        }

        // PUT: api/InfractionInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfractionInfo(string id, InfractionInfo infractionInfo)
        {
            if (id != infractionInfo.IInfoID)
            {
                return BadRequest();
            }

            _context.Entry(infractionInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfractionInfoExists(id))
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

        // POST: api/InfractionInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfractionInfo>> PostInfractionInfo(InfractionInfo infractionInfo)
        {
          if (_context.InfractionInfo == null)
          {
              return Problem("Entity set 'DMV_APIContext.InfractionInfo'  is null.");
          }
            _context.InfractionInfo.Add(infractionInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfractionInfoExists(infractionInfo.IInfoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfractionInfo", new { id = infractionInfo.IInfoID }, infractionInfo);
        }

        // DELETE: api/InfractionInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfractionInfo(string id)
        {
            if (_context.InfractionInfo == null)
            {
                return NotFound();
            }
            var infractionInfo = await _context.InfractionInfo.FindAsync(id);
            if (infractionInfo == null)
            {
                return NotFound();
            }

            _context.InfractionInfo.Remove(infractionInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfractionInfoExists(string id)
        {
            return (_context.InfractionInfo?.Any(e => e.IInfoID == id)).GetValueOrDefault();
        }
    }
}
