using api_last_bug_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace api_last_bug_spa.Services
{
    public class UsuariosService
    {
        private readonly LastBugSpaContext _context;

        public UsuariosService(LastBugSpaContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            if (_context.Usuarios == null)
            {
                return null;
            }

            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return null;
            }

            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<bool> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return false;
            }

            _context.Entry(usuario).State = EntityState.Modified;

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

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            if (_context.Usuarios == null)
            {
                return null;
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return false;
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Usuario> Authenticate(Login userLogin)
        {

            var currentUser =  _context.Usuarios.FirstOrDefault(user => user.CorreoElectronico.ToLower() == userLogin.UserName.ToLower()
                   && user.Contrasena == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
        public bool UsuarioExists(int id)
        {
            return _context.Usuarios?.Any(e => e.UsuarioId == id) ?? false;
        }
    }
}
