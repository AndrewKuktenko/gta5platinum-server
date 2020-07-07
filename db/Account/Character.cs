using Gta5Platinum.DataAccess.Account.UserModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account
{
    public class Character
    {
        [Key]        
        public int CharacterId { get; set; }
        public bool Gender { get; set; }
        public string Name { get; set; }
        public string NameTag { get; set; }
        public int Health { get; set; } = 100;
        public int Armour { get; set; } = 100;
        public IEnumerable<UserVehicle> UserVehicles { get; set; }
        public Finance UserFinances { get; set; }
        public IEnumerable<InventoryItem> CharacterInventory { get; set; }
        public CharacterClothes Clothes { get; set; }
        public CharacterCustomization HeadBlend { get; set; }
        public Organization Organization { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int jail { get; set; }
        public int jailtime { get; set; }
        public float Xpos { get; set; }
        public float Ypos { get; set; }
        public float Zpos { get; set; }
        public List<Property> Properties { get; set; }

        //public double[] last_location { get; set; } = new double[] { -1167.994, -700.4285, 21.89281 };
        //public double[] temp_location { get; set; }

        public Character()
        {
            CharacterInventory = new List<InventoryItem>();
            UserVehicles = new List<UserVehicle>();
            Properties = new List<Property>();
        }
    }
}
