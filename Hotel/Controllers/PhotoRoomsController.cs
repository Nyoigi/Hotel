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
    public class PhotoRoomsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public PhotoRoomsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/PhotoRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoRoom>>> GetPhotoRooms()
        {
            return await _context.PhotoRooms.ToListAsync();
        }

        // GET: api/PhotoRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoRoom>> GetPhotoRoom(int id)
        {
            var photoRoom = await _context.PhotoRooms.FindAsync(id);

            if (photoRoom == null)
            {
                return NotFound();
            }

            return photoRoom;
        }

        // PUT: api/PhotoRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoRoom(int id, PhotoRoom photoRoom)
        {
            if (id != photoRoom.IdPhotoRoom)
            {
                return BadRequest();
            }

            _context.Entry(photoRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoRoomExists(id))
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

        // POST: api/PhotoRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoRoom>> PostPhotoRoom(PhotoRoom photoRoom)
        {
            _context.PhotoRooms.Add(photoRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoRoom", new { id = photoRoom.IdPhotoRoom }, photoRoom);
        }

        // DELETE: api/PhotoRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoRoom(int id)
        {
            var photoRoom = await _context.PhotoRooms.FindAsync(id);
            if (photoRoom == null)
            {
                return NotFound();
            }

            _context.PhotoRooms.Remove(photoRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoRoomExists(int id)
        {
            return _context.PhotoRooms.Any(e => e.IdPhotoRoom == id);
        }
    }
}
