using BiBerkLOB.Pages.PL;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;


namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_ThankYou
    {
        private readonly PLSummaryObject _plSummaryObject;

        public PL_Gen_ThankYou(PLSummaryObject plSummaryObject)
        {
            _plSummaryObject = plSummaryObject;
        }

        [Then(@"user verifies the PL how would you rate our service\? page appearance")]
        public void ThenUserVerifiesThePLHowWouldYouRateOurServicePageAppearance()
        {
            UserActions.SwitchToFrame("widget-container");
            PL_ThankYouPage.RateOurServiceTitle.AssertElementIsVisible();
            PL_ThankYouPage.RateOurServiceX.AssertElementIsVisible();
            PL_ThankYouPage.ClickNumStars.AssertElementIsVisible();
            PL_ThankYouPage.UnselectedStarOne.AssertElementIsVisible();
            PL_ThankYouPage.UnselectedStarTwo.AssertElementIsVisible();
            PL_ThankYouPage.UnselectedStarThree.AssertElementIsVisible();
            PL_ThankYouPage.UnselectedStarFour.AssertElementIsVisible();
            PL_ThankYouPage.UnselectedStarFive.AssertElementIsVisible();
            PL_ThankYouPage.UnselectedStarFive.Click();
            PL_ThankYouPage.SelectedStarOne.AssertElementIsVisible();
            PL_ThankYouPage.SelectedStarTwo.AssertElementIsVisible();
            PL_ThankYouPage.SelectedStarThree.AssertElementIsVisible();
            PL_ThankYouPage.SelectedStarFour.AssertElementIsVisible();
            PL_ThankYouPage.SelectedStarFive.AssertElementIsVisible();
            PL_ThankYouPage.EmailAddressTxtbox.AssertElementIsVisible();
            PL_ThankYouPage.FeedbackTitle.AssertElementIsVisible();
            PL_ThankYouPage.FeedbackParagraph.AssertElementIsVisible();
            PL_ThankYouPage.FeedbackTxtbox.AssertElementIsVisible();
            PL_ThankYouPage.FeedbackRemainingChar.AssertElementIsVisible();
            PL_ThankYouPage.SubmitCTA.AssertElementIsVisible();
        }

        [Then(@"user verifies the PL thank you page appearance")]
        public void ThenUserVerifiesThePLThankYouPageAppearance()
        {
            CloseRateOurServiceModal();

            VerifyThankYouBaseElements();
        }

        [Then(@"user verifies that the following LOBs are recommended: (.*)")]
        public void ThenUserVerifiesThatTheFollowingLOBsAreRecommended(string lobs)
        {
            //Create a list of the passed in LOBs to validate against
            //Note: the lobs string should be a comma separated "list" of LOBs
            var expectedLobs = CreateExpectedLOBList(lobs);

            //Define the elements that should be visible by LOB:
            Element[] CAElements =
            { PL_ThankYouPage.CAAccordion, PL_ThankYouPage.CAWhatIsItCopy, PL_ThankYouPage.CAWhyGetItCopy, PL_ThankYouPage.CAExampleCopy, PL_ThankYouPage.CAPCTA };
            Element[] BOPElements =
            { PL_ThankYouPage.BOPAccordion,PL_ThankYouPage.BOPWhatIsItCopy, PL_ThankYouPage.BOPWhyGetItCopy, PL_ThankYouPage.BOPExampleCopy, PL_ThankYouPage.BOPCTA };
            Element[] GLElements =
            { PL_ThankYouPage.GLAccordion, PL_ThankYouPage.GLWhatIsItCopy, PL_ThankYouPage.GLWhyGetItCopy, PL_ThankYouPage.GLExampleCopy, PL_ThankYouPage.GLCTA };
            Element[] WCElements =
            { PL_ThankYouPage.WCAccordion, PL_ThankYouPage.WCWhatIsItCopy, PL_ThankYouPage.WCWhyGetItCopy, PL_ThankYouPage.WCExampleCopy, PL_ThankYouPage.WCCTA };

            //Arrange the arrays in another array in a specific order to be validated against
            Element[][] LOBArrays = { CAElements, BOPElements, GLElements, WCElements };

            //Validate the expected LOBS
            ValidateExpectedLOBS(expectedLobs, LOBArrays);
        }

        public List<string> CreateExpectedLOBList(string expectedLOBs)
        {
            List<string> expectedLOBArray = new List<string>();

            Regex rgx = new Regex("[^,]+");
            var result = rgx.Match(expectedLOBs);

            while (result.Success)
            {
                expectedLOBArray.Add(result.Value);
                result = result.NextMatch();
            }

            return expectedLOBArray;
        }

        public void ValidateExpectedLOBS(List<string> expectedLOBs, Element[][] LOBArrays)
        {
            foreach (string lob in expectedLOBs)
            {
                switch (lob)
                {
                    case "CA":
                        VerifyThankYouLOBElements(LOBArrays[0]);
                        break;
                    case "BOP":
                        VerifyThankYouLOBElements(LOBArrays[1]);
                        break;
                    case "GL":
                        VerifyThankYouLOBElements(LOBArrays[2]);
                        break;
                    case "WC":
                        VerifyThankYouLOBElements(LOBArrays[3]);
                        break;
                }
            }
        }

        public void CloseRateOurServiceModal()
        {
            if (PL_ThankYouPage.RateOurServiceX.AssertElementIsVisible())
            {
                PL_ThankYouPage.RateOurServiceX.Click();
                UserActions.SwitchToDefaultContent();
            }
            else 
            {
                UserActions.SwitchToFrame("widget-container");
                PL_ThankYouPage.RateOurServiceX.Click(30);
                UserActions.SwitchToDefaultContent();
            }
        }
        
        public void VerifyThankYouBaseElements()
        {
            PL_ThankYouPage.ThankYouPageTitle.AssertElementIsVisible();
            PL_ThankYouPage.ThankYouCopy.AssertElementIsVisible();
            PL_ThankYouPage.PLPolicyNum.AssertElementIsVisible();
            PL_ThankYouPage.CompanyName.AssertElementIsVisible();
            PL_ThankYouPage.PolicyStart.AssertElementIsVisible();
            PL_ThankYouPage.PaymentTermsHeader.AssertElementIsVisible();
            PL_ThankYouPage.PaymentAmount.AssertElementIsVisible();
            PL_ThankYouPage.PaymentFrequency.AssertElementIsVisible();
            PL_ThankYouPage.ConfirmationNumber.AssertElementIsVisible();
            if (_plSummaryObject.YearlyOrMonthly == "Monthly") PL_ThankYouPage.NextPaymentDue.AssertElementIsVisible();
            PL_ThankYouPage.CertificatofInsuranceCTA.AssertElementIsVisible();
            PL_ThankYouPage.PolicyEmailed.AssertElementIsVisible();
            PL_ThankYouPage.BusinessFullyCoveredHeader.AssertElementIsVisible();
        }

        public void VerifyThankYouLOBElements(Element[] elements)
        {
            var isRecommended = elements[0].AssertElementIsVisible(1, true);
            var isActive = elements[1].AssertElementIsVisible(1, true);
            var accordianElement = elements[0];

            if (isRecommended)
            {
                if (!isActive) accordianElement.Click();

                foreach (var element in elements) element.AssertElementIsPresent();
            }
        }
    }
}
