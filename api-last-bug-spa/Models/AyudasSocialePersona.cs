using System;
using System.Collections.Generic;

namespace api_last_bug_spa.Models;

public partial class AyudasSocialePersona
{
   public int AyudaSocialId { get; set; }
    public string AyudaSocialNombre { get; set; } // Propiedad para el nombre de la ayuda social
    public int ComunaId { get; set; }
    public int PersonaId { get; set; }
    public string PersonaNombre { get; set; } // Propiedad para el nombre de la persona
    public string PersonaCorreoElectronico { get; set; } // Propiedad para el correo electrónico de la persona
    public DateTime? Fecha { get; set; }

}