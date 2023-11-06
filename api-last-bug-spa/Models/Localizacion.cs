using System.Drawing;

namespace api_last_bug_spa.Models
{
    public class Localizacion
    {
        public int PaisId { get; set; }
        public string? Nombre { get; set; }
        public List<RegioneLo> Regiones { get; set; } = new List<RegioneLo>();
    }
    public class RegioneLo
    {
        public int RegionId { get; set; }

        public string? Nombre { get; set; }

        public int? PaisId { get; set; }

        public List<ComunaLo> Comunas { get; set; } = new List<ComunaLo>();

    }
    public class ComunaLo
    {
        public int ComunaId { get; set; }

        public string? Nombre { get; set; }

        public int? RegionId { get; set; }
    }
}
