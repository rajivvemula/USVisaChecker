using HitachiQA.Driver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
namespace BiBerkLOB.Pages.Other.Claims
{
    public sealed class PLClaimsPage : ClaimsPageBase
    {
        // Claim's page header: Report a Professional Liability (E&O) Claim
        public static Element ProLiabClaimHeader => new Element(By.XPath("//h1[@data-qa='report-a-professional-liability-(e&o)-claim-header']"));
        // Claim's page paragraph
        public static Element ProLiabInsParagraph => new Element(By.XPath("//p[@data-qa='report-claim-info-description']"));
        public static List<Element> PL_ClaimsPageElements => new List<Element>
        {
            ProLiabClaimHeader,
            ProLiabInsParagraph,
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

        public static List<Element> PLClaimErrorElements => new()
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