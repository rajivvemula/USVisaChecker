using System;
using BiBerkLOB.Pages.WC;
using HitachiQA.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class WC_Gen_ThankYou
    {
        private readonly WCYourQuoteObject _yourQuoteObject;

        public WC_Gen_ThankYou(WCYourQuoteObject yourQuoteObject)
        {
            _yourQuoteObject = yourQuoteObject;
        }

        [Then(@"user verifies the WC how would you rate our service modal")]
        public void ThenUserVerifiesTheWCHowWouldYouRateOurServiceModal()
        {
            UserActions.SwitchToFrame("widget-container");
            WC_ThankYouPage.RateOurServiceTitle.AssertElementIsVisible();
            WC_ThankYouPage.RateOurServiceX.AssertElementIsVisible();
        }

        [Then(@"user verifies the WC thank you page appearance")]
        public void ThenUserVerifiesTheWCThankYouPageAppearance()
        {
            CloseRateOurServiceModal();

            VerifyThankYouBaseElements();

            if (_yourQuoteObject.PaymentOption.ToLower() != "one pay plan")
            {
                VerifyThankYouMonthlyElements();
            }
        }

        [Then(@"user verifies that these LOBs are recommended: (.*)")]
        public void ThenUserVerifiesThatTheseLOBsAreRecommended(string lobs)
        {
            //Create a list of the passed in LOBs to validate against
            //Note: the lobs string should be a comma separated "list" of CAs
            var expectedLobs = CreateExpectedLOBList(lobs);

            //Define the elements that should be visible by LOB:
            Element[] CAElements =
            { WC_ThankYouPage.CAHeader, WC_ThankYouPage.CAWhatIsIt, WC_ThankYouPage.CAWhyGetIt, WC_ThankYouPage.CAExample, WC_ThankYouPage.GetCACTA };
            Element[] BOPElements =
            { WC_ThankYouPage.BOPHeader,WC_ThankYouPage.BOPWhatIsIt, WC_ThankYouPage.BOPWhyGetIt, WC_ThankYouPage.BOPExample, WC_ThankYouPage.GetBOPCTA };
            Element[] GLElements =
            { WC_ThankYouPage.GLHeader, WC_ThankYouPage.GLWhatIsIt, WC_ThankYouPage.GLWhyGetIt, WC_ThankYouPage.GLExample, WC_ThankYouPage.GetGLCTA };
            Element[] PLElements =
            { WC_ThankYouPage.PLHeader, WC_ThankYouPage.PLWhatIsIt, WC_ThankYouPage.PLWhyGetIt, WC_ThankYouPage.PLExample, WC_ThankYouPage.GetPLCTA };

            //Arrange the arrays in another array in a specific order to be validated against
            Element[][] LOBArrays = { CAElements, BOPElements, GLElements, PLElements };

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
                try
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
                        case "PL":
                            VerifyThankYouLOBElements(LOBArrays[3]);
                            break;
                    }
                }
                catch (Exception e)
                {
                    throw new AggregateException($"The {lob.ToUpper()} lob should be recommended but is missing", e);
                }
            }
        }

        public void CloseRateOurServiceModal()
        {

            if (WC_ThankYouPage.RateOurServiceX.AssertElementIsVisible())
            {
                WC_ThankYouPage.RateOurServiceX.Click();
                UserActions.SwitchToDefaultContent();
            }
            else
            {
                UserActions.SwitchToFrame("widget-container");
                WC_ThankYouPage.RateOurServiceX.Click(30);
                UserActions.SwitchToDefaultContent();
            }
        }

        public void VerifyThankYouBaseElements()
        {
            WC_ThankYouPage.ThankYou.AssertElementIsVisible();
            WC_ThankYouPage.ThankYouBHText.AssertElementIsVisible();
            WC_ThankYouPage.GetCOICTA.AssertElementIsVisible();
            WC_ThankYouPage.CopyOfYourPolicyText.AssertElementIsVisible();
            WC_ThankYouPage.ProductLabel.AssertElementIsVisible();
            WC_ThankYouPage.ProductValue.AssertElementIsVisible();
            WC_ThankYouPage.PolicyNumberLabel.AssertElementIsVisible();
            WC_ThankYouPage.PolicyNumberValue.AssertElementIsVisible();
            WC_ThankYouPage.ConfirmationNumberLabel.AssertElementIsVisible();
            WC_ThankYouPage.PolicyStartDateLabel.AssertElementIsVisible();
            WC_ThankYouPage.PolicyStartDateValue.AssertElementIsVisible();
            WC_ThankYouPage.CoverageForOneYearTxt.AssertElementIsVisible();
            WC_ThankYouPage.DownPaymentLabel.AssertElementIsVisible();
            WC_ThankYouPage.DownPaymentValue.AssertElementIsVisible();
        }

        public void VerifyThankYouMonthlyElements()
        {
            WC_ThankYouPage.PaymentPerMonthValue.AssertElementIsVisible();
            WC_ThankYouPage.NextPaymentDueLabel.AssertElementIsVisible();
            WC_ThankYouPage.NextPaymentDueValue.AssertElementIsVisible();
            WC_ThankYouPage.MakeSureYourBusiness.AssertElementIsVisible();
        }

        public void VerifyThankYouLOBElements(Element[] elements)
        {
            var isActive = elements[1].AssertElementIsVisible(1, true);
            var accordianElement = elements[0];

            if (!isActive) accordianElement.Click();
            foreach (var element in elements) element.AssertElementIsVisible();
        }
    }
}