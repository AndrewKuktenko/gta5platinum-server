using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Gta5Platinum.Server.Services.Common
{
    public class CharacterService
    {
        public List<Character> GetUserCharacters(int userId)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                List<Character> userCharacters = dbContext.Users
                    .Where(c => c.UserId == userId)
                    .SelectMany(u => u.Characters)
                    .ToList();
                    
                return userCharacters;
            }
        }

        public JObject GetUserCharactersForClient(int userId)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                List<Character> userCharacters = dbContext.Users
                    .Where(c => c.UserId == userId)
                    .SelectMany(u => u.Characters)
                    .ToList();                
                
                return JObject.FromObject(userCharacters);
            }
        }

        public Character GetUserCharactersFromClient(JObject json)
        {
            var character = JsonConvert.DeserializeObject<Character>(json.ToString());

            return character;            
        }
    }
}
