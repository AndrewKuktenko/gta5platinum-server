using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
using GTANetworkAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Gta5Platinum.Server.Services.Common
{
    public class CharacterService
    {
        public List<Character> GetUserCharacters(Player player)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                List<Character> userCharacters = dbContext.Users
                    .Where(c => c.UserId == player.GetData<int>("UserId"))
                    .SelectMany(u => u.Characters)
                    .ToList();
                    
                return userCharacters;
            }
        }

        public JObject GetUserCharactersForClient(Player player)
        {
            var userCharacters = GetUserCharacters(player);

            return JObject.FromObject(userCharacters);          
        }        

        public Character GetUserCharacterFromClient(JObject json)
        {
            var character = JsonConvert.DeserializeObject<Character>(json.ToString());

            return character;            
        }
    }
}
