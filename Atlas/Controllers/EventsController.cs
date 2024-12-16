using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atlas.Data;
using Atlas.DTO;
using System.Xml;
using Newtonsoft.Json;
using Atlas.Services.Events;

namespace Atlas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly X23DbContext _context;
        private readonly IEventServices _eventServices;

        public EventsController(X23DbContext context, IEventServices eventServices)
        {
            _context = context;
            _eventServices = eventServices;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<EventsListDTO>> GetEvents()
        {
            
            var v = await _context.Events
                .Include(x => x.Venue)
                // .Where(x => x.EventDate.Value.Date == DateTime.Today.Date)
                .ToListAsync();

            return Ok(new EventsListDTO
            {
                EventsList = v.Select(x => new EventDTO
                {
                    EventArtist = x.EventArtist,
                    EventDate = x.EventDate.Value.Date.ToString(),
                    EventTime = x.EventTime,
                    EventLink = x.EventLink,
                    EventImgSrc = x.EventImgSrc,
                    EventVenue = x.VenueId switch
                    {
                        1 => "The Signal",
                        2 => "Soldiers and Sailors Memorial Auditorium",
                        3 => "The Walker Theatre",
                        4 => "The Tivoli Theatre",
                        _ => ""
                    },
                }).ToList()
            });
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEvents(int id)
        {
            var events = await _context.Events.FindAsync(id);

            if (events == null)
            {
                return NotFound();
            }

            return events;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents(int id, Events events)
        {
            if (id != events.EventId)
            {
                return BadRequest();
            }

            _context.Entry(events).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Events>> PostEvents(EventsListDTO events)
        {

            var evts = events.EventsList
                .Select(x => new Events(x))
                .ToList();
            
            _context.AddRange(evts);
            await _context.SaveChangesAsync();

            return Ok(evts);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvents(int id)
        {
            var events = await _context.Events
                .Include(x => x.Venue)
                .Include(x => x.EventArtists)
                .ThenInclude(x => x.Artists)
                .FirstOrDefaultAsync(X => X.EventId == id);
            
            
            if (events == null)
            {
                return NotFound();
            }

            _context.Events.Remove(events);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventsExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
