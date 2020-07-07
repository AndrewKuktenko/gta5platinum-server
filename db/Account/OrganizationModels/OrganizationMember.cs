using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gta5Platinum.DataAccess.Account.OrganizationModels
{
    public class OrganizationMember
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public Organization Organization { get; set; }
        public bool Leader { get; set; }
    }
}
