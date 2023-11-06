using api_last_bug_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Services
{
    public class AyudaSocialService
    {
        private readonly LastBugSpaContext _context;

        public AyudaSocialService(LastBugSpaContext context)
        {
            _context = context;
        }

        public async Task<List<AyudasSociale>> GetAyudasSociales()
        {
            if (_context.AyudasSociales == null)
            {
                return null;
            }
            return await _context.AyudasSociales.ToListAsync();
        }

        public async Task<AyudasSociale> GetAyudasSociale(int id)
        {
            if (_context.AyudasSociales == null)
            {
                return null;
            }
            return await _context.AyudasSociales.FindAsync(id);
        }

        public async Task<bool> UpdateAyudasSociale(int id, AyudasSociale ayudasSociale)
        {
            if (id != ayudasSociale.AyudaSocialId)
            {
                return false;
            }

            _context.Entry(ayudasSociale).State = EntityState.Modified;

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

        public async Task<AyudasSociale> CreateAyudasSociale(AyudasSociale ayudasSociale)
        {
            if (_context.AyudasSociales == null)
            {
                return null;
            }

            _context.AyudasSociales.Add(ayudasSociale);
            await _context.SaveChangesAsync();

            return ayudasSociale;
        }

        public async Task<bool> DeleteAyudasSociale(int id)
        {
            if (_context.AyudasSociales == null)
            {
                return false;
            }

            var ayudasSociale = await _context.AyudasSociales.FindAsync(id);
            if (ayudasSociale == null)
            {
                return false;
            }

            _context.AyudasSociales.Remove(ayudasSociale);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool AyudasSocialeExists(int id)
        {
            return _context.AyudasSociales?.Any(e => e.AyudaSocialId == id) ?? false;
        }
    }
}
