using System;
using System.Collections.Generic;
using System.Threading;
using HitachiQA.Driver;
using TechTalk.SpecFlow;

namespace ApolloQAAutomation.StepDefinition
{
    [Binding]
    public sealed class USVisaChecker
    {
        [Given(@"Check US slots for following (.*) and (.*)")]
        public void GivenCheckUSSlotsForFollowingVydyamdwarakamaiGmail_ComAndCktaYV(string username, string pwd)
        {

            UserActions.Navigate("https://ais.usvisa-info.com/en-ca/niv/users/sign_in");

            Element signInHeader = new("//h2[text()='Sign In']");
            Element email = new("//input[@name='user[email]']");
            Element password = new("//input[@name='user[password]']");
            Element IAgreeBtn = new("//input[@name='policy_confirmed']/ancestor::label");
            Element submitBtn = new("//input[@name='commit']");
            Element continueBtn = new("//a[text()='Continue']");
            Element rescheduleBtn = new("//a[.//span[contains(@class,'fa-calendar-minus')]]");
            Element rescheduleAppointment = new("//a[text()='Reschedule Appointment']");


            email.SetText(username);
            password.SetText(pwd);
            IAgreeBtn.Click();
            submitBtn.Click();

            // After Login
            continueBtn.Click();
            rescheduleBtn.Click(1);
            rescheduleAppointment.Click(1);

            // Selecting Cities and checking the dates
            Element ConsularSelectionDD = new("//select[@name='appointments[consulate_appointment][facility_id]']");

            //Calgary
            List<string> cities = new List<string>()
            {
                "Calgary",
                "Halifax",
                "Montreal",
                "Ottawa",
                "Quebec City",
                "Toronto",
                "Vancouver"
            };

            foreach (string city in cities)
            {
                ConsularSelectionDD.SelectDropdownOptionByText(city);
                Thread.Sleep(2000);
                VerifyDates(city);
            }
        }

        private static void VerifyDates(string city)
        {
            Element noDates = new("//div[@id='consulate_date_time_not_available']");
            Element dateofAppointment = new("//input[@id='appointments_consulate_appointment_date']");
            bool flag;
            try
            {
                flag = noDates.IsElementVisibleInViewport();
            }
            catch (Exception)
            {
                flag = false;
            }

            if (flag)
            {
                Console.WriteLine("No dates available for city - " + city);
            }
            else
            {
                dateofAppointment.AssertElementIsPresent(2, true);
                dateofAppointment.Click();

                //Traverse through the date
                Element firstGroup = new("(//div[@class='ui-datepicker-group ui-datepicker-group-first']//a[@href='#'])[1]");
                Element firstGroupMonthYear = new("(//div[@class='ui-datepicker-group ui-datepicker-group-first']//a[@href='#']/..)[1]");
                Element secondGroup = new("(//div[@class='ui-datepicker-group ui-datepicker-group-last']//a[@href='#'])[1]");
                Element secondGroupMonthYear = new("(//div[@class='ui-datepicker-group ui-datepicker-group-last']//a[@href='#']/..)[1]");
                Element nextDate = new("//a[@data-handler='next']");

                try
                {
                    while (firstGroup.GetCountOfElements() == 0 && secondGroup.GetCountOfElements() == 0)
                    {
                        nextDate.Click();
                    }

                    if (firstGroup.GetCountOfElements() > 0)
                    {
                        var day = firstGroup.GetElementText();
                        var month = firstGroupMonthYear.GetAttribute("data-month");
                        var year = firstGroupMonthYear.GetAttribute("data-year");

                        Console.WriteLine("\n\nCongratulation you got the slot\n");
                        Console.WriteLine("Here are the dates and city:\n");
                        Console.WriteLine($"City: {city} Date in DD/MM/YYYY - {day}/{month}/{year}.");
                        Thread.Sleep(1000);
                        firstGroup.Click();
                    }
                    else if (secondGroup.GetCountOfElements() > 0)
                    {
                        var day = secondGroup.GetElementText();
                        var month = secondGroupMonthYear.GetAttribute("data-month");
                        var year = secondGroupMonthYear.GetAttribute("data-year");

                        Console.WriteLine("\n\nCongratulation you got the slot\n");
                        Console.WriteLine("Here are the dates and city:\n");
                        Console.WriteLine($"City: {city} Date in DD/MM/YYYY(Month starts with 0) - {day}/{month}/{year}.");
                        Thread.Sleep(1000);
                        secondGroup.Click();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Exception");
                }
            }
        }


    }
}
