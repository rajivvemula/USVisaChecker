using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class LimitAnswers : AnswersBase
    {
        #region Cargo Coverage

        public QuestionAnswer IncludeCargoTheftCoverage { get; set; }
            = new QuestionAnswer(Alias.IncludeCargoTheftCoverage, "Included");

        public QuestionAnswer IncludeCargoNamedPerilsCoverage { get; set; }
            = new QuestionAnswer(Alias.IncludeCargoNamedPerilsCoverage, "Included");

        public QuestionAnswer IncludeEarnedFreightCoverage { get; set; }
            = new QuestionAnswer(Alias.IncludeEarnedFreightCoverage, "true");

        #endregion Cargo Coverage

        #region Rental Reimbursement

        public QuestionAnswer RentalDowntimeIncluded { get; set; }
            = new QuestionAnswer(Alias.RentalDowntimeIncluded, "Included");

        #endregion Rental Reimbursement

        #region In-Tow

        public QuestionAnswer CustomerCargoCoverage { get; set; }
            = new QuestionAnswer(Alias.CustomerCargoCoverage, "Included");

        #endregion In-Tow
    }
}
