using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using api_last_bug_spa.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace api_last_bug_spa.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        public readonly LastBugSpaContext _lastBugSpaContext;
        public PaisesController(LastBugSpaContext _context) {
            _lastBugSpaContext = _context;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPaises() { 
            List<Paise> lista = new List<Paise>();
            try { 
                lista = _lastBugSpaContext.Paises.Include(o=>o.Regiones).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensage="ok", response = lista});
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message, response = lista });
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetPais(int PaisID)
        {
            Paise paise = _lastBugSpaContext.Paises.Find(PaisID);
            if (paise == null) { 
            return BadRequest("Pais no encontrado");
            }
            try
            {
                paise = _lastBugSpaContext.Paises.Include(c=>c.Regiones).Where(p=>p.PaisId==PaisID).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok", response = paise });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message, response = paise });
            }
        }
        [HttpPost]
        public IActionResult Save([FromBody] Paise objeto)
        {
            try
            {
                _lastBugSpaContext.Paises.Add(objeto);
                _lastBugSpaContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] Paise objeto)
        {
            Paise paise = _lastBugSpaContext.Paises.Find(objeto.PaisId);
            if (paise == null)
            {
                return BadRequest("Pais no encontrado");
            }
            try
            {
                paise.Nombre = objeto.Nombre is null ? paise.Nombre : objeto.Nombre;
                _lastBugSpaContext.Update(paise);
                _lastBugSpaContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Paise paise = _lastBugSpaContext.Paises.Find(id);
            if (paise == null)
            {
                return BadRequest("Pais no encontrado");
            }
            try
            {
                _lastBugSpaContext.Remove(paise);
                _lastBugSpaContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }
    }
}
