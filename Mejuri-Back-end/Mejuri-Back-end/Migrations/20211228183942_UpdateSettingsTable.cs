using Microsoft.EntityFrameworkCore.Migrations;

namespace Mejuri_Back_end.Migrations
{
    public partial class UpdateSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactImg",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactSubtitle1",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactSubtitle2",
                table: "Settings",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Settings",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqImg",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqTitle",
                table: "Settings",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactSubtitle1",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactSubtitle2",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FaqImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FaqTitle",
                table: "Settings");
        }
    }
}
