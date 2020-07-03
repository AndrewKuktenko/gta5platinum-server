using Gta5Platinum.DataAccess.Account.UserModels;
using Gta5Platinum.DataAccess.UnitOfWork;
using System.Linq;

namespace Gta5Platinum.Server.Services.Common
{
    public class FinanceService : ServiceBase
    {
        public FinanceService(IGta5PlatinumUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public bool AddBankMoney(int characterId, int amount)
        {
            var user = _unitOfWork.GetRepository<Finance>()
                .GetAll()
                .Single(c => c.CharacterId == characterId);

            user.Bank += amount;

            int save = _unitOfWork.SaveChanges();

            if (save != 0)            
                return true;            
            else
                return false;             
                
        }
    }
}
