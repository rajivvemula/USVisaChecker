using BiBerkLOB.Pages.Other.States;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Driver;
using System.Collections.Generic;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.Other
{
    [Binding]
    public sealed class Gen_StatePages
    {
        private string _state;

        [When(@"user validates the (.*) state page")]
        public void WhenUserValidatesTheStatePage(string state)
        {
            _state = state.Replace(" ", "-");
            AutomationHelper.ValidateElements(StatePageElements);
        }

        public List<Element> StatePageElements => new List<Element>
        {
            StatePage.PageTitle(_state),
            StatePage.GetAQuoteBtn,
            StatePage.MainParagraph
        };
    }
}