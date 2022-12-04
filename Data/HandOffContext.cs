using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Data
{
    public class HandOffContext : DbContext
    {
        public HandOffContext(DbContextOptions<HandOffContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("");
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
