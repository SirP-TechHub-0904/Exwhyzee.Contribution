using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exwhyzee.Contribution.Web.Migrations
{
    public partial class ipnumber6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "AspNetUsers");
        }
    }
}
