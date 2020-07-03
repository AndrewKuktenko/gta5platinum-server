using Gta5Platinum.Server.Services.Common;
using GTANetworkAPI;

namespace Gta5Platinum.Server.Client.Authorization
{
    public class Authorization : Script
    {
        private readonly UserService _userService;
        public Authorization()
        {
            _userService = new UserService();
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            player.TriggerEvent("loginBrowser");
        }

        [RemoteEvent("OnPlayerLoginAttempt")]
        public void OnPlayerLoginAttempt(Player player, string username, string password)
        {            
            bool success = _userService.TryLogIn(username, password);

            NAPI.Util.ConsoleOutput($"[Login Attempt] Username {username} | Password: {password}"); //TODO: Заменить на логирование

            if (success == true)
            {
                player.TriggerEvent("LoginResult", 1);
            }
            else player.TriggerEvent("LoginResult", 0);
        }

        [RemoteEvent("OnPlayerRegisterAttempt")]
        public void OnPlayerRegisterAttempt(Player player, string email, string username, string password)
        {           
            bool success = _userService.CreateUser(player, email, username, password);

            NAPI.Util.ConsoleOutput($"[Registration Attempt] Username {username} | Password: {password}"); //TODO: Заменить на логирование

            if (success == true)
            {
                player.TriggerEvent("RegistrationResult", 1);
            }
            else player.TriggerEvent("RegistrationResult", 0);
        }
    }
}
