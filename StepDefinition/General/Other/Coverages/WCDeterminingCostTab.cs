using HitachiQA.Driver;
using System.Collections.Generic;
using BiBerkLOB.Source.Driver.SimpleInteractions;

namespace BiBerkLOB.StepDefinition.General.Other.Coverages
{
    public class WCDeterminingCostTab : IStaticInteraction
    {
        private Element _tab;
        private Element _header;
        private Element _paragraphText;

        public WCDeterminingCostTab(Element tab, Element header, Element paragraphText)
        {
            _tab = tab;
            _header = header;
            _paragraphText = paragraphText;
        }

        public void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
        {
            _tab.AssertElementIsVisible(waitSeconds);
            _tab.Click(waitSeconds);
            _header.AssertElementIsVisible(waitSeconds);
            _paragraphText.AssertElementIsVisible(waitSeconds);
        }
    }
}