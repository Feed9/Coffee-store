using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_store.Data.Migrations
{
    public partial class FixOrderItemAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderItemAdditions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderItemAdditions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
