using Microsoft.EntityFrameworkCore.Migrations;

namespace Mejuri_Back_end.Migrations
{
    public partial class IsDeletedAddIntoCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Companies");
        }
    }
}
