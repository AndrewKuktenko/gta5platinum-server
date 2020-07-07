using System.ComponentModel.DataAnnotations;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class UserVehicle
    {
        
        [Key]
        public int _id { get; set; }
        //public int _cid { get; set; }
        public int carslot { get; set; }
        public string carmodel { get; set; }
        //public double[] last_location { get; set; } = new double[] { 0, 0, 0 };
        public float last_rotation { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int spoilers { get; set; }
        public int fbumber { get; set; }
        public int rbumber { get; set; }
        public int sskirt { get; set; }
        public int exhaust { get; set; }
        public int frame { get; set; }
        public int grill { get; set; }
        public int roof { get; set; }
        public int motortuning { get; set; }
        public int brakes { get; set; }
        public int transmission { get; set; }
        public int turbo { get; set; }
        public int fwheels { get; set; }
        public int bwheels { get; set; }
        public int window { get; set; }
        public int suspension { get; set; }

                       

        /*public static void GetLastCarPosition(Player Player)
        {
            Vehicle personal_vehicle = Player.GetData<Vehicle>("UserVehicle");

            int Player_id = Player.GetData<int>("ID");

            PlayerInfo playerInfo = PlayerHelper.GetPlayerStats(Player);
            UserVehicle pVeh = PlayerHelper.GetpVehiclesStats(Player);


            if (pVeh == null)
                return;

            if (pVeh._id == Player_id)
            {
                Vector3 pVehSpawn = new Vector3(pVeh.last_location[0], pVeh.last_location[1], pVeh.last_location[2]);

                //Player.SendChatMessage("~g~Du besitzt ein Fahrzeug!");
                uint pVehHash = NAPI.Util.GetHashKey(pVeh.carmodel);
                Vehicle veh = NAPI.Vehicle.CreateVehicle(pVehHash, pVehSpawn, pVeh.last_rotation, 0, 0);
                //NAPI.Vehicle.SetVehicleEngineStatus(veh, false);
                NAPI.Vehicle.SetVehicleNumberPlate(veh, Player.Name);

                NAPI.Vehicle.SetVehicleLocked(veh, true);
                NAPI.Vehicle.SetVehicleEngineStatus(veh, false);
                NAPI.Vehicle.SetVehicleExtra(veh, 0, true);

                //Tunes
                LoadTunes(Player, veh);

                Player.SetData("Engine", false);
                Player.SetData("UserVehicle", veh);
                veh.SetData("ID", Player_id);
            }
        }
        public static void LoadTunes(Player Player, Vehicle vehicle)
        {
            UserVehicle pVeh = PlayerHelper.GetpVehiclesStats(Player);
            NAPI.Vehicle.SetVehiclePrimaryColor(vehicle, pVeh.Color1);
            NAPI.Vehicle.SetVehicleSecondaryColor(vehicle, pVeh.Color2);
            NAPI.Vehicle.SetVehicleMod(vehicle, 0, pVeh.spoilers);
            NAPI.Vehicle.SetVehicleMod(vehicle, 1, pVeh.fbumber);
            NAPI.Vehicle.SetVehicleMod(vehicle, 2, pVeh.rbumber);
            NAPI.Vehicle.SetVehicleMod(vehicle, 3, pVeh.sskirt);
            NAPI.Vehicle.SetVehicleMod(vehicle, 4, pVeh.exhaust);
            NAPI.Vehicle.SetVehicleMod(vehicle, 5, pVeh.frame);
            NAPI.Vehicle.SetVehicleMod(vehicle, 6, pVeh.grill);
            NAPI.Vehicle.SetVehicleMod(vehicle, 10, pVeh.roof);
            NAPI.Vehicle.SetVehicleMod(vehicle, 11, pVeh.motortuning);
            NAPI.Vehicle.SetVehicleMod(vehicle, 12, pVeh.brakes);
            NAPI.Vehicle.SetVehicleMod(vehicle, 13, pVeh.transmission);
            NAPI.Vehicle.SetVehicleMod(vehicle, 18, pVeh.turbo);
            NAPI.Vehicle.SetVehicleMod(vehicle, 23, pVeh.fwheels);
            NAPI.Vehicle.SetVehicleMod(vehicle, 24, pVeh.bwheels); //MOTORAD
            NAPI.Vehicle.SetVehicleWindowTint(vehicle, pVeh.window);
            NAPI.Vehicle.SetVehicleMod(vehicle, 15, pVeh.suspension);
        }
    }*/


        public UserVehicle()
        {
            /*Vehicle = new Entity() { id
            };*/
        }
    }
}
