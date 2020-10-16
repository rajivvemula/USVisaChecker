using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Helpers
{
 
    class JavaScriptExecutor
    {
        // Highligth Element
        public static void highlight(IWebDriver driver, IWebElement element, int borderwidth = 3)
        {
            if (borderwidth == 0)
            {
                Thread.Sleep(500);
            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script: "arguments[0].style.border='"+ borderwidth + "px solid red'", element);
        }
    }
}
