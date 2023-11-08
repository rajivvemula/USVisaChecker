using BiBerkLOB.Pages.Other;
using HitachiQA;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;
namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public sealed class CareerPage
    {
        [Then(@"user clicks on the Open Positions button")]
        public void UserClicksOpenPositions()
        {
            Careers_Page.CareerPageheader.AssertElementIsVisible();
            Careers_Page.CareerPagesubheader.AssertElementIsVisible();
            Careers_Page.OpenPositionsButton.AssertElementIsVisible();
            Careers_Page.OpenPositionsButton.Click();

        }
        [Then(@"user verifies new tab for job search")]
        public void UserVerifiesNewTabJobSearch()
        {
            AutomationHelper.WaitForLoading();
            Assert.CurrentURLEquals("https://nationalindemnity.wd5.myworkdayjobs.com/BHDIC");
        }
    }
}
