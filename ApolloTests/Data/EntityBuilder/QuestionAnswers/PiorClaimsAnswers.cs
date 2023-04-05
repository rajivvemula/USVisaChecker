using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class PriorClaimAnsswers : AnswersBase
    {
        public QuestionAnswer DateOfLoss { get; set; } = new QuestionAnswer(Alias.DateOfLoss, "03/2020");
        public QuestionAnswer ClaimDesc { get; set; } = new QuestionAnswer(Alias.ClaimDesc, "COVID HIT - by: Automation API Test");
        public QuestionAnswer EstimatedCost { get; set; } = new QuestionAnswer(Alias.EstimatedCost, "100000");
    }
}
