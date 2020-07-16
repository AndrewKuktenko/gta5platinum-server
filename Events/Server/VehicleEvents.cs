using GTANetworkAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gta5Platinum.Server.Events.Server
{
    public enum WindowID
    {
        WindowFrontRight,
        WindowFrontLeft,
        WindowRearRight,
        WindowRearLeft
    }

    public enum WindowState
    {
        WindowFixed,
        WindowDown,
        WindowBroken
    }

    public enum DoorID
    {
        DoorFrontLeft,
        DoorFrontRight,
        DoorRearLeft,
        DoorRearRight,
        DoorHood,
        DoorTrunk
    }

    public enum DoorState
    {
        DoorClosed,
        DoorOpen,
        DoorBroken
    }

    public enum WheelID
    {
        Wheel0,
        Wheel1,
        Wheel2,
        Wheel3,
        Wheel4,
        Wheel5,
        Wheel6,
        Wheel7,
        Wheel8,
        Wheel9
    }

    public enum WheelState
    {
        WheelFixed,
        WheelBurst,
        WheelOnRim
    }
    public class VehicleSyncData
    {
        public int CarId { get; set; } = 0;
        //Used to bypass some streaming bugs
        public Vector3 Position { get; set; } = new Vector3();
        public Vector3 Rotation { get; set; } = new Vector3();

        //Basics
        public float Dirt { get; set; } = 0.0f;
        public bool Locked { get; set; } = true;
        public bool Engine { get; set; } = false;

        //(Not synced)
        public float BodyHealth { get; set; } = 1000.0f;
        public float EngineHealth { get; set; } = 1000.0f;

        //Doors 0-7 (0 = closed, 1 = open, 2 = broken) (This uses enums so don't worry about it)
        public int[] Door { get; set; } = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

        //Windows (0 = up, 1 = down, 2 = smashed) (This uses enums so don't worry about it)
        public int[] Window { get; set; } = new int[4] { 0, 0, 0, 0 };

        //Wheels 0-7, 45/47 (0 = fixed, 1 = flat, 2 = missing) (This uses enums so don't worry about it)
        public int[] Wheel { get; set; } = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    public class VehicleEvents : Script
    {
        /*[ServerEvent(Event.PlayerEnterVehicle)]
        public void OnPlayerEnterVehicle(Player player, Vehicle veh, sbyte seatID)
        {

            veh.GetData<VehicleSyncData>("VehicleSyncData");
                player.SendNotification("Schalte den Motor mit '~g~X~w~' an oder aus");
            
        }
        public void SetVehicleSyncDataFromClient(Player player, string data)
        {
            player.Vehicle.SetData("VehicleSyncData", JsonConvert.DeserializeObject<VehicleSyncData>(data));
        }
        public JObject SendVehicleSyncDataToClient(Player player)
        {
            return JObject.FromObject(player.Vehicle.GetData<VehicleSyncData>("VehicleSyncData"));
        }        

        [ServerEvent(Event.PlayerExitVehicleAttempt)]
        public void OnPlayerExitVehicleAttempt(Player player, Vehicle vehicle)
        {

            player.TriggerEvent("GetVehicleSyncDataFromClient", vehicle);

        }
        [ServerEvent(Event.VehicleDamage)]
        public void OnVehicleDamage(Player player, Vehicle vehicle)
        {

            player.TriggerEvent("GetVehicleSyncDataFromClient", vehicle);

        }
        [ServerEvent(Event.VehicleSirenToggle)]
        public void OnVehicleSirenToggle(Player player, Vehicle vehicle)
        {

           
        }*/
        [Command("car")]
        public void CarSpawn(Player player, string car, int carId)
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(car), player.Position.Around(5), 0f, 0, 0, "TU PIDOR");
            VehicleSyncData data = new VehicleSyncData();
            data.CarId = carId;
            vehicle.SetSharedData("VehicleSyncData", data);
            //vehicle.SetData("VehicleSyncData", new VehicleStreaming.VehicleSyncData());

        }
        [RemoteEvent("SyncDataFromClient")]
        public void VehStreamSetWheelData(Vehicle veh, string clientData)
        {
            VehicleSyncData data = JsonConvert.DeserializeObject<VehicleSyncData>(clientData);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            
            veh.SetData("VehicleSyncData", data);

            //Re-distribute the goods            
        }
        [ServerEvent(Event.VehicleDoorBreak)]
        public void VehDoorBreak(Vehicle veh, int index)
        {
            VehicleSyncData data = GetVehicleSyncData(veh);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            data.Door[index] = 2;

            veh.SetData("VehicleSyncData", data);

            NAPI.ClientEvent.TriggerClientEventInDimension(veh.Dimension, "VehStream_SetVehicleDoorStatus", veh.Handle, data.Door[0], data.Door[1], data.Door[2], data.Door[3], data.Door[4], data.Door[5], data.Door[6], data.Door[7]);
        }
        [ServerEvent(Event.PlayerEnterVehicleAttempt)]
        public void VehStreamEnterAttempt(Player player, Vehicle veh, sbyte seat)
        {
            VehicleSyncData data = GetVehicleSyncData(veh);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            veh.SetData("VehicleSyncData", data);
            NAPI.ClientEvent.TriggerClientEvent(player, "VehStream_PlayerEnterVehicleAttempt", veh.Handle, seat);
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        public void VehStreamEnter(Player player, Vehicle veh, sbyte seat)
        {
            VehicleSyncData data = GetVehicleSyncData(veh);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            veh.SetData("VehicleSyncData", data);
            NAPI.ClientEvent.TriggerClientEvent(player, "VehStream_PlayerEnterVehicle", veh.Handle, player.VehicleSeat);
        }

        [RemoteEvent("VehStream_SetWheelData")]
        public void VehStreamSetWheelData(Player player, Vehicle veh, int wheel1state, int wheel2state, int wheel3state, int wheel4state, int wheel5state, int wheel6state, int wheel7state, int wheel8state, int wheel9state, int wheel10state)
        {
            VehicleSyncData data = GetVehicleSyncData(veh);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            data.Wheel[0] = wheel1state;
            data.Wheel[1] = wheel2state;
            data.Wheel[2] = wheel3state;
            data.Wheel[3] = wheel4state;
            data.Wheel[4] = wheel5state;
            data.Wheel[5] = wheel6state;
            data.Wheel[6] = wheel7state;
            data.Wheel[7] = wheel8state;
            data.Wheel[8] = wheel9state;
            data.Wheel[9] = wheel10state;
            veh.SetData("VehicleSyncData", data);

            //Re-distribute the goods
            NAPI.ClientEvent.TriggerClientEventInDimension(veh.Dimension, "VehStream_SetVehicleWheelStatus", veh.Handle, wheel1state, wheel2state, wheel3state, wheel4state, wheel5state, wheel6state, wheel7state, wheel8state, wheel9state, wheel10state);
        }
        [ServerEvent(Event.VehicleDamage)]
        public void VehDamage(Vehicle veh, float bodyHealthLoss, float engineHealthLoss)
        {
            VehicleSyncData data = GetVehicleSyncData(veh);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            data.BodyHealth -= bodyHealthLoss;
            data.EngineHealth -= engineHealthLoss;

            veh.SetData("VehicleSyncData", data);

            if (NAPI.Vehicle.GetVehicleDriver(veh.Handle) != default(Player)) //Doesn't work?
                NAPI.ClientEvent.TriggerClientEvent((Player)NAPI.Vehicle.GetVehicleDriver(veh.Handle), "VehStream_PlayerExitVehicleAttempt", veh.Handle);
        }

        public static VehicleSyncData GetVehicleSyncData(Vehicle veh)
        {
            if (veh != null)
            {
                if (NAPI.Entity.DoesEntityExist(veh.Handle))
                {
                    if (veh.HasData("VehicleSyncData"))
                    {

                        return veh.GetData<VehicleSyncData>("VehicleSyncData");
                    }
                }
            }

            return default(VehicleSyncData); //null
        }
        /*[ServerEvent(Event.PlayerEnterVehicleAttempt)]
        public void OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatID)
        {
            vehicle.NumberPlate = "IIOCOCU";
            if (player.VehicleSeat == 0)
            {
                player.TriggerEvent("PlayerEnterVehicleAttempt", player.Vehicle, player.VehicleSeat);
            }
        }*/
        [Command("tengine")]
        public void EngineToggle(Player player)
        {              
                       

            VehicleSyncData data = GetVehicleSyncData(player.Vehicle);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            player.TriggerEvent("ToggleEngine", player.Vehicle.Handle, data);

            player.Vehicle.SetData("VehicleSyncData", data);            

        }
        [RemoteEvent("SyncEngine")]
        public void IsEngineStarted(Vehicle vehicle, bool engine)
        {
            VehicleSyncData data = GetVehicleSyncData(vehicle);
            if (data == default(VehicleSyncData))
                data = new VehicleSyncData();

            data.Engine = engine;

            vehicle.SetData("VehicleSyncData", data);
        }

        /* [ServerEvent(Event.PlayerExitVehicleAttempt)]
         public void OnPlayerExitVehicleAttempt(Player player, Vehicle vehicle)
         {

             player.TriggerEvent("PlayerExitVehicleAttempt", vehicle);

         }*/

        /*[ServerEvent(Event.PlayerExitVehicle)]
        public void OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {

            player.TriggerEvent("PlayerExitVehicle", vehicle);

        }*/
    }
}

