using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_last_bug_spa.Models;

namespace api_last_bug_spa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionesController : ControllerBase
    {
        private readonly LastBugSpaContext _context;

        public RegionesController(LastBugSpaContext context)
        {
            _context = context;
        }

        // GET: api/Regiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regione>>> GetRegiones()
        {
          if (_context.Regiones == null)
          {
              return NotFound();
          }
            return await _context.Regiones.ToListAsync();
        }

        // GET: api/Regiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Regione>> GetRegione(int id)
        {
          if (_context.Regiones == null)
          {
              return NotFound();
          }
            var regione = await _context.Regiones.FindAsync(id);

            if (regione == null)
            {
                return NotFound();
            }

            return regione;
        }

        // PUT: api/Regiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegione(int id, Regione regione)
        {
            if (id != regione.RegionId)
            {
                return BadRequest();
            }

            _context.Entry(regione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegioneExists(id))
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

        // POST: api/Regiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Regione>> PostRegione(Regione regione)
        {
          if (_context.Regiones == null)
          {
              return Problem("Entity set 'LastBugSpaContext.Regiones'  is null.");
          }
            _context.Regiones.Add(regione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegione", new { id = regione.RegionId }, regione);
        }

        // DELETE: api/Regiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegione(int id)
        {
            if (_context.Regiones == null)
            {
                return NotFound();
            }
            var regione = await _context.Regiones.FindAsync(id);
            if (regione == null)
            {
                return NotFound();
            }

            _context.Regiones.Remove(regione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegioneExists(int id)
        {
            return (_context.Regiones?.Any(e => e.RegionId == id)).GetValueOrDefault();
        }
    }
}
