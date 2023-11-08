using BiBerkLOB.Pages;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto;

[Binding]
public sealed class CA_Gen_StepperNavigation
{
    [Then(@"user returns to A Quick Introduction page for reverification")]
    public void ThenUserReturnsToAQuickIntroductionPageForReverification()
    {
        Reusable_PurchasePath.CAStepper_1Coverage_Past.Click();
        Reusable_PurchasePath.CAStepper_1Coverage_Current.AssertElementIsVisible();
        CA_IntroductionPage.BackCTA.Click();
    }
}