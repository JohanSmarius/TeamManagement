using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddCareTakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareTakers_Players_PlayerId",
                table: "CareTakers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "CareTakers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CareTakers",
                columns: new[] { "Id", "EMailAddress", "GameId", "HasCar", "HasPassedTrainingScoringTable", "Name", "PhoneNumber", "PlayerId" },
                values: new object[,]
                {
                    { 1, null, null, true, false, "Johan", 0, 1 },
                    { 2, null, null, true, false, "Manuela", 0, 1 },
                    { 3, null, null, false, false, "Inge", 0, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayerNumber",
                value: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_CareTakers_Players_PlayerId",
                table: "CareTakers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareTakers_Players_PlayerId",
                table: "CareTakers");

            migrationBuilder.DeleteData(
                table: "CareTakers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CareTakers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CareTakers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "CareTakers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayerNumber",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_CareTakers_Players_PlayerId",
                table: "CareTakers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
