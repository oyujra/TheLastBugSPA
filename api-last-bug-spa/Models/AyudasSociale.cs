using System;
using System.Collections.Generic;

namespace api_last_bug_spa.Models;

public partial class AyudasSociale
{
    public int AyudaSocialId { get; set; }

    public string? Nombre { get; set; }

    public int? ComunaId { get; set; }

    public virtual ICollection<AsignacionesAyudaSocial> AsignacionesAyudaSocials { get; set; } = new List<AsignacionesAyudaSocial>();

    public virtual Comuna? Comuna { get; set; }
}
