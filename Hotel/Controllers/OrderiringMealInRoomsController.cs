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
    public class OrderiringMealInRoomsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public OrderiringMealInRoomsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/OrderiringMealInRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderiringMealInRoom>>> GetOrderiringMealInRooms()
        {
            return await _context.OrderiringMealInRooms.ToListAsync();
        }

        // GET: api/OrderiringMealInRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderiringMealInRoom>> GetOrderiringMealInRoom(int id)
        {
            var orderiringMealInRoom = await _context.OrderiringMealInRooms.FindAsync(id);

            if (orderiringMealInRoom == null)
            {
                return NotFound();
            }

            return orderiringMealInRoom;
        }

        // PUT: api/OrderiringMealInRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderiringMealInRoom(int id, OrderiringMealInRoom orderiringMealInRoom)
        {
            if (id != orderiringMealInRoom.IdOrderiringMealInRoom)
            {
                return BadRequest();
            }

            _context.Entry(orderiringMealInRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderiringMealInRoomExists(id))
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

        // POST: api/OrderiringMealInRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderiringMealInRoom>> PostOrderiringMealInRoom(OrderiringMealInRoom orderiringMealInRoom)
        {
            _context.OrderiringMealInRooms.Add(orderiringMealInRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderiringMealInRoom", new { id = orderiringMealInRoom.IdOrderiringMealInRoom }, orderiringMealInRoom);
        }

        // DELETE: api/OrderiringMealInRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderiringMealInRoom(int id)
        {
            var orderiringMealInRoom = await _context.OrderiringMealInRooms.FindAsync(id);
            if (orderiringMealInRoom == null)
            {
                return NotFound();
            }

            _context.OrderiringMealInRooms.Remove(orderiringMealInRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderiringMealInRoomExists(int id)
        {
            return _context.OrderiringMealInRooms.Any(e => e.IdOrderiringMealInRoom == id);
        }
    }
}
