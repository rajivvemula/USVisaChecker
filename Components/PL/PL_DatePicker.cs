using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BiBerkLOB.Source.Driver;
using Microsoft.Azure.Cosmos;

namespace BiBerkLOB.Components.PL
{
    public class PL_DatePicker : IDatePicker
    {
        private string _fieldsetXPath;
        private string _inputXPath;

        IWebElement TheInput => UserActions.FindElementWaitUntilClickable(By.XPath(_inputXPath));

        public PL_DatePicker(string questionText)
        {
            //gets us the fieldset, matching on question label text
            _fieldsetXPath = $"//fieldset[.//label[translate(normalize-space(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')=\"{questionText.ToLower()}\"]]";

            //gets us the specific elements we're interested in manipulating (inside the fieldset)
            _inputXPath = $"{_fieldsetXPath}//input";

            // if the questiontext is a retroactive date, select the calender icon. waiting on bug (https://dev.azure.com/biberk/biBERK/_workitems/edit/83112)
            if (questionText == "What is the retroactive date?") _inputXPath = $"{_fieldsetXPath}//i[@click.trigger='openPicker()']";
        }


        public void EnterDefaultDate()
        {
            //click the datepicker field
            TheInput.Click();

            //opens a new modal, let's just click OK for now (with defaulted date)
            string okButtonXPath = "//button[contains(@class, 'datepicker-done')]";
            IWebElement okButton = UserActions.FindElementWaitUntilClickable(By.XPath(okButtonXPath));
            okButton.Click();
        }

        public void SelectDate(string dateString)
        {
            var targetDate = DateTime.Parse(dateString);
            SelectDate(targetDate);
        }

        public void SelectDate(DateTime date)
        {
            TheInput.Click();

            var YearDD = UserActions.FindElementWaitUntilClickable(By.XPath("//div[@class='modal datepicker-modal open']//div[@class='select-wrapper select-year']"));
            YearDD.Click();

            var targetYear = UserActions.FindElementWaitUntilPresent(By.XPath($"//ul[contains(@style, 'opacity: 1')]//li[contains(@id, 'select-options')]//span[text()='{date.ToString("yyyy")}']"));
            UserActions.HoverOverElement(targetYear);
            targetYear.Click();

            var MonthDD = UserActions.FindElementWaitUntilClickable(By.XPath("//div[@class='modal datepicker-modal open']//div[@class='select-wrapper select-month']"));
            MonthDD.Click();

            var targetMonth = UserActions.FindElementWaitUntilPresent(By.XPath($"//ul[contains(@style, 'opacity: 1')]//span[text()='{date.ToString("MMMM")}']"));
            UserActions.HoverOverElement(targetMonth);
            targetMonth.Click();

            var targetDay = UserActions.FindElementWaitUntilClickable(By.XPath($"//div[@class='modal datepicker-modal open']//table//button[@data-day='{date.Day.ToString()}']"));
            targetDay.Click();
        }

        public void AssertIsVisible(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS)
        {
            UserActions.FindElementWaitUntilVisible(By.XPath(_inputXPath), waitSeconds);
        }

        public string GetDateString(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS) 
        {
            var datePickerInput = UserActions.FindElementWaitUntilVisible(By.XPath(_inputXPath), waitSeconds);

            return datePickerInput.GetAttribute("value");
        }

        public DateTime GetDateValue(int waitSeconds = DatePickerConstants.DEFAULT_WAIT_SECONDS)
        {
            return DateTime.Parse(GetDateString());
        }
    }
}