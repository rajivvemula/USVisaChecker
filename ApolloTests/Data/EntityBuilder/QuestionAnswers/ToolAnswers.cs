using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApolloTests.Data.EntityBuilder.QuestionAnswers.QuestionAnswer;

namespace ApolloTests.Data.EntityBuilder.QuestionAnswers
{
    public class ToolAnswers : AnswersBase
    {
        public QuestionAnswer ToolDesc { get; set; } = new QuestionAnswer(Alias.ToolDesc, $"{DateTime.Now:O} - tool added by Apollo Test's Entity Builder");
        public QuestionAnswer Manufacturer { get; set; } = new QuestionAnswer(Alias.Manufacturer, "Yamaha");
        public QuestionAnswer ModelNumber { get; set; } = new QuestionAnswer(Alias.ModelNumber, "Model #123456");
        public QuestionAnswer ToolReplacementCost { get; set; } = new QuestionAnswer(Alias.ToolReplacementCost, "10000");

    }
}
