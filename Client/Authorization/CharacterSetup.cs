using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
using Gta5Platinum.Server.Services.Common;
using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Gta5Platinum.Server.player.Authorization
{
    public class CharacterSetup
    {
        public void TestLoadCharacterOnSpawn(Player player, JObject characterJson)
        {
            CharacterService characterService = new CharacterService();

            var character = characterService.GetUserCharacterFromClient(characterJson);

            player.SetData<int>("CharacterId", character.CharacterId);
            player.Armor = character.Armour;
            player.Health = character.Health;
            player.Name = character.Name + $"({character.CharacterId})";            
            
        }
        /*public void LoadCharacterOnSpawn(Player player, int characterId)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                var character = dbContext.Characters.Single(c => c.CharacterId == characterId);

                player.Armor = character.Armour;
                player.Health = character.Health;
                player.Name = character.Name + $"({character.CharacterId})";
                player.Nametag = character.NameTag;
                player.Position = new Vector3(character.LastPosition.X, character.LastPosition.Y, character.LastPosition.Z);

                //player.SetCustomization(character.Gender, GetCharacterHeadBlend(character), character.HeadBlend.EyeColor, character.HeadBlend.HairColor, character.HeadBlend.HighlightColor, new Dictionary<int, HeadOverlay>(), new Decoration[] { new Decoration() { Collection = 0, Overlay = 0} });

                NAPI.Player.SetPlayerHeadBlend(player, GetCharacterHeadBlend(character));
                SetClothesOnSpawn(player, character);         
            }            
            
        }*/

        /// <summary>
        /// загрузка персонажа после его выбора
        /// </summary>
        /// <returns>void</returns>
        public void LoadCharacterOnSpawn(Player player, JObject characterJson)
        {
            CharacterService characterService = new CharacterService();           
            
            var character = characterService.GetUserCharacterFromClient(characterJson);

            player.SetData<int>("CharacterId", character.CharacterId);
            player.Armor = character.Armour;
            player.Health = character.Health;
            player.Name = character.Name + $"({character.CharacterId})";
            player.Nametag = character.NameTag;
            player.Position = new Vector3(character.LastPosition.X, character.LastPosition.Y, character.LastPosition.Z);

            //player.SetCustomization(character.Gender, GetCharacterHeadBlend(character), character.HeadBlend.EyeColor, character.HeadBlend.HairColor, character.HeadBlend.HighlightColor, new Dictionary<int, HeadOverlay>(), new Decoration[] { new Decoration() { Collection = 0, Overlay = 0} });

            NAPI.Player.SetPlayerHeadBlend(player, GetCharacterHeadBlend(character));
            SetClothesOnSpawn(player, character);
            

        }

        public void SetClothesOnSpawn(Player player, Character character)
        {
            player.SetClothes(1, character.Clothes.clothes_1, 0);
            player.SetClothes(2, character.Clothes.clothes_2, 0);
            player.SetClothes(3, character.Clothes.clothes_3, 0);
            player.SetClothes(4, character.Clothes.clothes_4, 0);
            player.SetClothes(5, character.Clothes.clothes_5, 0);
            player.SetClothes(6, character.Clothes.clothes_6, 0);
            player.SetClothes(7, character.Clothes.clothes_7, 0);
            player.SetClothes(8, character.Clothes.clothes_8, 0);
            player.SetClothes(9, character.Clothes.clothes_9, 0);
            player.SetClothes(10, character.Clothes.clothes_10, 0);
            player.SetClothes(11, character.Clothes.clothes_11, 0);
        }
        /// <summary>
        /// загрузка черт лицы персонажа
        /// </summary>
        /// <returns>HeadBlend</returns>
        public HeadBlend GetCharacterHeadBlend(Character character)
        {
            return new HeadBlend()
            { 
                ShapeFirst = character.HeadBlend.ShapeFirst,
                ShapeSecond = character.HeadBlend.ShapeSecond,
                ShapeThird = character.HeadBlend.ShapeThird,
                SkinFirst = character.HeadBlend.SkinFirst,
                SkinSecond = character.HeadBlend.SkinSecond,
                SkinThird = character.HeadBlend.SkinThird,
                ShapeMix = character.HeadBlend.ShapeMix,
                SkinMix = character.HeadBlend.SkinMix,
                ThirdMix = character.HeadBlend.SkinMix
            };            
        }
    }
}
