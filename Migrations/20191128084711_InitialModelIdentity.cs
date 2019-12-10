using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class InitialModelIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_UserID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_UserID",
                table: "AspNetUsers",
                column: "UserID");
        }
    }
}
