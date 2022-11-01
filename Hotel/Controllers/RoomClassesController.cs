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
    public class RoomClassesController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public RoomClassesController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/RoomClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomClass>>> GetRoomClasses()
        {
            return await _context.RoomClasses.ToListAsync();
        }

        // GET: api/RoomClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomClass>> GetRoomClass(int id)
        {
            var roomClass = await _context.RoomClasses.FindAsync(id);

            if (roomClass == null)
            {
                return NotFound();
            }

            return roomClass;
        }

        // PUT: api/RoomClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomClass(int id, RoomClass roomClass)
        {
            if (id != roomClass.IdRoomClass)
            {
                return BadRequest();
            }

            _context.Entry(roomClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomClassExists(id))
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

        // POST: api/RoomClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomClass>> PostRoomClass(RoomClass roomClass)
        {
            _context.RoomClasses.Add(roomClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomClass", new { id = roomClass.IdRoomClass }, roomClass);
        }

        // DELETE: api/RoomClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomClass(int id)
        {
            var roomClass = await _context.RoomClasses.FindAsync(id);
            if (roomClass == null)
            {
                return NotFound();
            }

            _context.RoomClasses.Remove(roomClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomClassExists(int id)
        {
            return _context.RoomClasses.Any(e => e.IdRoomClass == id);
        }
    }
}
