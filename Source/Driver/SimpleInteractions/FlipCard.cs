using System;
using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver.SimpleInteractions
{
    public class FlipCard : MouseHoverInteraction
    {
        private Element _image;
        
        public FlipCard(Element title, Element image, Element textBehind) : base(title, textBehind, 3)
        { 
            _image = image;
        }

        public override void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
        {
            _image.AssertElementIsVisible();
            base.ValidateInteraction(waitSeconds);
        }
    }
}