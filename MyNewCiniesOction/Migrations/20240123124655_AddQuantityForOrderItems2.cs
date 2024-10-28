using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewCiniesOction.Migrations
{
    public partial class AddQuantityForOrderItems2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "OIQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OIQuantity",
                table: "OrderItems",
                newName: "Quantity");
        }
    }
}
