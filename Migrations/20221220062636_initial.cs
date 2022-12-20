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
                    JobDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_JobDetails_JobDetailId",
                        column: x => x.JobDetailId,
                        principalTable: "JobDetails",
                        principalColumn: "JobDetailId");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeFirstName", "EmployeeLastName", "JobDetailId" },
                values: new object[,]
                {
                    { 1, "Paul", "Ford", null },
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
                    { 1, "Register Nurse" },
                    { 2, "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobDetailId",
                table: "Employees",
                column: "JobDetailId",
                unique: true,
                filter: "[JobDetailId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobDetails");
        }
    }
}
