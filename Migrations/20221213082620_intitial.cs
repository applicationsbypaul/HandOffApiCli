using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class intitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeefname = table.Column<string>(name: "employee_fname", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    employeelname = table.Column<string>(name: "employee_lname", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    employeejobdescriptionId = table.Column<int>(name: "employee_job_descriptionId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Handoffs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    handoffexecution = table.Column<bool>(name: "handoff_execution", type: "bit", nullable: false),
                    handoffdate = table.Column<DateTime>(name: "handoff_date", type: "datetime2", nullable: false),
                    handoffemployeecurrentid = table.Column<int>(name: "handoff_employee_current_id", type: "int", nullable: false),
                    handoffemployeenextid = table.Column<int>(name: "handoff_employee_next_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handoffs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "JobDescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobdescription = table.Column<string>(name: "job_description", type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    visitdate = table.Column<DateTime>(name: "visit_date", type: "datetime2", nullable: false),
                    visithandoffid = table.Column<int>(name: "visit_handoff_id", type: "int", nullable: true),
                    workgroupid = table.Column<int>(name: "work_group_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WorkGroups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wgemployeeid = table.Column<int>(name: "wg_employee_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientfname = table.Column<string>(name: "patient_fname", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patientlname = table.Column<string>(name: "patient_lname", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patientcity = table.Column<string>(name: "patient_city", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    patientphone = table.Column<string>(name: "patient_phone", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    patientvisitID = table.Column<int>(name: "patient_visitID", type: "int", nullable: true),
                    patientprimarycareid = table.Column<int>(name: "patient_primary_care_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Patients_Visits_patient_visitID",
                        column: x => x.patientvisitID,
                        principalTable: "Visits",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_patient_visitID",
                table: "Patients",
                column: "patient_visitID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Handoffs");

            migrationBuilder.DropTable(
                name: "JobDescriptions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "WorkGroups");

            migrationBuilder.DropTable(
                name: "Visits");
        }
    }
}
