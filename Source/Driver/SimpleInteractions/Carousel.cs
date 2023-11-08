using System;
using System.Collections.Generic;
using System.Linq;
using HitachiQA.Driver;
using HitachiQA.Helpers;

namespace BiBerkLOB.Source.Driver.SimpleInteractions
{
    public class Carousel : IStaticInteraction
    {
        private readonly List<CarouselSlide> _carouselSlides;
        private readonly Element _leftArrow;
        private readonly Element _rightArrow;
        private readonly Element? _carouselImage;

        [Obsolete("Propagates dictionary anti-pattern")]
        public Carousel(Dictionary<Element, Element> headerParagraphDict, Element leftArrow, Element rightArrow, Element image = null)
        {
            _carouselSlides = headerParagraphDict
                .Select(kvp => new CarouselSlide(kvp.Key, kvp.Value))
                .ToList();
            _leftArrow = leftArrow;
            _rightArrow = rightArrow;
            _carouselImage = image;
        }

        public Carousel(List<CarouselSlide> carouselSlides, Element leftArrow, Element rightArrow, Element carouselImage = null)
        {
            _carouselSlides = carouselSlides;
            _leftArrow = leftArrow;
            _rightArrow = rightArrow;
            _carouselImage = carouselImage;
        }

        public void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
        {
            _leftArrow.AssertElementIsVisible(waitSeconds);
            _rightArrow.AssertElementIsVisible(waitSeconds);
            _carouselImage?.AssertElementIsVisible(waitSeconds);

            foreach (var carouselSlide in _carouselSlides)
            {
                foreach (var element in carouselSlide.ElementsInSlide)
                {
                    element.AssertElementIsVisible(waitSeconds);
                }
                _rightArrow.ScrollIntoView();
                UserActions.BumpScreenDownABit();
                _rightArrow.ClickHack();
            }
        }
    }
}
