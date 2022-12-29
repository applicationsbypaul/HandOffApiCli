using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class PatientstoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientBirthDate", "PatientCity", "PatientFirstName", "PatientLastName", "PatientPhone", "PatientPrimaryDoctorId" },
                values: new object[] { 1, new DateTime(1987, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Steve", "Rogers", "555-555-5555", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
