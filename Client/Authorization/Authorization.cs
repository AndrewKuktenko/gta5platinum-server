using Gta5Platinum.Server.Events.Client.CharacterSelector;
using Gta5Platinum.Server.Services.Common;
using GTANetworkAPI;
using System;

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
            player.TriggerEvent("OnPlayerConnected");
        }

        [RemoteEvent("OnPlayerLoginAttempt")]
        public void OnPlayerLoginAttempt(Player player, string username, string password)
        {            
            LoginInfo loginInfo = _userService.TryLogIn(username, password);

            NAPI.Util.ConsoleOutput($"[Login Attempt] Username {username} | Password: {password}"); //TODO: Заменить на логирование

            if (loginInfo.Status == 1) // Успешный вход
            {
                player.SetData<int>("UserId", (int)loginInfo.UserId);
                player.TriggerEvent("LoginResult", 1);
                player.TriggerEvent("OpenCharacterSelector");
                OnSignInCharacterEvents charEvents = new OnSignInCharacterEvents();
                player.TriggerEvent("GetUserCharacters", charEvents.GetUserCharacters(player));
            }
            else if (loginInfo.Status == 2) // Неверный пароль
            { 
                player.TriggerEvent("LoginResult", 2); 
            }
            else if (loginInfo.Status == 3) // Неверный логин, или такого пользователя не существует
            {
                player.TriggerEvent("LoginResult", 3);
            }
            else // Сервер не отвечает
            {
                player.TriggerEvent("LoginResult", 4);
            }
        }

        [RemoteEvent("OnPlayerRegisterAttempt")]
        public void OnPlayerRegisterAttempt(Player player, string email, string username, string password)
        {           
            var task = _userService.CreateUser(player, email, username, password);
            var status = task.Result;

            NAPI.Util.ConsoleOutput($"[Registration Attempt] Username {username} | Password: {password}"); //TODO: Заменить на логирование

            if (status == 1)
            {
                player.TriggerEvent("RegistrationResult", 1);
            }
            else if (status == 2)
            {
                player.TriggerEvent("RegistrationResult", 2);
            }
            else if (status == 3)
            {
                player.TriggerEvent("RegistrationResult", 3);
            }
            else
            {
                player.TriggerEvent("RegistrationResult", 4);
            }
        }
    }
}
