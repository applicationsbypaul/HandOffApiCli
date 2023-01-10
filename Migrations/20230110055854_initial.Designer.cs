﻿// <auto-generated />
using System;
using HandOffApiCli.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HandOffApiCli.Migrations
{
    [DbContext(typeof(HandOffContext))]
    [Migration("20230110055854_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EmployeeJobDetailId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmployeeFirstName = "Paul",
                            EmployeeLastName = "Ford"
                        },
                        new
                        {
                            EmployeeId = 2,
                            EmployeeFirstName = "Amy",
                            EmployeeLastName = "Eisenberg"
                        },
                        new
                        {
                            EmployeeId = 3,
                            EmployeeFirstName = "Tom",
                            EmployeeLastName = "Hardy"
                        },
                        new
                        {
                            EmployeeId = 4,
                            EmployeeFirstName = "John",
                            EmployeeLastName = "Grossman"
                        },
                        new
                        {
                            EmployeeId = 5,
                            EmployeeFirstName = "Olivia",
                            EmployeeLastName = "Mundain"
                        },
                        new
                        {
                            EmployeeId = 6,
                            EmployeeFirstName = "Jessica",
                            EmployeeLastName = "Stone"
                        });
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.JobDetail", b =>
                {
                    b.Property<int>("JobDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobDetailId"));

                    b.Property<string>("JobDescription")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("JobDetailId");

                    b.ToTable("JobDetails");

                    b.HasData(
                        new
                        {
                            JobDetailId = 1,
                            JobDescription = "Registerd Nurse"
                        },
                        new
                        {
                            JobDetailId = 2,
                            JobDescription = "Doctor"
                        });
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<DateTime>("PatientBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientCity")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PatientFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PatientLastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PatientPhone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("PatientPrimaryDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.HasIndex("VisitId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            PatientBirthDate = new DateTime(1987, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientCity = "Chicago",
                            PatientFirstName = "Steve",
                            PatientLastName = "Rogers",
                            PatientPhone = "555-555-5555",
                            VisitId = 0
                        });
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitId"));

                    b.Property<string>("VisitCheifComplaint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VisitId");

                    b.ToTable("Visits");

                    b.HasData(
                        new
                        {
                            VisitId = 1,
                            VisitCheifComplaint = "HeadAche",
                            VisitDate = new DateTime(2023, 1, 10, 5, 58, 54, 808, DateTimeKind.Utc).AddTicks(7481)
                        });
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Patient", b =>
                {
                    b.HasOne("HandOffApiCli.Data.Entities.Visit", "Visits")
                        .WithMany()
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}