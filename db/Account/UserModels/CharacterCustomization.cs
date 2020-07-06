using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class CharacterCustomization
    {
        [Key]
        public int CustomizationId { get; set; }

        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
        public byte EyeColor { get; set; }
        public byte HairColor { get; set; }
        public byte HighlightColor { get; set; }
        //public float[] FaceFeatures { get; set; }
        public byte ShapeFirst { get; set; } //Parents.Mother
        public byte ShapeSecond { get; set; } // Parents.Father
        public byte ShapeThird { get; set; } = 0;
        public byte SkinFirst { get; set; } //Parents.Mother
        public byte SkinSecond { get; set; } //Parents.Father
        public byte SkinThird { get; set; } = 0;
        public float ShapeMix { get; set; } //Parents.Similarity
        public float SkinMix { get; set; } //Parents.SkinSimilarity
        public float ThirdMix { get; set; } = 0.0f;
    }
}
