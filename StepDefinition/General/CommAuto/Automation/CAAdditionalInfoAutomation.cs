using System.Collections.Generic;
using System.Linq;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.CommAuto.Automation;

public class CAAdditionalInfoAutomation
{
    private readonly CASummaryObject _caSummaryObject;

    private List<AIPanelAutomation> _panels;

    public CAAdditionalInfoAutomation(CASummaryObject caSummaryObject)
    {
        _caSummaryObject = caSummaryObject;
        _panels = new List<AIPanelAutomation>();
    }

    public void InitPanelsAutomation(int numPanels)
    {
        _panels = GenerateList(numPanels).ToList();
    }

    public AIPanelAutomation GetPanel(int index)
    {
        return _panels[index];
    }

    public void ClickContinue()
    {
        CA_AdditionalInformationPage.ContinueToPurchaseCTA.Click();
        AutomationHelper.WaitForLoading();
        // consistently loads TWICE each
        AutomationHelper.WaitForLoading();
    }

    private IEnumerable<AIPanelAutomation> GenerateList(int numPanels)
    {
        for (int i = 0; i < numPanels; i++)
        {
            yield return new AIPanelAutomation(_caSummaryObject, i);
        }
    }
}