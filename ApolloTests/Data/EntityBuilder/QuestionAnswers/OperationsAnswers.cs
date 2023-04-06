using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class OperationsAnswers : AnswersBase
    {
        public QuestionAnswer VehicleRadius { get; set; } = new QuestionAnswer(Alias.VehicleRadius, "50");

        public QuestionAnswer FineArt { get; set; } = new QuestionAnswer(Alias.FineArt, "false");

        //[HydratorAttr(true)]
        public QuestionAnswer Haul { get; set; } = new QuestionAnswer(Alias.Haul, "[\"General Freight\"]");

        public QuestionAnswer Chains { get; set; } = new QuestionAnswer(Alias.Chains, "false");

        public QuestionAnswer ResidentialMoving { get; set; } = new QuestionAnswer(Alias.ResidentialMoving, "false");

        public QuestionAnswer Biohazard { get; set; } = new QuestionAnswer(Alias.Biohazard, "false");

        public QuestionAnswer TeamDriving { get; set; } = new QuestionAnswer(Alias.TeamDriving, "false");

        public QuestionAnswer TravelToMexico { get; set; } = new QuestionAnswer(Alias.TravelToMexico, "false");

        public QuestionAnswer ClaimCount { get; set; } = new QuestionAnswer(Alias.ClaimCount, "0");

        public QuestionAnswer IL_Authority { get; set; } = new QuestionAnswer(Alias.IL_Authority, "false");

        public QuestionAnswer SC_Authority { get; set; } = new QuestionAnswer(Alias.SC_Authority, "false");

        public QuestionAnswer KS_Authority { get; set; } = new QuestionAnswer(Alias.KS_Authority, "false");

        public QuestionAnswer NE_Authority { get; set; } = new QuestionAnswer(Alias.NE_Authority, "false");

        public QuestionAnswer OK_Authority { get; set; } = new QuestionAnswer(Alias.OK_Authority, "false");

        public QuestionAnswer OR_Authority { get; set; } = new QuestionAnswer(Alias.OR_Authority, "false");

        public QuestionAnswer CT_Authority { get; set; } = new QuestionAnswer(Alias.CT_Authority, "false");

        public QuestionAnswer CO_Authority { get; set; } = new QuestionAnswer(Alias.CO_Authority, "false");

        public QuestionAnswer BorrowVehicles { get; set; } = new QuestionAnswer(Alias.BorrowVehicles, "false");

        public QuestionAnswer USDOT { get; set; } = new QuestionAnswer(Alias.USDOT, "false");

        public QuestionAnswer USDOTNumber { get; set; } = new QuestionAnswer(Alias.USDOTNumber, "545167");

        public QuestionAnswer UseOwnerOperators { get; set; } = new QuestionAnswer(Alias.UseOwnerOperators, "false");

        public QuestionAnswer OnCall { get; set; } = new QuestionAnswer(Alias.OnCall, "false");

        public QuestionAnswer PartyBus { get; set; } = new QuestionAnswer(Alias.PartyBus, "false");

        public QuestionAnswer DayCare { get; set; } = new QuestionAnswer(Alias.DayCare, "false");

        public QuestionAnswer VehicleSellOrLease { get; set; } = new QuestionAnswer(Alias.VehicleSellOrLease, "false");

        public QuestionAnswer Salvage { get; set; } = new QuestionAnswer(Alias.Salvage, "No we only provide towing or roadside assistance services");

        public QuestionAnswer ServiceAccess { get; set; } = new QuestionAnswer(Alias.ServiceAccess, "Both on demand and pre-arranged");

        public QuestionAnswer Ammonia { get; set; } = new QuestionAnswer(Alias.Ammonia, "false");

        public QuestionAnswer Poison { get; set; } = new QuestionAnswer(Alias.Poison, "false");

        public QuestionAnswer Radioactive { get; set; } = new QuestionAnswer(Alias.Radioactive, "false");

        public QuestionAnswer EmergencyResponse { get; set; } = new QuestionAnswer(Alias.EmergencyResponse, "false");

        public QuestionAnswer CaliOperatingAuth { get; set; } = new QuestionAnswer(Alias.CaliOperatingAuth, "false");

        public QuestionAnswer CaliCarrierNumber { get; set; } = new QuestionAnswer(Alias.CaliCarrierNumber, "765432");

        public QuestionAnswer PUC { get; set; } = new QuestionAnswer(Alias.PUC, "false");

        public QuestionAnswer NonOwnedGoods { get; set; } = new QuestionAnswer(Alias.NonOwnedGoods, "false");

        public QuestionAnswer StringerchangeAgreements { get; set; } = new QuestionAnswer(Alias.stringerchangeAgreements, "false");

        public QuestionAnswer MotorCarrierFiling { get; set; } = new QuestionAnswer(Alias.MotorCarrierFiling, "false");

        public QuestionAnswer TXAuth { get; set; } = new QuestionAnswer(Alias.TXAuth, "false");

        public QuestionAnswer OwnerOperatorsPendingVehicles { get; set; } = new QuestionAnswer(Alias.OwnerOperatorsPendingVehicles, "false");

        public QuestionAnswer OwnerOperatorsPendingVehiclesCost { get; set; } = new QuestionAnswer(Alias.OwnerOperatorsPendingVehiclesCost, "1000");

        public QuestionAnswer OwnerOperatorsBorrowCost { get; set; } = new QuestionAnswer(Alias.OwnerOperatorsBorrowCost, "1000");

        public QuestionAnswer HoldHarmlessAgreements { get; set; } = new QuestionAnswer(Alias.HoldHarmlessAgreements, "false");

        public QuestionAnswer HoldHarmlessRequireCerts { get; set; } = new QuestionAnswer(Alias.HoldHarmlessRequireCerts, "false");

        public QuestionAnswer FmscaOperating { get; set; } = new QuestionAnswer(Alias.FmscaOperating, "false");

        public QuestionAnswer FmscaOperatingTypes { get; set; } = new QuestionAnswer(Alias.FmscaOperatingTypes, "Freight Forwarding");

        public QuestionAnswer TrailerInterchangeAgreements { get; set; } = new QuestionAnswer(Alias.TrailerInterchangeAgreements, "false");

        public QuestionAnswer HaulIntermodal { get; set; } = new QuestionAnswer(Alias.HaulIntermodal, "false");

        public QuestionAnswer DynamicVehicleMoratorium { get; set; } = new QuestionAnswer(Alias.DynamicVehicleMoratorium, "false");
    }
}
