using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_last_bug_spa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace api_last_bug_spa.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LocalizacionController : ControllerBase
    {
        private readonly LastBugSpaContext _context;
        public readonly ILogger<LocalizacionController> _logger;

        public LocalizacionController(LastBugSpaContext context, ILogger<LocalizacionController> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogInformation("Init Localizacion");
        }

        // GET: api/Localizacion
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Paise>>> GetPaises()
        {
            _logger.LogInformation("Init Localizacion GetPaises");

            if (_context.Paises == null)
          {
              return NotFound();
          }
            return await _context.Paises
                  .Include(p => p.Regiones) // Carga las regiones relacionadas
                  .ThenInclude(r => r.Comunas) // Carga las comunas relacionadas de las regiones
                  .ToListAsync();
        }

        // GET: api/Localizacion/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Paise>> GetPaise(int id)
        {
            _logger.LogInformation("Init Localizacion GetPaise");

            if (_context.Paises == null)
          {
              return NotFound();
          }
            //var paise = await _context.Paises.FindAsync(id);
            var paise = await _context.Paises
        .Include(p => p.Regiones) // Carga las regiones relacionadas si es necesario
        .ThenInclude(r => r.Comunas) // Carga las comunas relacionadas si es necesario
        .FirstOrDefaultAsync(p => p.PaisId == id);
            if (paise == null)
            {
                return NotFound();
            }

            return paise;
        }

        // PUT: api/Localizacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaise([FromBody] Localizacion objeto, int id)
        {
            _logger.LogInformation("Init Localizacion PutPaise");

            if (id != objeto.PaisId)
            {
                return BadRequest();
            }
            try
            {
                Paise paise = new Paise();
                paise.PaisId = objeto.PaisId;
                paise.Nombre = objeto.Nombre;
                _context.Paises.Add(paise);
                //_context.SaveChanges();
                _context.Entry(paise).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                foreach (RegioneLo regione in objeto.Regiones)
                {
                    Regione region = new Regione();
                    region.RegionId = regione.RegionId;
                    region.PaisId = paise.PaisId;
                    region.Nombre = regione.Nombre;
                    _context.Entry(region).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    //_context.Regiones.Add(region);
                    //_context.SaveChanges();
                    foreach (ComunaLo comuna in regione.Comunas)
                    {
                        Comuna comunaTmp = new Comuna();
                        comunaTmp.ComunaId = comuna.ComunaId;
                        comunaTmp.RegionId = region.RegionId;
                        comunaTmp.Nombre = comuna.Nombre;
                        _context.Entry(comunaTmp).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        ///_context.Comunas.Add(comunaTmp);
                        //_context.SaveChanges();
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init Localizacion " + ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
            /*if (id != paise.PaisId)
            {
                return BadRequest();
            }

            _context.Entry(paise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();*/
        }

        // POST: api/Localizacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Save([FromBody] Localizacion objeto)
        {
            try
            {
                _logger.LogInformation("Init Localizacion Save");

                Paise paise = new Paise();
                paise.Nombre = objeto.Nombre;
                _context.Paises.Add(paise);
                _context.SaveChanges();

                foreach (RegioneLo regione in objeto.Regiones) { 
                    Regione region = new Regione();
                    region.PaisId = paise.PaisId;
                    region.Nombre = regione.Nombre;
                    _context.Regiones.Add(region);
                    _context.SaveChanges();
                    foreach (ComunaLo comuna in regione.Comunas)
                    {
                        Comuna comunaTmp = new Comuna();
                        comunaTmp.RegionId = region.RegionId;
                        comunaTmp.Nombre= comuna.Nombre;
                        _context.Comunas.Add(comunaTmp);
                        _context.SaveChanges();
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init Localizacion " + ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }

        // DELETE: api/Localizacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaise(int id)
        {
            _logger.LogInformation("Init Localizacion DeletePaise");

            if (_context.Paises == null)
            {
                return NotFound();
            }
            var paise = await _context.Paises.FindAsync(id);
            if (paise == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaiseExists(int id)
        {
            return (_context.Paises?.Any(e => e.PaisId == id)).GetValueOrDefault();
        }
    }
}
