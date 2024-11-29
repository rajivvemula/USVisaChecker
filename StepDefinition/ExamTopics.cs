using System;
using System.Linq;
using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace US_Visa_Checker.StepDefinition
{
    [Binding]
    public sealed class ExamTopics
    {
        [Given(@"Open Exam Topics and links to (.*) from questions (.*) to (.*)")]
        public void GivenOpenExamTopicsAndLinksTo(string examName, int minQuestionRange, int maxQuestionRange)
        {

            Element googleSearchArea = new("//textarea[@title='Search']");
            Element firstLink = new($"(//a[.//h3[contains(text(),'Exam {examName}')]])[1]");
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)Setup.driver;

            for (int i = minQuestionRange; i < maxQuestionRange; i++)
            {
                UserActions.Navigate("https://www.google.com/");
                googleSearchArea.SetText($"exam topics microsoft/{examName} questrion {i}" + Keys.Enter);

                try
                {
                    firstLink.Click();
                }
                catch (Exception)
                {
                    continue;
                }


                js.ExecuteScript("window.open();");
                Setup.driver.SwitchTo().Window(Setup.driver.WindowHandles.Last());
            }
        }

    }
}
