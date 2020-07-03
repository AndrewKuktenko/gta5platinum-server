using Microsoft.EntityFrameworkCore;
using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Account.UserModels;
using System.Collections.Generic;

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
            optionsBuilder.UseMySql("Server = 127.0.0.1; Database = platinum; Uid = root; Pwd = 1234");
            
        }

        

        // Account model class created somewhere else 
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<UserVehicle> UserVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
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
