﻿// <auto-generated />
using System;
using Gta5Platinum.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gta5Platinum.DataAccess.Migrations
{
    [DbContext(typeof(Gta5PlatinumDbContext))]
    partial class Gta5PlatinumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("BulletproofTyres")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<bool>("CustomTires")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("DashboardColor")
                        .HasColumnType("int");

                    b.Property<float>("EnginePowerMultiplier")
                        .HasColumnType("float");

                    b.Property<bool>("EngineStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("EngineTorqueMultiplier")
                        .HasColumnType("float");

                    b.Property<float>("Health")
                        .HasColumnType("float");

                    b.Property<int>("Livery")
                        .HasColumnType("int");

                    b.Property<bool>("Neons")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NumberPlate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NumberPlateStyle")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("PearlescentColor")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryColor")
                        .HasColumnType("int");

                    b.Property<int>("SecondaryColor")
                        .HasColumnType("int");

                    b.Property<bool>("SpecialLight")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TrimColor")
                        .HasColumnType("int");

                    b.Property<int>("WheelColor")
                        .HasColumnType("int");

                    b.Property<int>("WheelType")
                        .HasColumnType("int");

                    b.Property<int>("WindowTint")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Armour")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NameTag")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("Xpos")
                        .HasColumnType("float");

                    b.Property<float>("Ypos")
                        .HasColumnType("float");

                    b.Property<float>("Zpos")
                        .HasColumnType("float");

                    b.Property<int>("jail")
                        .HasColumnType("int");

                    b.Property<int>("jailtime")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExtraType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Property", b =>
                {
                    b.Property<int>("PropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<bool>("Enterable")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("ExtPosX")
                        .HasColumnType("float");

                    b.Property<float>("ExtPosY")
                        .HasColumnType("float");

                    b.Property<float>("ExtPosZ")
                        .HasColumnType("float");

                    b.Property<string>("IPL")
                        .HasColumnType("varchar(48) CHARACTER SET utf8mb4")
                        .HasMaxLength(48);

                    b.Property<float>("IntPosX")
                        .HasColumnType("float");

                    b.Property<float>("IntPosY")
                        .HasColumnType("float");

                    b.Property<float>("IntPosZ")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("PropertyID");

                    b.HasIndex("CharacterId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DonateBalance")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Ip")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsHelper")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsModerator")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Login")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Serial")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("SocialClubId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("SocialClubName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DonateBalance = 0,
                            Email = "mail@mail.com",
                            Ip = "127.0.0.1",
                            IsAdmin = false,
                            IsHelper = false,
                            IsModerator = false,
                            Login = "firstlog",
                            Password = "firstpass",
                            Serial = "sdq2213sdddewe21213wsdas3d5f",
                            SocialClubId = 5184516684ul,
                            SocialClubName = "petyxblyat"
                        });
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.CharacterClothes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("clothes_1")
                        .HasColumnType("int");

                    b.Property<int>("clothes_10")
                        .HasColumnType("int");

                    b.Property<int>("clothes_11")
                        .HasColumnType("int");

                    b.Property<int>("clothes_2")
                        .HasColumnType("int");

                    b.Property<int>("clothes_3")
                        .HasColumnType("int");

                    b.Property<int>("clothes_4")
                        .HasColumnType("int");

                    b.Property<int>("clothes_5")
                        .HasColumnType("int");

                    b.Property<int>("clothes_6")
                        .HasColumnType("int");

                    b.Property<int>("clothes_7")
                        .HasColumnType("int");

                    b.Property<int>("clothes_8")
                        .HasColumnType("int");

                    b.Property<int>("clothes_9")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterClothes");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.CharacterCustomization", b =>
                {
                    b.Property<int>("CustomizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<byte>("EyeColor")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("HairColor")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("HighlightColor")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("ShapeFirst")
                        .HasColumnType("tinyint unsigned");

                    b.Property<float>("ShapeMix")
                        .HasColumnType("float");

                    b.Property<byte>("ShapeSecond")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("ShapeThird")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("SkinFirst")
                        .HasColumnType("tinyint unsigned");

                    b.Property<float>("SkinMix")
                        .HasColumnType("float");

                    b.Property<byte>("SkinSecond")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte>("SkinThird")
                        .HasColumnType("tinyint unsigned");

                    b.Property<float>("ThirdMix")
                        .HasColumnType("float");

                    b.HasKey("CustomizationId");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("CharacterCustomization");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.Finance", b =>
                {
                    b.Property<Guid>("FinanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Bank")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.HasKey("FinanceId");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Finances");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.Inventory", b =>
                {
                    b.Property<Guid>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.InventoryItem", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<Guid?>("InventoryId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ItemId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("InventoryId1");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.UserVehicle", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Color1")
                        .HasColumnType("int");

                    b.Property<int>("Color2")
                        .HasColumnType("int");

                    b.Property<int>("brakes")
                        .HasColumnType("int");

                    b.Property<int>("bwheels")
                        .HasColumnType("int");

                    b.Property<string>("carmodel")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("carslot")
                        .HasColumnType("int");

                    b.Property<int>("exhaust")
                        .HasColumnType("int");

                    b.Property<int>("fbumber")
                        .HasColumnType("int");

                    b.Property<int>("frame")
                        .HasColumnType("int");

                    b.Property<int>("fwheels")
                        .HasColumnType("int");

                    b.Property<int>("grill")
                        .HasColumnType("int");

                    b.Property<float>("last_rotation")
                        .HasColumnType("float");

                    b.Property<int>("motortuning")
                        .HasColumnType("int");

                    b.Property<int>("rbumber")
                        .HasColumnType("int");

                    b.Property<int>("roof")
                        .HasColumnType("int");

                    b.Property<int>("spoilers")
                        .HasColumnType("int");

                    b.Property<int>("sskirt")
                        .HasColumnType("int");

                    b.Property<int>("suspension")
                        .HasColumnType("int");

                    b.Property<int>("transmission")
                        .HasColumnType("int");

                    b.Property<int>("turbo")
                        .HasColumnType("int");

                    b.Property<int>("window")
                        .HasColumnType("int");

                    b.HasKey("_id");

                    b.HasIndex("CharacterId");

                    b.ToTable("UserVehicles");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Car", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Organization", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Character", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Organization", "Organization")
                        .WithMany("Players")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Gta5Platinum.DataAccess.Account.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.Property", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Character", "Character")
                        .WithMany("Properties")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gta5Platinum.DataAccess.Account.Organization", "Organization")
                        .WithMany("Properties")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.CharacterClothes", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Character", null)
                        .WithOne("Clothes")
                        .HasForeignKey("Gta5Platinum.DataAccess.Account.UserModels.CharacterClothes", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.CharacterCustomization", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Character", null)
                        .WithOne("HeadBlend")
                        .HasForeignKey("Gta5Platinum.DataAccess.Account.UserModels.CharacterCustomization", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.Finance", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Character", null)
                        .WithOne("UserFinances")
                        .HasForeignKey("Gta5Platinum.DataAccess.Account.UserModels.Finance", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.InventoryItem", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Character", null)
                        .WithMany("CharacterInventory")
                        .HasForeignKey("CharacterId");

                    b.HasOne("Gta5Platinum.DataAccess.Account.UserModels.Inventory", null)
                        .WithMany("Items")
                        .HasForeignKey("InventoryId1");
                });

            modelBuilder.Entity("Gta5Platinum.DataAccess.Account.UserModels.UserVehicle", b =>
                {
                    b.HasOne("Gta5Platinum.DataAccess.Account.Character", null)
                        .WithMany("UserVehicles")
                        .HasForeignKey("CharacterId");
                });
#pragma warning restore 612, 618
        }
    }
}
