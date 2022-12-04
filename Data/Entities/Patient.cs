using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string patient_fname { get; set; }
        [MaxLength(50)]
        public string patient_lname { get; set; }
        [MaxLength(50)]
        public string? patient_city { get; set; }
        [MaxLength(25)]
        public string? patient_phone { get; set; }
        public int? patient_vist_id { get; set; }
        public int? patient_primary_care_id { get; set; }
    }
  
}