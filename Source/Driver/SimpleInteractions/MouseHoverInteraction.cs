using System;
using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver.SimpleInteractions;

public class MouseHoverInteraction : IStaticInteraction
{
    private readonly Element _elementOffHover;
    private readonly Element _elementOnHover;
    private readonly int _animationTime;

    public MouseHoverInteraction(Element elementOffHover, Element elementOnHover, int animationTime)
    {
        _elementOffHover = elementOffHover;
        _elementOnHover = elementOnHover;
        _animationTime = animationTime;
    }

    public virtual void ValidateInteraction(int waitSeconds = StaticConstants.DEFAULT_INTERACTION_SECONDS)
    {
        _elementOffHover.AssertElementIsVisible(waitSeconds);
        _elementOffHover.ScrollIntoView();
        _elementOffHover.HoverOver(waitSeconds);
        _elementOnHover.AssertElementIsVisible(Math.Max(_animationTime, waitSeconds));
    }
}