using HitachiQA.Driver;
using BiBerkLOB.Pages.CommAuto;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Features.Comm_Auto.Unit
{
    [Binding]
    public class CA_No_PPSteps
    {
        [Then(@"user forces No PP Page")]
        public void ThenUserForcesNoPPPage()
        {
            Setup.driver.Navigate().Back();
            CA_NoPPPage.CurrentlyReviewingSubmission.AssertElementIsVisible();
        }
        
        [Then(@"user verifies No PP page")]
        public void ThenUserVerifiesNoPPPage()
        {
            CA_NoPPPage.CurrentlyReviewingSubmission.AssertElementTextEquals("We're currently reviewing your submission.");
            CA_NoPPPage.ContactNearFuture.AssertElementTextEquals("We'll be in contact in the near future, if we haven't been already.");
            CA_NoPPPage.Questions.AssertElementTextEquals("Questions?");
            CA_NoPPPage.OurCustomerService.AssertElementTextEquals("Our customer service team is here to help.");
            CA_NoPPPage.QuestionsCustServiceImage_Phone.AssertElementIsVisible();
            CA_NoPPPage.QuestionsCustServicePhoneNumber.AssertElementTextEquals("phone1-844-472-0967");
            CA_NoPPPage.QuestionsCustServiceImage_Email.AssertElementIsVisible();
            CA_NoPPPage.QuestionsCustServiceEmailAddress.AssertElementTextEquals("emailcustomerservice@biberk.com");
        }
    }
}