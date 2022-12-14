using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandOffApiCli.Data.Entities
{
    public class Visit
    {
        [Key]
        public int id { get; set; }
        
        public DateTime visit_date { get; set; }
        public int? visit_handoff_id { get; set; }
        public int? work_group_id { get; set; }

        public ICollection<Patient> Patients { get; set; }
        public ICollection<WorkGroup> WorkGroups { get; set; }
    }
}
