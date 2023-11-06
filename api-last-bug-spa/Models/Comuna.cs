using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api_last_bug_spa.Models;

public partial class Comuna
{
    public int ComunaId { get; set; }

    public string? Nombre { get; set; }
    [JsonIgnore]

    public int? RegionId { get; set; }
    [JsonIgnore]
    public virtual ICollection<AyudasSociale> AyudasSociales { get; set; } = new List<AyudasSociale>();
    [JsonIgnore]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
    [JsonIgnore]
    public virtual Regione? Region { get; set; }
}
