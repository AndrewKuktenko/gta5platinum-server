using Microsoft.EntityFrameworkCore.Migrations;

namespace Gta5Platinum.DataAccess.Migrations
{
    public partial class CharacterHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegistrationDate",
                value: "21.07.2020 13:46:13");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CharacterId",
                table: "Houses",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Characters_CharacterId",
                table: "Houses",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Characters_CharacterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_CharacterId",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegistrationDate",
                value: "20.07.2020 0:09:54");
        }
    }
}
