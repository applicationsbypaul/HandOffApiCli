using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandOffApiCli.Data.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [MaxLength(50)]
        public string? PatientFirstName { get; set; }
        [MaxLength(50)]
        public string? PatientLastName { get; set; }
        [MaxLength(50)]
        public string? PatientCity { get; set; }
        [MaxLength(25)]
        public string? PatientPhone { get; set; }
        public DateTime PatientBirthDate { get; set;}

        public virtual int? Patient_EmployeeId { get; set; }

        [ForeignKey("Patient_EmployeeId")]
        public virtual Employee? Employees { get; set; }
    }
}