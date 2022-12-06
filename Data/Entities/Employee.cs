using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        [Required]
        [StringLength(50)]
        public string employee_fname { get; set; }
        [MaxLength(50)]
        [Required]
        [StringLength(50)]
        public string employee_lname { get; set; }
        public int employee_job_description { get; set; }
    }
}
