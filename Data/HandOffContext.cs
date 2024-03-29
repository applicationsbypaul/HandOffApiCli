﻿using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Data
{
    public class HandOffContext : DbContext
    {
        public HandOffContext(DbContextOptions<HandOffContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=FKTESTDB;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Handoff> Handoffs { get; set; }
        //public DbSet<WorkGroup> WorkGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, EmployeeFirstName = "Paul", EmployeeLastName = "Ford", Employee_JobDetailId = 2 },
                new Employee() { EmployeeId = 2, EmployeeFirstName = "Amy", EmployeeLastName = "Eisenberg" },
                new Employee() { EmployeeId = 3, EmployeeFirstName = "Tom", EmployeeLastName = "Hardy" },
                new Employee() { EmployeeId = 4, EmployeeFirstName = "John", EmployeeLastName = "Grossman" },
                new Employee() { EmployeeId = 5, EmployeeFirstName = "Olivia", EmployeeLastName = "Mundain" },
                new Employee() { EmployeeId = 6, EmployeeFirstName = "Jessica", EmployeeLastName = "Stone" });

            modelBuilder.Entity<JobDetail>().HasData(
                new JobDetail() { JobDetailId = 1, JobDescription = "Registerd Nurse" },
                new JobDetail() { JobDetailId = 2, JobDescription = "Doctor" });

            modelBuilder.Entity<Patient>().HasData(
                new Patient()
                {
                    PatientId = 1,
                    PatientFirstName = "Steve",
                    PatientLastName = "Rogers",
                    PatientCity = "Chicago",
                    PatientPhone = "555-555-5555",
                    PatientBirthDate = new DateTime(1987,05,21),
                    Patient_EmployeeId = 1
                });
            modelBuilder.Entity<Visit>().HasData(
                new Visit()
                {
                    VisitId = 1,
                    VisitDate = DateTime.UtcNow,
                    VisitCheifComplaint = "HeadAche",
                    Visit_PatientId = 1
                });
        }
    }
}
