using api_last_bug_spa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Services
{
    public class PaisesService
    {
        public readonly LastBugSpaContext _lastBugSpaContext;

        public PaisesService(LastBugSpaContext context)
        {
            _lastBugSpaContext = context;
        }
        public async Task<List<Paise>> GetListaAsync()
        {
            try
            {
                return await _lastBugSpaContext.Paises.Include(o => o.Regiones).ToListAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw ex;
            }
        }

        public async Task<Paise> ObtenerAsync(int PaisID)
        {
            Paise paise = await _lastBugSpaContext.Paises.FindAsync(PaisID);
            if (paise == null)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw new Exception("Pais no encontrado");
            }

            try
            {
                return await _lastBugSpaContext.Paises.Include(c => c.Regiones).Where(p => p.PaisId == PaisID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw ex;
            }
        }

        public async Task GuardarAsync(Paise objeto)
        {
            try
            {
                _lastBugSpaContext.Paises.Add(objeto);
                await _lastBugSpaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw ex;
            }
        }

        public async Task EditarAsync(Paise objeto)
        {
            Paise paise = await _lastBugSpaContext.Paises.FindAsync(objeto.PaisId);
            if (paise == null)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw new Exception("Pais no encontrado");
            }

            try
            {
                paise.Nombre = objeto.Nombre ?? paise.Nombre;
                _lastBugSpaContext.Update(paise);
                await _lastBugSpaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw ex;
            }
        }

        public async Task EliminarAsync(int PaisID)
        {
            Paise paise = await _lastBugSpaContext.Paises.FindAsync(PaisID);
            if (paise == null)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw new Exception("Pais no encontrado");
            }

            try
            {
                _lastBugSpaContext.Remove(paise);
                await _lastBugSpaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Maneja la excepción o lánzala si es necesario.
                throw ex;
            }
        }
    }
}