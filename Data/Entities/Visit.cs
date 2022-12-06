using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class Visit
    {
        [Key]
        public int id { get; set; }
        public DateTime visit_date { get; set; }
        [Required]
        public int visit_handoff_id { get; set; }
        public int work_group_id { get; set; }
    }
}
