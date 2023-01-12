using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        public virtual int? Employee_JobDetailId { get; set; }

        [ForeignKey("Employee_JobDetailId")]
        [JsonIgnore]
        public virtual JobDetail? JobDetails { get; set; }
    }
}
