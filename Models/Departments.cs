using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace INVENTAR.IO.Models
{
    public class Departments
    {
        [Key]
        [NotNull]
        [DisplayName("Department")]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
