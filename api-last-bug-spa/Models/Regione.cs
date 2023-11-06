using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_last_bug_spa.Models;

public partial class Regione
{
    public int RegionId { get; set; }

    public string? Nombre { get; set; }
    [JsonIgnore]

    public int? PaisId { get; set; }

    public virtual ICollection<Comuna> Comunas { get; set; } = new List<Comuna>();
    [JsonIgnore]

    public virtual Paise? Pais { get; set; }
}
