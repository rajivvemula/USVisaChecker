using BiBerkLOB.Pages.WC;
using HitachiQA;
using HitachiQA.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class WC_Gen_AdditionalInformation
    {
        private readonly WCAdditionalInformationObject _localAIObject;

        public WC_Gen_AdditionalInformation(WCAdditionalInformationObject wcAIObject)
        {
            _localAIObject = wcAIObject;
        }

        [Then(@"user lands on and continues past the Additional Information page")]
        public void UserLandsOnAndContinuesPastAI()
        {
            WC_AdditionalInformationPage.AdditionalInfoTitle.AssertElementIsVisible();
            WC_AdditionalInformationPage.AdditionalInfoSubTitle.AssertElementIsVisible();

            WC_AdditionalInformationPage.ContinueToPurchaseCTA.Click();
        }

        [Then(@"user continues on from the WC Additional Information page")]
        public void ThenUserMovesOnFromAIPage()
        {
            WC_AdditionalInformationPage.AdditionalInfoTitle.Click();
            WC_AdditionalInformationPage.ContinueToPurchaseCTA.Click();
        }

        [Then(@"user verifies the appearance of the WC Additional Information page")]
        public void ThenUserVerifiesAdditionalInfoPage()
        {
            WC_AdditionalInformationPage.AdditionalInfoTitle.AssertElementIsVisible();
            WC_AdditionalInformationPage.AdditionalInfoSubTitle.AssertElementIsVisible();
        }

        [Then(@"user begins the WC AI page (.*) with value (.*)")]
        public void UserSetAIPageWithValue(string p0, string p1)
        {
            switch (p0)
            {
                case "setting the FEIN":
                    WC_AdditionalInformationPage.HaveFEIN.AssertElementIsVisible();
                    WC_AdditionalInformationPage.HaveFEINBTN_Yes.Click();
                    WC_AdditionalInformationPage.WhatIsFEIN.AssertElementIsVisible();
                    WC_AdditionalInformationPage.WhatIsFEINTxtbox.SetText(p1);
                    break;
                case "setting the SSN":
                    WC_AdditionalInformationPage.HaveFEIN.AssertElementIsVisible();
                    WC_AdditionalInformationPage.HaveFEINBTN_No.Click();
                    WC_AdditionalInformationPage.WhatIsSSNLabel.AssertElementIsVisible();
                    WC_AdditionalInformationPage.WhatIsSSNTextbox.SetText(p1);
                    break;
                case "having the FEIN": //the FEIN is already entered on the page
                    WC_AdditionalInformationPage.HaveFEIN.AssertElementIsVisible();
                    WC_AdditionalInformationPage.HaveFEINBTN_YesDisabled.AssertElementIsVisible();
                    WC_AdditionalInformationPage.WhatIsFEIN.AssertElementIsVisible();
                    WC_AdditionalInformationPage.WhatIsFEINTxtbox_Disabled.AssertElementIsVisible();
                    Assert.Equals(WC_AdditionalInformationPage.HaveFEINBTN_YesDisabled.GetInnerText(), p1);
                    break;
                case "having the SSN": //the SSN is already entered on the page
                    WC_AdditionalInformationPage.HaveFEIN.AssertElementIsVisible();
                    WC_AdditionalInformationPage.HaveFEINBTN_NoDisabled.AssertElementIsVisible();
                    WC_AdditionalInformationPage.WhatIsSSNLabel.AssertElementIsVisible();
                    WC_AdditionalInformationPage.WhatIsSSNTextbox_Disabled.AssertElementIsVisible();
                    Assert.Equals(WC_AdditionalInformationPage.WhatIsSSNTextbox_Disabled.GetInnerText(), p1);
                    break;
            }
        }

        [Then(@"wc user handles (.*) covered oo")]
        public void WCUserHandleCovOO(int numOfCoveredOO)
        {
            //if the CoveredList has a blank value for the name...
            if (_localAIObject.CoveredOOList[0].OfficerFullName.Equals(""))
            {
                PopulateCoveredOONamesOnly(numOfCoveredOO);
            }
            else
            {
                //use data saved from OO page about Name (and maybe also Job Title)
                VerifyCoveredOONameAndPossiblyRole();
            }
        }

        [When(@"user sets the additional information page state unemployment insurance value to: (.*)")]
        public void WhenUserSetsTheAdditionalInformationPageStateUnemploymentInsuranceValueTo(string uiNumber)
        {
            WC_AdditionalInformationPage.StateUnemploymentInput.AssertAllElements();
            WC_AdditionalInformationPage.StateUnemploymentInput.EnterResponse(uiNumber);
        }

        [Then(@"wc user handles (.*) excluded oo with these values:")]
        public void WCUserHandlesExclOO(int numOfCoveredOO, Table table)
        {
            //flag to reset the index to 0 when the covered included officers appear in the excluded section
            bool includedOfficersAreExcluded = ExcludedListCountFix(numOfCoveredOO);

            //index for xpath
            int indexForXPath = 0;
            //index for place in the list
            int indexForListLocation = 0;


            foreach (TableRow rowy in table.Rows)
            {
                var countOfColumns = rowy.Count;
                var listOfKeys = rowy.Keys;
                var orderedListOfKeys = listOfKeys.ToList();

                /*
                 * If covered officers were excluded (because of type of plan selected)
                 * AND we at the point in the excluded list where the first originally covered officer is...
                 * reset the index (because the XPath on this page restarts at 0 once the covered officers show up in the excluded section).
                 * Also, set the includedOfficersAreExcluded to false, so it quickly jumps out of the IF check.
                 */
                if (includedOfficersAreExcluded.Equals(true) && _localAIObject.ExcludedOOList[indexForListLocation].OfficerInOrEx.Equals("covered"))
                {
                    indexForXPath = 0;
                    includedOfficersAreExcluded = false;
                }


                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    var questionTag = orderedListOfKeys[i];
                    var answer = rowy[i];

                    HandleExcludedOO(questionTag, answer, indexForXPath, indexForListLocation);
                }
                indexForXPath++;
                indexForListLocation++;
            }
        }

        /*
         * if the number of excluded does not match the excluded list...
         * then they chose the standard plan and the covered list will ALSO be excluded
         */
        private bool ExcludedListCountFix(int numOfCoveredOO)
        {
            if (numOfCoveredOO != _localAIObject.ExcludedOOList.Count)
            {
                _localAIObject.ExcludedOOList.AddRange(_localAIObject.CoveredOOList);
                return _localAIObject.ExcludedOOList.Any();
            }
            return false;
        }

        private void HandleExcludedOO(string questionTag, string answer, int index, int indexForListLocation)
        {
            switch (questionTag)
            {
                case "Set Name":
                    SetExcludedOOName(index, answer, indexForListLocation);
                    break;
                case "Have Name":
                    HaveName(index, indexForListLocation);
                    break;
                case "Set SSN":
                    SetExcludedOOSSN(index, answer, indexForListLocation);
                    break;
                case "Set Job":
                    SetJob(index, answer, indexForListLocation);
                    break;
                case "Set DOB":
                    SetDOB(index, answer, indexForListLocation);
                    break;
                default:
                    throw new ArgumentException("Table header value currently not implemented");
            }
        }

        private void HaveName(int index, int indexForListLocation)
        {
            //if it is "covered", the xpath says "included"
            var xpathValue = ConvertCoveredToIncluded(indexForListLocation);
            WC_AdditionalInformationPage.ExcludedFullNameLabel(xpathValue, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedFullNameLabel(xpathValue, index).AssertElementInnerTextEquals(_localAIObject.ExcludedOOList[indexForListLocation].OfficerFullName);
        }

        private void SetJob(int index, string answer, int indexForListLocation)
        {
            //if it is "covered", the xpath says "included"
            var xpathValue = ConvertCoveredToIncluded(indexForListLocation);
            WC_AdditionalInformationPage.ExcludedOfficerOwnerJobTitleLabel(xpathValue, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedOfficerOwnerJobTitleDD(xpathValue, index).SelectDropdownOptionByText(answer);
        }

        private void SetDOB(int index, string answer, int indexForListLocation)
        {
            //if it is "covered", the xpath says "included"
            var xpathValue = ConvertCoveredToIncluded(indexForListLocation);
            WC_AdditionalInformationPage.ExcludedOfficerOwnerDOBLabel(xpathValue, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedOfficerOwnerDOBInput(xpathValue, index).SetText(answer);
        }

        private string ConvertCoveredToIncluded(int indexForListLocation)
        {
            if (_localAIObject.ExcludedOOList[indexForListLocation].OfficerInOrEx.Equals("covered")){
                return "included";
            }
            else
            {
                return "excluded";
            }
        }

        private void SetExcludedOOSSN(int index, string answer, int indexForListLocation)
        {
            //if it is "covered", the xpath says "included"
            var xpathValue = ConvertCoveredToIncluded(indexForListLocation);
            WC_AdditionalInformationPage.ExcludedOfficerSSNLabel(xpathValue, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedOfficerSSNHelper(xpathValue, index).Click();
            WC_AdditionalInformationPage.ExcludedOfficerSSNHelperTxt(xpathValue, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedOfficerSSNTextbox(xpathValue, index).SetText(answer);
        }

        private void SetExcludedOOName(int index, string answer, int indexForListLocation)
        {
            Regex rx = new Regex("([A-z'-]*)");
            MatchCollection matches = rx.Matches(answer);

            WC_AdditionalInformationPage.ExcludedOfficersOwnersFirstNameLabel(_localAIObject.ExcludedOOList[indexForListLocation].OfficerInOrEx, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedOfficerOwnerFirstNameTextbox(_localAIObject.ExcludedOOList[indexForListLocation].OfficerInOrEx, index).SetText(matches[0].Value);
            WC_AdditionalInformationPage.ExcludedOfficerOwnerLastNameLabel(_localAIObject.ExcludedOOList[indexForListLocation].OfficerInOrEx, index).AssertElementIsVisible();
            WC_AdditionalInformationPage.ExcludedOfficerOwnerLastNameTextbox(_localAIObject.ExcludedOOList[indexForListLocation].OfficerInOrEx, index).SetText(matches[2].Value);
        }


        /*
         * Verify saved off Covered OO Name (from Owner Officer Page).
         * If a Role is saved off, verify its appearance.
         * If a Role is NOT saved off, verify it does not appear.
         */
        private void VerifyCoveredOONameAndPossiblyRole()
        {
            WC_AdditionalInformationPage.CoveredIncludedOOLabel.AssertElementIsVisible();
            for (int i = 0; i < _localAIObject.CoveredOOList.Count; i++)
            {
                //checking if the name appears here, does not check if the InnerText EQUALS because they are adding a ":" at the end of the name
                WC_AdditionalInformationPage.CoveredIncludedExcludedOOFullNameLabel(i).AssertElementContainsText(_localAIObject.CoveredOOList[i].OfficerFullName);
                if (_localAIObject.CoveredOOList[i].OfficerRole != "")
                {
                    //checking if the Role appears here, does not check if the InnerText EQUALS because they are adding a "Role: " before the job duty
                    WC_AdditionalInformationPage.CoveredIncludedExcludedOOJobLabel(i).AssertElementContainsText(_localAIObject.CoveredOOList[i].OfficerRole);
                }
                else
                {
                    //this check added because of Bug 84361 - WC Path |  Role is appearing after officers when it should not [because they were not entered]
                    WC_AdditionalInformationPage.CoveredIncludedExcludedOOJobLabel(i).AssertElementNotPresent(2);
                }
            }
        }

        /*
         * Set Covered Owner Officer Names.
         */
        private void PopulateCoveredOONamesOnly(int numOfCoveredOO)
        {
            WC_AdditionalInformationPage.CoveredOwnersOfficersLabel.AssertElementIsVisible();
            for(int i = 0; i < numOfCoveredOO; i++)
            {
                WC_AdditionalInformationPage.CoveredOwnersOfficersFirstNameLabel(i).AssertElementIsVisible();
                WC_AdditionalInformationPage.CoveredOwnerOfficerFirstNameTextBox(i).SetText(Functions.GetRandomStringWithRestrictions(7, "alpha"));
                WC_AdditionalInformationPage.CoveredOwnerOfficerLastNameLabel(i).AssertElementIsVisible();
                WC_AdditionalInformationPage.CoveredOwnerOfficerLastNameTextBox(i).SetText(Functions.GetRandomStringWithRestrictions(7, "alpha"));
            }
        }
    }
}