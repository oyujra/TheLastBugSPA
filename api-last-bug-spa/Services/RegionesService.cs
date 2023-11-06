using api_last_bug_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Controllers
{
    public class RegionesService
    {
        private readonly LastBugSpaContext _context;

        public RegionesService(LastBugSpaContext context)
        {
            _context = context;
        }

        public async Task<List<Regione>> GetRegiones()
        {
            if (_context.Regiones == null)
            {
                return null;
            }
            return await _context.Regiones.ToListAsync();
        }

        public async Task<Regione> GetRegione(int id)
        {
            if (_context.Regiones == null)
            {
                return null;
            }
            return await _context.Regiones.FindAsync(id);
        }

        public async Task<bool> UpdateRegione(int id, Regione regione)
        {
            if (id != regione.RegionId)
            {
                return false;
            }

            _context.Entry(regione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<Regione> CreateRegione(Regione regione)
        {
            if (_context.Regiones == null)
            {
                return null;
            }

            _context.Regiones.Add(regione);
            await _context.SaveChangesAsync();

            return regione;
        }

        public async Task<bool> DeleteRegione(int id)
        {
            if (_context.Regiones == null)
            {
                return false;
            }

            var regione = await _context.Regiones.FindAsync(id);
            if (regione == null)
            {
                return false;
            }

            _context.Regiones.Remove(regione);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool RegioneExists(int id)
        {
            return _context.Regiones?.Any(e => e.RegionId == id) ?? false;
        }
    }
}

