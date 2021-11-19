using static ApolloQA.Data.TestData.QuestionAnswer;

namespace ApolloQA.Data.TestData.Params
{
    public class PolicyCoverageQuestionAnswerParam : QuentionAnswerParamBase
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