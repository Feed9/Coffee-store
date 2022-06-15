using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_store.Migrations
{
    public partial class reworkedquantitysystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionQuantities");

            migrationBuilder.DropTable(
                name: "ProductQuantities");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PricesVolumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Additions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PricesVolumes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Additions");

            migrationBuilder.CreateTable(
                name: "AdditionQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionQuantities_Additions_AdditionId",
                        column: x => x.AdditionId,
                        principalTable: "Additions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceVolumeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQuantities_PricesVolumes_PriceVolumeId",
                        column: x => x.PriceVolumeId,
                        principalTable: "PricesVolumes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionQuantities_AdditionId",
                table: "AdditionQuantities",
                column: "AdditionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_PriceVolumeId",
                table: "ProductQuantities",
                column: "PriceVolumeId",
                unique: true,
                filter: "[PriceVolumeId] IS NOT NULL");
        }
    }
}
