using Gta5Platinum.DataAccess.Account;
using Gta5Platinum.DataAccess.Account.UserModels;
using Gta5Platinum.DataAccess.Context;
using Gta5Platinum.DataAccess.UnitOfWork;
using Gta5Platinum.Server.Client.Authorization;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using SocialApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gta5Platinum.Server.Services.Common
{
    public interface IUserService
    {
        /// <summary>
        /// регистрация пользоватя
        /// </summary>
        /// <returns>bool</returns>
        int CreateUser(Player player, string email, string login, string password);

        /// <summary>
        /// получает пользоватя через его Id
        /// </summary>
        /// <returns>User or null</returns>
        User GetUser(int userId);

        /// <summary>
        /// получает пользоватя используя переданный предикат через метод FirstOrDefault
        /// </summary>
        /// <returns>User or null</returns>
        User GetFirstUser(Expression<Func<User, bool>> predicate);

        /// <summary>
        /// получает пользоватя используя переданный предикат через метод SingleOrDefault
        /// </summary>
        /// <returns>User or null</returns>
        User GetSingleUser(Expression<Func<User, bool>> predicate);

        IEnumerable<User> GetUsers();

        IEnumerable<User> GetUsers(Expression<Func<User, bool>> predicate);

        /// <summary>
        /// получает id последнего зарегестрированного пользователя 
        /// </summary>
        //int GetLastUserId();

        /// <summary>
        /// сохраняет изменения с пользователями 
        /// </summary>
        int SaveChanges();
    }

    public class UserService
    {
        private readonly Gta5PlatinumUnitOfWork _unitOfWork;
        public UserService()
        {
            _unitOfWork = new Gta5PlatinumUnitOfWork();
        }

        public async Task<bool> SendMessage(string email)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, "Platinum", "Тест письма: тест!");
            return true;
        }

        public async Task<int> CreateUser(Player player, string email, string login, string password)
        {           
            User userByLogin = GetSingleUser(u => u.Login == login);
            User userByEmail = GetSingleUser(u => u.Email == email);
                        
            if (userByLogin == null && userByEmail == null)
            {
                User user = new User
                {
                    Email = email,
                    Login = login,
                    Password = password,
                    RegistrationDate = DateTime.Now.ToString(),
                    SocialClubId = player.SocialClubId,
                    SocialClubName = player.SocialClubName,
                    Serial = player.Serial,
                    Ip = player.Address,
                    DonateBalance = 0,
                    Characters = new List<Character>()
                };

                using (var dbContext = new Gta5PlatinumDbContext())
                {
                    var users = dbContext.Users;

                    try
                    {
                        dbContext.Add(user);

                        dbContext.SaveChanges();

                        await SendMessage(email);

                        return 1;       // Пользователь успешно зарегестрирован
                        
                    }
                    catch (Exception) // Ошибка сервера
                    {
                        return 4; 
                    }

                }
            }
            else if (userByLogin != null) // Пользователь с таким логином уже существует
            {
                return 2; 
            }
            else if (userByEmail != null) // Пользователь с такой почтой уже существует
            {
                return 3; 
            }
            else // Ошибка сервера
            {
                return 4;  
            }

        }
    

        public User GetUser(int userId)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                return dbContext.Users.SingleOrDefault(u => u.UserId == userId);
            }
        }

        public LoginInfo TryLogIn(string userLogin, string userPassword)
        {
            var loginInfo = new LoginInfo();

            using (var dbContext = new Gta5PlatinumDbContext())
            {
                try
                {
                    var user = dbContext.Users.Single(u => u.Login == userLogin);                    

                    if (user.Password == userPassword)
                    {
                        loginInfo.UserId = user.UserId;
                        loginInfo.Status = 1;

                        return loginInfo;
                    }
                    else if (user.Password != userPassword)
                    {
                        loginInfo.Status = 2;

                        return loginInfo;
                    }
                }
                catch (Exception) // Неверный логин, или такого пользователя не существует
                {
                    loginInfo.Status = 3;

                    return loginInfo;
                }

                loginInfo.Status = 4;
                return loginInfo; // Сервер не отвечает
            }
        }

        public User GetSingleUser(Expression<Func<User, bool>> predicate)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                return dbContext.Users.SingleOrDefault(predicate);
            }
        }

        public User GetFirstUser(Expression<Func<User, bool>> predicate)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                return dbContext.Users.FirstOrDefault(predicate);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                return dbContext.Users.ToArray();
            }
        }

        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> predicate)
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                return dbContext.Users.Where(predicate).ToArray();
            }
        }

        public int SaveChanges()
        {
            using (var dbContext = new Gta5PlatinumDbContext())
            {
                return dbContext.SaveChanges();
            }
        }
        
    }    
}
