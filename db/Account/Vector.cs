using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account
{
    public class Vector
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PropertyId")]
        public int? PropertyId { get; set; }
        [ForeignKey("CharacterId")]
        public int? CharacterId { get; set; }
        [ForeignKey("VehicleId")]
        public int? VehicleId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
