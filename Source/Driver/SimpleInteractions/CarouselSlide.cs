using System.Collections.Generic;
using System.Linq;
using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver.SimpleInteractions;

public class CarouselSlide
{
    public List<Element> ElementsInSlide { get; init; }

    public CarouselSlide()
    {
        ElementsInSlide = new List<Element>();
    }

    public CarouselSlide(IEnumerable<Element> elementsInSlide)
    {
        ElementsInSlide = elementsInSlide.ToList();
    }

    public CarouselSlide(params Element[] elementsInSlide)
    {
        ElementsInSlide = elementsInSlide.ToList();
    }
}