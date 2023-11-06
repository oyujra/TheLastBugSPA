using api_last_bug_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Services
{
    public class AsignacionAyudaSocialService
    {
        private readonly LastBugSpaContext _context;

        public AsignacionAyudaSocialService(LastBugSpaContext context)
        {
            _context = context;
        }

        public async Task<List<AsignacionesAyudaSocial>> GetAsignacionesAyudaSocials()
        {
            if (_context.AsignacionesAyudaSocials == null)
            {
                return null;
            }
            return await _context.AsignacionesAyudaSocials.ToListAsync();
        }

        public async Task<AsignacionesAyudaSocial> GetAsignacionAyudaSocial(int id)
        {
            if (_context.AsignacionesAyudaSocials == null)
            {
                return null;
            }
            return await _context.AsignacionesAyudaSocials.FindAsync(id);
        }

        public async Task<bool> UpdateAsignacionAyudaSocial(int id, AsignacionesAyudaSocial asignacionAyudaSocial)
        {
            if (id != asignacionAyudaSocial.AsignacionId)
            {
                return false;
            }

            _context.Entry(asignacionAyudaSocial).State = EntityState.Modified;

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

        public async Task<AsignacionesAyudaSocial> CreateAsignacionAyudaSocial(AsignacionesAyudaSocial asignacionAyudaSocial)
        {
            if (_context.AsignacionesAyudaSocials == null)
            {
                return null;
            }

            _context.AsignacionesAyudaSocials.Add(asignacionAyudaSocial);
            await _context.SaveChangesAsync();

            return asignacionAyudaSocial;
        }

        public async Task<bool> DeleteAsignacionAyudaSocial(int id)
        {
            if (_context.AsignacionesAyudaSocials == null)
            {
                return false;
            }

            var asignacionAyudaSocial = await _context.AsignacionesAyudaSocials.FindAsync(id);
            if (asignacionAyudaSocial == null)
            {
                return false;
            }

            _context.AsignacionesAyudaSocials.Remove(asignacionAyudaSocial);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool AsignacionAyudaSocialExists(int id)
        {
            return _context.AsignacionesAyudaSocials?.Any(e => e.AsignacionId == id) ?? false;
        }
    }
}