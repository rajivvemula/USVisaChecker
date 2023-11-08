using System.Linq;
using System.Threading.Tasks;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.PL.Automation;
using BiBerkLOB.StepDefinition.General.PL.Automation.Factories;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public sealed class PL_Gen_AQuickIntroduction
    {
        private readonly PLQuickIntroAutomation _automation;

        public PL_Gen_AQuickIntroduction(PLQuickIntroAutomationFactory factory)
        {
            _automation = factory.CreateAutomation();
        }

        [Then(@"user verifies the appearance of the PL A Quick Introduction page")]
        public void ThenUserVerifiesQuickIntroPage()
        {
            PL_IntroductionPage.LoadingRequirements.AssertLegacy();
            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();

            //pull in the text from the UI to get the quoteid
            _automation.SaveQuoteID();
        }

        [Then(@"user fills out A Quick Introduction page with these values:")]
        public async Task ThenUserFillsOutQuickIntroPage(Table table)
        {
            foreach (TableRow tableRow in table.Rows)
            {
                var countOfColumns = tableRow.Count;
                var tableHeaders = tableRow.Keys.ToList();
                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    var quickIntroQuestion = tableHeaders[i];
                    var quickIntroAnswer = tableRow[i];

                    await FillQuickIntroPage(quickIntroQuestion, quickIntroAnswer);
                }
            }
            PL_IntroductionPage.LetsGoCTA.Click();
        }

        public async Task FillQuickIntroPage(string quickIntroQuestion, string quickIntroAnswer)
        {
            switch (quickIntroQuestion)
            {
                case "Business Structure":
                    _automation.SelectBusinessStructureButton(quickIntroAnswer);
                    break;
                case "Name of Business":
                    _automation.EnterBusinessName(quickIntroAnswer);
                    break;
                case "Insured First Name":
                    _automation.EnterInsuredFirstName(quickIntroAnswer);
                    break;
                case "Insured Last Name":
                    _automation.EnterInsuredLastName(quickIntroAnswer);
                    break;
                case "DBA":
                    _automation.SpecifyBusinessUnderAnotherName(quickIntroAnswer);
                    break;
                case "Business Address":
                    await _automation.EnterPLQuickIntroBusinessAddress(quickIntroAnswer);
                    break;
                case "LLC":
                    _automation.ChooseLLCIfDBAHasLLCInName(quickIntroAnswer);
                    break;
            }
        }
    }
}