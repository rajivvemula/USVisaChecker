using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Claims
{
    [Binding]
    public sealed class BOPClaimsPage : ClaimsPageBase
    {
        public static Element ReportAnBOPClaimTitle => new Element(By.XPath("//h1[@data-qa='report-a-business-owners-(bop)-claim-header']"));
        public static Element ReportAnBOPClaimParagraph => new Element(By.XPath("//p[@data-qa='report-claim-info-description']"));

        //Select Files to Upload
        public static Element SelectFilesToUpload => new Element(By.XPath("//div[@data-qa='upload-drag-drop-files']"));
        public static Element SelectFilesToUploadButton => new Element(By.XPath("//button[@data-qa='select-files-upload-button']"));
        public static Element SelectFilesToUploadParagraph => new Element(By.XPath("//p[@data-qa='upload-info-text']"));

        public static List<Element> BOP_ClaimsPageElements => new List<Element>
        {
            ReportAnBOPClaimTitle,
            ReportAnBOPClaimParagraph,
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
            SelectFilesToUpload,
            SelectFilesToUploadButton,
            SelectFilesToUploadParagraph,
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
        public static List<Element> BOP_ClaimsPageErrorMessages => new()
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