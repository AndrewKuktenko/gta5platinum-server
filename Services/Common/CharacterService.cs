using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Context;
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
    }
}
