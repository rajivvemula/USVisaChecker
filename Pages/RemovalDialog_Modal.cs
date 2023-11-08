using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    public class RemovalDialog_Modal
    {
        public static Element Header(string subject) => new Element(By.XPath($"//h2[@data-qa='You are removing {subject}-header']"));
        public static Element AreYouSureQST => new Element(By.XPath("//div[@data-qa='email-link-later-text']/div/div"));
        public static Element YesButton => new Element(By.XPath("//button[@data-qa='modal-secondary-btn']"));
        public static Element NoButton => new Element(By.XPath("//button[@data-qa='modal-primary-btn']"));

        public static List<Element> ListOfElements2(string subject)
        {
            var list = new List<Element>();
            list.Add(Header(subject));
            return list;

        }

        public static List<Element> ListOfElements(string subject) =>  new List<Element>
        {
            Header(subject),
            AreYouSureQST,
            YesButton,
            NoButton
        };
    }
}
