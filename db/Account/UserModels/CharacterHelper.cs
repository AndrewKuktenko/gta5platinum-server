using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class CharacterHelper
    {
        /*public static Character GetPlayer(Player Player)
        {
            if (!Player.HasData("ID"))
                return null;

            int pInfo = Player.GetData<int>("ID");
            Character p = Database.GetById<Players>(pInfo);
            return p;
        }

        public static Character GetPlayerStats(Player Player)
        {
            if (!Player.HasData("ID"))
                return null;

            int pInfo = Player.GetData<int>("ID");
            Character playerInfo = Database.GetById<Character>(pInfo);
            return playerInfo;
        }

        public static CharacterClothes GetPlayerClothes(Player Player)
        {
            if (!Player.HasData("ID"))
                return null;

            int pInfo = Player.GetData<int>("ID");
            CharacterClothes pClothes = Database.GetById<CharacterClothes>(pInfo);
            return pClothes;
        }

        public static BanLog BanLogs(Player Player)
        {
            if (!Player.HasData("ID"))
                return null;

            int bpid = Player.GetData<int>("ID");
            BanLog Banlog = Database.GetById<BanLog>(bpid);
            return Banlog;
        }

        public static KickLog KickLogs(Player Player)
        {
            if (!Player.HasData("ID"))
                return null;

            int kpid = Player.GetData<int>("ID");
            KickLog Kicklog = Database.GetById<KickLog>(kpid);
            return Kicklog;
        }

        public static UserVehicle GetpVehiclesStats(Player Player)
        {
            if (!Player.HasData("ID"))
                return null;

            int pInfo = Player.GetData<int>("ID");
            UserVehicle pVeh = Database.GetById<UserVehicle>(pInfo);
            return pVeh;
        }

        public static Player GetPlayerByName(string name)
        {
            Player Player = null;

            foreach (Player Player_itr in NAPI.Pools.GetAllPlayers())
            {
                if (Player.Name.ToLower() == name.ToLower())
                {
                    return Player_itr;
                }
            }

            return Player;
        }
*/
    }
}
