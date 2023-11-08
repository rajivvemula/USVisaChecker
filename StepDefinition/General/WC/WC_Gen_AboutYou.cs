using BiBerkLOB.Pages.CommAuto;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.WC;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using BiBerkLOB.Source.Helpers;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class WC_Gen_AboutYou
    {
        private readonly WCYourQuoteObject _yourQuoteObject;
        private readonly QuoteIDRetriever _quoteIDRetriever;

        public WC_Gen_AboutYou(WCYourQuoteObject yourQuoteObject, QuoteIDRetriever quoteIDRetriever)
        {
            _yourQuoteObject = yourQuoteObject;
            _quoteIDRetriever = quoteIDRetriever;
        }
        //regex to get Business value BEFORE Semicolon (Business name)
        Regex busBeforeSemi = new Regex("^[^;]*");
        //regex to get Business value AFTER Semicolon (DBA)
        Regex busAfterSemi = new Regex("(?<=\\;).*");


        [Then(@"user verifies the appearance of the WC About You Page")]
        public void ThenUserVerifiesAboutYouPage()
        {
            WC_AboutYouPage.AboutYouHeader.AssertElementIsVisible();
            _yourQuoteObject.QuoteID = _quoteIDRetriever.CaptureQuoteIdFromRibbonText();
        }

        [Then(@"user fills out the WC About You page with these values:")]
        public void ThenUserFillsOutAboutYouPage(Table table)
        {
            //Pulls the data from the next row in the table in the feature file
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];

                //Handle the specific entry in the row in the table
                HandleTableValue(theQuestion, theAnswer);
            }
            WC_AboutYouPage.ContinueCTA.Click();
        }

        public void HandleTableValue(string tableQuestion, string tableAnswer)
        {
            switch (tableQuestion)
            {
                case "When do you want your policy to start?":
                    WC_AboutYouPage.WhenDoYouWantToStartQST.AssertElementIsVisible();
                    if (tableAnswer.Equals(""))
                    {
                        //we should verify it is tommorrow's date, will handle this when we refactor out date functionality
                    }
                    else
                    {
                        WC_AboutYouPage.WhenDoYouWantToStartTxtbox.SetText(tableAnswer);
                    }
                    break;
                case "When did you start your business?":
                    WC_AboutYouPage.WhenDidYouStartQST.AssertElementIsVisible();
                    WC_AboutYouPage.WhenDidYouStartDD.SelectDropdownOptionByText(tableAnswer);
                    break;
                case "How is your business structured?":
                    WC_AboutYouPage.HowIsYourBusinessStructuredQST.AssertElementIsVisible();
                    WC_AboutYouPage.HowIsYourBusinessStructuredDD.SelectDropdownOptionByText(tableAnswer);
                    break;
                case "What is the total annual payroll for W-2 employees? (exclude business owners/officers)":
                    WC_AboutYouPage.WhatIsTheTotalAnnualPayrollQST.AssertElementIsVisible();
                    WC_AboutYouPage.WhatIsTheTotalAnnualPayrollTxtbox.SetText(tableAnswer);
                    break;
                case "Do any employees deliver goods but wouldn't help set up or install anything?":
                    WC_AboutYouPage.HelpSetUpOrInstallAnythingInput.AssertAllElements();
                    WC_AboutYouPage.HelpSetUpOrInstallAnythingInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any retail store employees that do not do any installation, maintenance, or contracting work?":
                    WC_AboutYouPage.EmployeesThatDoInstallationInput.AssertAllElements();
                    WC_AboutYouPage.EmployeesThatDoInstallationInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees only do general office work and do not work a cash register?":
                    WC_AboutYouPage.WorkACashRegisterInput.AssertAllElements();
                    WC_AboutYouPage.WorkACashRegisterInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any actors, entertainers, or musicians on staff?":
                    WC_AboutYouPage.AnyActorsEntertainersQST.AssertElementIsVisible();
                    WC_AboutYouPage.AnyActorsEntertainersAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Do any employees only do general office work and would never interact with any residents?":
                    WC_AboutYouPage.DoAnyEmployeesOnlyDoGeneralOfficeWork.AssertAllElements();
                    WC_AboutYouPage.DoAnyEmployeesOnlyDoGeneralOfficeWork.EnterResponse(tableAnswer);
                    break;
                case "Are there any licensed employee physicians, RNs, practical nurses, directors or administrators?":
                    WC_AboutYouPage.LicensedEmployeePhysiciansInput.AssertAllElements();
                    WC_AboutYouPage.LicensedEmployeePhysiciansInput.EnterResponse(tableAnswer);
                    break;
                case "Do you make any payments to workers using IRS Form 1099?":
                    WC_AboutYouPage.PaymentsToWorkersUsingIRSInput.AssertAllElements();
                    WC_AboutYouPage.PaymentsToWorkersUsingIRSInput.EnterResponse(tableAnswer);
                    break;
                case "Do you use any volunteers or donated labor?":
                    WC_AboutYouPage.AnyVolunteers_Input.AssertAllElements();
                    WC_AboutYouPage.AnyVolunteers_Input.EnterResponse(tableAnswer);
                    break;
                case "Do any staff work only in sales?":
                    WC_AboutYouPage.DoAnyStaffWorkOnlyInSalesLabel.AssertElementIsVisible();
                    WC_AboutYouPage.DoAnyStaffWorkOnlyInSalesAnswer(tableAnswer).Click();
                    break;
                case "Are there any delivery drivers on staff (includes bicycles)?":
                    WC_AboutYouPage.AreThereAnyDeliveryDriversOnStaffInput.AssertAllElements();
                    WC_AboutYouPage.AreThereAnyDeliveryDriversOnStaffInput.EnterResponse(tableAnswer);
                    break;
                case "Is housing provided for any of the workers?":
                    WC_AboutYouPage.IsHousingProvidedForAnyWorkersInput.AssertAllElements();
                    WC_AboutYouPage.IsHousingProvidedForAnyWorkersInput.EnterResponse(tableAnswer);
                    break;
                case "Are there employees that do not do any actual physical work but travel to job sites?":
                    WC_AboutYouPage.EmployeesDoNotWorkAndTravelInput.AssertAllElements();
                    WC_AboutYouPage.EmployeesDoNotWorkAndTravelInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees do any maintenance, repair, or service on motor vehicles?":
                    WC_AboutYouPage.MaintenanceRepairOrServiceVehiclesInput.AssertAllElements();
                    WC_AboutYouPage.MaintenanceRepairOrServiceVehiclesInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees travel frequently for sales or consultation?":
                    WC_AboutYouPage.DoEmployeesTravelInput.AssertAllElements();
                    WC_AboutYouPage.DoEmployeesTravelInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any back office employees that would never assist with moves, handle any goods, or drive any trucks?":
                    WC_AboutYouPage.OfficeEmployeesInput.AssertAllElements();
                    WC_AboutYouPage.OfficeEmployeesInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees help set up/install items such as furniture, lighting, stages, or tents?":
                    WC_AboutYouPage.EmployeesInstallItemsInput.AssertAllElements();
                    WC_AboutYouPage.EmployeesInstallItemsInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees travel frequently for sales, consultation, or auditing?":
                    WC_AboutYouPage.AnyEmployeeSalesConsultationInput.AssertAllElements();
                    WC_AboutYouPage.AnyEmployeeSalesConsultationInput.EnterResponse(tableAnswer);
                    break;
                case "Do you provide any staffing services?":
                    WC_AboutYouPage.StaffingServicesInput.AssertAllElements();
                    WC_AboutYouPage.StaffingServicesInput.EnterResponse(tableAnswer);
                    break;
                case "What is the compensation arrangement for your staffing services?":
                    WC_AboutYouPage.StaffingServicesCompensation.AssertElementIsVisible();
                    WC_AboutYouPage.StaffingServicesCompensation.SelectDropdownOptionByText(tableAnswer);
                    break;
                case "What is the annual pay from your business to temporary workers you help staff?":
                    WC_AboutYouPage.TemporaryWorkersPay.AssertElementIsVisible();
                    WC_AboutYouPage.TemporaryWorkersPay.SetText(tableAnswer);
                    break;
                case "Are there any employees that do not drive and do not load/unload goods?":
                    WC_AboutYouPage.EmpDoNotDriveUnloadGoodsInput.AssertAllElements();
                    WC_AboutYouPage.EmpDoNotDriveUnloadGoodsInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any drivers that drive trucks you own or lease but pay via 1099?":
                    WC_AboutYouPage.DriversPaidVia1099Input.AssertAllElements();
                    WC_AboutYouPage.DriversPaidVia1099Input.EnterResponse(tableAnswer);
                    break;
                case "Do any owner operators or sub-haulers transport goods on your behalf?":
                    WC_AboutYouPage.OOTransportGoodsBehalfInput.AssertAllElements();
                    WC_AboutYouPage.OOTransportGoodsBehalfInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any scouts or traveling recruiters on staff?":
                    WC_AboutYouPage.ScoutsOrRecruitersInput.AssertAllElements();
                    WC_AboutYouPage.ScoutsOrRecruitersInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any clerical office staff?":
                    WC_AboutYouPage.ClericalStaffInput.AssertAllElements();
                    WC_AboutYouPage.ClericalStaffInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any clerical office workers or real estate/leasing agents on staff?":
                    WC_AboutYouPage.ClericalOrOfficeWorkersInput.AssertAllElements();
                    WC_AboutYouPage.ClericalOrOfficeWorkersInput.EnterResponse(tableAnswer);
                    break;
                case "Do you pay any subcontractors/1099 workers to do installation of machines/equipment on your behalf?":
                    WC_AboutYouPage.WorkersInstallMachinesInput.AssertAllElements();
                    WC_AboutYouPage.WorkersInstallMachinesInput.EnterResponse(tableAnswer);
                    break;
                case "Do you provide any boxing, martial arts, climbing, or gymnastics training/classes?":
                    WC_AboutYouPage.ProvideMartialArtTrainingInput.AssertAllElements();
                    WC_AboutYouPage.ProvideMartialArtTrainingInput.EnterResponse(tableAnswer);
                    break;
                case "Do you pay any class instructors or personal trainers using 1099s?":
                    WC_AboutYouPage.PayPersonalInstructorsInput.AssertAllElements();
                    WC_AboutYouPage.PayPersonalInstructorsInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any travelling salespersons on staff that do not interact with clients?":
                    WC_AboutYouPage.DoNotInteractWithClientsInput.AssertAllElements();
                    WC_AboutYouPage.DoNotInteractWithClientsInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any administrative staff that do not interact with clients and never travel?":
                    WC_AboutYouPage.DoNotInteractWithClientsNeverTravelInput.AssertAllElements();
                    WC_AboutYouPage.DoNotInteractWithClientsNeverTravelInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any administrative staff that never interact with clients/patients?":
                    WC_AboutYouPage.AdminStaffNeverInteractWithClientInput.AssertAllElements();
                    WC_AboutYouPage.AdminStaffNeverInteractWithClientInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any security personnel, maintenance, janitorial, bus drivers, or food service workers?":
                    WC_AboutYouPage.SecurityPersonnelOrOtherWorkersAnswerInput.AssertAllElements();
                    WC_AboutYouPage.SecurityPersonnelOrOtherWorkersAnswerInput.EnterResponse(tableAnswer);
                    break;
                case "Are there any licensed or certified teachers on staff?":
                    WC_AboutYouPage.LicensedOrCertifiedTeachersAnswerInput.AssertAllElements();
                    WC_AboutYouPage.LicensedOrCertifiedTeachersAnswerInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees only do electrical work?":
                    WC_AboutYouPage.DoAnyEmployeesDoElectricalWorkQST.AssertElementIsVisible();
                    WC_AboutYouPage.DoAnyEmployeesDoElectricalWorkAnswer(tableAnswer.ToLower()).Click();
                    break;
                //Are there any licensed or certified teachers on staff? ,Total annual payroll question
                case "Enter their total annual payroll":
                    WC_AboutYouPage.LicensedOrCertifiedTeachersAnnualPayrollQST.AssertElementIsVisible();
                    WC_AboutYouPage.LicensedOrCertifiedTeachersAnnualPayrollTxtBox.SetText(tableAnswer);
                    break;
                case "Business":
                    //if you leave the value blank fill in random business and DBA
                    if (tableAnswer.Equals(""))
                    {
                        WC_AboutYouPage.BusinessNameQST.AssertElementIsVisible();
                        WC_AboutYouPage.BusinessNameTxtbox.SetText(Functions.GetRandomStringWithRestrictions(9, "alpha"));
                        WC_AboutYouPage.DoingBusinessAsQst.AssertElementIsVisible();
                        WC_AboutYouPage.DoingBusinessAsTxtbox.SetText(Functions.GetRandomStringWithRestrictions(9, "alpha"));
                    }
                    else
                    {
                        //if you have two names separated by a semi colon
                        //assumes you are passing in Business name and DBA
                        if (tableAnswer.Contains(';'))
                        {
                            WC_AboutYouPage.BusinessNameQST.AssertElementIsVisible();
                            WC_AboutYouPage.BusinessNameTxtbox.SetText(busBeforeSemi.Match(tableAnswer).Value);
                            WC_AboutYouPage.DoingBusinessAsQst.AssertElementIsVisible();
                            WC_AboutYouPage.DoingBusinessAsTxtbox.SetText(busAfterSemi.Match(tableAnswer).Value);
                        }
                        //if you don't have semicolon
                        //assumes you are just passing in Business name
                        else
                        {
                            WC_AboutYouPage.BusinessNameQST.AssertElementIsVisible();
                            WC_AboutYouPage.BusinessNameTxtbox.SetText(tableAnswer);
                        }
                    }
                    break;
                case "Address":
                    WC_AboutYouPage.BusinessAddressLine1QST.AssertElementIsVisible();
                    WC_AboutYouPage.BusinessAddressLine2QST.AssertElementIsVisible();
                    WC_AboutYouPage.CityQST.AssertElementIsVisible();

                    List<string> list = ParseAddress(tableAnswer);
                    if (list.Count == 2)
                    {
                        WC_AboutYouPage.BusinessAddressLine1Txtbox.SetText(list[0]);
                        WC_AboutYouPage.CityDD.SelectDropdownOptionByText(list[1]);
                        _yourQuoteObject.State = WC_AboutYouPage.getState.GetInnerText().Trim();
                    }
                    else
                    {
                        WC_AboutYouPage.BusinessAddressLine1Txtbox.SetText(list[0]);
                        WC_AboutYouPage.BusinessAddressLine2Txtbox.SetText(list[1]);
                        WC_AboutYouPage.CityDD.SelectDropdownOptionByText(list[2]);
                        _yourQuoteObject.State = WC_AboutYouPage.getState.GetInnerText().Trim();
                    }
                    break;
                case "Fill Contact":
                    WC_AboutYouPage.ContactFirstNameQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactLastNameQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactEmailQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactPhoneQST.AssertElementIsVisible();
                    WC_AboutYouPage.BusinessWebsiteQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactFirstNameTxtbox.SetText(Functions.GetRandomStringWithRestrictions(6, "alpha"));
                    WC_AboutYouPage.ContactLastNameTxtbox.SetText(Functions.GetRandomStringWithRestrictions(6, "alpha"));
                    WC_AboutYouPage.ContactEmailTxtbox.SetText(Functions.GetRandomStringWithRestrictions(8, "alphaNumeric") + "@yahoo.com");
                    WC_AboutYouPage.ContactPhoneTxtbox.SetText(Functions.GetRandomStringWithRestrictions(10, "numeric"));
                    WC_AboutYouPage.BusinessWebsiteTxtbox.SetText("www." + Functions.GetRandomStringWithRestrictions(12, "alphaNumeric") + ".com");
                    break;
                case "Do you have any auto salespersons on staff?":
                    WC_AboutYouPage.AutoSalesperOnStaffQST.AssertElementIsVisible();
                    WC_AboutYouPage.AutoSalesperOnStaffHelper.Click();
                    WC_AboutYouPage.AutoSalesperOnStaffHelperText.AssertElementIsVisible();
                    if (tableAnswer.Equals("No", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        WC_AboutYouPage.AutoSalesperOnStaffNo().Click();
                    }
                    else
                    {
                        WC_AboutYouPage.AutoSalesperOnStaffYes().Click();
                        WC_AboutYouPage.AutoSalesperOnStaffPayrollQST.AssertElementIsVisible();

                        //pull payroll value out of the answer to set it OR generate it randomly
                        var payroll = ParsePayroll(tableAnswer);
                        WC_AboutYouPage.AutoSalesperOnStaffPayrollTxtbox().SetText(payroll);
                    }
                    break;
                case "Do any employees do any roadside assistance or towing?":
                    WC_AboutYouPage.RoadsideTowingQST.AssertElementIsVisible();
                    WC_AboutYouPage.RoadsideTowingHelper.Click();
                    WC_AboutYouPage.RoadsideTowingHelperText.AssertElementIsVisible();
                    if (tableAnswer.Equals("No", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        WC_AboutYouPage.RoadsideTowingNo().Click();
                    }
                    else
                    {
                        WC_AboutYouPage.RoadsideTowingYes().Click();
                        WC_AboutYouPage.RoadsideTowingPayrollQST.AssertElementIsVisible();

                        //pull payroll value out of the answer to set it OR generate it randomly
                        var payroll = ParsePayroll(tableAnswer);
                        WC_AboutYouPage.RoadsideTowingPayrollTxtbox().SetText(payroll);
                    }
                    break;
                case "Do any employees only do clerical office tasks and does not write up repair estimates?":
                    WC_AboutYouPage.EmpOfficeNotRepairEstQST.AssertElementIsVisible();
                    WC_AboutYouPage.EmpOfficeNotRepairEstHelper.Click();
                    WC_AboutYouPage.EmpOfficeNotRepairEstHelperText.AssertElementIsVisible();
                    if (tableAnswer.Equals("No", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        WC_AboutYouPage.EmpOfficeNotRepairEstNo().Click();
                    }
                    else
                    {
                        WC_AboutYouPage.EmpOfficeNotRepairEstYes().Click();
                        WC_AboutYouPage.EmpOfficeNotPayrollQST.AssertElementIsVisible();

                        //pull payroll value out of the answer to set it OR generate it randomly
                        var payroll = ParsePayroll(tableAnswer);
                        WC_AboutYouPage.EmpOfficeNotPayrollTxtbox().SetText(payroll);
                    }
                    break;
                case "Email":
                    WC_AboutYouPage.ContactEmailQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactEmailTxtbox.SetText(tableAnswer);
                    break;
                case "Phone":
                    WC_AboutYouPage.ContactPhoneQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactPhoneTxtbox.SetText(tableAnswer);
                    break;
                case "Contact First Name":
                    WC_AboutYouPage.ContactFirstNameQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactFirstNameTxtbox.SetText(tableAnswer);
                    break;
                case "Contact Last Name":
                    WC_AboutYouPage.ContactLastNameQST.AssertElementIsVisible();
                    WC_AboutYouPage.ContactLastNameTxtbox.SetText(tableAnswer);
                    break;
                case "Insured First Name":
                    WC_AboutYouPage.InsuredFirstNameQST.AssertElementIsVisible();
                    WC_AboutYouPage.InsuredFirstNameTxtbox.SetText(tableAnswer);
                    break;
                case "Insured Last Name":
                    WC_AboutYouPage.InsuredLastNameQST.AssertElementIsVisible();
                    WC_AboutYouPage.InsuredLastNameTxtbox.SetText(tableAnswer);
                    break;
                case "Business website":
                    WC_AboutYouPage.BusinessWebsiteTxtbox.AssertElementIsVisible();
                    WC_AboutYouPage.BusinessWebsiteTxtbox.SetText(tableAnswer);
                    break;
                case "Are there any employees that never travel to job sites or do any construction work?":
                    WC_AboutYouPage.EmpNeverTravelJobSiteConstQST.AssertElementIsVisible();
                    WC_AboutYouPage.EmpNeverTravelJobSiteConstAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Do you use any subcontractors or pay any workers using IRS Form 1099?":
                    WC_AboutYouPage.PayIRSForm1099QST.AssertElementIsVisible();
                    WC_AboutYouPage.PayIRSForm1099Answer(tableAnswer.ToLower()).Click();
                    break;
                case "Do you require all subcontractors/1099 workers to have certificates of insurance?":
                    WC_AboutYouPage.ReqWorkCOIQST.AssertElementIsVisible();
                    WC_AboutYouPage.ReqWorkCOIDD.SelectDropdownOptionByText(tableAnswer);
                    break;
                case "How much of total work is done by subcontractors/1099 workers?":
                    WC_AboutYouPage.HowMuchTotalWorkDoneQST.AssertElementIsVisible();
                    WC_AboutYouPage.HowMuchTotalWorkDoneDD.SelectDropdownOptionByText(tableAnswer);
                    break;
                case "Are there any cost estimators on staff that wouldn't do any direct physical work?":
                    WC_AboutYouPage.CostEstOnStaffNoDirectPhysicalQST.AssertElementIsVisible();
                    WC_AboutYouPage.CostEstOnStaffNoDirectPhysicalAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Do any employees only do general office work and rarely travel?":
                    WC_AboutYouPage.EmpGeneralWorkRarelyTravelQST.AssertElementIsVisible();
                    WC_AboutYouPage.EmpGeneralWorkRarelyTravelAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Are there any delivery drivers on staff?":
                    WC_AboutYouPage.AreThereAnyDeliveryDriversLabel.AssertElementIsVisible();
                    WC_AboutYouPage.AreThereAnyDelivertDriversAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Are there any travelling sales staff that are not involved at all in the manufacturing process?":
                    WC_AboutYouPage.AreThereAnyTravellingSalesStaffLabel.AssertElementIsVisible();
                    WC_AboutYouPage.AreThereAnyTravellingSalesStaffAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Are there any administrative or back office employees that are not involved at all in the manufacturing process?":
                    WC_AboutYouPage.AreThereAnyAdminstrativeEmployeesLabel.AssertElementIsVisible();
                    WC_AboutYouPage.AreThereAnyAdminstrativeEmployeeAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Do any employee contractors make at least $32/hr?":
                    WC_AboutYouPage.DoAnyEmployeeMake32Input.AssertAllElements();
                    WC_AboutYouPage.DoAnyEmployeeMake32Input.EnterResponse(tableAnswer);                     
                    break;
                case "Are there any employees that do not do any cleaning or maintenance work?":
                    WC_AboutYouPage.CleaningOrMaintenanceWork.AssertElementIsVisible();
                    WC_AboutYouPage.CleaningOrMaintenanceWorkAnswer(tableAnswer.ToLower()).Click();
                    break;
                case "Do any employees do any maintenance or repair work on aircraft?":
                    WC_AboutYouPage.EmployeesMaintenanceRepairAircraftAnswerInput.AssertAllElements();
                    WC_AboutYouPage.EmployeesMaintenanceRepairAircraftAnswerInput.EnterResponse(tableAnswer);
                    break;
                case "Do any employees only do clerical office work or operate a retail store?":
                    WC_AboutYouPage.ClericalOfficeWorkOrOperateRetailStoreAnswerInput.AssertAllElements();
                    WC_AboutYouPage.ClericalOfficeWorkOrOperateRetailStoreAnswerInput.EnterResponse(tableAnswer);
                    break;
                default:
                    break;
            }
        }

        [Then(@"user verifies the following companion class payroll answers and input fields:")]
        public void ThenUserVerifiesTheFollowingCompanionClassPayrollAnswersAndInputFields(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string disabled = (row["Disabled"].ToLower() == "yes" || row["Disabled"].ToLower() == "") ? "" : "not";
                var question = row["Question"];
                VerifyStatus(question, disabled);
            }
        }

        public void VerifyStatus(string question, string disabled)
        {
            switch (question)
            {
                case "Do you have any auto salespersons on staff?":
                    WC_AboutYouPage.AutoSalesperOnStaffYes(disabled).AssertElementIsVisible();
                    WC_AboutYouPage.AutoSalesperOnStaffNo(disabled).AssertElementIsVisible();
                    if (WC_AboutYouPage.AutoSalesperOnStaffYes(disabled).GetAttribute("class").Contains("active"))
                    {
                        WC_AboutYouPage.AutoSalesperOnStaffPayrollTxtbox(disabled).AssertElementIsVisible();
                    }
                    break;
                case "Do any employees do any roadside assistance or towing?":
                    break;
                case "Do any employees only do clerical office tasks and does not write up repair estimates?":
                    break;

                default:
                    break;
            }
        }

        /*
         * Pulls number value out of the table value answer.
         * If there isn't a number value, generate a random value and return that.
         */
        private string ParsePayroll(string answerWithPay)
        {
            Regex rgx = new Regex("([0-9])*");
            try
            {
                var result = rgx.Match(answerWithPay);
                while (result.Success)
                {
                    var potentialMatch = result.Value;
                    if (potentialMatch != "")
                    {
                        return potentialMatch;
                    }
                    result = result.NextMatch();
                }
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
                //if no match is found
                return Functions.GetRandomStringWithRestrictions(4, "numeric");
            }
        }

        /*
         * Takes in ;/, separated fields either:
         * Bus Address Line 1;City
         * or
         * Bus Address Line 1,Bus Address Line 2,City
         * 
         * Returns: LIST of these values
         */
        private List<string> ParseAddress(string addressString)
        {
            List<string> result = new List<string>();
            Regex rgx = new Regex("[0-9A-z ]*");
            var rgxFind = rgx.Match(addressString);
            while (rgxFind.Success)
            {
                var potentialMatch = rgxFind.Value;
                if (potentialMatch != "")
                {
                    result.Add(potentialMatch);
                }
                rgxFind = rgxFind.NextMatch();
            }

            return result;
        }
    }
}