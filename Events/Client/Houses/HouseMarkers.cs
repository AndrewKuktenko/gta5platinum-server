using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gta5Platinum.Server.Events.Client.Houses
{
    class HouseMarkers : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void CreateMarker()
        {
            /*Vector3 pos = new Vector3(-418.83035f, 1147.7933f, 325.86194f);
			Vector3 tpTo = new Vector3(341.05682f, 436.80807f, 149.39407f);
			Vector3 house = new Vector3(342.21008f, 437.7816f, 149.38077f);
			Vector3 fromHouse = new Vector3(-419.2538f, 1146.3009f, 325.8557f);
			Vector3 houseRot = new Vector3(0f, 0f, 139.90523f);
			Vector3 backRot = new Vector3(0f, 0f, 158.89879f);


			Marker marker = NAPI.Marker.CreateMarker(20, pos, new Vector3(), new Vector3(0, 0, -15.618415), 1, new Color(115, 115, 115), false, 0);
			Marker houseMarker = NAPI.Marker.CreateMarker(20, house, new Vector3(), new Vector3(0, 0, -15.618415), 1, new Color(115, 115, 115), false, 0);

			ColShape shape = NAPI.ColShape.CreateCylinderColShape(pos, 1, 1, 0);
			ColShape houseShape = NAPI.ColShape.CreateCylinderColShape(house, 1, 1, 0);

			
			shape.SetData("Marker", marker);
			shape.SetData("Position", tpTo);
			shape.SetData("Rotation", houseRot);
			//shape.SetData("Entered", false);
			
			houseShape.SetData("Marker", houseMarker);
			houseShape.SetData("Position", fromHouse);
			houseShape.SetData("Rotation", backRot);*/             

            using (var dbContext = new Gta5PlatinumDbContext())
            {
				//dbContext.Houses.AsNoTracking().Include(a => a.ExteriorPosition);


				List<House> houses = dbContext.Houses.ToList();
				
				houses = dbContext.Houses.Include(a => a.Inventory).ToList();
				
				if(houses != null)
				foreach (var house in houses)
				{
					NAPI.Util.ConsoleOutput(house.ToString());
					Vector3 extPos = new Vector3() { X = house.ExteriorPositionX, Y = house.ExteriorPositionY, Z = house.ExteriorPositionZ };
					Vector3 intPos = new Vector3() { X = house.InteriorPositionX, Y = house.InteriorPositionY, Z = house.InteriorPositionZ };
					Vector3 extRot = new Vector3() { X = 0f, Y = 0f, Z = house.ExteriorRotation };

					Vector3 houseRot = new Vector3(0f, 0f, 139.90523f);//TODO: заменить

					Marker marker = NAPI.Marker.CreateMarker(20, extPos, new Vector3(), new Vector3(0, 0, -15.618415), 1, new Color(115, 115, 115), false, 0);
					Marker houseMarker = NAPI.Marker.CreateMarker(20, intPos, new Vector3(), new Vector3(0, 0, -15.618415), 1, new Color(115, 115, 115), false, Convert.ToUInt32(house.HouseId));

					ColShape shape = NAPI.ColShape.CreateCylinderColShape(extPos, 1, 1, 0);
					ColShape houseShape = NAPI.ColShape.CreateCylinderColShape(intPos, 1, 1, Convert.ToUInt32(house.HouseId));

					shape.SetData("Marker", marker);
					shape.SetData("Dimension", house.HouseId);
					shape.SetData("Position", intPos + new Vector3(-1, -1, -1));
					shape.SetData("Rotation", houseRot);
					shape.SetData("House", house);
					//shape.SetData("Entered", false);

					houseShape.SetData("House", house);
					houseShape.SetData("Dimension", 0);
					houseShape.SetData("Marker", houseMarker);
					houseShape.SetData("Position", extPos + new Vector3(1, 1, 1));
					houseShape.SetData("Rotation", extRot);
				}
			}

            



        }
		/*[Command("sh")]
        public ColShape CreateShape(Player player, ColShape shape)
        {
            shape = CreateMarker(player);
        }*/
		[ServerEvent(Event.PlayerEnterColshape)]
		public void Event_EnterColshape(ColShape colshape, Player player)
		{			
			Marker marker = colshape.GetData<Marker>("Marker");
			Vector3 pos = colshape.GetData<Vector3>("Position");
			Vector3 rot = colshape.GetData<Vector3>("Rotation");
			int dimension = colshape.GetData<int>("Dimension");
			if (marker != null)
			{
				player.SendNotification("You entered zone");
				player.Dimension = Convert.ToUInt32(dimension);
				player.Position = pos;
				player.Rotation = rot;						
			}
		}

		[ServerEvent(Event.PlayerExitColshape)]
		public void Event_ExitColshape(ColShape colshape, Player player)
		{
			Marker marker = colshape.GetData<Marker>("Marker");
			if (marker != null)
			{
				player.SendNotification("You left zone");				
			}
		}
	}
}
