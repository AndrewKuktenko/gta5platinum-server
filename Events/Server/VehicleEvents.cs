using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gta5Platinum.Server.Events.Server
{
    public class VehicleEvents : Script
    {
        [ServerEvent(Event.PlayerEnterVehicleAttempt)]
        public void OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatID)
        {
            vehicle.NumberPlate = "IIOCOCU";
            if (player.VehicleSeat == 0)
            {
                player.TriggerEvent("PlayerEnterVehicleAttempt", player.Vehicle, player.VehicleSeat);
            }
        }
        [Command("tengine")]
        public void EngineToggle(Player player)
        {
                       
                player.TriggerEvent("ToggleEngine", player.Vehicle);
            
        }

       /* [ServerEvent(Event.PlayerExitVehicleAttempt)]
        public void OnPlayerExitVehicleAttempt(Player player, Vehicle vehicle)
        {

            player.TriggerEvent("PlayerExitVehicleAttempt", vehicle);

        }*/

        [ServerEvent(Event.PlayerExitVehicle)]
        public void OnPlayerExitVehicle(Player player, Vehicle vehicle)
        {      
            
                player.TriggerEvent("PlayerExitVehicle", vehicle);
            
        }
    }
}

