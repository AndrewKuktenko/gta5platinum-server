using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class InventoryItem
    {
        [Key]
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }        
        [ForeignKey("InventoryId")]
        public int InventoryId { get; set; }
        public InventoryItem()
        {

        }
    }
}
