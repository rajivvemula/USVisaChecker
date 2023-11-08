using System.Collections.Generic;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Source.Driver.SimpleInteractions;

public class ReviewsModal : IStaticInteraction
{
    private const int LOAD_WAIT = 5;

    private Element _openButton;
    private Element _closeButton;
    private Element _header;
    private Element _searchAndSort;
    private List<Element> _reviews;

    public ReviewsModal(Element openButton, Element closeButton, Element header, Element searchAndSort, List<Element> reviews)
    {
        _openButton = openButton;
        _closeButton = closeButton;
        _header = header;
        _searchAndSort = searchAndSort;
        _reviews = reviews;
    }

    public void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
    {
        _openButton.Click(waitSeconds);

        new Element(By.XPath("//div[@id='spinner-reviews']")).AssertElementNotPresent(LOAD_WAIT);

        _header.AssertElementIsVisible(waitSeconds);
        _searchAndSort.AssertElementIsVisible(waitSeconds);
        foreach (var review in _reviews)
        {
            review.AssertElementIsVisible(waitSeconds);
        }

        _closeButton.Click(waitSeconds);
    }
}