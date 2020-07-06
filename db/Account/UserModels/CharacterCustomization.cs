namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class CharacterCustomization
    {
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
