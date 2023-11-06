using api_last_bug_spa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;

namespace api_last_bug_spa.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AyudasSocialesController : ControllerBase
    {
        private readonly LastBugSpaContext _context;
        public readonly ILogger<AyudasSocialesController> _logger;

        public AyudasSocialesController(LastBugSpaContext context, ILogger<AyudasSocialesController> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogInformation("Init AyudasSociales ");
        }

        // GET: api/AyudasSociales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AyudasSocialePersona>>> GetAyudasSociales()
        {
            _logger.LogInformation("Init AyudasSocialePersona");

            List<AyudasSocialePersona> lista = new List<AyudasSocialePersona>();
            try
            {
                if (_context.AyudasSociales == null)
                {
                    return NotFound();
                }
                //return await _context.AyudasSociales.ToListAsync();
                lista = await _context.Personas
                    .Join(_context.AsignacionesAyudaSocials, persona => persona.PersonaId, asignacion => asignacion.PersonaId, (persona, asignacion) => new { Persona = persona, Asignacion = asignacion })
                    .Join(_context.AyudasSociales, pa => pa.Asignacion.AyudaSocialId, ayudaSocial => ayudaSocial.AyudaSocialId, (pa, ayudaSocial) => new AyudasSocialePersona
                    {
                        AyudaSocialId = ayudaSocial.AyudaSocialId,
                        AyudaSocialNombre = ayudaSocial.Nombre,
                        ComunaId = (int)ayudaSocial.ComunaId,
                        PersonaId = pa.Persona.PersonaId,
                        PersonaNombre = pa.Persona.Nombre,
                        PersonaCorreoElectronico = pa.Persona.CorreoElectronico,
                        Fecha = pa.Asignacion.Fecha

                    })
                    .ToListAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok", response = lista });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init AyudasSocialePersona "+ ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message, response = lista });
            }
        }

        // GET: api/AyudasSociales
        [HttpGet("PersonaId")]
        public async Task<ActionResult<IEnumerable<AyudasSocialePersona>>> GetAyudasSociales(int PersonaId)
        {
            List<AyudasSocialePersona> lista = new List<AyudasSocialePersona>();
            try
            {
                _logger.LogInformation("Init AyudasSociales GetAyudasSociales");

                if (_context.AyudasSociales == null)
                {
                    return NotFound();
                }
                //return await _context.AyudasSociales.ToListAsync();
                lista = await _context.Personas
                    .Join(_context.AsignacionesAyudaSocials, persona => persona.PersonaId, asignacion => asignacion.PersonaId, (persona, asignacion) => new { Persona = persona, Asignacion = asignacion })
                    .Join(_context.AyudasSociales, pa => pa.Asignacion.AyudaSocialId, ayudaSocial => ayudaSocial.AyudaSocialId, (pa, ayudaSocial) => new AyudasSocialePersona
                    {
                        AyudaSocialId = ayudaSocial.AyudaSocialId,
                        AyudaSocialNombre = ayudaSocial.Nombre,
                        ComunaId = (int)ayudaSocial.ComunaId,
                        PersonaId = pa.Persona.PersonaId,
                        PersonaNombre = pa.Persona.Nombre,
                        PersonaCorreoElectronico = pa.Persona.CorreoElectronico,
                        Fecha = pa.Asignacion.Fecha

                    }).Where(p => p.PersonaId == PersonaId)
                    .ToListAsync();

                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok", response = lista });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init AyudasSocialePersona " + ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message, response = lista });
            }
        }


        // GET: api/AyudasSociales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AyudasSociale>> GetAyudasSociale(int id)
        {
            _logger.LogInformation("Init AyudasSociales GetAyudasSociale");

            if (_context.AyudasSociales == null)
            {
                return NotFound();
            }
            var ayudasSociale = await _context.AyudasSociales.FindAsync(id);

            if (ayudasSociale == null)
            {

                return NotFound();
            }

            return ayudasSociale;
        }

        // PUT: api/AyudasSociales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAyudasSociale(int id, AyudasSociale ayudasSociale)
        {
            _logger.LogInformation("Init AyudasSociales PutAyudasSociale");

            if (id != ayudasSociale.AyudaSocialId)
            {
                return BadRequest();
            }

            _context.Entry(ayudasSociale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AyudasSocialeExists(id))
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

        // POST: api/AyudasSociales
        //A una persona no se le puede asignar más de una vez con el mismo servicio social el mismo año.
        [HttpPost]
        public async Task<ActionResult<AyudasSociale>> PostAyudasSociale( LocalizacionAsignado ayudasSociale)
        {
            try
            {
                _logger.LogInformation("Init AyudasSociales PostAyudasSociale");

                if (!ComunaExists(ayudasSociale.PersonaId, (int)ayudasSociale.ComunaId))
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensage = "La Persona no esta asignada a la comuna " });
                }
                DateTime myDateTime = DateTime.Parse(ayudasSociale.Fecha.ToString());
                int year = myDateTime.Year;

                var asignacionExistente = _context.AsignacionesAyudaSocials
                    .Where(a => a.PersonaId == ayudasSociale.PersonaId && a.AyudaSocialId == ayudasSociale.AyudaSocialId && a.Fecha.HasValue && a.Fecha.Value.Year == year)
    .FirstOrDefault();
                if (asignacionExistente!=null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensage = "La Persona ya tiene asignado un Ayuda Social " });
                }
                AsignacionesAyudaSocial asignacionesAyudaSocial = new AsignacionesAyudaSocial();

                asignacionesAyudaSocial.Fecha = ayudasSociale.Fecha;
                asignacionesAyudaSocial.AyudaSocialId = ayudasSociale.AyudaSocialId;
                asignacionesAyudaSocial.PersonaId = ayudasSociale.PersonaId;
                _context.AsignacionesAyudaSocials.Add(asignacionesAyudaSocial);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init AyudasSocialePersona " + ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }


        [HttpPost("SaveComuna")]
        public IActionResult Save([FromBody] AyudasSociale ayudasSociale)
        {
            try
            {
                _logger.LogInformation("Init AyudasSociales Save");

                _context.AyudasSociales.Add(ayudasSociale);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init AyudasSocialePersona " + ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }
        [HttpPost("SaveRegion")]
        public async Task<ActionResult> SaveRegion([FromBody] AyudasSocialeRegion ayudasSociale)
        {
            try
            {
                _logger.LogInformation("Init AyudasSociales SaveRegion");

                List<Comuna> comunas = new List<Comuna>();
                List<AyudasSociale> ayudasSociale1 = new List<AyudasSociale>();
                comunas = await _context.Comunas.Where(r => r.RegionId == ayudasSociale.RegionID).ToListAsync();
                foreach (Comuna comuna in comunas)
                {
                    AyudasSociale ayudasSocialeTmp = new AyudasSociale();
                    ayudasSocialeTmp.Nombre = ayudasSociale.Nombre;
                    ayudasSocialeTmp.ComunaId = comuna.ComunaId;
                    ayudasSociale1.Add(ayudasSocialeTmp);
                }
                _context.AyudasSociales.AddRange(ayudasSociale1);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Init AyudasSocialePersona " + ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }
        // DELETE: api/AyudasSociales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAyudasSociale(int id)
        {
            _logger.LogInformation("Init AyudasSociales DeleteAyudasSociale");

            if (_context.AyudasSociales == null)
            {
                return NotFound();
            }
            var ayudasSociale = await _context.AyudasSociales.FindAsync(id);
            if (ayudasSociale == null)
            {
                return NotFound();
            }

            _context.AyudasSociales.Remove(ayudasSociale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AyudasSocialeExists(int id)
        {
            _logger.LogInformation("Init AyudasSociales AyudasSocialeExists");

            return (_context.AyudasSociales?.Any(e => e.AyudaSocialId == id)).GetValueOrDefault();
        }
        private bool ComunaExists(int PersonaId, int ComunaId)
        {
            _logger.LogInformation("Init AyudasSociales ComunaExists");

            return (_context.Personas?.Any(e => e.PersonaId == PersonaId && e.ComunaId == ComunaId)).GetValueOrDefault();
        }
    }
}
