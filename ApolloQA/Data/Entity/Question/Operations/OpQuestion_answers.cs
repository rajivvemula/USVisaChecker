using ApolloQA.Source.Helpers;
using System;
using System.Collections.Generic;

namespace ApolloQA.Data.Entity.Question
{
    public class OpQuestion_answers
    {
        public static readonly Dictionary<string, string> TruckingLongDistance = new Dictionary<string, string>()
        {
            {"VehicleRadius","501 miles or more" },
            {"FineArt", "No" },
            {"ResidentialMoving", "No" },
            {"TeamDriving", "No - one driver per haul" },
            {"TravelToMexico", "No" },
            { "TrailerInterchangeAgreements", "No" },
            {"ClaimCount", "1" },
            {"Haul", "General Freight" },
            {"Chains", "No" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"USDOT#", $"DOT" },
            {"FmscaOperating", "No" },
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
            { "TrailerInterchangeAgreements", "No" },
            {"ClaimCount", "1" },
            {"Haul", "Motor Vehicles (Cars)" },
            {"Chains", "Yes" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"USDOT#", "DOT" },
            {"FmscaOperating", "No" },
            {"IL-Authority", "No" },
        };

        public static readonly Dictionary<string, string> LimoCompany = new Dictionary<string, string>()
        {
            {"PartyBus", "No" },
            {"DayCare", "No" },
            {"ServiceAccess", "Both on demand and pre-arranged" },
            {"VehicleRadius", "51 to 100 miles" },
            {"TravelToMexico", "No" },
            { "TrailerInterchangeAgreements", "No" },
            {"ClaimCount", "1" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
        };

        public static readonly Dictionary<string, string> BusCompany = new Dictionary<string, string>()
        {
            {"PartyBus", "No" },
            {"DayCare", "No" },
            {"ServiceAccess", "Both on demand and pre-arranged" },
            {"VehicleRadius", "51 to 100 miles" },
            {"TravelToMexico", "No" },
            { "TrailerInterchangeAgreements", "No" },
            {"ClaimCount", "1" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"USDOT#", "DOT" },
            {"FmscaOperating", "No" },
        };

        public static readonly Dictionary<string, string> BrineHaulingLess300 = new Dictionary<string, string>()
        {
            {"VehicleRadius","501 miles or more" },
            {"FineArt", "No" },
            {"ResidentialMoving", "No" },
            {"TeamDriving", "No - one driver per haul" },
            {"TravelToMexico", "No" },
            {"ClaimCount", "1" },
            {"Haul", "General Freight" },
            {"Chains", "No" },
            {"Biohazard", "No" },
            {"BorrowVehicles", "No" },
            {"UseOwnerOperators", "No" },
            {"USDOT", "Yes" },
            {"USDOT#", "DOT" },
            {"FmscaOperating", "No" },
            {"IL-Authority", "No" },
        };
    }
}