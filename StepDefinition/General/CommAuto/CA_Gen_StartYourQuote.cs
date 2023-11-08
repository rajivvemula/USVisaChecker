using BiBerkLOB.General;
using HitachiQA.Helpers;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;
using BiBerkLOB.Pages;
using BiBerkLOB.StepDefinition.General.GenAutomation;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_StartYourQuote
    {
        private readonly CAStartYourQuoteAutomation _automation;
        private readonly QuoteIDRetriever _quoteIDRetriever;
        private readonly QuestionErrorHandler _questionErrorHandler;

        public CA_Gen_StartYourQuote(CAStartYourQuoteAutomationFactory factory, QuoteIDRetriever quoteIDRetriever, QuestionErrorHandler questionErrorHandler)
        {
            _automation = factory.CreateAutomation();
            _quoteIDRetriever = quoteIDRetriever;
            _questionErrorHandler = questionErrorHandler;
        }

        [Then(@"user verifies the appearance of the Start Your Quote page")]
        public void GivenNavigatesToCommAutoPath()
        {
            //verifies URL is on CA path in same environment
            General_SiteWide.AssertUrlSegmentWithCorrectHost(AppSettings.CaUrlBaseSegment);
            AutomationHelper.WaitForAngularAppToRender();
            CA_PreIntroductionPage.LoadingRequirements.Assert();
            _automation.SaveQuoteId(_quoteIDRetriever);
        }

        [Then(@"user fills in the Start Your Quote page with these values:")]
        public void GivenFillsInStartYourQuotePageWithValues(Table table)      
        {
            var row = table.Rows[0];
            
            _automation.EnterNameOfBusiness(row["Name of Business"]);
            _automation.EnterDBAIfDefined(row["DBA"]);
            _automation.SetPolicyStartDate(row["Policy Start Date"]);
        }

        [Then(@"user clicks continue from the Start Your Quote page")]
        public void ThenUserContinues()
        {
            CA_PreIntroductionPage.LetsGoCTA.Click(2);
            _questionErrorHandler.IsErrorVisible();          
        }
    }
}
