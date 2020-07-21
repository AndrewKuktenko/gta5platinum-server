//using Gta5Platinum.DataAccess.Account.UserModels;
using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
using Gta5Platinum.Server.Client.Authorization;
using Gta5Platinum.Server.Services.Common;
/*using Gta5Platinum.Server.Services.Common;
using Gta5Platinum.Server.Unity.DependencyResolvers;*/
using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gta5Platinum.Server.Admin
{
    public class AdminEvents : Script
    {                
        
        public AdminEvents()
        {
            
        }
        [Command("coord")]
        public void SaveCoord(Player player, string name)
        {
            string path = @"F:\gta5platinum\platinum\coords\";
            File.WriteAllText(path + name + ".txt", " Position: " + player.Position.ToString() + "/n" + " Rotation: " + player.Rotation.ToString());
        }
        [Command("getid")]
        public void GetAId(Player player)
        {

            player.GetData<int>("ID");
            int pInfo = player.GetData<int>("ID");
            int aInfo = player.Id;
            NAPI.Chat.SendChatMessageToPlayer(player, $"Data{pInfo} Id{aInfo}");
        }

        [Command("voice")]
        public void Carpawn(Player player, Player player1)
        {
            player.EnableVoiceTo(player1);

        }
        [Command("hs")]
        public void CreateHouse(Player player, int number)
        {            
            Vector3 housePos = player.Position;
            Vector3 houseExitRot = player.Rotation; 
            Vector3 tpTo = new Vector3(341.05682f, 436.80807f, 149.39407f);
            Vector3 houseCoord = new Vector3(342.21008f, 437.7816f, 149.38077f);
            Vector3 fromHouse = player.Position;
            Vector3 houseEnterRot = new Vector3(0f, 0f, 139.90523f);
            


            Marker marker = NAPI.Marker.CreateMarker(20, housePos, new Vector3(), houseExitRot, 1, new Color(115, 115, 115), false, 0);
            Marker houseMarker = NAPI.Marker.CreateMarker(20, houseCoord, new Vector3(), new Vector3(0, 0, -15.618415), 1, new Color(115, 115, 115), false, 0);

            ColShape shape = NAPI.ColShape.CreateCylinderColShape(housePos, 1, 1, 0);
            ColShape houseShape = NAPI.ColShape.CreateCylinderColShape(houseCoord, 1, 1, 0);

            House house = new House()
            {
                Name = "Дом №" + number,
                ExteriorPositionX = player.Position.X,
                ExteriorPositionY = player.Position.Y,
                ExteriorPositionZ = player.Position.Z,
                ExteriorRotation = player.Rotation.Z,
                InteriorPositionX = 342.21008f,
                InteriorPositionY = 437.7816f,
                InteriorPositionZ = 149.38077f
            };
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                dbContext.Houses.Add(house);
                dbContext.SaveChanges();
            }

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

        [Command("id")]
        public void GetId(Player player)
        {
            
;           int userId = player.GetData<int>("UserId");
            int characterId = player.GetData<int>("CharacterId");

            NAPI.Chat.SendChatMessageToAll($"User: {userId}\n Character: {characterId}");
            
            
        }
        [Command("spawnped")]
        public void SpawnPed(Player player, PedHash skin)
        {            
            var peda = NAPI.Ped.CreatePed(skin, player.Position.Around(5), -1);
            Player ped = new Player(peda);
            NAPI.Player.SpawnPlayer(ped, player.Position.Around(6));
            NAPI.Player.SetPlayerSkin(ped, skin);
            NAPI.ClientEvent.TriggerClientEvent(player, "setFollow", player, ped, true);                      
                        
            /*mp.events.add('setFollow', function(toggle, entity) {  /// entity is the guy that player will follow him
                if (toggle)
                {
                    if (entity && mp.players.exists(entity))
                        localplayer.taskFollowToOffsetOf(entity.handle, 0, -1, 0, 1.0, -1, 1.0, true)
                }
                else
                    localplayer.clearTasks();
            });*/

        }            
        
        [Command("carlocked")]
        public void CarpawnLocked(Player player, string car)
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(car), NAPI.Entity.GetEntityPosition(player), 0f, 0, 0);
            vehicle.SetData("Engine", false);
            vehicle.Locked = true;
        }

        [Command("carcolor")]
        public void CarColor (Player player, int color)
        {
            player.Vehicle.PrimaryColor = color;
            //player.Vehicle.Controller.
        }
        [Command("setskin")]
        public void SetSkin(Player player, PedHash skin)
        {            
            player.SetSkin(skin);
        }

        [Command("caracc")]
        public void CarAcc(Player player, float number)
        {
            player.Vehicle.EnginePowerMultiplier = number;
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

        

        [Command("engine")]
        public void EngineToogle(Player player)
        {
            var status = NAPI.Vehicle.GetVehicleEngineStatus(player.Vehicle.Handle);
            NAPI.Vehicle.SetVehicleEngineStatus(player.Vehicle.Handle, !status);
        }
        [Command("lock")]
        public void LockToogle(Player player)
        {            
            var status = NAPI.Vehicle.GetVehicleLocked(player.Vehicle.Handle);
            NAPI.Vehicle.SetVehicleLocked(player.Vehicle.Handle, !status);
        }

        [Command("newuser")]
        public void NewUser(Player player, string email, string login, string password)
        {
            var _userService = new UserService();

            _userService.CreateUser(player, email, login, password);            

        }
        [Command("dim")]
        public void SetDimention(Player player, uint dimension)
        {
            player.Dimension = dimension;            

        }
        [Command("getdim")]
        public void getDimention(Player player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, player.Dimension.ToString());

        }



        [RemoteEvent("admChangeWeather")]
        public void AdminEvent_admChangeWeather(Player player, string select)
        {
            NAPI.World.SetWeather(select);
            NAPI.Notification.SendNotificationToPlayer(player, "Погода изменилась", true);
        }

        [RemoteEvent("admChangeTime")]
        public void AdminEvent_admChangeTime(Player player, string hour)
        {
            int new_hour = Convert.ToInt32(hour);
            NAPI.World.SetTime(new_hour, 0, 0);
            NAPI.Notification.SendNotificationToPlayer(player, "~g~Время изменено: " + new_hour, true);
        }

        [RemoteEvent("admChangeSkin")]
        public void AdminEvent_admChangeSkin(Player player, uint model)
        {
            NAPI.Player.SetPlayerSkin(player, model);
        }

    }
}
