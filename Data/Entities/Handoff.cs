using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class Handoff
    {
        [Key]
        public int id { get; set; }
        public bool handoff_execution { get; set; }
        public DateTime handoff_date { get; set; }
        public int handoff_employee_current_id { get; set; }
        public int handoff_employee_next_id { get; set; }
    }
}
