using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gta5Platinum.DataAccess.Migrations
{
    public partial class platinum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
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
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
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
                    WindowTint = table.Column<int>(nullable: false),
                    EnginePowerMultiplier = table.Column<float>(nullable: false),
                    EngineTorqueMultiplier = table.Column<float>(nullable: false),
                    DashboardColor = table.Column<int>(nullable: false),
                    WheelType = table.Column<int>(nullable: false),
                    TrimColor = table.Column<int>(nullable: false),
                    Neons = table.Column<bool>(nullable: false),
                    NumberPlateStyle = table.Column<int>(nullable: false),
                    PrimaryColor = table.Column<int>(nullable: false),
                    SecondaryColor = table.Column<int>(nullable: false),
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
                        name: "FK_Car_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
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
                    Health = table.Column<int>(nullable: false),
                    Armour = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    jail = table.Column<int>(nullable: false),
                    jailtime = table.Column<int>(nullable: false),
                    Xpos = table.Column<float>(nullable: false),
                    Ypos = table.Column<float>(nullable: false),
                    Zpos = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
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
                name: "Property",
                columns: table => new
                {
                    PropertyID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    IPL = table.Column<string>(maxLength: 48, nullable: true),
                    ExtPosX = table.Column<float>(nullable: false),
                    ExtPosY = table.Column<float>(nullable: false),
                    ExtPosZ = table.Column<float>(nullable: false),
                    IntPosX = table.Column<float>(nullable: false),
                    IntPosY = table.Column<float>(nullable: false),
                    IntPosZ = table.Column<float>(nullable: false),
                    Enterable = table.Column<bool>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_Property_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVehicles",
                columns: table => new
                {
                    _id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    carslot = table.Column<int>(nullable: false),
                    carmodel = table.Column<string>(nullable: true),
                    last_rotation = table.Column<float>(nullable: false),
                    Color1 = table.Column<int>(nullable: false),
                    Color2 = table.Column<int>(nullable: false),
                    spoilers = table.Column<int>(nullable: false),
                    fbumber = table.Column<int>(nullable: false),
                    rbumber = table.Column<int>(nullable: false),
                    sskirt = table.Column<int>(nullable: false),
                    exhaust = table.Column<int>(nullable: false),
                    frame = table.Column<int>(nullable: false),
                    grill = table.Column<int>(nullable: false),
                    roof = table.Column<int>(nullable: false),
                    motortuning = table.Column<int>(nullable: false),
                    brakes = table.Column<int>(nullable: false),
                    transmission = table.Column<int>(nullable: false),
                    turbo = table.Column<int>(nullable: false),
                    fwheels = table.Column<int>(nullable: false),
                    bwheels = table.Column<int>(nullable: false),
                    window = table.Column<int>(nullable: false),
                    suspension = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVehicles", x => x._id);
                    table.ForeignKey(
                        name: "FK_UserVehicles_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DonateBalance", "Email", "Ip", "IsAdmin", "IsHelper", "IsModerator", "Login", "Password", "Serial", "SocialClubId", "SocialClubName" },
                values: new object[] { 1, 0, "mail@mail.com", "127.0.0.1", false, false, false, "firstlog", "firstpass", "sdq2213sdddewe21213wsdas3d5f", 5184516684ul, "petyxblyat" });

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
                name: "IX_Property_CharacterId",
                table: "Property",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_OrganizationId",
                table: "Property",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicles_CharacterId",
                table: "UserVehicles",
                column: "CharacterId");
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
                name: "Property");

            migrationBuilder.DropTable(
                name: "UserVehicles");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
