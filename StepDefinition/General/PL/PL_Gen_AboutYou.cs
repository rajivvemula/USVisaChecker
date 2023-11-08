using TechTalk.SpecFlow;
using HitachiQA;
using HitachiQA.Driver;
using BiBerkLOB.Pages.PL;
using BiBerkLOB.General;
using BiBerkLOB.Pages;
using System.Text.RegularExpressions;
using System.Threading;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;


namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_AboutYou
    {
        private readonly PLSummaryObject _plSummaryObject;

        public PL_Gen_AboutYou(PLSummaryObject plSummaryObject)
        {
            _plSummaryObject = plSummaryObject;
        }

        [Then(@"user verifies the appearance of the PL About You Page")]
        public void ThenUserVerifiesTheAppearanceOfThePLAboutYouPage()
        {
            AutomationHelper.LegacyWaitForLoading();
            PL_AboutYou.AboutYouHeader.AssertElementIsVisible();
        }

        [Then(@"user fills out About You page with these values:")]
        public void ThenUserFillsOutAboutYouPageWithTheseValues(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleAboutYouPage(theQuestion, theAnswer);
            }

            PL_AboutYou.SummaryButton.Click();
        }       
        public void HandleAboutYouPage(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "First Name":
                    PL_AboutYou.FirstNameTxtbox.AssertElementIsVisible();
                    _plSummaryObject.ContactFirstName = theAnswer;
                    PL_AboutYou.FirstNameTxtbox.SetText(_plSummaryObject.ContactFirstName);
                    break;

                case "Last Name":
                    PL_AboutYou.LastNameTxtbox.AssertElementIsVisible();
                    _plSummaryObject.ContactLastName = theAnswer;
                    PL_AboutYou.LastNameTxtbox.SetText(_plSummaryObject.ContactLastName);
                    break;

                case "Address":
                    PL_AboutYou.BusinessAddressTxtbox.AssertElementIsVisible();
                    _plSummaryObject.BusAddress = theAnswer;
                    PL_AboutYou.BusinessAddressTxtbox.SetText(_plSummaryObject.BusAddress);
                    break;

                case "Apt/Suite":
                    PL_AboutYou.AptSuiteTxtbox.AssertElementIsVisible();
                    _plSummaryObject.BusAddress2 = theAnswer;
                    PL_AboutYou.AptSuiteTxtbox.SetText(theAnswer);
                    break;

                case "City":
                    PL_AboutYou.AddressCityDD.AssertElementIsVisible();
                    _plSummaryObject.BusCity = theAnswer;
                    if (!theAnswer.Equals(PL_AboutYou.AddressCityDD.GetTextFieldValue()))
                    {
                        PL_AboutYou.AddressCityDD.Click();
                        PL_AboutYou.AddressCityDDOption1(theAnswer).Click();
                    }
                    //get state, zipcode                                 
                    HandleStateZipParse(PL_AboutYou.StateZipTxt.GetElementText());
                    break;

                case "Use as Mailing Address":
                    PL_AboutYou.UseMailingAddressChkbox.AssertElementIsVisible();
                    if (theAnswer == "No")
                    {
                        PL_AboutYou.UseMailingAddressChkbox.Click();
                    }
                    break;

                case "Mailing Address":
                    PL_AboutYou.MailingAddressTxtbox.AssertElementIsVisible();
                    PL_AboutYou.MailingAddressTxtbox.SetText(theAnswer);
                    break;

                case "Mailing Apt/Suite":
                    PL_AboutYou.AptSuite2Txtbox.AssertElementIsVisible();
                    PL_AboutYou.AptSuite2Txtbox.SetText(theAnswer);
                    break;

                case "Mailing ZIP":
                    PL_AboutYou.MailingZipCodeTxtbox.AssertElementIsVisible();
                    PL_AboutYou.MailingZipCodeTxtbox.SetText(theAnswer);
                    break;

                case "Mailing City":
                    PL_AboutYou.MailingCityDD.AssertElementIsVisible();
                    if (!theAnswer.Equals(PL_AboutYou.MailingCityDD.GetTextFieldValue()))
                    {
                        PL_AboutYou.MailingCityDD.Click();
                        PL_AboutYou.MailingCityDDOption(theAnswer).Click();
                    }
                    break;

                case "Mailing State":
                    PL_AboutYou.MailingStateTxtbox.AssertElementIsVisible();
                    PL_AboutYou.MailingStateTxtbox.SetText(theAnswer);
                    break;

                case "Email":
                    PL_AboutYou.EmailAddressTxtbox.AssertElementIsVisible();
                    if (theAnswer.Contains("[[") && theAnswer.Contains("]]")) theAnswer = new General_ParamValueInterpreter().ExtractParamValue(theAnswer);
                    _plSummaryObject.BusEmail = theAnswer;
                    PL_AboutYou.EmailAddressTxtbox.SetText(_plSummaryObject.BusEmail);
                    break;

                case "Business Phone":
                    PL_AboutYou.BusinessPhoneTxtbox.AssertElementIsVisible();
                    if (theAnswer.Contains("[[") && theAnswer.Contains("]]")) theAnswer = new General_ParamValueInterpreter().ExtractParamValue(theAnswer);
                    _plSummaryObject.BusPhone = theAnswer;
                    PL_AboutYou.BusinessPhoneTxtbox.SetText(_plSummaryObject.BusPhone);
                    break;

                case "Ext":
                    PL_AboutYou.BusinessPhoneExtTxtbox.AssertElementIsVisible();
                    _plSummaryObject.BusExtPhone = theAnswer;
                    PL_AboutYou.BusinessPhoneExtTxtbox.SetText(_plSummaryObject.BusExtPhone);
                    break;

                case "Website/Social":
                    PL_AboutYou.BusinessWebsiteTxtbox.AssertElementIsVisible();
                    _plSummaryObject.BusWebSocialPage = theAnswer;
                    PL_AboutYou.BusinessWebsiteTxtbox.SetText(_plSummaryObject.BusWebSocialPage);
                    break;

                case "Have Broker":
                    PL_AboutYou.BrokerChkbox.AssertElementIsVisible();
                    _plSummaryObject.HaveBrokerAccount = theAnswer;
                    if (_plSummaryObject.HaveBrokerAccount == "Yes")
                    {
                        PL_AboutYou.BrokerChkbox.Click();
                    }
                    break;

                case "Manager First Name":
                    PL_AboutYou.BrokerFirstName.AssertElementIsVisible();
                    _plSummaryObject.ManagerFirstName = theAnswer;
                    PL_AboutYou.BrokerFirstName.SetText(_plSummaryObject.ManagerFirstName);
                    break;

                case "Manager Last Name":
                    PL_AboutYou.BrokerLastName.AssertElementIsVisible();
                    _plSummaryObject.ManagerLastName = theAnswer;
                    PL_AboutYou.BrokerLastName.SetText(_plSummaryObject.ManagerLastName);
                    break;

                case "Manager Phone Number":
                    PL_AboutYou.BrokerPhone.AssertElementIsVisible();
                    _plSummaryObject.ManagerPhone = theAnswer;
                    PL_AboutYou.BrokerPhone.SetText(_plSummaryObject.ManagerPhone);
                    break;

                case "Manager Phone Ext":
                    PL_AboutYou.BrokerExt.AssertElementIsVisible();
                    _plSummaryObject.ManagerPhoneExt = theAnswer;
                    PL_AboutYou.BrokerExt.SetText(_plSummaryObject.ManagerPhoneExt);
                    break;

                case "Manager Email":
                    PL_AboutYou.BrokerEmail.AssertElementIsVisible();
                    _plSummaryObject.ManagerEmail = theAnswer;
                    PL_AboutYou.BrokerEmail.SetText(_plSummaryObject.ManagerEmail);
                    break;
            }
        }

        public void HandleStateZipParse(string zipState)
        {
            Regex rgxState = new Regex(@"[A-z]*");
            Regex rgxZip = new Regex(@"[0-9]*");

            //get State
            _plSummaryObject.BusState = (rgxState.Match(zipState)).Value;

            //get ZipCode
            Match m = rgxZip.Match(zipState);   // m is the first "match"
            while (m.Success)
            {
                // Do something with m
                var potentialMatch = m.Value;   //this is what is used to get the information returned from that match
                if (potentialMatch != "")
                {
                    _plSummaryObject.BusZipCode = potentialMatch;
                    break;
                }
                m = m.NextMatch();              // more matches
            }
        }
    }
}