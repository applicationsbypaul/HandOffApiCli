using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandOffApiCli.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientfname = table.Column<string>(name: "patient_fname", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patientlname = table.Column<string>(name: "patient_lname", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patientcity = table.Column<string>(name: "patient_city", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    patientphone = table.Column<string>(name: "patient_phone", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    patientvistid = table.Column<int>(name: "patient_vist_id", type: "int", nullable: true),
                    patientprimarycareid = table.Column<int>(name: "patient_primary_care_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
