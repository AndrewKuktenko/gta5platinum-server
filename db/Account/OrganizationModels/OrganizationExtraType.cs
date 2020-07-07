using System.ComponentModel.DataAnnotations;

namespace Gta5Platinum.DataAccess.Account.OrganizationModels
{
    public enum OrganizationExtraType
    {
        None = 0,

        [Display(Name = "Car Dealership")]
        //[BlipType(225)]
        CarDealership = 1,

        [Display(Name = "Food Market")]
        //[BlipType(11)]
        FoodMarket = 2,

        [Display(Name = "Gun Store")]
        //[BlipType(110)]
        GunStore = 3,

        [Display(Name = "Gas Station")]
        //[BlipType(361)]
        GasStation = 4
    }
}
