using BiBerkLOB.Pages.WC;
using HitachiQA.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class WC_Gen_OwnersAndOfficers
    {
        private WCOwnerOfficerObject _localOOObject = new WCOwnerOfficerObject();
        private readonly WCAdditionalInformationObject _localAIObject;
        private bool _excludedOfficersDetermined = false;
        private int _totalNumberOfOfficers = 0;
        private string _coverageForBusinessOwners = "";
        WCYourQuoteObject _wcYourQuoteObject;

        public WC_Gen_OwnersAndOfficers(WCYourQuoteObject wcYourQuoteObject, WCAdditionalInformationObject wcAIObject)
        {
            _wcYourQuoteObject = wcYourQuoteObject;
            _localAIObject = wcAIObject;
        }

        [Then(@"user verifies the appearance of the WC Owners and Officers Page")]
        public void ThenUserVerifiesWCOwnerOfficer()
        {
            WC_OwnersAndOfficers.OwnersAndOfficers_Header.AssertElementIsVisible();
        }

        [Then(@"user handles the WC OO kickoff questions with these values:")]
        public void ThenWCOOKickoff(Table table)
        {
            _totalNumberOfOfficers = SetTotalNumberOfOfficers(table);

            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleKickOffQST(theQuestion, theAnswer);
            }
            if (_excludedOfficersDetermined != true)
            {
                _localAIObject.ExcludedOfficers = _totalNumberOfOfficers - _localAIObject.IncludedOfficers;
            }
        }
        public int SetTotalNumberOfOfficers(Table table)
        {
            var totalIncluded = 0;
            var totalExcluded = 0;

            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];

                switch (theQuestion.ToLower())
                {
                    case "how many owners/officers does your business have?":
                    case "How many owners/officers are there?":
                        if (theAnswer.Contains("+") != true)
                        {
                            return int.Parse(theAnswer);
                        }
                        break;
                    case "how many owners/officers do you want to cover with this policy?":
                        totalIncluded = int.Parse(theAnswer);
                        break;
                    case "how many owners/officers do you want to exclude from this policy?":
                        totalExcluded = int.Parse(theAnswer);
                        break;
                }
            }

            return totalIncluded + totalExcluded;
        }

        [Then(@"user handles the WC Covered OO with these values:")]
        public void ThenWCCoveredOOKickoff(Table table)
        {
            //variable used for xpath path locator
            int instanceTracker = 0;

            foreach (TableRow rowy in table.Rows)
            {
                for (int i = 0; i < rowy.Count; i++)
                {
                    //get the Value of the Table header AND value
                    var valueOfTableHeader = rowy.Keys.ToList()[i];
                    var valueOfColumn = rowy[i];

                    HandleCoveredOO(valueOfTableHeader, valueOfColumn, instanceTracker.ToString());
                }
                instanceTracker++;
                AddIncludedOfficer();
            }
        }

        [Then(@"user handles the WC Excluded OO with these values:")]
        public void ThenWCExcludedOOKickoff(Table table)
        {
            WC_OwnersAndOfficers.ExcludedOO_Header.AssertElementIsVisible();
            WC_OwnersAndOfficers.ExcludedOOStateReq_Header.AssertElementIsVisible();

            //variable used for xpath path locator
            int instanceTracker = 0;

            foreach (TableRow rowy in table.Rows)
            {
                for (int i = 0; i < rowy.Count; i++)
                {
                    //get the Value of the Table header AND value
                    var valueOfTableHeader = rowy.Keys.ToList()[i];
                    var valueOfColumn = rowy[i];

                    HandleExcludedOO(valueOfTableHeader, valueOfColumn, instanceTracker.ToString());
                }
                instanceTracker++;
                AddExcludedOfficer();
            }
        }

        [Then(@"user continues on from the WC OO page")]
        public void UserContinuesOnFromOO()
        {
            CreateOwnerOfficersList();
            WC_OwnersAndOfficers.ContinueCTA.Click();
        }

        [Then(@"user verifies that the How many owners/officers do you want to cover with this policy\? dropdown options are equivalent to the following:")]
        public void ThenUserVerifiesThatTheDropdownOptionsAreEquivalentToTheFollowing(Table table)
        {
            var theFullAttributeValue = WC_OwnersAndOfficers.getHowManyOfficersId.GetAttribute("data-qa");
            Regex rgx = new Regex("[a-z_]*");
            var qstID = rgx.Replace(theFullAttributeValue, "");
            var expectedOptions = Functions.GetTableRowsAsAStringList(table);
            var ddQstId = new List<string>() { "103", "109", "112", "113" };

            if (ddQstId.Contains(qstID))
            {
                var ddelement = WC_OwnersAndOfficers.getHowManyToCover_DD(qstID);
                AutomationHelper.RetryUntilSucceeded(() => WC_OwnersAndOfficers.getHowManyToCover_DD(qstID).AssertSelectDropdownOptionsEqual(expectedOptions), 3);
            }
            else
            {
                WC_OwnersAndOfficers.HowManyToCover_Txtbox(qstID).AssertSelectDropdownOptionsEqual(expectedOptions);
            }
        }

        [Then(@"user verifies that the How many owners/officers does your business have\? dropdown options are equivalent to the following:")]
        public void ThenUserVerifiesThatTheHowManyOwnersOfficersDoesYourBusinessHaveDropdownOptionsAreEquivalentToTheFollowing(Table table)
        {
            var theFullAttributeValue = WC_OwnersAndOfficers.getHowManyOfficers_QST.GetAttribute("data-qa");
            Regex rgx = new Regex("[a-z_]*");
            var qstID = rgx.Replace(theFullAttributeValue, "");
            var expectedOptions = Functions.GetTableRowsAsAStringList(table);
            var ddQstId = new List<string>() { "100", "108" };

            if (ddQstId.Contains(qstID))
            {
                var ddelement = WC_OwnersAndOfficers.getHowManyOfficers_DD(qstID);
                AutomationHelper.RetryUntilSucceeded(() => WC_OwnersAndOfficers.getHowManyOfficers_DD(qstID).AssertSelectDropdownOptionsEqual(expectedOptions), 3);
            }
            else
            {
                WC_OwnersAndOfficers.HowManyToCover_Txtbox(qstID).AssertSelectDropdownOptionsEqual(expectedOptions);
            }
        }

        [Then(@"user verifies that the How many owners/officers do you want to cover with this policy\? dropdown options are equivalent to the following: (.*)")]
        public void ThenUserVerifiesThatTheHowManyOwnersOfficersDoYouWantToCoverWithThisPolicyDropdownOptionsAreEquivalentToTheFollowing(string optionsString)
        {
            var theFullAttributeValue = WC_OwnersAndOfficers.getHowManyOfficersId.GetAttribute("data-qa");
            Regex rgx = new Regex("[a-z_]*");
            var qstID = rgx.Replace(theFullAttributeValue, "");
            var expectedOptions = optionsString.Split(";").ToList();
            var ddQstId = new List<string>() { "103", "109", "112" };

            if (ddQstId.Contains(qstID))
            {
                var ddelement = WC_OwnersAndOfficers.getHowManyToCover_DD(qstID);
                AutomationHelper.RetryUntilSucceeded(() => WC_OwnersAndOfficers.getHowManyToCover_DD(qstID).AssertSelectDropdownOptionsEqual(expectedOptions), 3);
            }
            else
            {
                WC_OwnersAndOfficers.HowManyToCover_Txtbox(qstID).AssertSelectDropdownOptionsEqual(expectedOptions);
            }
        }

        /*
         * Check number of covered and not covered officers.  if they don't match the count on the list
         * add the appropriate number of people with the "covered" or "excluded" value filled in
         */
        private void CreateOwnerOfficersList()
        {
            if (_localAIObject.IncludedOfficers != _localAIObject.CoveredOOList.Count)
            {
                _localOOObject.OfficerInOrEx = "covered";

                for (int i = 0; i < _localAIObject.IncludedOfficers; i++)
                {
                    _localAIObject.CoveredOOList.Add(_localOOObject);
                }
            }

            if (_localAIObject.ExcludedOfficers != _localAIObject.ExcludedOOList.Count)
            {
                _localOOObject = new WCOwnerOfficerObject();
                _localOOObject.OfficerInOrEx = "excluded";
                for (int j = 0; j < _localAIObject.ExcludedOfficers; j++)
                {
                    _localAIObject.ExcludedOOList.Add(_localOOObject);
                }
            }
        }

        private void HandleExcludedOO(string valueOfTableHeader, string valueOfColumn, string instanceOfXPath)
        {
            switch (valueOfTableHeader)
            {
                case "First Name":
                    WC_OwnersAndOfficers.ExcludedOOFirstName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.ExcludedOOFirstName_Txtbox(instanceOfXPath).SetText(valueOfColumn);
                    _localOOObject.OfficerFullName = valueOfColumn;
                    break;
                case "Last Name":
                    WC_OwnersAndOfficers.ExcludedOOLastName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.ExcludedOOLastName_Txtbox(instanceOfXPath).SetText(valueOfColumn);
                    _localOOObject.OfficerFullName += " " + valueOfColumn;
                    break;
                case "Checkbox":
                    WC_OwnersAndOfficers.PercentCoveredMoreThan_Checkbox(instanceOfXPath).AssertElementIsVisible();
                    //if something is written as a value in the Checkbox column, assume you want to check the box, otherwise just check the existance of it
                    if (valueOfColumn != "")
                    {
                        WC_OwnersAndOfficers.PercentCoveredMoreThan_Checkbox(instanceOfXPath).Click();
                    }
                    break;
                case "Name":
                    var name = Functions.GetRandomStringWithRestrictions(7, "alpha");
                    WC_OwnersAndOfficers.ExcludedOOFirstName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.ExcludedOOFirstName_Txtbox(instanceOfXPath).SetText(name);
                    WC_OwnersAndOfficers.ExcludedOOLastName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.ExcludedOOLastName_Txtbox(instanceOfXPath).SetText(name);
                    _localOOObject.OfficerFullName = name + " " + name;
                    break;
                default:
                    break;
            }
        }

        private void HandleCoveredOO(string valueOfTableHeader, string valueOfColumn, string instanceOfXPath)
        {
            switch (valueOfTableHeader.ToLower())
            {
                case "first name":
                    WC_OwnersAndOfficers.CoveredOwnerHeader(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.StateRequireInfo_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredFirstName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredFirstName_Txtbox(instanceOfXPath).SetText(valueOfColumn);
                    _localOOObject.OfficerFullName = valueOfColumn;
                    break;
                case "last name":
                    WC_OwnersAndOfficers.CoveredLastName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredLastName_Txtbox(instanceOfXPath).SetText(valueOfColumn);
                    _localOOObject.OfficerFullName += " " + valueOfColumn;
                    break;
                case "insured first name":
                    WC_OwnersAndOfficers.CoveredOwnerHeader(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.StateRequireInfo_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredFirstName_QST(instanceOfXPath).AssertElementIsVisible();
                    _localOOObject.OfficerFullName = valueOfColumn;
                    break;
                case "insured last name":
                    WC_OwnersAndOfficers.CoveredLastName_QST(instanceOfXPath).AssertElementIsVisible();
                    _localOOObject.OfficerFullName += " " + valueOfColumn;
                    break;
                case "name":
                    var name = Functions.GetRandomStringWithRestrictions(7, "alpha");
                    WC_OwnersAndOfficers.CoveredOwnerHeader(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.StateRequireInfo_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredFirstName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredFirstName_Txtbox(instanceOfXPath).SetText(name);
                    WC_OwnersAndOfficers.CoveredLastName_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.CoveredLastName_Txtbox(instanceOfXPath).SetText(name);
                    _localOOObject.OfficerFullName = name + " " + name;
                    break;
                case "% ownership":
                    WC_OwnersAndOfficers.PercentCoveredLessThan_QST(instanceOfXPath).AssertElementIsVisible();
                    if (valueOfColumn.ToLower().Equals("yes"))
                    {
                        WC_OwnersAndOfficers.PercentCoveredLessThan_Yes(instanceOfXPath).Click();
                    }
                    else
                    {
                        WC_OwnersAndOfficers.PercentCoveredLessThan_No(instanceOfXPath).Click();
                    }
                    break;
                case "w2 payroll":
                    WC_OwnersAndOfficers.W2Payroll_QST(instanceOfXPath).AssertElementIsVisible();
                    if (valueOfColumn.ToLower().Equals("yes"))
                    {
                        WC_OwnersAndOfficers.W2Payroll_Yes(instanceOfXPath).Click();
                        _localOOObject.DoesOfficerReceieveW2Payroll = true;
                    }
                    else
                    {
                        WC_OwnersAndOfficers.W2Payroll_No(instanceOfXPath).Click();
                    }
                    break;
                case "annual payroll":
                    WC_OwnersAndOfficers.AnnualPayroll_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.AnnualPayroll_Txtbox(instanceOfXPath).SetText(valueOfColumn);
                    _localOOObject.OfficerPayroll = valueOfColumn;
                    break;
                case "job duty":
                    WC_OwnersAndOfficers.OwnerJobDuty_QST(instanceOfXPath).AssertElementIsVisible();
                    WC_OwnersAndOfficers.OwnerJobDuty_DD(instanceOfXPath).SelectDropdownOptionByText(valueOfColumn);
                    _localOOObject.OfficerRole = valueOfColumn;
                    break;
            }
        }

        private void HandleKickOffQST(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "How many owners/officers does your business have?":
                    try
                    {
                        WC_OwnersAndOfficers.HowManyOfficers_QST("100").AssertElementIsVisible(2);
                        WC_OwnersAndOfficers.HowManyOfficers_DD.SelectDropdownOptionByText(theAnswer);
                    }
                    catch
                    {
                        WC_OwnersAndOfficers.HowManyOfficers_QST("108").AssertElementIsVisible();
                        WC_OwnersAndOfficers.HowManyOfficers_Txtbox.SetText(theAnswer);
                    }
                    theAnswer = theAnswer.Equals("5+") ? "5" : theAnswer;
                    _localAIObject.NoOfOOForBusiness = int.Parse(theAnswer);
                    break;
                case "Are there included owner/officers that do not drive for your business?":
                    WC_OwnersAndOfficers.HowManyOfficersDrive_Txtbox.AssertElementIsVisible();
                    WC_OwnersAndOfficers.HowManyOfficersDrive_Txtbox.SetText(theAnswer);
                    break;
                case "How many owners/officers do you want to cover with this policy?":
                case "How many owners/officers do you want to cover with this policy? State law requires that they all be covered.":
                    //pull the info from the data-qa attribute to see what questionID you will be interacting with
                    var theFullAttributeValue = WC_OwnersAndOfficers.getHowManyOfficersId.GetAttribute("data-qa");
                    Regex rgx = new Regex("[a-z_]*");
                    //remove the other characters from the data-qa attribute so you can get the id#
                    var qstID = rgx.Replace(theFullAttributeValue, "");

                    WC_OwnersAndOfficers.getHowManyToCover_Helper(qstID).Click();
                    WC_OwnersAndOfficers.getHowManyToCover_HelperText(qstID).AssertElementIsVisible();
                    WC_OwnersAndOfficers.getHowManyToCover_QST(qstID).AssertElementIsVisible();

                    //list potential qstIDs that would need to interact with the answer as a dropdown
                    var ddQstId = new List<string>() { "103", "109", "112", "119" };
                    if (ddQstId.Contains(qstID))
                    {
                        //interact as a dropdown
                        //expected qstIDs: 103, 109, 112
                        WC_OwnersAndOfficers.getHowManyToCover_DD(qstID).SelectDropdownOptionByText(theAnswer);
                    }
                    else
                    {
                        //interact as a textbox OR a numbertextbox
                        //expected qstIDs: 114, 101, 104
                        WC_OwnersAndOfficers.HowManyToCover_Txtbox(qstID).SetText(theAnswer);
                    }
                    _localAIObject.IncludedOfficers = int.Parse(theAnswer);
                    break;
                case "How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered.":
                    if (_localAIObject.NoOfOOForBusiness >= 5)
                    {
                        WC_OwnersAndOfficers.HowMany10PercentO_TxtboxInput.EnterResponse(theAnswer);
                    }
                    else
                    {
                        WC_OwnersAndOfficers.HowMany10PercentOInput.EnterResponse(theAnswer);
                    }
                    _localAIObject.IncludedOfficers = int.Parse(theAnswer);
                    break;
                case "How many owners/officers do you want to exclude from this policy?":
                case "How many owners/officers do you want to exclude from this policy? State law requires that they all be excluded.":
                    try
                    {
                        WC_OwnersAndOfficers.ExcludeOOQST102.AssertElementIsVisible(2);
                        WC_OwnersAndOfficers.ExcludeOO_Txtbox("102").SetText(theAnswer);
                    }
                    catch
                    {
                        WC_OwnersAndOfficers.ExcludeOOQST105.AssertElementIsVisible();
                        WC_OwnersAndOfficers.ExcludeOO_Txtbox("105").SetText(theAnswer);
                    }
                    _localAIObject.ExcludedOfficers = int.Parse(theAnswer);
                    _excludedOfficersDetermined = true;
                    break;
                case "Are there any included owners/officers that never travel to job sites or do any construction work?":
                    WC_OwnersAndOfficers.IncOONeverTravel_QST.AssertElementIsVisible();
                    WC_OwnersAndOfficers.IncOONeverTravel_DD.SelectDropdownOptionByText(theAnswer);
                    WC_OwnersAndOfficers.IncOONeverTravel_Helper.Click();
                    WC_OwnersAndOfficers.IncOONeverTravel_HelperText.AssertElementIsVisible();
                    break;
                case "Are any included owners/officers licensed physicians, nurses, directors or administrators?":
                    WC_OwnersAndOfficers.IncOOLicensedPhysicians_Input.AssertAllElements();
                    WC_OwnersAndOfficers.IncOOLicensedPhysicians_Input.EnterResponse(theAnswer);
                    break;
                case "Are any included owners/officers real estate/leasing agents?":
                    WC_OwnersAndOfficers.AreAnyOfficersLeasingAgents.AssertElementIsVisible();
                    WC_OwnersAndOfficers.AreAnyOfficersLeasingAgents.SelectDropdownOptionByText(theAnswer);
                    break;
                case "Do any included owners/officers only do general office work and rarely travel?":
                    WC_OwnersAndOfficers.IncOORarelyTravel_Input.AssertAllElements();
                    WC_OwnersAndOfficers.IncOORarelyTravel_Input.EnterResponse(theAnswer);
                    break;
                case "Are any included owners/officers cost estimators that wouldn't do any direct physical work?":
                    WC_OwnersAndOfficers.DirectPhysicalWork_Input.AssertAllElements();
                    WC_OwnersAndOfficers.DirectPhysicalWork_Input.EnterResponse(theAnswer);
                    break;
                case "Do you want to buy coverage for the business owners?":
                    WC_OwnersAndOfficers.BuyCovBusinessOwn_QST.AssertElementIsVisible();
                    WC_OwnersAndOfficers.BuyCovBusinessOwn_BTN(theAnswer.ToLower()).Click();
                    _coverageForBusinessOwners = theAnswer;
                    break;
                case "How many owners/officers are there?":
                    WC_OwnersAndOfficers.HowManyOOAreThereQST.AssertElementIsVisible();
                    WC_OwnersAndOfficers.HowManyOOAreThereTxtbox.SetText(theAnswer);
                    _localAIObject.NoOfOOForBusiness = int.Parse(theAnswer);
                    break;
                case "Do any included owners/officers travel frequently for sales, consultation, or auditing?":
                    WC_OwnersAndOfficers.DoAnyOfficersTravelFrequently.AssertElementIsVisible();
                    WC_OwnersAndOfficers.DoAnyOfficersTravelFrequently.SelectDropdownOptionByText(theAnswer);
                    break;
                case "Do any included owners/officers only do general office work never writing up repair estimates?":
                    UnderwritersQuestionPage.ownerRepairEstQST.AssertElementIsVisible();
                    UnderwritersQuestionPage.ownerRepairEst.SelectDropdownOptionByText(theAnswer);
                    break;
                case "Are there any included owners/officers that do not do any cleaning or maintenance work?":
                    UnderwritersQuestionPage.CleaningOrMaintenanceWorkQST.AssertElementIsVisible();
                    UnderwritersQuestionPage.CleaningOrMaintenanceWork.SelectDropdownOptionByText(theAnswer);
                    break;
                case "How many owners have less than 50% ownership? State law requires that they be covered.":
                    try
                    {
                        WC_OwnersAndOfficers.HowManyPercentO_QSTX.AssertElementIsVisible(2);
                        WC_OwnersAndOfficers.HowManyPercentO_Helper("111").Click();
                        WC_OwnersAndOfficers.HowManyPercentO_HelperText("111").AssertElementIsVisible();
                        WC_OwnersAndOfficers.HowManyPercentO_DD.SelectDropdownOptionByText(theAnswer);
                    }
                    catch
                    {
                        WC_OwnersAndOfficers.HowManyPercentO_QSTZ.AssertElementIsVisible();
                        WC_OwnersAndOfficers.HowManyPercentO_Helper("113").Click();
                        WC_OwnersAndOfficers.HowManyPercentO_HelperText("113").AssertElementIsVisible();
                        WC_OwnersAndOfficers.HowManyPercentO_TxtboxZ.SetText(theAnswer);
                    }
                    break;
                case "Do any included owners/officers only do general office work and do not work a cash register?":
                    WC_OwnersAndOfficers.CashRegister_Input.AssertAllElements();
                    WC_OwnersAndOfficers.CashRegister_Input.EnterResponse(theAnswer);
                    break;
                case "Are there any included owners/officers that never interact with clients/patients?":
                    WC_OwnersAndOfficers.OONeverInteractWithClient_Input.AssertAllElements();
                    WC_OwnersAndOfficers.OONeverInteractWithClient_Input.EnterResponse(theAnswer);
                    break;

                default:
                    throw new System.NotImplementedException("Question not handled in the WC OO Kickoff Questions logic.");
            }
            SaveWCOOQuestion(new OwnerOfficerQuestionObject(theQuestion, theAnswer));
        }

        private void SaveWCOOQuestion(OwnerOfficerQuestionObject ownerOfficerQuestionObject)
        {
            _localAIObject.OwnerOfficerQuestions.Add(ownerOfficerQuestionObject);
        }

        [Then(@"user clicks back and modify from the WC Owners and Officers Page")]
        public void ThenUserClicksBackAndModifyFromTheWCOwnersAndOfficersPage()
        {
            WC_OwnersAndOfficers.BackAndModifyCTA.Click();
            AutomationHelper.WaitForWCLoading();
        }

        public void AddIncludedOfficer()
        {
            _wcYourQuoteObject.IncludedOfficers++;
            _localOOObject.OfficerInOrEx = "covered";
            _localAIObject.CoveredOOList.Add(_localOOObject);
            _localOOObject = new WCOwnerOfficerObject();
        }

        public void AddExcludedOfficer()
        {
            _wcYourQuoteObject.ExcludedOfficers++;
            _localOOObject.OfficerInOrEx = "excluded";
            _localAIObject.ExcludedOOList.Add(_localOOObject);
            _localOOObject = new WCOwnerOfficerObject();
        }
    }
}