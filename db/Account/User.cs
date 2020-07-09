using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gta5Platinum.DataAccess.Account
{
    public class User
    {
        [Key, ForeignKey("UserId")]        
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegistrationDate { get; set; }
        public string Login { get; set; }
        public string Serial { get; set; }
        public string SocialClubName { get; set; }
        public ulong SocialClubId { get; set; }
        public string Ip { get; set; }
        //public bool? IsFirstLogin { get; set; }
        //public bool IsFirstLogin { get; set; } = true;
        public bool? IsAdmin { get; set; }
        public bool? IsModerator { get; set; }
        public bool? IsHelper { get; set; }
        public int DonateBalance { get; set; }
        //public Property UserProperty { get; set; }
        public List<Character> Characters { get; set; }

        public User()
        {
            Characters = new List<Character>();
        }
    }
}
