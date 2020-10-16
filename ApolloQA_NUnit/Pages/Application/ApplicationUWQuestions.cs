using ApolloQA.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloQA.Pages.Application
{
    class ApplicationUWQuestions
    {
        private IWebDriver driver;
        private Functions functions;

        public ApplicationUWQuestions(IWebDriver driver)
        {
            this.driver = driver;
            functions = new Functions(driver);
        }


        public bool QuestionIsDisplayed(string questionType, string questionText)
        {
            try 
            {
                IWebElement theQuestionItself = functions.FindElementWait(10, By.XPath("//" + questionType + "[.//div[@class='question-text' and normalize-space(text()) = '" + questionText + "']]"));
                return (theQuestionItself.Displayed) ? true : false;
            } catch 
            { 
                return false; 
            }           
        }

        public bool AnswerQuestion(string questionType, string questionText, string selection)
        {
            try
            {
                Console.WriteLine("//" + questionType + "[.//div[@class='question-text' and normalize-space(text()) = '" + questionText + "']]//mat-radio-button[.//input[@value='" + selection + "']]");

                IWebElement desiredAnswer = functions.FindElementWait(10, By.XPath("//" + questionType + "[.//div[@class='question-text' and normalize-space(text()) = '" + questionText + "']]//mat-radio-button[.//input[@value='" + selection + "']]"));
                desiredAnswer.Click();
                return true;
            } catch
            {
                return false;
            }
        }


        public bool AnswerIsSelected(string questionType, string questionText, string selection)
        {
            try
            {
                IWebElement selectedAnswer = functions.FindElementWait(10, By.XPath("//" + questionType + "//mat-radio-button[contains(@class, 'checked')]//input"));
                if (selectedAnswer.GetAttribute("value").Contains(selection))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
