using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetfilxPractice.Data.Migrations
{
    public partial class AddFavouriteUserShowAndWatchUserShowTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteUserShow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavouriteShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteUserShow_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserShow_Show_FavouriteShowId",
                        column: x => x.FavouriteShowId,
                        principalTable: "Show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchUserShow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WatchingShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchUserShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchUserShow_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchUserShow_Show_WatchingShowId",
                        column: x => x.WatchingShowId,
                        principalTable: "Show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserShow_FavouriteShowId",
                table: "FavouriteUserShow",
                column: "FavouriteShowId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserShow_UserId",
                table: "FavouriteUserShow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchUserShow_UserId",
                table: "WatchUserShow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchUserShow_WatchingShowId",
                table: "WatchUserShow",
                column: "WatchingShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteUserShow");

            migrationBuilder.DropTable(
                name: "WatchUserShow");
        }
    }
}
