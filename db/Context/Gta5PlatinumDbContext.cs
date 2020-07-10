using Microsoft.EntityFrameworkCore;
using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Account.UserModels;
using System.Collections.Generic;
using Gta5Platinum.DataAccess.Account.OrganizationModels;
using System;

namespace Gta5Platinum.DataAccess.Context
{
    public class Gta5PlatinumDbContext : DbContext
    {                       

        // Initialize a new MySQL connection with the given connection parameters 
        public Gta5PlatinumDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseMySql("Server = 127.0.0.1; Database = platinum; Uid = biolion; Pwd = osatw2je");
            
        }

        

        // Account model class created somewhere else 
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<UserVehicle> UserVehicles { get; set; }
        public DbSet<OrganizationMember> OrganizationMembers { get; set; }
        public DbSet<CharacterClothes> CharacterClothes { get; set; }
        public DbSet<CharacterCustomization> CharacterCustomization { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Vector> Vectors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    RegistrationDate = DateTime.Now.ToString(),
                    Characters = new List<Character>(),                    
                    DonateBalance = 0,
                    Email = "mail@mail.com",
                    Ip = "127.0.0.1",
                    IsAdmin = false,
                    IsHelper = false,
                    IsModerator = false,
                    Login = "firstlog",
                    Password = "firstpass",
                    Serial = "sdq2213sdddewe21213wsdas3d5f",
                    SocialClubId = 5184516684,
                    SocialClubName = "petyxblyat"
                });

            
            /*modelBuilder
                .Entity<Finance>(eb =>
                {
                    eb.HasNoKey();
                })
            .Entity<Inventory>(eb =>
            {
                eb.HasNoKey();
            })
            .Entity<InventoryItem>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<User>().HasMany(ch => ch.Characters);
            modelBuilder.Entity<Character>().HasOne(ch => ch.UserFinances);
            modelBuilder.Entity<Character>().HasMany(ch => ch.UserVehicles);*/
        }


    }
}
