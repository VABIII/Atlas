using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atlas.Data;

namespace Atlas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly X23DbContext _context;

        public VenueController(X23DbContext context)
        {
            _context = context;
        }

        // GET: api/Venue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venues>>> GetVenues()
        {
            return await _context.Venues.ToListAsync();
        }

        // GET: api/Venue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venues>> GetVenues(int id)
        {
            var venues = await _context.Venues.FindAsync(id);

            if (venues == null)
            {
                return NotFound();
            }

            return venues;
        }

        // PUT: api/Venue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenues(int id, Venues venues)
        {
            if (id != venues.VenueId)
            {
                return BadRequest();
            }

            _context.Entry(venues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenuesExists(id))
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

        // POST: api/Venue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venues>> PostVenues(Venues venues)
        {
            _context.Venues.Add(venues);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenues", new { id = venues.VenueId }, venues);
        }

        // DELETE: api/Venue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenues(int id)
        {
            var venues = await _context.Venues.FindAsync(id);
            if (venues == null)
            {
                return NotFound();
            }

            _context.Venues.Remove(venues);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VenuesExists(int id)
        {
            return _context.Venues.Any(e => e.VenueId == id);
        }
    }
}
