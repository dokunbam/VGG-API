using Microsoft.EntityFrameworkCore.Migrations;

namespace VGG_API.Migrations
{
    public partial class ActionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedAt",
                table: "Actions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Actions");
        }
    }
}
