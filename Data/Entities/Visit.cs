using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HandOffApiCli.Data.Entities
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        
        public DateTime VisitDate { get; set; }

        public string? VisitCheifComplaint { get; set; }

        public virtual int? Visit_PatientId { get; set; }

        [ForeignKey("Visit_PatientId")]
        [JsonIgnore]
        public virtual Patient? Patients { get; set; }
    }
}
