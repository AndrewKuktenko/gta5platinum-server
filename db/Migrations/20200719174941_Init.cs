using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gta5Platinum.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    MaxSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ExtraType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    SocialClubName = table.Column<string>(nullable: true),
                    SocialClubId = table.Column<ulong>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: true),
                    IsModerator = table.Column<bool>(nullable: true),
                    IsHelper = table.Column<bool>(nullable: true),
                    DonateBalance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    WheelColor = table.Column<int>(nullable: false),
                    EngineStatus = table.Column<bool>(nullable: false),
                    TyreSmokeColorRed = table.Column<int>(nullable: false),
                    TyreSmokeColorGreen = table.Column<int>(nullable: false),
                    TyreSmokeColorBlue = table.Column<int>(nullable: false),
                    TyreSmokeColorAlpha = table.Column<int>(nullable: false),
                    PrimaryType = table.Column<int>(nullable: false),
                    PrimaryColor = table.Column<int>(nullable: false),
                    SecondaryType = table.Column<int>(nullable: false),
                    SecondaryColor = table.Column<int>(nullable: false),
                    WindowTint = table.Column<int>(nullable: false),
                    EnginePowerMultiplier = table.Column<float>(nullable: false),
                    EngineTorqueMultiplier = table.Column<float>(nullable: false),
                    NeonColorRed = table.Column<int>(nullable: false),
                    NeonColorGreen = table.Column<int>(nullable: false),
                    NeonColorBlue = table.Column<int>(nullable: false),
                    NeonColorAlpha = table.Column<int>(nullable: false),
                    DashboardColor = table.Column<int>(nullable: false),
                    WheelType = table.Column<int>(nullable: false),
                    TrimColor = table.Column<int>(nullable: false),
                    Neons = table.Column<bool>(nullable: false),
                    NumberPlateStyle = table.Column<int>(nullable: false),
                    PearlescentColor = table.Column<int>(nullable: false),
                    Health = table.Column<float>(nullable: false),
                    Livery = table.Column<int>(nullable: false),
                    NumberPlate = table.Column<string>(nullable: true),
                    SpecialLight = table.Column<bool>(nullable: false),
                    CustomTires = table.Column<bool>(nullable: false),
                    BulletproofTyres = table.Column<bool>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameTag = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Armour = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    jail = table.Column<int>(nullable: false),
                    jailtime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClothes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    clothes_1 = table.Column<int>(nullable: false),
                    clothes_2 = table.Column<int>(nullable: false),
                    clothes_3 = table.Column<int>(nullable: false),
                    clothes_4 = table.Column<int>(nullable: false),
                    clothes_5 = table.Column<int>(nullable: false),
                    clothes_6 = table.Column<int>(nullable: false),
                    clothes_7 = table.Column<int>(nullable: false),
                    clothes_8 = table.Column<int>(nullable: false),
                    clothes_9 = table.Column<int>(nullable: false),
                    clothes_10 = table.Column<int>(nullable: false),
                    clothes_11 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClothes", x => x.id);
                    table.ForeignKey(
                        name: "FK_CharacterClothes_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterCustomization",
                columns: table => new
                {
                    CustomizationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    EyeColor = table.Column<byte>(nullable: false),
                    HairColor = table.Column<byte>(nullable: false),
                    HighlightColor = table.Column<byte>(nullable: false),
                    ShapeFirst = table.Column<byte>(nullable: false),
                    ShapeSecond = table.Column<byte>(nullable: false),
                    ShapeThird = table.Column<byte>(nullable: false),
                    SkinFirst = table.Column<byte>(nullable: false),
                    SkinSecond = table.Column<byte>(nullable: false),
                    SkinThird = table.Column<byte>(nullable: false),
                    ShapeMix = table.Column<float>(nullable: false),
                    SkinMix = table.Column<float>(nullable: false),
                    ThirdMix = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCustomization", x => x.CustomizationId);
                    table.ForeignKey(
                        name: "FK_CharacterCustomization_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    FinanceId = table.Column<Guid>(nullable: false),
                    Bank = table.Column<int>(nullable: false),
                    Money = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.FinanceId);
                    table.ForeignKey(
                        name: "FK_Finances_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true),
                    InventoryId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Inventories_InventoryId1",
                        column: x => x.InventoryId1,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    IPL = table.Column<string>(maxLength: 48, nullable: true),
                    InteriorPositionX = table.Column<float>(nullable: false),
                    InteriorPositionY = table.Column<float>(nullable: false),
                    InteriorPositionZ = table.Column<float>(nullable: false),
                    Enterable = table.Column<bool>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true),
                    VehicleId = table.Column<int>(nullable: true),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    Z = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vectors_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vectors_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserVehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    LastLocationId = table.Column<int>(nullable: true),
                    Carslot = table.Column<int>(nullable: false),
                    CarModel = table.Column<string>(nullable: true),
                    LastRotation = table.Column<float>(nullable: false),
                    Color1 = table.Column<int>(nullable: false),
                    Color2 = table.Column<int>(nullable: false),
                    Spoilers = table.Column<int>(nullable: false),
                    FrontBumper = table.Column<int>(nullable: false),
                    RearBumper = table.Column<int>(nullable: false),
                    SideSkirt = table.Column<int>(nullable: false),
                    Exhaust = table.Column<int>(nullable: false),
                    Frame = table.Column<int>(nullable: false),
                    Grill = table.Column<int>(nullable: false),
                    Roof = table.Column<int>(nullable: false),
                    MotorTuning = table.Column<int>(nullable: false),
                    Brakes = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    Turbo = table.Column<int>(nullable: false),
                    FrontWheels = table.Column<int>(nullable: false),
                    RearWheels = table.Column<int>(nullable: false),
                    Window = table.Column<int>(nullable: false),
                    Suspension = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_UserVehicles_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVehicles_Vectors_LastLocationId",
                        column: x => x.LastLocationId,
                        principalTable: "Vectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DonateBalance", "Email", "Ip", "IsAdmin", "IsHelper", "IsModerator", "Login", "Password", "RegistrationDate", "Serial", "SocialClubId", "SocialClubName" },
                values: new object[] { 1, 0, "mail@mail.com", "127.0.0.1", false, false, false, "firstlog", "firstpass", "19.07.2020 20:49:41", "sdq2213sdddewe21213wsdas3d5f", 5184516684ul, "petyxblyat" });

            migrationBuilder.CreateIndex(
                name: "IX_Car_OrganizationId",
                table: "Car",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClothes_CharacterId",
                table: "CharacterClothes",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCustomization_CharacterId",
                table: "CharacterCustomization",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_OrganizationId",
                table: "Characters",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_CharacterId",
                table: "Finances",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CharacterId",
                table: "InventoryItems",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryId1",
                table: "InventoryItems",
                column: "InventoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembers_CharacterId",
                table: "OrganizationMembers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMembers_OrganizationId",
                table: "OrganizationMembers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CharacterId",
                table: "Properties",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OrganizationId",
                table: "Properties",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicles_CharacterId",
                table: "UserVehicles",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicles_LastLocationId",
                table: "UserVehicles",
                column: "LastLocationId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CharacterClothes");

            migrationBuilder.DropTable(
                name: "CharacterCustomization");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "OrganizationMembers");

            migrationBuilder.DropTable(
                name: "UserVehicles");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Vectors");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
