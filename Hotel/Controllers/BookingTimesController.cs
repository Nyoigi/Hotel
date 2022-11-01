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
    public class BookingTimesController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public BookingTimesController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/BookingTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingTime>>> GetBookingTimes()
        {
            return await _context.BookingTimes.ToListAsync();
        }

        // GET: api/BookingTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingTime>> GetBookingTime(int id)
        {
            var bookingTime = await _context.BookingTimes.FindAsync(id);

            if (bookingTime == null)
            {
                return NotFound();
            }

            return bookingTime;
        }

        // PUT: api/BookingTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingTime(int id, BookingTime bookingTime)
        {
            if (id != bookingTime.IdTime)
            {
                return BadRequest();
            }

            _context.Entry(bookingTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingTimeExists(id))
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

        // POST: api/BookingTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingTime>> PostBookingTime(BookingTime bookingTime)
        {
            _context.BookingTimes.Add(bookingTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingTime", new { id = bookingTime.IdTime }, bookingTime);
        }

        // DELETE: api/BookingTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingTime(int id)
        {
            var bookingTime = await _context.BookingTimes.FindAsync(id);
            if (bookingTime == null)
            {
                return NotFound();
            }

            _context.BookingTimes.Remove(bookingTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingTimeExists(int id)
        {
            return _context.BookingTimes.Any(e => e.IdTime == id);
        }
    }
}
