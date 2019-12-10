using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class ShopInitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "tblShop",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblShop_UserId",
                table: "tblShop",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblShop_AspNetUsers_UserId",
                table: "tblShop",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblShop_AspNetUsers_UserId",
                table: "tblShop");

            migrationBuilder.DropIndex(
                name: "IX_tblShop_UserId",
                table: "tblShop");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblShop");
        }
    }
}
