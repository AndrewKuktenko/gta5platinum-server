using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account.UserModels
{    
    public class Finance
    {
        [Key]
        public Guid FinanceId { get; set; }
        public int Bank { get; set; }
        public int Money { get; set; }
        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
    }
}
