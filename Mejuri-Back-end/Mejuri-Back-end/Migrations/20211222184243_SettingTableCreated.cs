using Microsoft.EntityFrameworkCore.Migrations;

namespace Mejuri_Back_end.Migrations
{
    public partial class SettingTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomePageImg = table.Column<string>(maxLength: 150, nullable: true),
                    HomePageInfo = table.Column<string>(maxLength: 50, nullable: true),
                    LocationImg = table.Column<string>(maxLength: 150, nullable: true),
                    LocationTitle = table.Column<string>(maxLength: 25, nullable: true),
                    LocationSubTitle = table.Column<string>(maxLength: 50, nullable: true),
                    ShopImg = table.Column<string>(maxLength: 150, nullable: true),
                    CompanyImg = table.Column<string>(maxLength: 150, nullable: true),
                    Fb = table.Column<string>(maxLength: 100, nullable: true),
                    Twitter = table.Column<string>(maxLength: 50, nullable: true),
                    Insta = table.Column<string>(maxLength: 50, nullable: true),
                    Pinterest = table.Column<string>(maxLength: 50, nullable: true),
                    CopyRight = table.Column<string>(maxLength: 150, nullable: true),
                    FbUrl = table.Column<string>(maxLength: 150, nullable: true),
                    InstaUrl = table.Column<string>(maxLength: 150, nullable: true),
                    PinterestUrl = table.Column<string>(maxLength: 150, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
