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
            optionsBuilder.UseSqlServer("server=127.0.0.1;uid=root;pwd=Star5820!;database=test");
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
