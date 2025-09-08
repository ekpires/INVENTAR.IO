using System.ComponentModel.DataAnnotations;

namespace INVENTAR.IO.Models
{
    public class Sector
    {
        [Key]
        public string SectorName { get; set; } = string.Empty;
    }
}
