using System.ComponentModel.DataAnnotations;

namespace HandOffApiCli.Data.Entities
{
    public class JobDescription
    {
        [Key]
        public int id { get; set; }
        [MaxLength(80)]
        public string job_description { get; set; }
    }
}
