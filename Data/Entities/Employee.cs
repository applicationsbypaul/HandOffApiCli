﻿using System.ComponentModel.DataAnnotations;
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
        public int? JobDetailId { get; set; }
        public JobDetail? JobDetail { get; set; }
    }
}
