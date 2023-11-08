using TechTalk.SpecFlow;
using HitachiQA;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.General;
using BiBerkLOB.Pages;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_Attorneys
    {
        //index counters for each type of lawyer used to map the xpaths
        private int _attorneyIndex, _ftContIndex, _ptContIndex = 0;

        //list created to hold first and last name values after being separated
        private List<string> _nameList = new List<string>();


        [Then(@"user verifies the appearance of the PL Attorneys - Almost Done page with these values:")]
        public void UserVerifyAttorneyAlmostDone(Table table)
        {
            PL_AttorneysPage.AlmostDoneTitle.AssertElementIsVisible();
            PL_AttorneysPage.AttorneyPageCopy.AssertElementIsVisible();

            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                UserHandlesAttorneyPage(theQuestion, theAnswer);
            }

            PL_AttorneysPage.ReferredContinueCTA.Click();
        }


        [Then(@"user verifies the appearance of the PL Attorneys - Nearly Finished page with these values:")]
        public void UserVerifyAttorneyNearlyFinished(Table table)
        {
            PL_AttorneysPage.AttorneyPageTitle.AssertElementIsVisible();

            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                UserHandlesAttorneyPage(theQuestion, theAnswer);
            }

            PL_AttorneysPage.ReferredContinueCTA.Click();
        }

        public void UserHandlesAttorneyPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Attorney":
                    DoFullNameSplit(theAnswer);
                    var AttIndexTemp = _attorneyIndex.ToString();
                    PL_AttorneysPage.AttorneyNameQST(AttIndexTemp).AssertElementIsVisible();
                    PL_AttorneysPage.FirstNameTxtbox(AttIndexTemp).SetText(_nameList[0]);
                    PL_AttorneysPage.LastNameTxtbox(AttIndexTemp).SetText(_nameList[1]);
                    _attorneyIndex++;
                    _nameList.Clear();
                    break;
                case "FT":
                    DoFullNameSplit(theAnswer);
                    var FTIndexTemp = _ftContIndex.ToString();
                    PL_AttorneysPage.FullTimeQST(FTIndexTemp).AssertElementIsVisible();
                    PL_AttorneysPage.FTFirstNameTxtbox(FTIndexTemp).SetText(_nameList[0]);
                    PL_AttorneysPage.FTLastNameTxtbox(FTIndexTemp).SetText(_nameList[1]);
                    _ftContIndex++;
                    _nameList.Clear();
                    break;
                case "PT":
                    DoFullNameSplit(theAnswer);
                    var PTIndexTemp = _ptContIndex.ToString();
                    PL_AttorneysPage.PartTimeQST(PTIndexTemp).AssertElementIsVisible();
                    PL_AttorneysPage.PTFirstNameTxtbox(PTIndexTemp).SetText(_nameList[0]);
                    PL_AttorneysPage.PTLastNameTxtbox(PTIndexTemp).SetText(_nameList[1]);
                    _ptContIndex++;
                    _nameList.Clear();
                    break;
                case "Title Agency":
                    PL_AttorneysPage.TitleAgencyQST.AssertElementIsVisible();
                    PL_AttorneysPage.TitleAgencyTxtbox.AssertElementIsVisible();
                    PL_AttorneysPage.TitleAgencyTxtbox.SetText(theAnswer);
                    break;
                default:
                    break;
            }
        }

        //this method breaks apart the first and last name that is passed in via the feature file
        //For instance: D'Andre Hopkins-Ceely
        //becomes "D'Andre" and "Hopkins-Ceely" as separate values in the list
        public void DoFullNameSplit(string fullName)
        {
            string pattern = @"([A-z'-]*)";

            foreach (Match match in Regex.Matches(fullName, pattern))
            {
                if(match.Value != "")
                {
                    _nameList.Add(match.Value);
                }                
            }
        }
    }
}