using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandOffApiCli.Data.Entities
{
    public class Handoff
    {
        [Key]
        public int Handoffid { get; set; }
        public bool HandoffExecution { get; set; }
        public DateTime HandoffDate { get; set; }


        public virtual int? Handoff_Employee_CurrentId { get; set; }
        public virtual int? Handoff_Employee_NextId { get; set; }

        [ForeignKey("Handoff_Employee_CurrentId")]
        public virtual Employee? Handoff_Employee_Current { get; set; }
        [ForeignKey(" Handoff_Employee_NextId")]
        public virtual Employee? Handoff_Employee_Next { get; set; }
    }
}
