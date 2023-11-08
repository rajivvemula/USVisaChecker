using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.CommAuto
{
    [Binding]
    public sealed class CA_Error500 : Reusable_PurchasePath
    {
       //We're Sorry, a System Error has Occurred
       public static Element SystemErrorOccurred => new Element(By.XPath("//h2[@data-qa='error-page-title']"));

       //If you need assistance contact us at
       public static Element ForAssistanceContact => new Element(By.XPath("//p[@data-qa='if-you-need-assistance-subHeader']"));

       //1-833-224-5431
       public static Element CAPhoneNumber => new Element(By.XPath("//a[@data-qa='1-833-224-5431-number']"));

       //experts@biberk.com
       public static Element CAEmailAddress => new Element(By.XPath("//a[@data-qa='experts@biberk.com-email']"));




    }
}
