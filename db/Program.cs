using Gta5Platinum.DataAccess.Account;
//using Gta5Platinum.DataAccess.Account.UserModels;
using Gta5Platinum.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gta5Platinum.DataAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new Gta5PlatinumDbContext())
            {                
                db.Database.EnsureCreated();
            }
            Console.ReadKey();
        }
    }
}
