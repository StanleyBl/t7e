using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace t7e.db.Migrations
{
    public partial class AddedCreationOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TranslationKeys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "TranslationKeys",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "TranslationKeys");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "TranslationKeys");
        }
    }
}
