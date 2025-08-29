using System.ComponentModel.DataAnnotations;

namespace INVENTAR.IO.Models
{
    public class Sector
    {
        [Required]
        [DisplayColumn("Sector")]
        public string SectorName { get; set; }
    }
}
