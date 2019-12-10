using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class ProductUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseDetailID",
                table: "tblProduct",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PurchaseDetailID",
                table: "tblProduct",
                column: "PurchaseDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblPurchaseDetail_PurchaseDetailID",
                table: "tblProduct",
                column: "PurchaseDetailID",
                principalTable: "tblPurchaseDetail",
                principalColumn: "PurchaseDetailID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblPurchaseDetail_PurchaseDetailID",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_PurchaseDetailID",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "PurchaseDetailID",
                table: "tblProduct");
        }
    }
}
