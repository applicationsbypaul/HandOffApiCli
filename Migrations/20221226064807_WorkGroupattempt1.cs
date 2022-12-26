using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class WorkGroupattempt1 : Migration
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
                name: "WorkGroups",
                columns: table => new
                {
                    WorkGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroups", x => x.WorkGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeJobDetailId = table.Column<int>(type: "int", nullable: true),
                    WorkGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_WorkGroups_WorkGroupId",
                        column: x => x.WorkGroupId,
                        principalTable: "WorkGroups",
                        principalColumn: "WorkGroupId");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeFirstName", "EmployeeJobDetailId", "EmployeeLastName", "WorkGroupId" },
                values: new object[,]
                {
                    { 1, "Paul", null, "Ford", null },
                    { 2, "Amy", null, "Eisenberg", null },
                    { 3, "Tom", null, "Hardy", null },
                    { 4, "John", null, "Grossman", null },
                    { 5, "Olivia", null, "Mundain", null },
                    { 6, "Jessica", null, "Stone", null }
                });

            migrationBuilder.InsertData(
                table: "JobDetails",
                columns: new[] { "JobDetailId", "JobDescription" },
                values: new object[,]
                {
                    { 1, "Registerd Nurse" },
                    { 2, "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkGroupId",
                table: "Employees",
                column: "WorkGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobDetails");

            migrationBuilder.DropTable(
                name: "WorkGroups");
        }
    }
}
