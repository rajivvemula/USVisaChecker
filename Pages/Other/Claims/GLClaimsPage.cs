using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other.Claims
{
    [Binding]
    class GLClaimsPage : ClaimsPageBase
    {
        //Claims Header title page with instructions: Complete the form below to notify biBERK of your claim. Once your form has been submitted. the Claims intake department will contact you by phone to gather detailed information.
        public static Element GLClaimsPageTitle => new Element(By.XPath("//h1[@data-qa='report-a-general-liability-claim-header']"));
        public static Element GLClaimsPageParagraph => new Element(By.XPath("//p[@data-qa='report-claim-info-description']"));

        public static List<Element> GL_ClaimsPageElements => new List<Element>
        {
            GLClaimsPageTitle,
            GLClaimsPageParagraph,
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

        public static List<Element> GL_ClaimsPageErrorMessages => new()
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