using api_last_bug_spa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Serilog;


namespace api_last_bug_spa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;
        public readonly LastBugSpaContext _context;
        public readonly ILogger<AutenticacionController> _logger;
        public AutenticacionController(LastBugSpaContext context, IConfiguration config, ILogger<AutenticacionController> logger)
        {
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            _context = context;
            _logger = logger;
            _logger.LogInformation("Init Login");

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Validar([FromBody] Login request)
        {
            _logger.LogInformation("Login Validar");

            var user = Authenticate(request);
            if (user != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.UserName));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else
            {

                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
        private Usuario Authenticate(Login userLogin)
        {
            _logger.LogInformation("Login Authenticate");
            var currentUser = _context.Usuarios.FirstOrDefault(user => user.CorreoElectronico.ToLower() == userLogin.UserName.ToLower()
                   && user.Contrasena == userLogin.Password);

            if (currentUser != null)
            {
                _logger.LogInformation("Login Authenticate null");

                return currentUser;
            }

            return null;
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                _logger.LogInformation("PostUsuario Authenticate ");

                usuario.UsuarioId = null;
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensage = "ok" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("PostUsuario Authenticate "+ ex.Message);

                return StatusCode(StatusCodes.Status200OK, new { mensage = ex.Message });
            }
        }
    }
}