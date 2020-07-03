using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gta5Platinum.DataAccess.Account.UserModels
{
    public class CharacterClothes
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
        public int clothes_1 { get; set; } = 0;
        public int clothes_2 { get; set; } = 49;
        public int clothes_3 { get; set; } = 0;
        public int clothes_4 { get; set; } = 9;
        public int clothes_5 { get; set; } = 0;
        public int clothes_6 { get; set; } = 4;
        public int clothes_7 { get; set; } = 0;
        public int clothes_8 { get; set; } = 0;
        public int clothes_9 { get; set; } = 0;
        public int clothes_10 { get; set; } = 0;
        public int clothes_11 { get; set; } = 163;
    }
}
