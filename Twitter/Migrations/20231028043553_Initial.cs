using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TweetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountReplies = table.Column<int>(type: "int", nullable: false),
                    CountReposts = table.Column<int>(type: "int", nullable: false),
                    CountLikes = table.Column<int>(type: "int", nullable: false),
                    CountViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Choice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountVoices = table.Column<int>(type: "int", nullable: false),
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollItems_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TweetId",
                table: "Medias",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_PollItems_TweetId",
                table: "PollItems",
                column: "TweetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "PollItems");

            migrationBuilder.DropTable(
                name: "Tweets");
        }
    }
}
