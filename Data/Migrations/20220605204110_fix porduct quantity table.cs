using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_store.Migrations
{
    public partial class fixporductquantitytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductQuantities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
