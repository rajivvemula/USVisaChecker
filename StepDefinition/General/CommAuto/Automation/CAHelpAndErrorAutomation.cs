using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Driver;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAHelpAndErrorAutomation
{
    private const int QUESTION_APPEARANCE_WAIT = 5;

    public void VerifyErrorText(Element errorElement)
    {
        errorElement.AssertElementIsVisible(QUESTION_APPEARANCE_WAIT);
    }

    public void VerifyHelpText(Element helpIcon, Element helpText, Element helpExit)
    {
        helpIcon.AssertElementIsVisible(QUESTION_APPEARANCE_WAIT);
        helpIcon.Click(QUESTION_APPEARANCE_WAIT);

        helpText.AssertElementIsVisible(QUESTION_APPEARANCE_WAIT);

        helpExit.Click(QUESTION_APPEARANCE_WAIT);
    }
}