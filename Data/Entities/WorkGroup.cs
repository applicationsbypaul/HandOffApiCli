using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class WorkGroup
    {
        [Key] 
        public int id { get; set; }
        public indexer wg_employee_id { get; set; }
    }
}
