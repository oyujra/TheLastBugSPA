using api_last_bug_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Services
{
    public class ComunaService
    {
        private readonly LastBugSpaContext _context;

        public ComunaService(LastBugSpaContext context)
        {
            _context = context;
        }

        public async Task<List<Comuna>> GetComunas()
        {
            if (_context.Comunas == null)
            {
                return null;
            }
            return await _context.Comunas.ToListAsync();
        }

        public async Task<Comuna> GetComuna(int id)
        {
            if (_context.Comunas == null)
            {
                return null;
            }
            return await _context.Comunas.FindAsync(id);
        }

        public async Task<bool> UpdateComuna(int id, Comuna comuna)
        {
            if (id != comuna.ComunaId)
            {
                return false;
            }

            _context.Entry(comuna).State = EntityState.Modified;

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

        public async Task<Comuna> CreateComuna(Comuna comuna)
        {
            if (_context.Comunas == null)
            {
                return null;
            }

            _context.Comunas.Add(comuna);
            await _context.SaveChangesAsync();

            return comuna;
        }

        public async Task<bool> DeleteComuna(int id)
        {
            if (_context.Comunas == null)
            {
                return false;
            }

            var comuna = await _context.Comunas.FindAsync(id);
            if (comuna == null)
            {
                return false;
            }

            _context.Comunas.Remove(comuna);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool ComunaExists(int id)
        {
            return _context.Comunas?.Any(e => e.ComunaId == id) ?? false;
        }
    }
}
