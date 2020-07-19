using Gta5Platinum.DataAccess.Account.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gta5Platinum.DataAccess.Account.PropertyModels
{
    public class HouseInventory
    {
        [Key]
        public Guid InventoryId { get; set; }
        [ForeignKey("HouseId")]
        public int HouseId { get; set; }
        public int MaxSize { get; set; }
        public IEnumerable<InventoryItem> Items { get; set; }

        public HouseInventory()
        {
            Items = new List<InventoryItem>();
        }
    }

}
