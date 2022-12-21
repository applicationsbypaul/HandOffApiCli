﻿// <auto-generated />
using System;
using HandOffApiCli.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HandOffApiCli.Migrations
{
    [DbContext(typeof(HandOffContext))]
    partial class HandOffContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("JobDetailId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("JobDetailId")
                        .IsUnique()
                        .HasFilter("[JobDetailId] IS NOT NULL");

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

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Employee", b =>
                {
                    b.HasOne("HandOffApiCli.Data.Entities.JobDetail", "JobDetail")
                        .WithOne("Employee")
                        .HasForeignKey("HandOffApiCli.Data.Entities.Employee", "JobDetailId");

                    b.Navigation("JobDetail");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.JobDetail", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
