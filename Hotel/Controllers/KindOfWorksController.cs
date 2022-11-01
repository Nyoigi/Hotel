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
    public class KindOfWorksController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public KindOfWorksController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/KindOfWorks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KindOfWork>>> GetKindOfWorks()
        {
            return await _context.KindOfWorks.ToListAsync();
        }

        // GET: api/KindOfWorks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KindOfWork>> GetKindOfWork(int id)
        {
            var kindOfWork = await _context.KindOfWorks.FindAsync(id);

            if (kindOfWork == null)
            {
                return NotFound();
            }

            return kindOfWork;
        }

        // PUT: api/KindOfWorks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKindOfWork(int id, KindOfWork kindOfWork)
        {
            if (id != kindOfWork.IdKindOfWork)
            {
                return BadRequest();
            }

            _context.Entry(kindOfWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindOfWorkExists(id))
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

        // POST: api/KindOfWorks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KindOfWork>> PostKindOfWork(KindOfWork kindOfWork)
        {
            _context.KindOfWorks.Add(kindOfWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKindOfWork", new { id = kindOfWork.IdKindOfWork }, kindOfWork);
        }

        // DELETE: api/KindOfWorks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKindOfWork(int id)
        {
            var kindOfWork = await _context.KindOfWorks.FindAsync(id);
            if (kindOfWork == null)
            {
                return NotFound();
            }

            _context.KindOfWorks.Remove(kindOfWork);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KindOfWorkExists(int id)
        {
            return _context.KindOfWorks.Any(e => e.IdKindOfWork == id);
        }
    }
}
