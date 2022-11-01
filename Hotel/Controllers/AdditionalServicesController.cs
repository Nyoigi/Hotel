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
    public class AdditionalServicesController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public AdditionalServicesController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/AdditionalServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalService>>> GetAdditionalServices()
        {
            return await _context.AdditionalServices.ToListAsync();
        }

        // GET: api/AdditionalServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalService>> GetAdditionalService(int id)
        {
            var additionalService = await _context.AdditionalServices.FindAsync(id);

            if (additionalService == null)
            {
                return NotFound();
            }

            return additionalService;
        }

        // PUT: api/AdditionalServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditionalService(int id, AdditionalService additionalService)
        {
            if (id != additionalService.IdAdditionalServices)
            {
                return BadRequest();
            }

            _context.Entry(additionalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalServiceExists(id))
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

        // POST: api/AdditionalServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdditionalService>> PostAdditionalService(AdditionalService additionalService)
        {
            _context.AdditionalServices.Add(additionalService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditionalService", new { id = additionalService.IdAdditionalServices }, additionalService);
        }

        // DELETE: api/AdditionalServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditionalService(int id)
        {
            var additionalService = await _context.AdditionalServices.FindAsync(id);
            if (additionalService == null)
            {
                return NotFound();
            }

            _context.AdditionalServices.Remove(additionalService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdditionalServiceExists(int id)
        {
            return _context.AdditionalServices.Any(e => e.IdAdditionalServices == id);
        }
    }
}
