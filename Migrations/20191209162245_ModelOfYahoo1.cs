using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class ModelOfYahoo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblProduct_CategoryID",
                table: "tblProduct");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_CategoryID",
                table: "tblProduct",
                column: "CategoryID",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblProduct_CategoryID",
                table: "tblProduct");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_CategoryID",
                table: "tblProduct",
                column: "CategoryID");
        }
    }
}
