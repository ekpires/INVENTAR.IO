using System.ComponentModel.DataAnnotations;

namespace INVENTAR.IO.Models
{
    public class Departments
    {
        [Key]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
