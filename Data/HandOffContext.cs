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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Handoff> Handoffs { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<WorkGroup> WorkGroups { get; set; }
    }
}
