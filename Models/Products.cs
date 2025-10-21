using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace INVENTAR.IO.Models
{
    [Index(nameof(ProductName), IsUnique = true)]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Name")]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DisplayName("Model")]
        public string ProductModel{ get; set; } = string.Empty;

        [StringLength(300)]
        [DisplayName("Description")]
        public string ProductDescription { get; set; } = string.Empty;
    }
}
