using System;
using TechTalk.SpecFlow;
using ApolloQA.Pages.Quote;
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
            Assert.AreEqual(this.sortedSectionNames, Quote_Page.LeftSiveNavBar.GetInnerTexts());

           
        }

        [Then(@"User should be able to navigate to each section successfully")]
        public void ThenUserShouldBeAbleToNavigateToEachSectionSuccessfully()
        {
            
        }

    }
}
