using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers.PartyAnswers
{
    public class PartyAnswers_BOP : AnswersBase
    {
        //typeID=6 (Additional Insured - Controlling Interest)
        public QuestionAnswer AdditionalInterests { get; set; } = new QuestionAnswer(Alias.AdditionalInterestsBuilding, "{\"additionalInterestTypeId\":6}");
        public QuestionAnswer AdditionalInterestName { get; set; } = new QuestionAnswer(Alias.AdditionalInterestName, "Addnl Interest Name Aut");

    }
}
