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
    public class PersonalAreasController : ControllerBase
    {
        private readonly MyHotelsContext _context;

        public PersonalAreasController(MyHotelsContext context)
        {
            _context = context;
        }

        // GET: api/PersonalAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalArea>>> GetPersonalAreas()
        {
            return await _context.PersonalAreas.ToListAsync();
        }

        // GET: api/PersonalAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalArea>> GetPersonalArea(int id)
        {
            var personalArea = await _context.PersonalAreas.FindAsync(id);

            if (personalArea == null)
            {
                return NotFound();
            }

            return personalArea;
        }

        // PUT: api/PersonalAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalArea(int id, PersonalArea personalArea)
        {
            if (id != personalArea.IdPersonal)
            {
                return BadRequest();
            }

            _context.Entry(personalArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalAreaExists(id))
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

        // POST: api/PersonalAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalArea>> PostPersonalArea(PersonalArea personalArea)
        {
            _context.PersonalAreas.Add(personalArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalArea", new { id = personalArea.IdPersonal }, personalArea);
        }

        // DELETE: api/PersonalAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalArea(int id)
        {
            var personalArea = await _context.PersonalAreas.FindAsync(id);
            if (personalArea == null)
            {
                return NotFound();
            }

            _context.PersonalAreas.Remove(personalArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalAreaExists(int id)
        {
            return _context.PersonalAreas.Any(e => e.IdPersonal == id);
        }
    }
}
