using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddAddressToComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayingAddress_Extension",
                table: "Opponents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayingAddress_Number",
                table: "Opponents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayingAddress_Street",
                table: "Opponents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayingAddress_Extension",
                table: "Opponents");

            migrationBuilder.DropColumn(
                name: "PlayingAddress_Number",
                table: "Opponents");

            migrationBuilder.DropColumn(
                name: "PlayingAddress_Street",
                table: "Opponents");
        }
    }
}
