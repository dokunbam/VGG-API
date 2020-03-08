using Microsoft.EntityFrameworkCore.Migrations;

namespace VGG_API.Migrations
{
    public partial class ProjectActionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "Actions");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Actions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ProjectId",
                table: "Actions",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Projects_ProjectId",
                table: "Actions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Projects_ProjectId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_ProjectId",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Actions");

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "Actions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
