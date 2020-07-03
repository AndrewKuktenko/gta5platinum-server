using Gta5Platinum.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gta5Platinum.Server.Services.Admin
{
    public class AdminService : ServiceBase
    {
        public AdminService(IGta5PlatinumUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }
    }
}
