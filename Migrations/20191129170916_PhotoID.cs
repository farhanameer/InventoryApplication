using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class PhotoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicID",
                table: "tblUserPhoto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicID",
                table: "tblUserPhoto");
        }
    }
}
