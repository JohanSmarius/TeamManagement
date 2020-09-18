using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RefactorRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareTaker_Games_GameId",
                table: "CareTaker");

            migrationBuilder.DropForeignKey(
                name: "FK_CareTaker_Players_PlayerId",
                table: "CareTaker");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_CareTaker_LaundryDutyId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CareTaker",
                table: "CareTaker");

            migrationBuilder.RenameTable(
                name: "CareTaker",
                newName: "CareTakers");

            migrationBuilder.RenameIndex(
                name: "IX_CareTaker_PlayerId",
                table: "CareTakers",
                newName: "IX_CareTakers_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_CareTaker_GameId",
                table: "CareTakers",
                newName: "IX_CareTakers_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareTakers",
                table: "CareTakers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CareTakers_Games_GameId",
                table: "CareTakers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CareTakers_Players_PlayerId",
                table: "CareTakers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.DropForeignKey(
                name: "FK_CareTakers_Players_PlayerId",
                table: "CareTakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_CareTakers_LaundryDutyId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CareTakers",
                table: "CareTakers");

            migrationBuilder.RenameTable(
                name: "CareTakers",
                newName: "CareTaker");

            migrationBuilder.RenameIndex(
                name: "IX_CareTakers_PlayerId",
                table: "CareTaker",
                newName: "IX_CareTaker_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_CareTakers_GameId",
                table: "CareTaker",
                newName: "IX_CareTaker_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareTaker",
                table: "CareTaker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CareTaker_Games_GameId",
                table: "CareTaker",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CareTaker_Players_PlayerId",
                table: "CareTaker",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_CareTaker_LaundryDutyId",
                table: "Games",
                column: "LaundryDutyId",
                principalTable: "CareTaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
