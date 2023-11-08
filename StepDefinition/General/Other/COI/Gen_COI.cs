using TechTalk.SpecFlow;
using BiBerkLOB.Pages;
using HitachiQA.Driver;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using System.Linq;
using BiBerkLOB.Pages.Other.COI;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.Other.COI
{
    [Binding]
    public sealed class Gen_COI
    {
        [Given(@"user navigates to the COI page")]
        public void GivenUserLandedBiBerkHomePageAndUserClicksOnGetAQuoteCTA()
        {
            UserActions.GoHome();
            try
            {
                Reusable_PurchasePath.MobileHamburgerMenu.Click(3);
                Reusable_PurchasePath.MobilePolicyHoldersDD.Click();
                Reusable_PurchasePath.MobileGetACertificate.Click();
            }
            catch
            {
                Reusable_PurchasePath.PolicyHoldersDD.Click();
                Reusable_PurchasePath.PolicyHoldersTitle.AssertElementIsVisible();
                Reusable_PurchasePath.GetACertificate.Click();
            }         
        }

        [Then(@"user verifies landing on Get a Certificate of Insurance login page")]
        public void ThenUserVerifyLandGetCOILoginPage()
        {
            AutomationHelper.ValidateElements(GetCertificateInsuranceLoginPage.COILoginPageElements);
        }

        [Then(@"user enters a policy number with a phone number")]
        public void UserEntersPolicyNumberAndPhone(Table table)
        {
            foreach (TableRow tableRow in table.Rows)
            {
                var countOfColumns = tableRow.Count;
                var tableHeaders = tableRow.Keys.ToList();
                for (int i = 0; i < countOfColumns; i++)
                {
                    //get the Value of the Table header AND value
                    var quoteTableQuestion = tableHeaders[i];
                    var quoteTableAnswer = tableRow[i];

                    HandleTableValues(quoteTableQuestion, quoteTableAnswer);
                }
                GetCertificateInsuranceLoginPage.ContinueCTA.Click();
            }
        }

        [Then(@"user fills out the COI form with the following values:")]
        public void UserFillsOutCOIForm(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                HandleTableValues(theQuestion, theAnswer);
            }

            GetACertificateOfInsuranceFormPage.GetCertificateCTA.Click();
        }

        [Then(@"user verifies the appearance of the certificate confirmation page")]
        public void ThenUserVerifiesTheAppearanceOfTheCertificateConfirmationPage()
        {
            AutomationHelper.ValidateElements(YourCertHasBeenEmailedPage.YourCertHasBeenEmailedElements);
        }

        [Then(@"user verifies the appearance of the COI Error Page")]
        public void ThenUserVerifiesTheAppearanceOfTheCOIErrorPage()
        {
            AutomationHelper.ValidateElements(CertificateOfInsuranceErrorPage.COIErrorPageElements);
        }     

        public void HandleTableValues(string theQuestion, string theAnswer)
        {
            switch (theQuestion)
            {
                case "Policy Number":
                    GetCertificateInsuranceLoginPage.PolicyNumberTxtBox.SetText(theAnswer);
                    break;
                case "Phone":
                    GetCertificateInsuranceLoginPage.PhoneTxtBox.SetText(theAnswer);
                    break;
                case "Do you need a certificate for a subcontractor or third-party vendor?":
                    GetACertificateOfInsuranceFormPage.CertForSubContractorQST.AssertElementIsVisible();
                    if(theAnswer== "Yes")
                    {
                        GetACertificateOfInsuranceFormPage.CertForSubContractorYes.Click();
                    }
                    else
                    {
                        GetACertificateOfInsuranceFormPage.CertForSubContractorNo.Click();
                    }
                    break;
                case "Do you want a certificate for all of your insurance policies?":
                    GetACertificateOfInsuranceFormPage.CertForAllQST.AssertElementIsVisible();
                    if(theAnswer == "Yes")
                    {
                        GetACertificateOfInsuranceFormPage.CertForAllYes.Click();
                    }
                    else
                    {
                        GetACertificateOfInsuranceFormPage.CertForAllNo.Click();
                    }
                    break;
                case "Subcontractor/Third-Party Business Name":
                    GetACertificateOfInsuranceFormPage.ContactNameQST.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.ContactNameTxtbox.SetText(theAnswer);
                    break;
                case "Subcontractor/Third-Party Business Street Address":
                    GetACertificateOfInsuranceFormPage.BusAdd.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.BusAdd_StreetTxtbox.SetText(theAnswer);
                    break;
                case "Subcontractor/Third-Party Business Apt/Suite":
                    GetACertificateOfInsuranceFormPage.BusAdd_AptTxtbox.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.BusAdd_AptTxtbox.SetText(theAnswer);
                    break;
                case "ZIP Code":
                    GetACertificateOfInsuranceFormPage.BusAdd_ZipTxtbox.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.BusAdd_ZipTxtbox.SetText(theAnswer);
                    break;
                case "City":
                    GetACertificateOfInsuranceFormPage.BusAdd_City.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.BusAdd_City.Click();
                    GetACertificateOfInsuranceFormPage.BusAdd_CityDDOption(theAnswer).Click();
                    break;
                case "State":
                    GetACertificateOfInsuranceFormPage.BusAdd_StateTxtbox.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.BusAdd_StateTxtbox.SetText(theAnswer);
                    break;
                case "Email":
                    GetACertificateOfInsuranceFormPage.EmailTxtbox.AssertElementIsVisible();
                    GetACertificateOfInsuranceFormPage.EmailTxtbox.SetText(theAnswer);
                    break;
                default:
                    break;
            }
        }
    }
}