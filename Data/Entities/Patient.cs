using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandOffApiCli.Data.Entities
{
    public class Patient
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string patient_fname { get; set; }
        [MaxLength(50)]
        public string patient_lname { get; set; }
        [MaxLength(50)]
        public string? patient_city { get; set; }
        [MaxLength(25)]
        public string? patient_phone { get; set; }

        public int? patient_visitID { get; set; }
        public Visit? patient_visit { get; set; }

        public int? patient_primary_care_id { get; set; }

    }
   }