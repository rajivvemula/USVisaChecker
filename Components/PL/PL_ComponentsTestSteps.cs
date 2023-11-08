using BiBerkLOB.Features.CaseyTests;
using BiBerkLOB.Source.Helpers;
using HitachiQA.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using HitachiQA;
using TechTalk.SpecFlow;
using NUnitAssert = NUnit.Framework.Assert;
using HitachiAssert = HitachiQA.Assert;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.Components.PL
{
    [Binding]
    public class PL_ComponentsTestSteps
    {
        [When(@"user clicks (.*) pl-button")]
        public void WhenUserClicksPl_Button(string displayText)
        {
            PL_Button plButton = new PL_Button(displayText);
            plButton.Click();
        }

        [Then(@"page header is (.*)")]
        public void ThenPageHeaderIs(string headerText)
        {
            PL_HeaderGroup headers = new PL_HeaderGroup();
            NUnitAssert.That(() => headers.GetHeaderText(), Is.EqualTo(headerText).After(15).Seconds.PollEvery(250).MilliSeconds);
        }

        [When(@"user waits for loading to complete")]
        public void WhenUserWaitsForLoadingToComplete()
        {

            AutomationHelper.LegacyWaitForLoading(120);
        }


        [Then(@"the following fields display error text")]
        public void ThenTheFollowingFieldsDisplayErrorText(Table table)
        {
            foreach (var row in table.Rows)
            {
                string displayText = row["Display Text"];
                string fieldType = row["Field Type"];
                string errorText = row["Error Text"];

                string displayedValue = "";

                switch (fieldType.ToLower())
                {
                    case "pl-input":
                        PL_InputField plInput = new PL_InputField(displayText);
                        displayedValue = plInput.GetErrorText();
                        break;
                    case "pl-singleselect":
                        PL_SingleSelect plSelect = new PL_SingleSelect(displayText);
                        displayedValue = plSelect.GetErrorText();
                        break;
                    default:
                        NUnitAssert.Fail("Unexpected Fieldtype");
                        break;
                }

                if (errorText.ToLower() == "any")
                {
                    HitachiAssert.IsTrue(displayedValue.Length > 0);
                }
                else
                {
                    HitachiAssert.AreEqual(errorText, displayedValue);
                }

            }
        }

        [When(@"user enters default date for datepicker (.*)")]
        public void WhenUserEntersDefaultDateForDatepicker(string questionText)
        {
            PL_DatePicker datePicker = new PL_DatePicker(questionText);
            datePicker.EnterDefaultDate();
        }

        [When(@"user enters complex input (.*)")]
        public void WhenUserEntersComplexInput(string questionText, Table table)
        {
            PL_ComplexInput complex = new PL_ComplexInput(questionText);

            var row = table.Rows[0];

            foreach (var header in table.Header)
            {
                complex.EnterInput(header, row[header]);
            }
        }

        //[When(@"user enters number (.*) complex input (.*)")]
        //public void WhenUserEntersComplexInput(int index, string questionText, Table table)
        //{
        //    PL_ComplexInputMultiple complex = new PL_ComplexInputMultiple(questionText, index);

        //    foreach (var row in table.Rows)
        //    {
        //        string placeholderText = row["Placeholder Text"];
        //        string value = row["Value"];

        //        complex.EnterInput(placeholderText, value);
        //    }
        //}


        //for complex inputs duplicates (e.g. Attorney Name)
        [When(@"user enters complex inputs (.*)")]
        public void WhenUserEntersComplexInputs(string questionText, Table table)
        {

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                PL_ComplexInputMultiple nextComplex = new PL_ComplexInputMultiple(questionText, i + 1);

                foreach (var header in table.Header)
                {
                    nextComplex.EnterInput(header, row[header]);
                }
            }

        }


        [When(@"user clicks purchase for (.*) plan")]
        public void WhenUserClicksPurchaseForPlan(string planName)
        {
            PL_QuotePlan thePlan = new PL_QuotePlan(planName);
            thePlan.purchaseButton.Click();
        }

        [When(@"user enters payment information")]
        public void WhenUserEntersPaymentInformation(Table table)
        {
            PL_Payment paymentComponent = new PL_Payment("Payment Information");

            foreach (var row in table.Rows)
            {
                string placeholderText = row["Placeholder Text"];
                string value = row["Value"];

                paymentComponent.EnterInput(placeholderText, value);

            }
        }


        [When(@"user checks checkbox (.*)")]
        public void WhenUserChecksCheckbox(string checkboxBinding)
        {
            string checkboxXPath = $"//md-checkbox[@checked.bind='{checkboxBinding}']";
            IWebElement checkbox = UserActions.FindElementWaitUntilClickable(By.XPath(checkboxXPath));
            checkbox.Click();
        }

        [When(@"user clicks button with class (.*)")]
        public void WhenUserClicksButtonWithClass(string classContains)
        {
            string buttonXPath = $"//button[contains(@class, '{classContains}')]";
            IWebElement button = UserActions.FindElementWaitUntilClickable(By.XPath(buttonXPath));
            button.Click();
        }

        [When(@"user prints out PLCTA quote number")]
        public void WhenUserPrintsOutPLQuoteNumber()
        {
            string spanXPath = $"//h6[contains(normalize-space(), 'Professional Liability (E&O) Quote ID')]";
            IWebElement theSpan = UserActions.FindElementWaitUntilPresent(By.XPath(spanXPath), 20);
            string spanText = theSpan.Text.Trim();
            string[] words = spanText.Split(':');
            string policyNumber = words[1].Trim();
            Log.Info(policyNumber);
        }

        [When(@"user prints out PLCTA policy number")]
        public void WhenUserPrintsOutPLPolicyNumber()
        {
            string spanXPath = $"//span[contains(normalize-space(), 'Professional Liability (E&O) Policy')]";
            IWebElement theSpan = UserActions.FindElementWaitUntilPresent(By.XPath(spanXPath), 20);
            string spanText = theSpan.Text.Trim();
            string[] words = spanText.Split(':');
            string policyNumber = words[1].Trim();
            Log.Info(policyNumber);
        }


        /* WORKFLOWS */

        [Given(@"user completes PLCTA Introduction Page with below values")]
        public void GivenUserCompletesIntroductionPageWithBelowValues(Table table)
        {
            //this is more of a static workflow for a more static page
            // it contains some defaulted values

            var row = table.Rows[0];
            string businessType = row["Business Type"];
            string businessName = row["Business Name"];

            new MadLibsSteps().ThenURLContains("get-pl/introduction");
            WhenUserEntersTheValue("How is your business structured?", "pl-singleselect", businessType);
            WhenUserEntersTheValue("What's the name of your business?", "pl-input", businessName);
            WhenUserEntersTheValue("Do you do business under another name?", "pl-singleselect", "No");
            WhenUserClicksPl_Button("Let's Go!");
            WhenUserWaitsForLoadingToComplete();
            
        }

        [Given(@"user completes PLCTA Business Page with below values")]
        public void GivenUserCompletesPLBusinessPageWithBelowValues(Table table)
        {
            //this is a dynamic workflow for a super dynamic page (we just pass along the table of Questions/Answers we'd normally get)

            new MadLibsSteps().ThenURLContains("get-pl/business");
            new MadLibsSteps().WhenUserEntersFollowingValues(table);
            WhenUserClicksPl_Button("Let's Continue!");
            WhenUserWaitsForLoadingToComplete();
        }

        [Given(@"user completes PLCTA Coverage Page with below values")]
        public void GivenUserCompletesPLCoveragePageWithBelowValues(Table table)
        {
            new MadLibsSteps().ThenURLContains("get-pl/coverage");
            WhenUserEntersDefaultDateForDatepicker("When should your policy start?");
            new MadLibsSteps().WhenUserEntersFollowingValues(table);
            WhenUserClicksPl_Button("Let's Continue!");
            WhenUserWaitsForLoadingToComplete();
        }

        [Given(@"user completes Customize Page with below values")]
        public void GivenUserCompletesCustomizePageWithBelowValues(Table table)
        {
            //this is a dynamic workflow for a super dynamic page (we just pass along the table of Questions/Answers we'd normally get)

            new MadLibsSteps().ThenURLContains("get-pl/customize");
            new MadLibsSteps().WhenUserEntersFollowingValues(table);
            WhenUserClicksPl_Button("Let's Continue!");
            WhenUserWaitsForLoadingToComplete();
        }

        [Given(@"user completes PLCTA Contact Page with random values")]
        public void GivenUserCompletesPLContactPageWithRandomValues()
        {
            //this is an example of entering random inputs using Faker

            var firstName = Faker.Name.First();
            var lastName = Faker.Name.Last();
            var address = Faker.Address.StreetAddress();
            var email = $"{firstName}.{lastName}@gmail.com";
            var businessPhone = Faker.Phone.Number();

            new MadLibsSteps().ThenURLContains("get-pl/contact");

            PL_ComplexInput contactName = new PL_ComplexInput("Contact Name");
            contactName.EnterInput("First name", firstName);
            contactName.EnterInput("Last name", lastName);

            PL_ComplexInput businessAddress = new PL_ComplexInput("Business Address");
            businessAddress.EnterInput("Street address", address);

            WhenUserEntersTheValue("How can we connect with you?", "pl-input", email);
            WhenUserEntersTheValue("Business Phone", "pl-input", businessPhone);

            WhenUserClicksPl_Button("Let's Wrap This Up");
            WhenUserWaitsForLoadingToComplete();
        }

        [Given(@"user views quote and selects (.*) plan")]
        public void GivenUserPurchasesPlan(string planName)
        {           
            //summary
            new MadLibsSteps().ThenURLContains("get-pl/summary");
            WhenUserClicksPl_Button("View Quote");
            WhenUserWaitsForLoadingToComplete();

            //quote
            new MadLibsSteps().ThenURLContains("get-pl/quote");
            WhenUserClicksPurchaseForPlan(planName);
            WhenUserWaitsForLoadingToComplete();
            
        }

        [Given(@"user purchases policy with default payment info")]
        public void GivenUserPurchasesPolicyWithDefaultPaymentInfo()
        {
            //payment
            new MadLibsSteps().ThenURLContains("get-pl/payment");
            PL_Payment paymentComponent = new PL_Payment("Payment Information");
            paymentComponent.EnterInput("Your name", "Card Holder");
            paymentComponent.EnterInput("Credit card number", "4111111111111111");
            paymentComponent.EnterInput("MM/YY", "0524");
            WhenUserChecksCheckbox("TermsAgreed");
            WhenUserClicksButtonWithClass("payment-btn");
            WhenUserWaitsForLoadingToComplete();
        }





        /* Helpers */

        [When(@"user enters the value: (.*), (.*), (.*)")]
        public void WhenUserEntersTheValue(string displayText, string fieldType, string value)
        {
            switch (fieldType.ToLower())
            {
                case "autocomplete":
                    AutoCompleteInput autoInput = new AutoCompleteInput(displayText);
                    autoInput.SetValue(value);
                    break;
                case "input":
                    InputField inputField = new InputField(displayText);
                    inputField.SetValue(value);
                    break;
                case "pl-input":
                    PL_InputField plInput = new PL_InputField(displayText);
                    plInput.EnterInput(value);
                    break;
                case "pl-singleselect":
                    PL_SingleSelect plSelect = new PL_SingleSelect(displayText);
                    plSelect.SelectOption(value);
                    break;
                default:
                    Log.Warn("Unexpected FieldType.");
                    break;

            }
        }



    }
}
