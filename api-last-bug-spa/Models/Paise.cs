using System;
using System.Collections.Generic;

namespace api_last_bug_spa.Models;

public partial class Paise
{
    public int PaisId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Regione> Regiones { get; set; } = new List<Regione>();
}
