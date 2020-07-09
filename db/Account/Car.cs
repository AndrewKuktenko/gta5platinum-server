using GTANetworkAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
        public int WheelColor { get; set; }
        public bool EngineStatus { get; set; }        
        public int TyreSmokeColorRed { get; set; }
        public int TyreSmokeColorGreen { get; set; }
        public int TyreSmokeColorBlue { get; set; }
        public int TyreSmokeColorAlpha { get; set; }
        public int PrimaryType { get; set; }
        public int PrimaryColor { get; set; }
        public int SecondaryType { get; set; }
        public int SecondaryColor { get; set; }        
        public int WindowTint { get; set; }
        public float EnginePowerMultiplier { get; set; }
        public float EngineTorqueMultiplier { get; set; }                
        public int NeonColorRed { get; set; }
        public int NeonColorGreen { get; set; }
        public int NeonColorBlue { get; set; }
        public int NeonColorAlpha { get; set; }
        public int DashboardColor { get; set; }
        public int WheelType { get; set; }
        public int TrimColor { get; set; }               
        public bool Neons { get; set; }        
        public int NumberPlateStyle { get; set; }              
        public int PearlescentColor { get; set; }        
        public float Health { get; set; }
        public int Livery { get; set; }                    
        public string NumberPlate { get; set; }
        public bool SpecialLight { get; set; }
        public bool CustomTires { get; set; }
        public bool BulletproofTyres { get; set; }        
    }
}
