using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.Contact
{
    public sealed class YourContactFormHasBeenSubmittedPage
    {
        public static Element ContactFormTitle => new Element(By.XPath("//h2[@data-qa='thank-you-header']"));
        public static Element OurTeamWillReviewCopy => new Element(By.XPath("//p[@data-qa='thank-you-subheader']"));
        public static Element ContactHeader => new Element(By.XPath("//h5[@data-qa='contact-header']"));
        public static Element ContactPhoneIcon => new Element(By.XPath("//i[@data-qa='contact-phone-icon']"));
        public static Element ContactPhoneNumber => new Element(By.XPath("//a[@data-qa='contact-phone']"));
        public static Element ContactHours => new Element(By.XPath("//span[@data-qa='contact-hours']"));
        public static Element ContactMailIcon => new Element(By.XPath("//i[@data-qa='contact-mail-icon']"));
        public static Element ContactMailCopy => new Element(By.XPath("//a[@data-qa='contact-email']"));
    }
}