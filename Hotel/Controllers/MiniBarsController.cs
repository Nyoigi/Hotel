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
    public class MiniBarsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public MiniBarsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/MiniBars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniBar>>> GetMiniBars()
        {
            return await _context.MiniBars.ToListAsync();
        }

        // GET: api/MiniBars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniBar>> GetMiniBar(int id)
        {
            var miniBar = await _context.MiniBars.FindAsync(id);

            if (miniBar == null)
            {
                return NotFound();
            }

            return miniBar;
        }

        // PUT: api/MiniBars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniBar(int id, MiniBar miniBar)
        {
            if (id != miniBar.IdMiniBar)
            {
                return BadRequest();
            }

            _context.Entry(miniBar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniBarExists(id))
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

        // POST: api/MiniBars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniBar>> PostMiniBar(MiniBar miniBar)
        {
            _context.MiniBars.Add(miniBar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniBar", new { id = miniBar.IdMiniBar }, miniBar);
        }

        // DELETE: api/MiniBars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniBar(int id)
        {
            var miniBar = await _context.MiniBars.FindAsync(id);
            if (miniBar == null)
            {
                return NotFound();
            }

            _context.MiniBars.Remove(miniBar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniBarExists(int id)
        {
            return _context.MiniBars.Any(e => e.IdMiniBar == id);
        }
    }
}
