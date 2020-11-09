using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Pages;
using TechTalk.SpecFlow;

namespace ApolloQA.StepDefinition.Claim
{[Binding]
    public class LossDetailStep
    {
        [When(@"user selects pending FNOL")]
        public void WhenUserSelectsPendingFNOL()
        {
            ClaimsFNOLGrid.PendingFNOL.Click();
        }

    }
}
