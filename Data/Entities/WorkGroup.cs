using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandOffApiCli.Data.Entities
{
    public class WorkGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkGroupId { get; set; }
        public ICollection<Employee?> WorkGroup_Employees { get; set; }
    }
}
