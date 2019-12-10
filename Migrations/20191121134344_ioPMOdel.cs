using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class ioPMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopID",
                table: "tblProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_ShopID",
                table: "tblProduct",
                column: "ShopID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblShop_ShopID",
                table: "tblProduct",
                column: "ShopID",
                principalTable: "tblShop",
                principalColumn: "ShopID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblShop_ShopID",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_ShopID",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ShopID",
                table: "tblProduct");
        }
    }
}
