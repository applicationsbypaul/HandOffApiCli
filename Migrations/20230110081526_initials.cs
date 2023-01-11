using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeJobDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    JobDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.JobDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PatientLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PatientCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PatientPhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PatientBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientPrimaryDoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitCheifComplaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeFirstName", "EmployeeJobDetailId", "EmployeeLastName" },
                values: new object[,]
                {
                    { 1, "Paul", null, "Ford" },
                    { 2, "Amy", null, "Eisenberg" },
                    { 3, "Tom", null, "Hardy" },
                    { 4, "John", null, "Grossman" },
                    { 5, "Olivia", null, "Mundain" },
                    { 6, "Jessica", null, "Stone" }
                });

            migrationBuilder.InsertData(
                table: "JobDetails",
                columns: new[] { "JobDetailId", "JobDescription" },
                values: new object[,]
                {
                    { 1, "Registerd Nurse" },
                    { 2, "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientBirthDate", "PatientCity", "PatientFirstName", "PatientLastName", "PatientPhone", "PatientPrimaryDoctorId" },
                values: new object[] { 1, new DateTime(1987, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Steve", "Rogers", "555-555-5555", null });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitId", "PatientId", "VisitCheifComplaint", "VisitDate" },
                values: new object[] { 1, null, "HeadAche", new DateTime(2023, 1, 10, 8, 15, 26, 762, DateTimeKind.Utc).AddTicks(3569) });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobDetails");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
