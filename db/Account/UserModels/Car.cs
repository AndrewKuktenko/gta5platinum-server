using GTANetworkAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
        public int WheelColor { get; set; }
        public bool EngineStatus { get; set; }
        [NotMapped]
        public Color TyreSmokeColor { get; set; }
        [NotMapped]
        public VehiclePaint PrimaryPaint { get; set; }
        [NotMapped]
        public VehiclePaint SecondaryPaint { get; set; }
        public int WindowTint { get; set; }
        public float EnginePowerMultiplier { get; set; }
        public float EngineTorqueMultiplier { get; set; }
        [NotMapped]
        public Color NeonColor { get; set; }
        public int DashboardColor { get; set; }
        public int WheelType { get; set; }
        public int TrimColor { get; set; }               
        public bool Neons { get; set; }        
        public int NumberPlateStyle { get; set; }        
        public int PrimaryColor { get; set; }
        public int SecondaryColor { get; set; }
        public int PearlescentColor { get; set; }
        [NotMapped]
        public Color CustomSecondaryColor { get; set; }
        public float Health { get; set; }
        public int Livery { get; set; }
        [NotMapped]
        public Color CustomPrimaryColor { get; set; }        
        public bool Siren { get; }
        public string NumberPlate { get; set; }
        public bool SpecialLight { get; set; }
        public bool CustomTires { get; set; }
        public bool BulletproofTyres { get; set; }        
    }
}
