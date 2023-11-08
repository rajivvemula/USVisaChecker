using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Claims
{
    [Binding]
    public sealed class UMClaimsPage : ClaimsPageBase
    {
        public static Element ReportAnUMClaimTitle => new Element(By.XPath("//h1[@data-qa='report-an-umbrella-claim-header']"));
        public static Element ReportAnUMClaimParagraph => new Element(By.XPath("//p[@data-qa='report-claim-info-description']"));

        public static List<Element> UM_ClaimsPageElements => new List<Element>
        {
            ReportAnUMClaimTitle,
            ReportAnUMClaimParagraph,
            PolicyNumberHeader,
            PolicyNumberTextbox,
            BusinessNameQST,
            BusinessNameTextbox,
            ContactNameHeader,
            FirstNameTextbox,
            LastNameTextbox,
            PhoneHeader,
            PhoneTextbox,
            ExtHeader,
            PhoneNumExtTextbox,
            HowToConnectQST,
            HowToConnectTextbox,
            DateOfLoss,
            DateOfLossDateField,
            LocationOfLoss,
            LocationOfLossTxtbox,
            ShortDescrip,
            ShortDescripTextbox,
            SubmitClaimsButton,
            QuestionsHeader,
            PhoneIcon,
            PhoneNumber,
            OfficeHours,
            FaxNumber,
            EmailIcon,
            ClaimsEmail,
            ClaimsContactAddress
        };

        public static List<Element> UM_ClaimsPageErrorMessages => new()
        {
            PolicyNumberError,
            BusinessNameError,
            FirstNameError,
            LastNameError,
            PhoneError,
            HowToConnectError,
            DateofLossError,
            LocationOfLossError,
            ShortDescripError
        };
    }
}