using Microsoft.EntityFrameworkCore.Migrations;

namespace t7e.db.Migrations
{
    public partial class ProjectLangugaeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProjectLanguages",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProjectLanguages");
        }
    }
}
