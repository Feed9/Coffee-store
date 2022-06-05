using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_store.Migrations
{
    public partial class reworkedproductquantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Products_ProductId",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities");

            migrationBuilder.AddColumn<int>(
                name: "PriceVolumeId",
                table: "ProductQuantities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAdditions",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_PriceVolumeId",
                table: "ProductQuantities",
                column: "PriceVolumeId",
                unique: true,
                filter: "[PriceVolumeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_PricesVolumes_PriceVolumeId",
                table: "ProductQuantities",
                column: "PriceVolumeId",
                principalTable: "PricesVolumes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_PricesVolumes_PriceVolumeId",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_PriceVolumeId",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "PriceVolumeId",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "HasAdditions",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Products_ProductId",
                table: "ProductQuantities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
