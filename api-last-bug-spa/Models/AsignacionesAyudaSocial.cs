using System;
using System.Collections.Generic;

namespace api_last_bug_spa.Models;

public partial class AsignacionesAyudaSocial
{
    public int AsignacionId { get; set; }

    public int? PersonaId { get; set; }

    public int? AyudaSocialId { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual AyudasSociale? AyudaSocial { get; set; }

    public virtual Persona? Persona { get; set; }
}
