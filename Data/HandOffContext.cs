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
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
