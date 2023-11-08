using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HitachiQA.Helpers
{
 
    public class JSExecutor
    {
        private IJavaScriptExecutor _jsExecutor;

        public JSExecutor(IWebDriver driver)
        {
            _jsExecutor = (IJavaScriptExecutor)driver;
        }

        public object Execute(string script, params object[] args)
        {
            return _jsExecutor.ExecuteScript(script,args );
        }

        // Highligth Element
        public void Highlight(IWebElement element, int borderwidth = 3)
        {
            try
            {
                Execute(script: "arguments[0].style.border='" + borderwidth + "px solid red'", element);
            }
            catch
            {
                // do nothing
            }
        }

        public string GetValueFromSessionStorage(string key)
        {
            var sanitizedKey = key.Replace("'", "\\'");
            return (string)Execute($"return sessionStorage.getItem('{sanitizedKey}')");
        }
    }
}
