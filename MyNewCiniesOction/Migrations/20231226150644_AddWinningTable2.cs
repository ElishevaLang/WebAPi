using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNewCiniesOction.Migrations
{
    public partial class AddWinningTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Winning",
                columns: table => new
                {
                    WinningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winning", x => x.WinningId);
                    table.ForeignKey(
                        name: "FK_Winning_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "GiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Winning_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Winning_GiftId",
                table: "Winning",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Winning_UserId",
                table: "Winning",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Winning");
        }
    }
}
