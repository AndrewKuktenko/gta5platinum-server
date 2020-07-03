using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class Inventory
    {
        [Key]
        public Guid InventoryId { get; set; }
        public IEnumerable<InventoryItem> Items { get; set; }
        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }

        public Inventory()
        {
            Items = new List<InventoryItem>();
        }
    }
}
