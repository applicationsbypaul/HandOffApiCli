using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class fklastloljkloljklmafo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobDetails_JobDetailId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobDetailId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobDetailId",
                table: "Employees",
                column: "JobDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobDetails_JobDetailId",
                table: "Employees",
                column: "JobDetailId",
                principalTable: "JobDetails",
                principalColumn: "JobDetailId");
        }
    }
}
