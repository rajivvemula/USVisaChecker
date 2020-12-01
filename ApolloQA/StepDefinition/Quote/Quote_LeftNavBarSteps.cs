using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
using ApolloQA.Pages;
using System.Collections.Generic;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_LeftNavBarSteps
    {
        List<String> sortedSectionNames;

        [Then(@"Left Nav Sections should be displayed successfully")]
        public void ThenLeftNavSectionsShouldBeDisplayedAccordingToTheCurrentStoryboard()
        {
            this.sortedSectionNames = Quote_SharedSteps.Quote.Storyboard.GetSortedSectionNames();
            Assert.AreEqual(this.sortedSectionNames, Quote_Page.LeftSiveNavBar.GetInnerTexts().FindAll(it=>it!= "Underwriting Results"));           
        }

        [Then(@"User should be able to navigate to each section successfully")]
        public void ThenUserShouldBeAbleToNavigateToEachSectionSuccessfully()
        {
            
            foreach(var section in Quote_SharedSteps.Quote.Storyboard.Sections)
            {
                var sectionCTA = Shared.GetLeftSideTab(section.Name);
                sectionCTA.Click();
                Assert.CurrentURLEquals(Quote_Page.GetURL(Quote_SharedSteps.Quote.Id, section.Id));

            }
        }
    }
}
