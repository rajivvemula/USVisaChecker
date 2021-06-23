using ApolloQA.Source.Helpers;
using System;
using System.Collections.Generic;

namespace ApolloQA.Data.Entity.Question
{
    public class OperationsQuestions
    {
        public static readonly Dictionary<String, String> TruckingLocalHauling = new Dictionary<String, String>() {

            {"VehicleRadius","501 miles or more" },
            {"FineArt", "No" },
            {"ResidentialMoving", "No" },
            {"TeamDriving", "No - one driver per haul" },
            {"TravelToMexico", "No" },
            {"ClaimCount", "Count" },
            {"Haul", "Haul" },
            {"Chains", "No" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"FmscaOperating", "No" },
            {"USDOT#", $"DOT" },
            {"IL-Authority", "No" },
        };

        public static readonly Dictionary<string, string> TruckingLongDistance = new Dictionary<string, string>()
        {
            {"VehicleRadius","501 miles or more" },
            {"FineArt", "No" },
            {"ResidentialMoving", "No" },
            {"TeamDriving", "No - one driver per haul" },
            {"TravelToMexico", "No" },
            {"ClaimCount", "Count" },
            {"Haul", "Haul" },
            {"Chains", "No" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"FmscaOperating", "No" },
            {"USDOT#", "DOT" },
            {"IL-Authority", "No" },
        };

        public static readonly Dictionary<string, string> TowingServices = new Dictionary<string, string>()
        {

            {"OnCall", "No" },
            {"Salvage", "No we only provide towing or roadside assistance services." },
            {"VehicleRadius","501 miles or more" },
            {"FineArt", "No" },
            {"ResidentialMoving", "No" },
            {"TeamDriving", "No - one driver per haul" },
            {"TravelToMexico", "No" },
            {"ClaimCount", "Count" },
            {"Haul", "Haul" },
            {"Chains", "No" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"FmscaOperating", "No" },
            {"USDOT#", "DOT" },
            {"IL-Authority", "No" },
        };

        public static readonly Dictionary<string, string> LimoCompany = new Dictionary<string, string>()
        {
            {"PartyBus", "No" },
            {"DayCare", "No" },
            {"ServiceAccess", "Both on demand and pre-arranged" },
            {"VehicleRadius", "51 to 100 miles" },
            {"TravelToMexico", "No" },
            {"ClaimCount", "1" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
        };

        public static readonly Dictionary<string, string> BrineHaulingLess300 = new Dictionary<string, string>()
        {
            {"VehicleRadius","501 miles or more" },
            {"FineArt", "No" },
            {"ResidentialMoving", "No" },
            {"TeamDriving", "No - one driver per haul" },
            {"TravelToMexico", "No" },
            {"ClaimCount", "Count" },
            {"Haul", "Haul" },
            {"Chains", "No" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"FmscaOperating", "No" },
            {"USDOT#", "DOT" },
            {"IL-Authority", "No" },
        };
    }
}