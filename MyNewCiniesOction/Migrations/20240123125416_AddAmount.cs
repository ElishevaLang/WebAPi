using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewCiniesOction.Migrations
{
    public partial class AddAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OIQuantity",
                table: "OrderItems",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "OrderItems",
                newName: "OIQuantity");
        }
    }
}
