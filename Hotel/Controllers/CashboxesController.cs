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
    public class CashboxesController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public CashboxesController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/Cashboxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cashbox>>> GetCashboxes()
        {
            return await _context.Cashboxes.ToListAsync();
        }

        // GET: api/Cashboxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cashbox>> GetCashbox(int id)
        {
            var cashbox = await _context.Cashboxes.FindAsync(id);

            if (cashbox == null)
            {
                return NotFound();
            }

            return cashbox;
        }

        // PUT: api/Cashboxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashbox(int id, Cashbox cashbox)
        {
            if (id != cashbox.IdCashbox)
            {
                return BadRequest();
            }

            _context.Entry(cashbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashboxExists(id))
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

        // POST: api/Cashboxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cashbox>> PostCashbox(Cashbox cashbox)
        {
            _context.Cashboxes.Add(cashbox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashbox", new { id = cashbox.IdCashbox }, cashbox);
        }

        // DELETE: api/Cashboxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashbox(int id)
        {
            var cashbox = await _context.Cashboxes.FindAsync(id);
            if (cashbox == null)
            {
                return NotFound();
            }

            _context.Cashboxes.Remove(cashbox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CashboxExists(int id)
        {
            return _context.Cashboxes.Any(e => e.IdCashbox == id);
        }
    }
}
