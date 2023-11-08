using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.BSP
{
    public sealed class BSP_LoginPage
    {
        public static Element UserNameInput => new Element(By.XPath("//input[@name='loginfmt']"));
        public static Element PassWordInput => new Element(By.XPath("//input[@name='passwd']"));
        public static Element Confirm => new Element(By.XPath("//input[@type='submit']"));
    }
}