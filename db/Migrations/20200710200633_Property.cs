using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gta5Platinum.DataAccess.Migrations
{
    public partial class Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Organization_OrganizationId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Organization_OrganizationId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Characters_CharacterId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Organization_OrganizationId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicles_Characters_CharacterId",
                table: "UserVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicles_Vector_LastLocationId",
                table: "UserVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vector",
                table: "Vector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Xpos",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Ypos",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Zpos",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ExtPosX",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ExtPosY",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ExtPosZ",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "IntPosX",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "IntPosY",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "IntPosZ",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Vector",
                newName: "Vectors");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Properties",
                newName: "PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_OrganizationId",
                table: "Properties",
                newName: "IX_Properties_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_CharacterId",
                table: "Properties",
                newName: "IX_Properties_CharacterId");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "UserVehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "InteriorPositionX",
                table: "Properties",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InteriorPositionY",
                table: "Properties",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InteriorPositionZ",
                table: "Properties",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vectors",
                table: "Vectors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "OrganizationId");

            migrationBuilder.CreateTable(
                name: "OrganizationMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: true),
                    Leader = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationMembers_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationMembers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vectors_CharacterId",
                table: "Vectors",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vectors_PropertyId",
                table: "Vectors",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembers_CharacterId",
                table: "OrganizationMembers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembers_OrganizationId",
                table: "OrganizationMembers",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Organizations_OrganizationId",
                table: "Car",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Organizations_OrganizationId",
                table: "Characters",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Characters_CharacterId",
                table: "Properties",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Organizations_OrganizationId",
                table: "Properties",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicles_Characters_CharacterId",
                table: "UserVehicles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicles_Vectors_LastLocationId",
                table: "UserVehicles",
                column: "LastLocationId",
                principalTable: "Vectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vectors_Characters_CharacterId",
                table: "Vectors",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vectors_Properties_PropertyId",
                table: "Vectors",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Organizations_OrganizationId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Organizations_OrganizationId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Characters_CharacterId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Organizations_OrganizationId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicles_Characters_CharacterId",
                table: "UserVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicles_Vectors_LastLocationId",
                table: "UserVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vectors_Characters_CharacterId",
                table: "Vectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vectors_Properties_PropertyId",
                table: "Vectors");

            migrationBuilder.DropTable(
                name: "OrganizationMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vectors",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Vectors_CharacterId",
                table: "Vectors");

            migrationBuilder.DropIndex(
                name: "IX_Vectors_PropertyId",
                table: "Vectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "InteriorPositionX",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "InteriorPositionY",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "InteriorPositionZ",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Vectors",
                newName: "Vector");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Property",
                newName: "PropertyID");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_OrganizationId",
                table: "Property",
                newName: "IX_Property_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CharacterId",
                table: "Property",
                newName: "IX_Property_CharacterId");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "UserVehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<float>(
                name: "Xpos",
                table: "Characters",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Ypos",
                table: "Characters",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Zpos",
                table: "Characters",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExtPosX",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExtPosY",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExtPosZ",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IntPosX",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IntPosY",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IntPosZ",
                table: "Property",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vector",
                table: "Vector",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "PropertyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Organization_OrganizationId",
                table: "Car",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Organization_OrganizationId",
                table: "Characters",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Characters_CharacterId",
                table: "Property",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Organization_OrganizationId",
                table: "Property",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicles_Characters_CharacterId",
                table: "UserVehicles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicles_Vector_LastLocationId",
                table: "UserVehicles",
                column: "LastLocationId",
                principalTable: "Vector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
