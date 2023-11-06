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
    public class ComunasController : ControllerBase
    {
        private readonly LastBugSpaContext _context;

        public ComunasController(LastBugSpaContext context)
        {
            _context = context;
        }

        // GET: api/Comunas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comuna>>> GetComunas()
        {
          if (_context.Comunas == null)
          {
              return NotFound();
          }
            return await _context.Comunas.ToListAsync();
        }

        // GET: api/Comunas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comuna>> GetComuna(int id)
        {
          if (_context.Comunas == null)
          {
              return NotFound();
          }
            var comuna = await _context.Comunas.FindAsync(id);

            if (comuna == null)
            {
                return NotFound();
            }

            return comuna;
        }

        // PUT: api/Comunas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComuna(int id, Comuna comuna)
        {
            if (id != comuna.ComunaId)
            {
                return BadRequest();
            }

            _context.Entry(comuna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunaExists(id))
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

        // POST: api/Comunas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comuna>> PostComuna(Comuna comuna)
        {
          if (_context.Comunas == null)
          {
              return Problem("Entity set 'LastBugSpaContext.Comunas'  is null.");
          }
            _context.Comunas.Add(comuna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComuna", new { id = comuna.ComunaId }, comuna);
        }

        // DELETE: api/Comunas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComuna(int id)
        {
            if (_context.Comunas == null)
            {
                return NotFound();
            }
            var comuna = await _context.Comunas.FindAsync(id);
            if (comuna == null)
            {
                return NotFound();
            }

            _context.Comunas.Remove(comuna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunaExists(int id)
        {
            return (_context.Comunas?.Any(e => e.ComunaId == id)).GetValueOrDefault();
        }
    }
}
