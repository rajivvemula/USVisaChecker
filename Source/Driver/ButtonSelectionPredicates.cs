using System;
using HitachiQA.Driver;

namespace BiBerkLOB.Source.Driver;

public static class ButtonSelectionPredicates
{
    public static Func<Element, bool> AngularSingleSelect => el => el.IsSelectedAngular();
}