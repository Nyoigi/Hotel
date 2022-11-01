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
    public class MaidsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public MaidsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/Maids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maid>>> GetMaids()
        {
            return await _context.Maids.ToListAsync();
        }

        // GET: api/Maids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maid>> GetMaid(int id)
        {
            var maid = await _context.Maids.FindAsync(id);

            if (maid == null)
            {
                return NotFound();
            }

            return maid;
        }

        // PUT: api/Maids/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaid(int id, Maid maid)
        {
            if (id != maid.IdMaids)
            {
                return BadRequest();
            }

            _context.Entry(maid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaidExists(id))
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

        // POST: api/Maids
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maid>> PostMaid(Maid maid)
        {
            _context.Maids.Add(maid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaid", new { id = maid.IdMaids }, maid);
        }

        // DELETE: api/Maids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaid(int id)
        {
            var maid = await _context.Maids.FindAsync(id);
            if (maid == null)
            {
                return NotFound();
            }

            _context.Maids.Remove(maid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaidExists(int id)
        {
            return _context.Maids.Any(e => e.IdMaids == id);
        }
    }
}
