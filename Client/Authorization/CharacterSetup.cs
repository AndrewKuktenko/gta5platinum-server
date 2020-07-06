using Gta5Platinum.DataAccess.Context;
using GTANetworkAPI;
using System.Linq;

namespace Gta5Platinum.Server.Client.Authorization
{
    public class CharacterSetup
    {
        public void LoadCharacterOnSpawn(Player player, int characterId)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                var character = dbContext.Characters.Single(c => c.CharacterId == characterId);

                player.Armor = character.Armour;
                player.Health = character.Health;
                player.Name = character.Name;
                player.Nametag = character.NameTag;
                player.Position = new Vector3(character.Xpos, character.Ypos, character.Zpos);
            }
            
            
        }
    }
}
