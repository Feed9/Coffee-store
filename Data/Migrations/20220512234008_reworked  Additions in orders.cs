using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_store.Data.Migrations
{
    public partial class reworkedAdditionsinorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemAdditions");

            migrationBuilder.CreateTable(
                name: "AdditionOrderItem",
                columns: table => new
                {
                    OrderAdditionsId = table.Column<int>(type: "int", nullable: false),
                    OrderItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionOrderItem", x => new { x.OrderAdditionsId, x.OrderItemsId });
                    table.ForeignKey(
                        name: "FK_AdditionOrderItem_Additions_OrderAdditionsId",
                        column: x => x.OrderAdditionsId,
                        principalTable: "Additions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionOrderItem_OrderItems_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionOrderItem_OrderItemsId",
                table: "AdditionOrderItem",
                column: "OrderItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionOrderItem");

            migrationBuilder.CreateTable(
                name: "OrderItemAdditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemAdditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemAdditions_Additions_AdditionId",
                        column: x => x.AdditionId,
                        principalTable: "Additions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemAdditions_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemAdditions_AdditionId",
                table: "OrderItemAdditions",
                column: "AdditionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemAdditions_OrderItemId",
                table: "OrderItemAdditions",
                column: "OrderItemId");
        }
    }
}
