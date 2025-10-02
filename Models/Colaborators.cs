using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INVENTAR.IO.Models
{
    [Index(nameof(ColaboratorEmail), IsUnique = true)]
    public class Colaborators
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColaboratorId { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Name")]
        public string ColaboratorName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [DisplayName("E-mail")]
        public string ColaboratorEmail { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(Departments.DepartmentId))]
        public int DepartmentId { get; set; }
        public virtual Departments Department { get; set; } = default!;
    }
}
