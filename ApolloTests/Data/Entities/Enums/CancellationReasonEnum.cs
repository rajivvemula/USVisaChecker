using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApolloTests.Data.Entities.Enums
{
    public enum CancellationReason
    {
        /// <summary>
        /// Policy cancelled and reissued. - INTERNAL USE ONLY
        /// </summary>
        PolicyCancelledAndReissued = 13,

        /// <summary>
        /// Substantial change in risk which increased risk of loss after policy issued or renewed
        /// </summary>
        SubstantialChangeInRisk = 6,

        /// <summary>
        /// NON-PAYMENT OF PREMIUM
        /// </summary>
        NonPaymentOfPremium = 4,

        /// <summary>
        /// Non-payment of deductible
        /// </summary>
        NonPaymentOfDeductible = 7,

        /// <summary>
        /// Loss or suspension of driver's license
        /// </summary>
        LossOrSuspensionOfDriversLicense = 53,

        /// <summary>
        /// Cancelled by Insured
        /// </summary>
        CancelledByInsured = 23
    }
}
