﻿using Gta5Platinum.DataAccess.Account.PropertyModels;
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
        public int PropertyId { get; set; }

        public string Name { get; set; }
        public PropertyType Type { get; set; }

        [ForeignKey("CharacterId")]
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        [ForeignKey("OrganizationId")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [StringLength(48)]
        public string IPL { get; set; }

        public float ExteriorPositionX { get; set; }
        public float ExteriorPositionY { get; set; }
        public float ExteriorPositionZ { get; set; }
        public float InteriorPositionX { get; set; }
        public float InteriorPositionY { get; set; }
        public float InteriorPositionZ { get; set; }

        [DefaultValue(false)]
        public bool Enterable { get; set; }
        public int Stock { get; set; }
    }
}
