using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class IODModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblPurchase_ProductID",
                table: "tblPurchase",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchase_SupplierID",
                table: "tblPurchase",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblPurchase_tblProduct_ProductID",
                table: "tblPurchase",
                column: "ProductID",
                principalTable: "tblProduct",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPurchase_tblSupplier_SupplierID",
                table: "tblPurchase",
                column: "SupplierID",
                principalTable: "tblSupplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblPurchase_tblProduct_ProductID",
                table: "tblPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPurchase_tblSupplier_SupplierID",
                table: "tblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_tblPurchase_ProductID",
                table: "tblPurchase");

            migrationBuilder.DropIndex(
                name: "IX_tblPurchase_SupplierID",
                table: "tblPurchase");
        }
    }
}
