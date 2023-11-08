using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Driver.Input;

using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;
namespace BiBerkLOB.Pages.BOP
{
    public sealed class BOP_3rdPartyCoveragePage
    {
        // Headers
        public static Element AdditionalInsuredsHeader => new Element(By.XPath("//h1[@data-qa='Additional Insureds-label']"));
        public static Element AdditionalInsuredsSubHeader => new Element(By.XPath("//h6[@data-qa='Additional Insureds-sub-label']"));

        //Questions
        //Additional Insured Required?
        public static Element AdditionalInsuredRequiredQST => new Element(By.XPath("//label[@data-qa='_apollo_AddInsRequired-label']"));
        public static Element AdditionalInsuredRequiredYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddInsRequired-8030-yes-button']"));
        public static Element AdditionalInsuredRequiredNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddInsRequired-8030-no-button']"));
        public static YesOrNoGroup AdditionalInsuredRequiredGroup => new YesOrNoGroup(AdditionalInsuredRequiredYesButton, AdditionalInsuredRequiredNoButton);
        public static InputSection WantToUseVINInput => new YesOrNoInput(AdditionalInsuredRequiredGroup)
            .AsAQuestion(AdditionalInsuredRequiredQST)
            .WithHelpText(AdditionalInsuredRequiredHelpToggle, AdditionalInsuredRequiredHelpText, AdditionalInsuredRequiredHelpX);
        public static Element AdditionalInsuredRequiredHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddInsRequired']"));
        public static Element AdditionalInsuredRequiredHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddInsRequired-label']"));
        public static Element AdditionalInsuredRequiredHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddInsRequired']"));
        public static Element AdditionalInsuredRequiredErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddInsRequired-errorMessage']"));

        //Add a bank or lender?
        public static Element AddBankQST => new Element(By.XPath("//label[@data-qa='_apollo_AddBank-label']"));
        public static Element AddBankYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddBank-8030-yes-button']"));
        public static Element AddBankNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddBank-8030-no-button']"));
        public static YesOrNoGroup AddBankGroup => new YesOrNoGroup(AddBankYesButton, AddBankNoButton);
        public static InputSection AddBankInput => new YesOrNoInput(AddBankGroup)
            .AsAQuestion(AddBankQST)
            .WithHelpText(AddBankHelpToggle, AddBankHelpText, AddBankHelpX);
        public static Element AddBankHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddBank']"));
        public static Element AddBankHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddBank-label']"));
        public static Element AddBankHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddInsRequired']"));
        public static Element AddBankErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddBank-errorMessage']"));

        //How many Banks or lenders do you need to add?

        public static Element BankNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_BankNumber-label']"));
        public static Element BankNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_BankNumber']"));
        public static Element BankNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_BankNumber-errorMessage']"));

        //Do you need to add a contractor, building owner or landlord to your policy?
        public static Element AddContractorQST => new Element(By.XPath("//label[@data-qa='_apollo_AddContractor-label']"));
        public static Element AddContractorYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddContractor-8030-yes-button']"));
        public static Element AddContractorNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddContractor-8030-no-button']"));
        public static Element AddContractorHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddContractor']"));
        public static Element AddContractorHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddContractor-label']"));
        public static Element AddContractorHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddContractor']"));
        public static Element AddContractorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddContractor-errorMessage']"));
        public static InputSection AddContractorInput => new YesOrNoInput(AddContractorYesButton,AddContractorNoButton)
            .AsAQuestion(AddContractorQST)
            .WithHelpText(AddContractorHelpToggle, AddContractorHelpText,AddContractorHelpX);

        //Select the type of Contractor, building owner, or landlord
        public static Element ContractorSelectQST => new Element(By.XPath("//label[@data-qa='_apollo_ContractorSelect-label']"));
        public static Element ContractorSelectCheckboxOngoing => new Element(By.XPath("//li[@data-qa='Ongoing Operations']"));
        public static Element ContractorSelectCheckboxAddInsured => new Element(By.XPath("//li[@data-qa='Blanket Additional Insured']"));
        public static Element ContractorSelectCheckboxPropertyCoverage => new Element(By.XPath("//li[@data-qa='Property Coverage']"));
        public static Element ContractorSelectCheckboxLiabilityCoverage => new Element(By.XPath("//li[@data-qa='Liability Coverage for Leased Space']"));
        public static Element ContractorSelectCheckboxCompletedOperations => new Element(By.XPath("//li[@data-qa='Completed Operations']"));
        public static Element ContractorSelectErrorMessage => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_ContractorSelect-errorMessage']"));

        // How many ongoing operations do you need to add?
        public static Element OngoingOpsNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_OngoingOpsNumber']"));
        public static Element OngoingOpsNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_OngoingOpsNumber']"));
        public static Element OngoingOpsNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_OngoingOpsNumber-errorMessage']"));

        // How Many property coverage interests do you need to add?
        public static Element PropertyCoverageNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_PropertyCoverageNumber']"));
        public static Element PropertyCoverageNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_PropertyCoverageNumber']"));
        public static Element PropertyCoverageNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_PropertyCoverageNumber-errorMessage']"));

        // How many liability coverage interests do you need to add
        public static Element LiabilityCoverageNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_LiabilityCoverageNumber']"));
        public static Element LiabilityCoverageNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_LiabilityCoverageNumber']"));
        public static Element LiabilityCoverageNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_LiabilityCoverageNumber-errorMessage']"));

        // How many completed operations do you need to add
        public static Element CompletedOpsNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_CompletedOpsNumber']"));
        public static Element CompletedOpsNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_CompletedOpsNumber']"));
        public static Element CompletedOpsNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_CompletedOpsNumber-errorMessage']"));

        // Do you need to add other people or organinzations to your policy?
        public static Element AddPeopleQST => new Element(By.XPath("//label[@data-qa='_apollo_AddPeople-label']"));
        public static Element AddPeopleYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddPeople-8030-yes-button']"));
        public static Element AddPeopleNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddPeople-8030-no-button']"));
        public static YesOrNoGroup AddPeopleGroup => new YesOrNoGroup(AddPeopleYesButton, AddPeopleNoButton);
        public static InputSection AddPeopleInput => new YesOrNoInput(AddPeopleGroup)
            .AsAQuestion(AddPeopleQST)
            .WithHelpText(AddPeopleHelpToggle, AddPeopleHelpText, AddPeopleHelpX);
        public static Element AddPeopleHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddPeople']"));
        public static Element AddPeopleHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddPeople-label']"));
        public static Element AddPeopleHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddPeople']"));
        public static Element AddPeopleErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddPeople-errorMessage']"));

        //How many people do you need to add?
        public static Element PeopleNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_PeopleNumber']"));
        public static Element PeopleNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_PeopleNumber']"));
        public static Element PeopleNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_PeopleNumber-errorMessage']"));

        // Do you need to add vendors?
        public static Element AddVendorsQST => new Element(By.XPath("//label[@data-qa='_apollo_AddVendors-label']"));
        public static Element AddVendorsYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddVendors-8030-yes-button']"));
        public static Element AddVendorsNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddVendors-8030-no-button']"));
        public static YesOrNoGroup AddVendorsGroup => new YesOrNoGroup(AddVendorsYesButton, AddVendorsNoButton);
        public static InputSection AddVendorsInput => new YesOrNoInput(AddVendorsGroup)
            .AsAQuestion(AddVendorsQST)
            .WithHelpText(AddVendorsHelpToggle, AddVendorsHelpText, AddVendorsHelpX);
        public static Element AddVendorsHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddVendors']"));
        public static Element AddVendorsHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddVendors-label']"));
        public static Element AddVendorsHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddVendors']"));
        public static Element AddVendorsErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddVendors-errorMessage']"));

        //How many vendors?
        public static Element VendorNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_VendorNumber']"));
        public static Element VendorNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_VendorNumber']"));
        public static Element VendorNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_VendorNumber-errorMessage']"));

        // Add Grantor of franchise?
        public static Element AddGrantorFranchiseQST => new Element(By.XPath("//label[@data-qa='_apollo_AddGrantorFranchise-label']"));
        public static Element AddGrantorFranchiseYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddGrantorFranchise-8030-yes-button']"));
        public static Element AddGrantorFranchiseNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddGrantorFranchise-8030-no-button']"));
        public static YesOrNoGroup AddGrantorFranchiseGroup => new YesOrNoGroup(AddGrantorFranchiseYesButton, AddGrantorFranchiseNoButton);
        public static InputSection AddGrantorFranchiseInput => new YesOrNoInput(AddGrantorFranchiseGroup)
            .AsAQuestion(AddGrantorFranchiseQST)
            .WithHelpText(AddGrantorFranchiseHelpToggle, AddGrantorFranchiseHelpText, AddGrantorFranchiseHelpX);
        public static Element AddGrantorFranchiseHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddGrantorFranchise']"));
        public static Element AddGrantorFranchiseHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddGrantorFranchise-label']"));
        public static Element AddGrantorFranchiseHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddGrantorFranchise']"));
        public static Element AddGrantorFranchiseErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddGrantorFranchise-errorMessage']"));

        //How many franchises?
        public static Element GrantorFranchiseNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_GrantorFranchiseNumber']"));
        public static Element GrantorFranchiseNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_GrantorFranchiseNumber']"));
        public static Element GrantorFranchiseNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_GrantorFranchiseNumber-errorMessage']"));

        //Do you need to add an equipment lessor on your policy?
        public static Element AddEquipLessorFranchiseQST => new Element(By.XPath("//label[@data-qa='_apollo_AddEquipLessor-label']"));
        public static Element AddEquipLessorYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddEquipLessor-8030-yes-button']"));
        public static Element AddEquipLessorNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddEquipLessor-8030-no-button']"));
        public static YesOrNoGroup AddEquipLessorGroup => new YesOrNoGroup(AddEquipLessorYesButton, AddEquipLessorNoButton);
        public static InputSection AddEquipLessorInput => new YesOrNoInput(AddEquipLessorGroup)
            .AsAQuestion(AddEquipLessorFranchiseQST)
            .WithHelpText(AddEquipLessorHelpToggle, AddEquipLessorHelpText, AddEquipLessorHelpX);
        public static Element AddEquipLessorHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddEquipLessor']"));
        public static Element AddEquipLessorHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddEquipLessor-label']"));
        public static Element AddEquipLessorHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddEquipLessor']"));
        public static Element AddEquipLessorErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddEquipLessor-errorMessage']"));

        //How many lessors?
        public static Element EquipLessorNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_EquipLessorNumber']"));
        public static Element EquipLessorNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_EquipLessorNumber']"));
        public static Element EquipLessorNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_EquipLessorNumber-errorMessage']"));

        //Do you need to add a waiver?
        public static Element AddSubrogationWaiverFranchiseQST => new Element(By.XPath("//label[@data-qa='_apollo_AddSubrogationWaiver-label']"));
        public static Element AddSubrogationWaiverYesButton => new Element(By.XPath("//button[@data-qa='_apollo_AddSubrogationWaiver-8030-yes-button']"));
        public static Element AddSubrogationWaiverNoButton => new Element(By.XPath("//button[@data-qa='_apollo_AddSubrogationWaiver-8030-no-button']"));
        public static YesOrNoGroup AddSubrogationWaiverGroup => new YesOrNoGroup(AddSubrogationWaiverYesButton, AddSubrogationWaiverNoButton);
        public static InputSection AddSubrogationWaiverInput => new YesOrNoInput(AddSubrogationWaiverGroup)
            .AsAQuestion(AddSubrogationWaiverFranchiseQST)
            .WithHelpText(AddSubrogationWaiverHelpToggle, AddSubrogationWaiverHelpText, AddSubrogationWaiverHelpX);
        public static Element AddSubrogationWaiverHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_AddSubrogationWaiver']"));
        public static Element AddSubrogationWaiverHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_AddSubrogationWaiver-label']"));
        public static Element AddSubrogationWaiverHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_AddSubrogationWaiver']"));
        public static Element AddSubrogationWaiverErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_AddSubrogationWaiver-errorMessage']"));

        //How many waivers?
        public static Element SubrogationWaiverNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_SubrogationWaiverNumber']"));
        public static Element SubrogationWaiverNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_SubrogationWaiverNumber']"));
        public static Element SubrogationWaiverNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_SubrogationWaiverNumber-errorMessage']"));

        // Are you required to name a loss payee on your policy?
        public static Element LossPayeeRequiredQST => new Element(By.XPath("//label[@data-qa='_apollo_LossPayeeRequired-label']"));
        public static Element LossPayeeRequiredYesButton => new Element(By.XPath("//button[@data-qa='_apollo_LossPayeeRequired-8030-yes-button']"));
        public static Element LossPayeeRequiredNoButton => new Element(By.XPath("//button[@data-qa='_apollo_LossPayeeRequired-8030-no-button']"));
        public static YesOrNoGroup LossPayeeRequiredGroup => new YesOrNoGroup(LossPayeeRequiredYesButton, LossPayeeRequiredNoButton);
        public static InputSection LossPayeeRequiredInput => new YesOrNoInput(LossPayeeRequiredGroup)
            .AsAQuestion(LossPayeeRequiredQST)
            .WithHelpText(LossPayeeRequiredHelpToggle, LossPayeeRequiredHelpText, LossPayeeRequiredHelpX);
        public static Element LossPayeeRequiredHelpToggle => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-_apollo_LossPayeeRequired']"));
        public static Element LossPayeeRequiredHelpText => new Element(By.XPath("//p[@data-qa='bbHelpText-_apollo_LossPayeeRequired-label']"));
        public static Element LossPayeeRequiredHelpX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-_apollo_LossPayeeRequired']"));
        public static Element LossPayeeRequiredErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_LossPayeeRequired-errorMessage']"));

        //how many loss payees?
        public static Element LossPayeeNumberQST => new Element(By.XPath("//label[@data-qa='_apollo_LossPayeeNumber']"));
        public static Element LossPayeeNumberInput => new Element(By.XPath("//input[@data-qa='_apollo_LossPayeeNumber']"));
        public static Element LossPayeeNumberErrorMsg => new Element(By.XPath("//bb-errormessage[@data-qa='_apollo_LossPayeeNumber-errorMessage']"));
    }
}
