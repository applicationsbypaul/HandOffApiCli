using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeJobDetailId = table.Column<int>(name: "Employee_JobDetailId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_JobDetails_Employee_JobDetailId",
                        column: x => x.EmployeeJobDetailId,
                        principalTable: "JobDetails",
                        principalColumn: "JobDetailId");
                });

            migrationBuilder.CreateTable(
                name: "Handoffs",
                columns: table => new
                {
                    Handoffid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandoffExecution = table.Column<bool>(type: "bit", nullable: false),
                    HandoffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HandoffEmployeeCurrentId = table.Column<int>(name: "Handoff_Employee_CurrentId", type: "int", nullable: true),
                    HandoffEmployeeNextId = table.Column<int>(name: "Handoff_Employee_NextId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handoffs", x => x.Handoffid);
                    table.ForeignKey(
                        name: "FK_Handoffs_Employees_Handoff_Employee_CurrentId",
                        column: x => x.HandoffEmployeeCurrentId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Handoffs_Employees_Handoff_Employee_NextId",
                        column: x => x.HandoffEmployeeNextId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
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
                    PatientEmployeeId = table.Column<int>(name: "Patient_EmployeeId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Employees_Patient_EmployeeId",
                        column: x => x.PatientEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitCheifComplaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitPatientId = table.Column<int>(name: "Visit_PatientId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_Visit_PatientId",
                        column: x => x.VisitPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeFirstName", "EmployeeLastName", "Employee_JobDetailId" },
                values: new object[,]
                {
                    { 2, "Amy", "Eisenberg", null },
                    { 3, "Tom", "Hardy", null },
                    { 4, "John", "Grossman", null },
                    { 5, "Olivia", "Mundain", null },
                    { 6, "Jessica", "Stone", null }
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
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeFirstName", "EmployeeLastName", "Employee_JobDetailId" },
                values: new object[] { 1, "Paul", "Ford", 2 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientBirthDate", "PatientCity", "PatientFirstName", "PatientLastName", "PatientPhone", "Patient_EmployeeId" },
                values: new object[] { 1, new DateTime(1987, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Steve", "Rogers", "555-555-5555", 1 });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitId", "VisitCheifComplaint", "VisitDate", "Visit_PatientId" },
                values: new object[] { 1, "HeadAche", new DateTime(2023, 1, 12, 3, 55, 33, 778, DateTimeKind.Utc).AddTicks(5180), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Employee_JobDetailId",
                table: "Employees",
                column: "Employee_JobDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Handoffs_Handoff_Employee_CurrentId",
                table: "Handoffs",
                column: "Handoff_Employee_CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Handoffs_Handoff_Employee_NextId",
                table: "Handoffs",
                column: "Handoff_Employee_NextId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patient_EmployeeId",
                table: "Patients",
                column: "Patient_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_Visit_PatientId",
                table: "Visits",
                column: "Visit_PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Handoffs");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobDetails");
        }
    }
}
