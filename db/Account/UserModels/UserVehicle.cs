using System.ComponentModel.DataAnnotations;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class UserVehicle
    {
        
        [Key]
        public int VehicleId { get; set; }
        public Vector LastLocation { get; set; }
        //public int _cid { get; set; }
        public int Carslot { get; set; }
        public string CarModel { get; set; }
        //public double[] last_location { get; set; } = new double[] { 0, 0, 0 };
        public float LastRotation { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Spoilers { get; set; }
        public int FrontBumper { get; set; }
        public int RearBumper { get; set; }
        public int SideSkirt { get; set; }
        public int Exhaust { get; set; }
        public int Frame { get; set; }
        public int Grill { get; set; }
        public int Roof { get; set; }
        public int MotorTuning { get; set; }
        public int Brakes { get; set; }
        public int Transmission { get; set; }
        public int Turbo { get; set; }
        public int FrontWheels { get; set; }
        public int RearWheels { get; set; }
        public int Window { get; set; }
        public int Suspension { get; set; }

                       

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
            NAPI.Vehicle.SetVehicleMod(vehicle, 0, pVeh.Spoilers);
            NAPI.Vehicle.SetVehicleMod(vehicle, 1, pVeh.FrontBumper);
            NAPI.Vehicle.SetVehicleMod(vehicle, 2, pVeh.RearBumper);
            NAPI.Vehicle.SetVehicleMod(vehicle, 3, pVeh.SideSkirt);
            NAPI.Vehicle.SetVehicleMod(vehicle, 4, pVeh.Exhaust);
            NAPI.Vehicle.SetVehicleMod(vehicle, 5, pVeh.Frame);
            NAPI.Vehicle.SetVehicleMod(vehicle, 6, pVeh.Grill);
            NAPI.Vehicle.SetVehicleMod(vehicle, 10, pVeh.Roof);
            NAPI.Vehicle.SetVehicleMod(vehicle, 11, pVeh.MotorTuning);
            NAPI.Vehicle.SetVehicleMod(vehicle, 12, pVeh.Brakes);
            NAPI.Vehicle.SetVehicleMod(vehicle, 13, pVeh.Transmission);
            NAPI.Vehicle.SetVehicleMod(vehicle, 18, pVeh.Turbo);
            NAPI.Vehicle.SetVehicleMod(vehicle, 23, pVeh.FrontWheels);
            NAPI.Vehicle.SetVehicleMod(vehicle, 24, pVeh.RearWheels); //MOTORAD
            NAPI.Vehicle.SetVehicleWindowTint(vehicle, pVeh.Window);
            NAPI.Vehicle.SetVehicleMod(vehicle, 15, pVeh.Suspension);
        }
    }*/


        public UserVehicle()
        {
            /*Vehicle = new Entity() { id
            };*/
        }
    }
}
