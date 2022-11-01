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
    public class TypeOfTransactionsController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public TypeOfTransactionsController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfTransaction>>> GetTypeOfTransactions()
        {
            return await _context.TypeOfTransactions.ToListAsync();
        }

        // GET: api/TypeOfTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfTransaction>> GetTypeOfTransaction(int id)
        {
            var typeOfTransaction = await _context.TypeOfTransactions.FindAsync(id);

            if (typeOfTransaction == null)
            {
                return NotFound();
            }

            return typeOfTransaction;
        }

        // PUT: api/TypeOfTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfTransaction(int id, TypeOfTransaction typeOfTransaction)
        {
            if (id != typeOfTransaction.IdTypeOfTransaction)
            {
                return BadRequest();
            }

            _context.Entry(typeOfTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfTransactionExists(id))
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

        // POST: api/TypeOfTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeOfTransaction>> PostTypeOfTransaction(TypeOfTransaction typeOfTransaction)
        {
            _context.TypeOfTransactions.Add(typeOfTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOfTransaction", new { id = typeOfTransaction.IdTypeOfTransaction }, typeOfTransaction);
        }

        // DELETE: api/TypeOfTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfTransaction(int id)
        {
            var typeOfTransaction = await _context.TypeOfTransactions.FindAsync(id);
            if (typeOfTransaction == null)
            {
                return NotFound();
            }

            _context.TypeOfTransactions.Remove(typeOfTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeOfTransactionExists(int id)
        {
            return _context.TypeOfTransactions.Any(e => e.IdTypeOfTransaction == id);
        }
    }
}
