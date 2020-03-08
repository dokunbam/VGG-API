using Microsoft.EntityFrameworkCore.Migrations;

namespace VGG_API.Migrations
{
    public partial class createdDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateCreated",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateUpdated",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Projects");
        }
    }
}
