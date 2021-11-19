using static ApolloQA.Data.TestData.QuestionAnswer;

namespace ApolloQA.Data.TestData.Params
{
    public class DriverQuentionAnswerParam : QuentionAnswerParamBase
    {
        public QuestionAnswer ExcludeDriver { get; set; } = new QuestionAnswer(Alias.ExcludeDriver, "false");

        public QuestionAnswer AccidentOrViolation { get; set; } = new QuestionAnswer(Alias.AccidentOrViolation, "false");

        public QuestionAnswer IL_DefensiveDriving { get; set; } = new QuestionAnswer(Alias.IL_DefensiveDriving, "true");

        public QuestionAnswer IL_LastYearViolation { get; set; } = new QuestionAnswer(Alias.IL_LastYearViolation, "false");

        public QuestionAnswer IL_Last3YearsLicenseSuspended { get; set; } = new QuestionAnswer(Alias.IL_Last3YearsLicenseSuspended, "false");

        public QuestionAnswer CDL { get; set; } = new QuestionAnswer(Alias.CDL, "0");

        public QuestionAnswer DefensiveDriving { get; set; } = new QuestionAnswer(Alias.DefensiveDriving, "false");
    }
}