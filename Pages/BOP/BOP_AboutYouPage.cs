using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Source.Driver;
using BiBerkLOB.Source.Driver.Input;

using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.BOP
{
    public sealed class BOP_AboutYouPage
    {
        //header 
        public static Element AboutYouHeader => new Element(By.XPath("//h1[@data-qa='Contacts-label']"));
        public static Element AboutYouSubHeader => new Element(By.XPath("//h6[@data-qa='Contacts-sub-label']"));
        //body
        public static Element ContactFirstNameLabel => new Element(By.XPath("//label[@data-qa='Contacts-firstName-label']"));
        public static Element ContactFirstName => new Element(By.XPath("//input[@data-qa='Contacts-firstName']"));
        public static Element ContactFirstNameErrorMessage => new Element(By.XPath("//mat-error[@data-qa='firstName-error']"));
        public static Element ContactLastNameLabel => new Element(By.XPath("//label[@data-qa='Contacts-lastName-label']"));
        public static Element ContactLastName => new Element(By.XPath("//input[@data-qa='Contacts-lastName']"));
        public static Element ContactLastNameErrorMessage => new Element(By.XPath("//mat-error[@data-qa='lastName-error']"));
        public static Element DifferentAccountManagerCheckbox => new Element(By.XPath("//mat-checkbox[@data-qa='_apollo_IsAccountManagerDifferent-checkbox']"));
        public static Element BusinessEmailLabel => new Element(By.XPath("//label[@data-qa='_apollo_BusinessEmail-label']"));
        public static Element BusinessEmail => new Element(By.XPath("//input[@data-qa='_apollo_BusinessEmail']"));
        public static Element BusinessEmailErrorMessage => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_BusinessEmail-errorMessage']"));
        public static Element BusinessPhoneandExtLabel => new Element(By.XPath("//label[@data-qa='_apollo_BusinessPhoneAndExt-label']"));
        public static Element BusinessPhoneNumber => new Element(By.XPath("//input[@data-qa='_apollo_BusinessPhoneAndExt']"));
        public static Element BussinessPhoneExt => new Element(By.XPath("//input[@data-qa='BusinessPhoneAndExt-phoneExtension']"));
        public static Element BusinessPhoneErrorMessage => new Element(By.XPath("//mat-error[@data-qa='number-error']"));
        public static Element BusinessWebsiteLabel => new Element(By.XPath("//label[@data-qa='_apollo_BusinessWebsite-label']"));
        public static Element BusinessWebsite => new Element(By.XPath("//input[@data-qa='_apollo_BusinessWebsite']"));
        public static Element BusinessWebsiteHint => new Element(By.XPath("//mat-hint[@data-qa='_apollo_BusinessWebsite-hint']"));
        public static Element ManagerFirstNameLabel => new Element(By.XPath("//label[@data-qa='AccountManagerName-firstName-label']"));
        public static Element ManagerFirstName => new Element(By.XPath("//input[@data-qa='AccountManagerName-firstName']"));
        public static Element ManangerFirstNameError => new Element(By.XPath("//mat-error[@data-qa='firstName-error']"));
        public static Element ManagerLastNameLabel => new Element(By.XPath("//label[@data-qa='AccountManagerName-lastName-label']"));
        public static Element ManagerLastName => new Element(By.XPath("//input[@data-qa='AccountManagerName-lastName']"));
        public static Element ManangerlastNameError => new Element(By.XPath("//mat-error[@data-qa='lastName-error']"));
        public static Element ManagerEmailLabel => new Element(By.XPath("//label[@data-qa='_apollo_AccountManagerEmail-label']"));
        public static Element ManagerEmail => new Element(By.XPath("//input[@data-qa='_apollo_AccountManagerEmail']"));
        public static Element ManagerEmailError => new Element(By.XPath("//bb-error[@data-qa='_apollo_AccountManagerEmail-errorMessage']"));
        public static Element ManagerPhoneAndExtLabel => new Element(By.XPath("//label[@data-qa='_apollo_AccountManagerPhoneAndExt-label']"));
        public static Element ManagerPhoneNum => new Element(By.XPath("//input[@data-qa='_apollo_AccountManagerPhoneAndExt']"));
        public static Element ManagerPhoneError => new Element(By.XPath("//mat-error[@data-qa='number-error']"));
        public static Element ManagerExtNum => new Element(By.XPath("//input[@data-qa='AccountManagerPhoneAndExt-phoneExtension']"));
        public static Element DateOfBirthLabel => new Element(By.XPath("//label[@data-qa='_apollo_PrimaryOwnerDateOfBirth-label']"));
        public static Element DateOfBirth => new Element(By.XPath("//input[@data-qa='_apollo_PrimaryOwnerDateOfBirth']"));
        public static Element DateOfBirthError => new Element(By.XPath("//bb-error-message[@data-qa='_apollo_PrimaryOwnerDateOfBirth-errorMessage']"));
    }
}
