using System.ComponentModel;

namespace ApolloTests.Data.Entities
{
    public enum BuildingGroups
    {

        [Description("Apartment")]
        Apartment = 1,

        [Description("Auto Services")]
        AutoServices = 2,

        [Description("Condominium - Office")]
        CondoOffice = 3,

        [Description("Contractors Office")]
        ContractOffice = 4,

        [Description("Contractors Shop")]
        ContractShop = 5,

        [Description("Convenience Food/Gasoline Store/Restaurant")]
        Store = 6,

        [Description("Fast Food Restaurant")]
        FastFood = 7,

        [Description("Hotels/Motels")]
        Hotel = 8,

        [Description("Limited Cooking Restaurant")]
        RestaurantLimited = 9,

        [Description("Mercantile")]
        Mercantile = 10,

        [Description("Office")]
        Office = 11,

        [Description("Processing & Services")]
        ProcServe = 12,

        [Description("Restaurant")]
        Restaurant = 13,

        [Description("Self-Storage Facility")]
        SelfStorage = 14,

        [Description("Wholesale")]
        Wholesale = 15

    }
}
