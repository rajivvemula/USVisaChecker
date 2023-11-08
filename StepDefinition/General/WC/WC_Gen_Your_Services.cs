using System.Threading.Tasks;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.WC;
using TechTalk.SpecFlow;
using BiBerkLOB.Pages.Other.MadLibs;
using BiBerkLOB.Source.Helpers;
using BiBerkLOB.StepDefinition.General.GenAutomation;
using HitachiQA.Helpers;

namespace BiBerkLOB.StepDefinition.General.WC
{
    [Binding]
    public sealed class WC_Gen_Your_Services
    {
        private readonly MadLibsSummaryObject _madLibsSummaryObject = new MadLibsSummaryObject();

        public WC_Gen_Your_Services(MadLibsSummaryObject madLibsSummaryObject)
        {
            _madLibsSummaryObject = madLibsSummaryObject;
        }

        [Then(@"user verifies the appearance of the WC Your Services Page")]
        public void UserVerfiesWCYourServicesPage()
        {
            WC_YourServicesPage.YourServices.AssertElementIsVisible();
        }

        [Then(@"user fills out the WC Your Services page")]
        public async Task UserFillsWCYourServices(Table table)
        {
            foreach (TableRow rowy in table.Rows)
            {
                var theQuestion = rowy["Question"];
                var theAnswer = rowy["Answer"];
                await HandleWCYourServicesPage(theQuestion, theAnswer);
            }

            WC_YourServicesPage.ContinueButton.Click();
        }

        public async Task HandleWCYourServicesPage(string theQuestion, string theAnswer)
        {
            var quoteKeyword = _madLibsSummaryObject.Keyword;
            WCYourServicesObject localServicesObject = new WCYourServicesObject();
            if (theQuestion == "Federal Employer Identification Number (FEIN)")
            {
                WC_YourServicesPage.FEINTextBox.EnterResponse(theAnswer);
            }
            else if (theQuestion == "Social Security Number (SSN)")
            {
                WC_YourServicesPage.SSNTextBox.EnterResponse(theAnswer);
            }
            else if (theQuestion == "Are you engaged in any framing work or new roof construction?")
            {
                WC_YourServicesPage.FramingOrConstruction.AssertElementIsVisible();
                WC_YourServicesPage.FramingOrConstructionAnswer(theAnswer).Click();
            }
            else if (theQuestion == "What type of vehicle is primarily used for your business?")
            {
                WC_YourServicesPage.PrimaryBusinessVehicle.AssertElementIsVisible();
                WC_YourServicesPage.PrimaryBusinessVehicle.SetText(theAnswer);
            }
            else if (theQuestion == "Do you participate in a delivery service on behalf of Amazon.com, Inc.?")
            {
                WC_YourServicesPage.AmazonDeliveryServiceParticipationQST.AssertElementIsVisible();
                WC_YourServicesPage.AmazonDeliveryServiceParticipationAnswer(theAnswer.ToLower()).Click();
            }
            else if (theQuestion == "How many years ago did you start participating in the Amazon.com, Inc. delivery service?")
            {
                WC_YourServicesPage.AmazonDeliveryYears.AssertElementIsVisible();
                WC_YourServicesPage.AmazonDeliveryInput.SetText(theAnswer);
            }
            else if (theQuestion == "What percentage of work involves Bankruptcy, Corporate, Intellectual Property, or Real Estate law?")
            {
                WC_YourServicesPage.WhatPercentageInvolvesBankruptcy.AssertElementIsVisible();
                WC_YourServicesPage.WhatPercentageInvolvesBankruptcy.SetText(theAnswer);
            }
            else if (theQuestion == "Enter the value for experience modification factor:")
            {
                WC_YourServicesPage.EnterXModFactorInput.EnterResponse(theAnswer);
            }
            else if (theQuestion == "Do you review MVRs for all employees with a driving exposure?")
            {
                WC_YourServicesPage.ReviewMVRForEmployeesAnswer.SetText(theAnswer);
            }
            else
            {
                var questionDefinition = await LegacyQuestionApiHelper.GetWCQuestionDefinitionByText(theQuestion, quoteKeyword);
                questionDefinition ??= await LegacyQuestionApiHelper.GetFEQuestionDefinitionByText(theQuestion);

                localServicesObject.QuestionID = questionDefinition.DataQa.ToString();
                localServicesObject.QuestionText = theQuestion;
                localServicesObject.QuestionAnswer = theAnswer;
                localServicesObject.QuestionSentence = questionDefinition.SentencesFormat ?? string.Empty;

                //verify the appearance of the question
                WC_YourServicesPage.ServiceQST(localServicesObject.QuestionID).AssertElementIsVisible();

                //get the type of question (pulled from DB), so we know how to interact with the answer
                var theQuestionType = questionDefinition.QuestionType;
                switch (theQuestionType)
                {
                    case "R": //Yes/No button
                        WC_YourServicesPage.ServiceYNAnswer(localServicesObject.QuestionID, theAnswer)
                            .AssertElementIsVisible();
                        WC_YourServicesPage.ServiceYNAnswer(localServicesObject.QuestionID, theAnswer).Click();
                        break;
                    case "L": //single select weird button names/List options
                        WC_YourServicesPage.ServiceDropDown(localServicesObject.QuestionID).Click();
                        WC_YourServicesPage.ServiceDropDown(localServicesObject.QuestionID)
                            .SelectDropdownOptionByText(theAnswer);
                        break;
                    case "T": //Textbox
                        WC_YourServicesPage.ServiceTextboxAnswer(localServicesObject.QuestionID)
                            .AssertElementIsVisible();
                        WC_YourServicesPage.ServiceTextboxAnswer(localServicesObject.QuestionID).SetText(theAnswer);
                        break;
                    case "N": //Number  
                        WC_YourServicesPage.ServiceNumberTextboxAnswer(localServicesObject.QuestionID)
                            .AssertElementIsVisible();
                        WC_YourServicesPage.ServiceNumberTextboxAnswer(localServicesObject.QuestionID)
                            .SetText(theAnswer);
                        break;
                    case "P": //Percent 
                        WC_YourServicesPage.ServicePercentAnswer(localServicesObject.QuestionID)
                            .AssertElementIsVisible();
                        WC_YourServicesPage.ServicePercentAnswer(localServicesObject.QuestionID).SetText(theAnswer);
                        break;
                    default:
                        break;
                }
            }


        }
    }
}