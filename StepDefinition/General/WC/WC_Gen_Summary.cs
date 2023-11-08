using BiBerkLOB.StepDefinition.General.WC.Automation;
using BiBerkLOB.StepDefinition.General.WC.Automation.Factories;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC;

[Binding]
public class WC_Gen_Summary
{
    private WCSummaryAutomation _automation;

    public WC_Gen_Summary(WCSummaryAutomationFactory factory)
    {
        _automation = factory.CreateAutomation();
    }

    [Then("user clicks continue from WC Summary page")]
    public void ClicksContinue()
    {
        _automation.ClickContinue();
    }

    [Then("user verifies the appearance of the WC Summary page")]
    public void VerifySummary()
    {
        _automation.WaitForLoading();

        //currently do nothing
        _automation.VerifyAboutYou();
        _automation.VerifyOwnerOfficers();
        _automation.VerifyYourServices();
    }
}