using Gta5Platinum.DataAccess.Account.OrganizationModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gta5Platinum.DataAccess.Account
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }        

        [StringLength(32)]
        public string Name { get; set; }

        public OrganizationType Type { get; set; }
        public OrganizationExtraType ExtraType { get; set; }

        public List<Car> Vehicles { get; set; }
        public List<Property> Properties { get; set; }
        public List<Character> Players { get; set; }

        public Organization()
        {
            Vehicles = new List<Car>();
            Properties = new List<Property>();
            Players = new List<Character>();
        }
    }
}
