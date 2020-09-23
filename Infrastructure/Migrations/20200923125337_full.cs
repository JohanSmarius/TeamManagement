using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opponents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlayingAddress_Street = table.Column<string>(nullable: true),
                    PlayingAddress_Number = table.Column<int>(nullable: true),
                    PlayingAddress_Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlayerNumber = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayTime = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: true),
                    IsHomeGame = table.Column<bool>(nullable: false),
                    CoachId = table.Column<int>(nullable: true),
                    LaundryDutyId = table.Column<int>(nullable: true),
                    OpponentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Opponents_OpponentId",
                        column: x => x.OpponentId,
                        principalTable: "Opponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CareTakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EMailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    HasCar = table.Column<bool>(nullable: false),
                    HasPassedTrainingScoringTable = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareTakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareTakers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CareTakers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.PlayerID, x.GameID });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tim" });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Iris" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "VU16" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "EmailAddress", "Name", "PlayerNumber", "TeamId" },
                values: new object[,]
                {
                    { 1, null, "Agnes", 10, 1 },
                    { 2, null, "Linda", 2, 1 },
                    { 3, null, "Debbie", 3, 1 },
                    { 4, null, "Sena", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "CareTakers",
                columns: new[] { "Id", "EMailAddress", "GameId", "HasCar", "HasPassedTrainingScoringTable", "Name", "PhoneNumber", "PlayerId" },
                values: new object[] { 1, null, null, true, false, "Johan", 0, 1 });

            migrationBuilder.InsertData(
                table: "CareTakers",
                columns: new[] { "Id", "EMailAddress", "GameId", "HasCar", "HasPassedTrainingScoringTable", "Name", "PhoneNumber", "PlayerId" },
                values: new object[] { 2, null, null, true, false, "Manuela", 0, 1 });

            migrationBuilder.InsertData(
                table: "CareTakers",
                columns: new[] { "Id", "EMailAddress", "GameId", "HasCar", "HasPassedTrainingScoringTable", "Name", "PhoneNumber", "PlayerId" },
                values: new object[] { 3, null, null, false, false, "Inge", 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CareTakers_GameId",
                table: "CareTakers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CareTakers_PlayerId",
                table: "CareTakers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CoachId",
                table: "Games",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LaundryDutyId",
                table: "Games",
                column: "LaundryDutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OpponentId",
                table: "Games",
                column: "OpponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Opponents_Name",
                table: "Opponents",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameID",
                table: "PlayerGames",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_CareTakers_LaundryDutyId",
                table: "Games",
                column: "LaundryDutyId",
                principalTable: "CareTakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareTakers_Games_GameId",
                table: "CareTakers");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "CareTakers");

            migrationBuilder.DropTable(
                name: "Opponents");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
