using Microsoft.EntityFrameworkCore.Migrations;

namespace Mejuri_Back_end.Migrations
{
    public partial class BasketitemCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductColorId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketItems_ProductColors_ProductColorId",
                        column: x => x.ProductColorId,
                        principalTable: "ProductColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_AppUserId",
                table: "BasketItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductColorId",
                table: "BasketItems",
                column: "ProductColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");
        }
    }
}
