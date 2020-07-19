using Gta5Platinum.DataAccess.Account.PropertyModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account
{
    public class House
    {
        [Key]
        public int HouseId { get; set; }
        [DefaultValue(10000)]
        public int Price { get; set; }
        [DefaultValue(false)]
        public bool Owned { get; set; }

        public string Name { get; set; }        

        [ForeignKey("CharacterId")]
        public int? CharacterId { get; set; }
        [ForeignKey("OrganizationId")]
        public int? OrganizationId { get; set; }        

        [StringLength(48)]
        public string IPL { get; set; }       
        
        public float ExteriorPositionX { get; set; }
        public float ExteriorPositionY { get; set; }
        public float ExteriorPositionZ { get; set; }
        public float ExteriorRotation { get; set; }

        public float InteriorPositionX { get; set; }
        public float InteriorPositionY { get; set; }
        public float InteriorPositionZ { get; set; }
        public float InteriorRotation { get; set; }

        [DefaultValue(false)]
        public bool Locked { get; set; }
        public List<HouseInventory> Inventory { get; set; }

    }
}
