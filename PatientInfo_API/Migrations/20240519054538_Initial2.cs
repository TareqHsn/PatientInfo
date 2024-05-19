using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInfo_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NDC_Id",
                table: "NCD_Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NDC_Id",
                table: "NCD_Details",
                type: "int",
                nullable: true);
        }
    }
}
