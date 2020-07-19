using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gta5Platinum.DataAccess.Migrations
{
    public partial class House : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HouseInventoryInventoryId",
                table: "InventoryItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Owned = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    IPL = table.Column<string>(maxLength: 48, nullable: true),
                    ExteriorPositionId = table.Column<int>(nullable: true),
                    ExteriorRotation = table.Column<float>(nullable: false),
                    InteriorPositionX = table.Column<float>(nullable: false),
                    InteriorPositionY = table.Column<float>(nullable: false),
                    InteriorPositionZ = table.Column<float>(nullable: false),
                    InteriorRotation = table.Column<float>(nullable: false),
                    Locked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_Houses_Vectors_ExteriorPositionId",
                        column: x => x.ExteriorPositionId,
                        principalTable: "Vectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseInventories",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(nullable: false),
                    HouseId = table.Column<int>(nullable: false),
                    MaxSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseInventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_HouseInventories_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegistrationDate",
                value: "19.07.2020 20:50:55");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_HouseInventoryInventoryId",
                table: "InventoryItems",
                column: "HouseInventoryInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseInventories_HouseId",
                table: "HouseInventories",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_ExteriorPositionId",
                table: "Houses",
                column: "ExteriorPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_HouseInventories_HouseInventoryInventoryId",
                table: "InventoryItems",
                column: "HouseInventoryInventoryId",
                principalTable: "HouseInventories",
                principalColumn: "InventoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_HouseInventories_HouseInventoryInventoryId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "HouseInventories");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_HouseInventoryInventoryId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "HouseInventoryInventoryId",
                table: "InventoryItems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegistrationDate",
                value: "19.07.2020 20:49:41");
        }
    }
}
