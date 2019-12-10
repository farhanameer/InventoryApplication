using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryApplication.Migrations
{
    public partial class PModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tblLocation",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(maxLength: 5, nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocation", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "tblSale",
                columns: table => new
                {
                    SaleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleNumber = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PO = table.Column<string>(nullable: false),
                    SalesTax = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSale", x => x.SaleID);
                });

            migrationBuilder.CreateTable(
                name: "tblShop",
                columns: table => new
                {
                    ShopID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(nullable: true),
                    LocationID = table.Column<int>(nullable: false),
                    ShopPhone = table.Column<string>(nullable: true),
                    GeneralContactEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShop", x => x.ShopID);
                    table.ForeignKey(
                        name: "FK_tblShop_tblLocation_LocationID",
                        column: x => x.LocationID,
                        principalTable: "tblLocation",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    PersonelPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_tblUser_tblLocation_LocationID",
                        column: x => x.LocationID,
                        principalTable: "tblLocation",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchase",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseNo = table.Column<string>(nullable: false),
                    PO = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    SalesTax = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ShopID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchase", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_tblPurchase_tblShop_ShopID",
                        column: x => x.ShopID,
                        principalTable: "tblShop",
                        principalColumn: "ShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblShopPhoto",
                columns: table => new
                {
                    ShopPhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopUrl = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    ShopID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShopPhoto", x => x.ShopPhotoID);
                    table.ForeignKey(
                        name: "FK_tblShopPhoto_tblShop_ShopID",
                        column: x => x.ShopID,
                        principalTable: "tblShop",
                        principalColumn: "ShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserPhoto",
                columns: table => new
                {
                    UserPhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserPhoto", x => x.UserPhotoID);
                    table.ForeignKey(
                        name: "FK_tblUserPhoto_tblUser_UserID",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPayment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckNumber = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PurchaseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_tblPayment_tblPurchase_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "tblPurchase",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseDetail",
                columns: table => new
                {
                    PurchaseDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostPerUnit = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PurchaseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseDetail", x => x.PurchaseDetailID);
                    table.ForeignKey(
                        name: "FK_tblPurchaseDetail_tblPurchase_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "tblPurchase",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    PurchaseDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tblCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblPurchaseDetail_PurchaseDetailID",
                        column: x => x.PurchaseDetailID,
                        principalTable: "tblPurchaseDetail",
                        principalColumn: "PurchaseDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblSupplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    PurchaseDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupplier", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_tblSupplier_tblPurchaseDetail_PurchaseDetailID",
                        column: x => x.PurchaseDetailID,
                        principalTable: "tblPurchaseDetail",
                        principalColumn: "PurchaseDetailID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblSupplier_tblUser_UserID",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblInventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsLeft = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_tblInventory_tblProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tblProduct",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSaleDetail",
                columns: table => new
                {
                    SaleDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PricePerUnit = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    SaleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSaleDetail", x => x.SaleDetailID);
                    table.ForeignKey(
                        name: "FK_tblSaleDetail_tblProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tblProduct",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSaleDetail_tblSale_SaleID",
                        column: x => x.SaleID,
                        principalTable: "tblSale",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductID, x.SupplierID });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_tblProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tblProduct",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_tblSupplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "tblSupplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SupplierID",
                table: "ProductSupplier",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblInventory_ProductID",
                table: "tblInventory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayment_PurchaseID",
                table: "tblPayment",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_CategoryID",
                table: "tblProduct",
                column: "CategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PurchaseDetailID",
                table: "tblProduct",
                column: "PurchaseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchase_ShopID",
                table: "tblPurchase",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseDetail_PurchaseID",
                table: "tblPurchaseDetail",
                column: "PurchaseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSaleDetail_ProductID",
                table: "tblSaleDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSaleDetail_SaleID",
                table: "tblSaleDetail",
                column: "SaleID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblShop_LocationID",
                table: "tblShop",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_tblShopPhoto_ShopID",
                table: "tblShopPhoto",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplier_PurchaseDetailID",
                table: "tblSupplier",
                column: "PurchaseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplier_UserID",
                table: "tblSupplier",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_LocationID",
                table: "tblUser",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserPhoto_UserID",
                table: "tblUserPhoto",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "tblInventory");

            migrationBuilder.DropTable(
                name: "tblPayment");

            migrationBuilder.DropTable(
                name: "tblSaleDetail");

            migrationBuilder.DropTable(
                name: "tblShopPhoto");

            migrationBuilder.DropTable(
                name: "tblUserPhoto");

            migrationBuilder.DropTable(
                name: "tblSupplier");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblSale");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblPurchaseDetail");

            migrationBuilder.DropTable(
                name: "tblPurchase");

            migrationBuilder.DropTable(
                name: "tblShop");

            migrationBuilder.DropTable(
                name: "tblLocation");
        }
    }
}
