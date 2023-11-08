using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.StepDefinition.General.CommAuto.Automation.Models;
using HitachiQA.Driver.Input;
using HitachiQA.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Mapping("CA Incidents")]
    public sealed class CA_DriverIncidentsPage
    {
        public static LoadingRequirements LoadingRequirements = new LoadingRequirements(DriverIncidentsTitle, TheseDriversHadAccidentOrViolation);
        /*
        * Headers----------------------------------------------------------
        */

        //Driver Incidents
        public static Element DriverIncidentsTitle => new Element(By.XPath("//h1[@data-qa='Drivers Incidents-label']"));

        //You've told us that these drivers have had an accident or violation in the past 3 years, or a conviction in the
        //past 5 years.  Please tell us about those incidents.
        public static Element TheseDriversHadAccidentOrViolation => new Element(By.XPath("//p[@data-qa='Drivers Incidents-sub-label']"));
        
        /*
        * Questions----------------------------------------------------------
        */

        //Which driver was involved in this incident?
        public static Element DriverInvolvedQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverIncidents_{index}-label']"));
        public static Element DriverInvolvedDD(int index) => new Element(By.XPath($"//mat-select[@data-qa='_apollo_DriverIncidents_{index}']"));
        public static InputSection DriverInvolvedInput(int index) => new MatDropdownInput(DriverInvolvedDD(index))
            .AsAQuestion(DriverInvolvedQST(index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //What was the date of the incident?
        public static Element DateOfTheIncidentQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverIncidentDate_{index}-label']"));
        public static Element DateOfTheIncidentTxtbox(int index) => new Element(By.XPath($"//input[@data-qa='_apollo_DriverIncidentDate_{index}']"));
        public static IDatePicker DateOfIncidentDatePicker(int index) => new TextEnterDatePicker(DateOfTheIncidentTxtbox(index));
        public static Element DateOfTheIncidentTextBelow(int index) => new Element(By.XPath($"//mat-hint[@data-qa='_apollo_DriverIncidentDate_{index}-hint']"));
        public static InputSection DateOfIncidentInput(int index) => new DatePickerInput(DateOfIncidentDatePicker(index))
            .AsAQuestion(DateOfTheIncidentQST(index))
            .WithExtraText(DateOfTheIncidentTextBelow(index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //What type of incident was it?
        public static Element TypeOfIncidentQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverIncidentType_{index}-label']"));
        public static Element TypeOfIncidentButton(int index, string type) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_DriverIncidentType_{index}') and contains(@data-qa,'{type}-button')]"));
        public static SelectionDomain TypeOfIncidentChoiceDomain => new SelectionDomain("Accident", "Violation", "Both");
        public static ChoiceGroup TypeOfIncidentChoiceGroup(int index) => new ChoiceGroup(Functions.CreateSingleArgSelector(TypeOfIncidentButton, index), TypeOfIncidentChoiceDomain);
        public static InputSection TypeOfIncidentInput(int index) => new SingleChoiceGroupInput(TypeOfIncidentChoiceGroup(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(TypeOfIncidentQST(index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Was the driver at fault? (Accident)
        public static Element WasDriverAtFaultQST(int index) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverAccidentDetermination_{index}-label']"));
        public static Element WasDriverAtFaultButton(int index, string choice) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_DriverAccidentDetermination_{index}') and contains(@data-qa,'-{choice}-button')]"));
        public static SelectionDomain WasDriverAtFaultDomain => new SelectionDomain("At Fault", "Not At Fault");
        public static ChoiceGroup WasDriverAtFaultChoices(int index) => new ChoiceGroup(Functions.CreateSingleArgSelector(WasDriverAtFaultButton, index), WasDriverAtFaultDomain);
        public static InputSection WasDriverAtFaultInput(int index) => new SingleChoiceGroupInput(WasDriverAtFaultChoices(index), ButtonSelectionPredicates.AngularSingleSelect)
            .AsAQuestion(WasDriverAtFaultQST(index))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Violations/Convictions (can have multiple in one incident)
        //What was the violation / conviction?
        public static Element WhatWasViolationConvictionQST(int index, IncidentViolationNumber vcNum) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverIncidentViolation{vcNum}_{index}-label']"));
        public static Element WhatWasViolationConvictionDD(int index, IncidentViolationNumber vcNum) => new Element(By.XPath($"//mat-select[@data-qa='_apollo_DriverIncidentViolation{vcNum}_{index}']"));
        public static InputSection WhatWasViolationConvictionInput(int index, IncidentViolationNumber vcNum) => new MatDropdownInput(WhatWasViolationConvictionDD(index, vcNum))
            .AsAQuestion(WhatWasViolationConvictionQST(index, vcNum))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Describe the violation / conviction:
        public static Element DescribeViolationConvictionQST(int index, IncidentViolationNumber vcNum) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverViolationDescription{vcNum}_{index}-label']"));
        public static Element DescribeViolationConvictionTxtbox(int index, IncidentViolationNumber vcNum) => new Element(By.XPath($"//textarea[@data-qa='_apollo_DriverViolationDescription{vcNum}_{index}']"));
        public static Element DescribeViolationConvictionTextBelow(int index, IncidentViolationNumber vcNum) => new Element(By.XPath($"//mat-hint[@data-qa='_apollo_DriverViolationDescription{vcNum}_{index}-hint']"));
        public static InputSection DescribeViolationConvictionInput(int index, IncidentViolationNumber vcNum) => new TextBoxInput(DescribeViolationConvictionTxtbox(index, vcNum))
            .AsAQuestion(DescribeViolationConvictionQST(index, vcNum))
            .WithExtraText(DescribeViolationConvictionTextBelow(index, vcNum))
            .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Did this speeding violation also result in a reckless/careless driving conviction? (Y/N)
        public static Element RecklessSpeedingQST(int index, IncidentViolationNumber vcNum) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverIncidentRecklessConviction{vcNum}_{index}-label']"));
        public static Element RecklessSpeedingChoice(int index, IncidentViolationNumber vcNum, string yesOrNo) => new Element(By.XPath($"//button[starts-with(@data-qa,'_apollo_DriverIncidentRecklessConviction{vcNum}_{index}') and contains(@data-qa,'{yesOrNo.ToLower()}-button')]"));
        public static InputSection RecklessSpeedingInput(int index, IncidentViolationNumber vcNum) => 
            new YesOrNoInput(RecklessSpeedingChoice(index, vcNum, "yes"), RecklessSpeedingChoice(index, vcNum, "no"), ButtonSelectionPredicates.AngularSingleSelect)
                .AsAQuestion(RecklessSpeedingQST(index, vcNum))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Was there another violation / conviction associated with this incident?
        public static Element AnotherVCQST(int index, IncidentViolationNumber nextVcNum) => new Element(By.XPath($"//label[@data-qa='_apollo_DriverIncident{nextVcNum}Flag_{index}-label']"));
        public static Element AnotherVCButton(int index, IncidentViolationNumber nextVcNum, string yesOrNo) => new Element(By.XPath($"//button[starts-with(@data-qa, '_apollo_DriverIncident{nextVcNum}Flag_{index}') and contains(@data-qa, '{yesOrNo.ToLower()}-button')]"));
        public static InputSection AnotherVCInput(int index, IncidentViolationNumber nextVcNum) =>
            new YesOrNoInput(AnotherVCButton(index, nextVcNum, "yes"), AnotherVCButton(index, nextVcNum, "no"), ButtonSelectionPredicates.AngularSingleSelect)
                .AsAQuestion(AnotherVCQST(index, nextVcNum))
                .IsDynamicallyRendered(CA_ReusableElements.InflightStatusElement, InflightStatusChecker.EXPECTED_MAX_SECONDS);

        //Remove
        public static Element RemoveButton => new Element(By.XPath("(//bb-remove-panel[@data-qa='INCIDENT-Remove-button'])"));

        //Add an Accident or Violation / Conviction
        public static Element AddAccidentViolationConvictionBTN => new Element(By.XPath("(//bb-add-panel[@data-qa='Incident-addPanel'])[last()]"));

        //Panel header
        public static Element IncidentPanelHeader(int index) => new Element(By.XPath($"(//mat-expansion-panel-header)[{index+1}]"));

        //Error Text
        public static Element ApolloErrorText(string questionAlias, int incidentIndex) => new Element(By.XPath($"//bb-error-message[@data-qa='_apollo_{questionAlias}_{incidentIndex}-errorMessage']"));

        //Help Text
        public static Element ApolloHelpIcon(string questionAlias, int incidentIndex) => new Element(By.XPath($"//button[@data-qa='buttonShowHelpToggle-_apollo_{questionAlias}_{incidentIndex}']"));
        public static Element ApolloHelpText(string questionAlias, int incidentIndex) => new Element(By.XPath($"//bb-helptext//p[@data-qa='bbHelpText-_apollo_{questionAlias}_{incidentIndex}-label']"));
        public static Element ApolloHelpX(string questionAlias, int incidentIndex) => new Element(By.XPath($"//bb-helptext//button[@data-qa='buttonClose-bbHelpText-_apollo_{questionAlias}_{incidentIndex}']"));

        //Please fix the following error(s) before proceeding:
        public static Element PleaseFixErrors => new Element(By.XPath("//div[@data-qa='bbnav-error-title']"));
        public static Element OneOrMoreInvalid => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));

        /*
        * Page CTA----------------------------------------------------------
        */

        //Let's Continue
        public static Element LetsContinueCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        //Back
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav - navBack']"));
    }
}
