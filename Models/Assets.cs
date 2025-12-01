using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INVENTAR.IO.Models
{
    [Index(nameof(AssetId), IsUnique = true)]
    public class Assets
    {
        [Key, Required, DisplayName("Asset Code")]
        public string AssetId{ get; set; } = string.Empty;

        [DisplayName("Owner"), ForeignKey(nameof(Colaborators.ColaboratorId))]
        public int? ColaboratorId { get; set; }
        public virtual Colaborators? Colaborator { get; set; } = default!;
    
        [Required, ForeignKey(nameof(Products.ProductId)), DisplayName("Product")]
        public int ProductId { get; set; }
        public virtual Products Product {  get; set; } = default!;
    }
}
