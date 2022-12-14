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
    [Migration("20221213082620_intitial")]
    partial class intitial
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("employee_fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("employee_job_descriptionId")
                        .HasColumnType("int");

                    b.Property<string>("employee_lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Handoff", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("handoff_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("handoff_employee_current_id")
                        .HasColumnType("int");

                    b.Property<int>("handoff_employee_next_id")
                        .HasColumnType("int");

                    b.Property<bool>("handoff_execution")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Handoffs");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.JobDescription", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("job_description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("id");

                    b.ToTable("JobDescriptions");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("patient_city")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("patient_fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("patient_lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("patient_phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("patient_primary_care_id")
                        .HasColumnType("int");

                    b.Property<int?>("patient_visitID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("patient_visitID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Visit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("visit_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("visit_handoff_id")
                        .HasColumnType("int");

                    b.Property<int?>("work_group_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.WorkGroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("wg_employee_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("WorkGroups");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Patient", b =>
                {
                    b.HasOne("HandOffApiCli.Data.Entities.Visit", "patient_visit")
                        .WithMany("Patients")
                        .HasForeignKey("patient_visitID");

                    b.Navigation("patient_visit");
                });

            modelBuilder.Entity("HandOffApiCli.Data.Entities.Visit", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
