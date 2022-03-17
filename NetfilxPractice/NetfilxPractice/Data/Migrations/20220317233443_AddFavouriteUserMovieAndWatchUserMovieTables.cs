using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetfilxPractice.Data.Migrations
{
    public partial class AddFavouriteUserMovieAndWatchUserMovieTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteUserMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavouriteMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteUserMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteUserMovie_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteUserMovie_Movie_FavouriteMovieId",
                        column: x => x.FavouriteMovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchUserMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WatchingMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchUserMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchUserMovie_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchUserMovie_Movie_WatchingMovieId",
                        column: x => x.WatchingMovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserMovie_FavouriteMovieId",
                table: "FavouriteUserMovie",
                column: "FavouriteMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteUserMovie_UserId",
                table: "FavouriteUserMovie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchUserMovie_UserId",
                table: "WatchUserMovie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchUserMovie_WatchingMovieId",
                table: "WatchUserMovie",
                column: "WatchingMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteUserMovie");

            migrationBuilder.DropTable(
                name: "WatchUserMovie");
        }
    }
}
