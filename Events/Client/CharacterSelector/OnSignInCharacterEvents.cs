using Gta5Platinum.Server.player.Authorization;
using Gta5Platinum.Server.Services.Common;
using GTANetworkAPI;
using Newtonsoft.Json.Linq;

namespace Gta5Platinum.Server.Events.Client.CharacterSelector
{
    public class OnSignInCharacterEvents : Script
    {
        /// <summary>
        /// загрузка персонажей пользователя для клиента
        /// </summary>
        /// <returns>JObject</returns>
        [RemoteEvent("GetUserCharacters")]
        public JObject GetUserCharacters(Player player)
        {
            CharacterService characterService = new CharacterService();

            return characterService.GetUserCharactersForClient(player);
        }

        /// <summary>
        /// загрузка персонажа после его выбора на клиенте
        /// </summary>
        /// <returns>void</returns>
        [RemoteEvent("SetSelectedCharacter")]
        public void CharacterSetUp(Player player, JObject character)
        {
            CharacterSetup characterSetup = new CharacterSetup();           

            characterSetup.LoadCharacterOnSpawn(player, character);
        }

        [RemoteEvent("TestSetSelectedCharacter")]
        public void TestCharacterSetUp(Player player, JObject character)
        {
            CharacterSetup characterSetup = new CharacterSetup();

            characterSetup.TestLoadCharacterOnSpawn(player, character);
        }


    }
}
