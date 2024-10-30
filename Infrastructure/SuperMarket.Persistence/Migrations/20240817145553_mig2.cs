using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "_OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BranchId",
                table: "Inventories",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX__Payment_OrderId",
                table: "_Payment",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__OrderDetails_OrderId",
                table: "_OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX__OrderDetails_ProductId",
                table: "_OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDetails_Orders_OrderId",
                table: "_OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDetails_Products_ProductId",
                table: "_OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Payment_Orders_OrderId",
                table: "_Payment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserId",
                table: "Customers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Branches_BranchId",
                table: "Inventories",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__OrderDetails_Orders_OrderId",
                table: "_OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDetails_Products_ProductId",
                table: "_OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__Payment_Orders_OrderId",
                table: "_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Branches_BranchId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_BranchId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX__Payment_OrderId",
                table: "_Payment");

            migrationBuilder.DropIndex(
                name: "IX__OrderDetails_OrderId",
                table: "_OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX__OrderDetails_ProductId",
                table: "_OrderDetails");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "_OrderDetails");
        }
    }
}
