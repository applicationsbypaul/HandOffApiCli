using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class JobDetail
    {
        [Key]
        public int JobDetailId { get; set; }
        [MaxLength(80)]
        public string? JobDescription { get; set; }
    }
}
