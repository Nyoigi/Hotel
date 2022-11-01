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
    public class FinancialDepartamentsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public FinancialDepartamentsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/FinancialDepartaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialDepartament>>> GetFinancialDepartaments()
        {
            return await _context.FinancialDepartaments.ToListAsync();
        }

        // GET: api/FinancialDepartaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialDepartament>> GetFinancialDepartament(int id)
        {
            var financialDepartament = await _context.FinancialDepartaments.FindAsync(id);

            if (financialDepartament == null)
            {
                return NotFound();
            }

            return financialDepartament;
        }

        // PUT: api/FinancialDepartaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialDepartament(int id, FinancialDepartament financialDepartament)
        {
            if (id != financialDepartament.IdFinancialDepartament)
            {
                return BadRequest();
            }

            _context.Entry(financialDepartament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialDepartamentExists(id))
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

        // POST: api/FinancialDepartaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialDepartament>> PostFinancialDepartament(FinancialDepartament financialDepartament)
        {
            _context.FinancialDepartaments.Add(financialDepartament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialDepartament", new { id = financialDepartament.IdFinancialDepartament }, financialDepartament);
        }

        // DELETE: api/FinancialDepartaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialDepartament(int id)
        {
            var financialDepartament = await _context.FinancialDepartaments.FindAsync(id);
            if (financialDepartament == null)
            {
                return NotFound();
            }

            _context.FinancialDepartaments.Remove(financialDepartament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialDepartamentExists(int id)
        {
            return _context.FinancialDepartaments.Any(e => e.IdFinancialDepartament == id);
        }
    }
}
