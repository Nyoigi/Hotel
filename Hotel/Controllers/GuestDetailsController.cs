using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestDetailsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public GuestDetailsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/GuestDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDetail>>> GetGuestDetails()
        {
            return await _context.GuestDetails.ToListAsync();
        }

        // GET: api/GuestDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDetail>> GetGuestDetail(int id)
        {
            var guestDetail = await _context.GuestDetails.FindAsync(id);

            if (guestDetail == null)
            {
                return NotFound();
            }

            return guestDetail;
        }

        // PUT: api/GuestDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestDetail(int id, GuestDetail guestDetail)
        {
            if (id != guestDetail.IdGuestDetails)
            {
                return BadRequest();
            }

            _context.Entry(guestDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestDetailExists(id))
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

        // POST: api/GuestDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuestDetail>> PostGuestDetail(GuestDetail guestDetail)
        {
            _context.GuestDetails.Add(guestDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuestDetail", new { id = guestDetail.IdGuestDetails }, guestDetail);
        }

        // DELETE: api/GuestDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestDetail(int id)
        {
            var guestDetail = await _context.GuestDetails.FindAsync(id);
            if (guestDetail == null)
            {
                return NotFound();
            }

            _context.GuestDetails.Remove(guestDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestDetailExists(int id)
        {
            return _context.GuestDetails.Any(e => e.IdGuestDetails == id);
        }
    }
}
