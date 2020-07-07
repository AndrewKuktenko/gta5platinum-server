using Gta5Platinum.DataAccess.Account.PropertyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gta5Platinum.DataAccess.Account
{
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }

        public string Name { get; set; }
        public PropertyType Type { get; set; }

        [ForeignKey("CharacterId")]
        public int? CharacterId { get; set; }
        public Character Character { get; set; }
        [ForeignKey("OrganizationId")]
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [StringLength(48)]
        public string IPL { get; set; }

        public float ExtPosX { get; set; }
        public float ExtPosY { get; set; }
        public float ExtPosZ { get; set; }
        public float IntPosX { get; set; }
        public float IntPosY { get; set; }
        public float IntPosZ { get; set; }

        [DefaultValue(false)]
        public bool Enterable { get; set; }
        public int Stock { get; set; }
    }
}
