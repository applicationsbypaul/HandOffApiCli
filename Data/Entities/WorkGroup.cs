using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class WorkGroup
    {
        [Key] 
        public int id { get; set; }
        public int wg_employee_id { get; set; }
    }
}
