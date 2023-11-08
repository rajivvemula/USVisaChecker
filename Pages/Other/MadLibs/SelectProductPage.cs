using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBerkLOB.Pages
{
    class SelectProductPage : Reusable_PurchasePath
    {
        // SELECT A PRODUCT
        public static Element TitleSelectProduct => new Element(By.XPath("//h3[contains(text(),'SELECT')]"));

        // Workers' Compensation
        public static Element WCCTA => new Element(By.XPath("//a[@name='WCBtn']"));
        //(Workers’ Compensation) -  protection for your team
        public static Element WCSubtitle => new Element(By.XPath(""));

        //Workers' Compensation Rewrite
        public static Element WCRewriteCTA => new Element(By.XPath("//a[@name='WCTestBtn']"));
        //(Workers’ Compensation Rewrite) This is the Angular codebase…protection for your team
        public static Element WCRewriteSubtitle => new Element(By.XPath(""));

        // General Liability + Property
        public static Element BOPCTA => new Element(By.XPath("//a[@name='BPBtn']"));
        //(General Liability + Property) – also known as business owner’s policy
        public static Element BOPSubtitle => new Element(By.XPath(""));

        // General Liability
        public static Element GLCTA => new Element(By.XPath("//a[@name='GLBtn']"));
        //(General Liability) protection from third party property damage and injury claims
        public static Element GLSubtitle => new Element(By.XPath(""));

        // Commercial Auto
        public static Element CACTA => new Element(By.XPath("//a[@name='CABtn']"));
        //(Commercial Auto) -  protection for your business vehicles
        public static Element CASubtitle => new Element(By.XPath(""));

        //Professional Liability
        public static Element PLCTA => new Element(By.XPath("//a[@name='PLBtn']"));
        //(Professional Liability (E&O)) – protection from lawsuits related to the quality of your services
        public static Element PLSubtitle => new Element(By.XPath(""));

        //Errors & Omissions
        public static Element EOCTA => new Element(By.XPath("//a[@name='PLBtn']"));
        //(Errors & Omissions) protection from lawsuits related to the quality of your services
        public static Element EOSubtitle => new Element(By.XPath(""));

        // Back CTA
        public static Element BackCTA => new Element(By.XPath("//a[@name='lobBack']"));


    }
}
