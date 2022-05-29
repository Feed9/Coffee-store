using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_store.Migrations
{
    public partial class addCancellationRequesttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionQuantity_Additions_AdditionId",
                table: "AdditionQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_CancellationRequest_Orders_OrderId",
                table: "CancellationRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantity_Products_ProductId",
                table: "ProductQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductQuantity",
                table: "ProductQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CancellationRequest",
                table: "CancellationRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionQuantity",
                table: "AdditionQuantity");

            migrationBuilder.RenameTable(
                name: "ProductQuantity",
                newName: "ProductQuantities");

            migrationBuilder.RenameTable(
                name: "CancellationRequest",
                newName: "CancellationRequests");

            migrationBuilder.RenameTable(
                name: "AdditionQuantity",
                newName: "AdditionQuantities");

            migrationBuilder.RenameIndex(
                name: "IX_ProductQuantity_ProductId",
                table: "ProductQuantities",
                newName: "IX_ProductQuantities_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CancellationRequest_OrderId",
                table: "CancellationRequests",
                newName: "IX_CancellationRequests_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionQuantity_AdditionId",
                table: "AdditionQuantities",
                newName: "IX_AdditionQuantities_AdditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductQuantities",
                table: "ProductQuantities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CancellationRequests",
                table: "CancellationRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionQuantities",
                table: "AdditionQuantities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionQuantities_Additions_AdditionId",
                table: "AdditionQuantities",
                column: "AdditionId",
                principalTable: "Additions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationRequests_Orders_OrderId",
                table: "CancellationRequests",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Products_ProductId",
                table: "ProductQuantities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionQuantities_Additions_AdditionId",
                table: "AdditionQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_CancellationRequests_Orders_OrderId",
                table: "CancellationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Products_ProductId",
                table: "ProductQuantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductQuantities",
                table: "ProductQuantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CancellationRequests",
                table: "CancellationRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionQuantities",
                table: "AdditionQuantities");

            migrationBuilder.RenameTable(
                name: "ProductQuantities",
                newName: "ProductQuantity");

            migrationBuilder.RenameTable(
                name: "CancellationRequests",
                newName: "CancellationRequest");

            migrationBuilder.RenameTable(
                name: "AdditionQuantities",
                newName: "AdditionQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantity",
                newName: "IX_ProductQuantity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CancellationRequests_OrderId",
                table: "CancellationRequest",
                newName: "IX_CancellationRequest_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionQuantities_AdditionId",
                table: "AdditionQuantity",
                newName: "IX_AdditionQuantity_AdditionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductQuantity",
                table: "ProductQuantity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CancellationRequest",
                table: "CancellationRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionQuantity",
                table: "AdditionQuantity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionQuantity_Additions_AdditionId",
                table: "AdditionQuantity",
                column: "AdditionId",
                principalTable: "Additions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationRequest_Orders_OrderId",
                table: "CancellationRequest",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantity_Products_ProductId",
                table: "ProductQuantity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
