using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class fkjobdescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobDetails",
                keyColumn: "JobDetailId",
                keyValue: 1,
                column: "JobDescription",
                value: "Registerd Nurse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobDetails",
                keyColumn: "JobDetailId",
                keyValue: 1,
                column: "JobDescription",
                value: "Register Nurse");
        }
    }
}
