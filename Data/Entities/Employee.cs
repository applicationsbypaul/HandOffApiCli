using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandOffApiCli.Data.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [MaxLength(50)]
        [Required]
        [StringLength(50)]
        public string? EmployeeFirstName { get; set; }
        [MaxLength(50)]
        [Required]
        [StringLength(50)]
        public string? EmployeeLastName { get; set; }
        [ForeignKey("JobDetailId")]
        public int? EmployeeJobDetailId { get; set; }
    }
}
