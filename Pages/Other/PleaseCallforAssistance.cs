using BiBerkLOB.Source.Helpers.RetryPolicy;
using DocumentFormat.OpenXml.Spreadsheet;
using Faker;
using HitachiQA.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Database;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.Other
{
    [StaticPageName("Please Call for Assistance")]
    public class  PleaseCallforAssistance  : IStaticPage 
    {
        //Mapping for Please Call for Assistance page for both COI and Autopay

        //public static Element COITitle => new Element(By.XPath("//h1[@data-qa='{PleaseCall}']"));
       // public static Element AutoPayTitle => new Element(By.XPath("//h1[@data-qa='autopay']"));

        //We're Sorry, Please Call for Assistance
        public static Element PleaseCallForAssistanceHeader => new Element(By.XPath("//h2[@data-qa='unauthorized-header']"));
        public static Element AutoPayHeader => new Element(By.XPath("//h2[@data-qa='unauthorized-header']"));
        public static Element COIAssistanceSubtext => new Element(By.XPath("//p[@data-qa='unauthorized-subheader']"));
       //Based on the policy number and phone number entered
        public static Element AutoPaySubtext => new Element(By.XPath("//p[@data-qa='unauthorized-subheader']"));
        //Questions?
        public static Element QuestionsHeader => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        //For Autopay
        public static Element QuestionsSubheader => new Element(By.XPath("//p[@data-qa='contact-subheader']']"));
        public static Element QuestionsPhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));
        public static Element QuestionsPhoneNumberLink => new Element(By.XPath("//a[@data-qa='contact-phone']"));
        public static Element QuestionsContactHours => new Element(By.XPath("//span[@data-qa='contact-hours']"));
        public static Element QuestionsIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element QuestionsEmail => new Element(By.XPath("//a[@data-qa='contact-email']"));

        public static Element GetTitle(string Title)
        {
            return new Element(By.XPath($"//h1[@data-qa='{Title}']"));
        }
    }
}