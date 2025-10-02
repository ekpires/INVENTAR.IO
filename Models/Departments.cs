using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace INVENTAR.IO.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    public class Departments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [NotNull]
        [StringLength(100)]
        [DisplayName("Department")]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
