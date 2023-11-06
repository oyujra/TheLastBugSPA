using System;
using System.Collections.Generic;

namespace api_last_bug_spa.Models;

public partial class Usuario
{

    public int? UsuarioId { get; set; } 

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasena { get; set; }

    public string? Rol { get; set; }
}
