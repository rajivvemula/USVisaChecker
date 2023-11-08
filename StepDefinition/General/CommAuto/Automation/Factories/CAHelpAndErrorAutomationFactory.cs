using HitachiQA;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation.Factories;

public class CAHelpAndErrorAutomationFactory : IAutomationFactory<CAHelpAndErrorAutomation>
{
    public CAHelpAndErrorAutomation CreateAutomation()
    {
        return new CAHelpAndErrorAutomation();
    }
}