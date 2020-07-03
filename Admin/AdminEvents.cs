//using Gta5Platinum.DataAccess.Account.UserModels;
using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
using Gta5Platinum.Server.Services.Common;
/*using Gta5Platinum.Server.Services.Common;
using Gta5Platinum.Server.Unity.DependencyResolvers;*/
using GTANetworkAPI;
using System;
using System.Linq;

namespace Gta5Platinum.Server.Admin
{
    public class AdminEvents : Script
    {                
        
        public AdminEvents()
        {
            
        }
        [Command("getid")]
        public void GetId(Player player)
        {

            player.SetData<int>("ID", 1212312);
            int pInfo = player.GetData<int>("ID");
            int aInfo = player.Id;
            NAPI.Chat.SendChatMessageToPlayer(player, $"Data{pInfo} Id{aInfo}");
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {                
                var playerCount = dbContext.Users.Count();
                NAPI.Util.ConsoleOutput("Total players in the database: " + playerCount);
                //NAPI.Util.ConsoleOutput("Total players in the database: " + _userService.GetUser(1).Email);
            }
        }
                        

        [Command("car")]
        public void Carpawn(Player player, VehicleHash car, int color)
        {
            NAPI.Vehicle.CreateVehicle(car, NAPI.Entity.GetEntityPosition(player), 0f, 0, 0);
        }
        [Command("tp")]
        public void Teleport(Player player, int x, int y, int z)
        {            
            
            player.Position = new Vector3(x, y, z);            
        }

        [Command("tptocoord")]
        public void TeleportToCoord(Player player, NetHandle marker)
        {
            Vector3 coord = NAPI.Marker.GetMarkerDirection(marker);

            player.Position = coord;
        }

        [Command("goto")]
        public void TeleportTo(Player player, Player target)
        {
            Vector3 Targetpos = NAPI.Entity.GetEntityPosition(target);
            NAPI.Entity.SetEntityPosition(player, new Vector3(Targetpos.X, Targetpos.Y, Targetpos.Z));
        }

        [Command("gotome")]
        public void TeleportToMe(Player me, Player target)
        {
            Vector3 mePos = NAPI.Entity.GetEntityPosition(me);
            NAPI.Entity.SetEntityPosition(target, new Vector3(mePos.X, mePos.Y, mePos.Z));
        }

        [Command("loc")]
        public void WhereIAm(Player player)
        {
            Vector3 PlayerPos = NAPI.Entity.GetEntityPosition(player);
            NAPI.Chat.SendChatMessageToPlayer(player, "GPS [X: " + PlayerPos.X + " Y: " + PlayerPos.Y + " Z: " + PlayerPos.Z + "]");
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatID)
        {
            //NAPI.Player.SetPlayerHealth(player, 0);
        }

        [Command("newuser")]
        public void NewUser(Player player, string email, string login, string password)
        {
            var _userService = new UserService();

            _userService.CreateUser(player, email, login, password);

            //int userLastId = _userService.GetLastUserId();
            
            /*using (var dbContext = new Gta5PlatinumDbContext())
            {
                userLastId = dbContext.Users
                .OrderByDescending(u => u.UserId)
                .Take(1)
                .Select(u => u.UserId)
                .Single();
            }*/

            /*User user = new User
            {
                UserId = ++userLastId,
                Email = email,
                Login = login,
                Password = password,
                SocialClubId = player.SocialClubId,
                Serial = player.Serial,
                Ip = player.Address,
                DonateBalance = 0,
                //Characters = new List<Character>()
            };*/

            /*using (var dbContext = new Gta5PlatinumDbContext())
            {

                dbContext.Users.Add(user);

                dbContext.SaveChanges();
            }*/

        }
    }
}
