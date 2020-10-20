using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ApolloQA.Source.Driver
{
    public class Element
    {
        public string Xpath;
        public By locator;

        public Element(string xpath)
        {
            this.Xpath = xpath;
            this.locator = By.XPath(Xpath);
        }
        public Element(By locator)
        {
            this.locator = locator;

        }


        //
        //  General Element Actions
        //
 
        public void Click()
        {
            UserActions.Click(locator);
        }

        public string GetElementText()
        {
            return UserActions.getElementText(locator);
        }
        public void assertElementIsVissible(int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            UserActions.FindElementWait(locator, wait_Seconds);
        }

        //
        //  Text Fields Actions
        //
        public void setText(String TextToEnter, int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            UserActions.setText(locator, TextToEnter, wait_Seconds);
        }
        public string getTextFieldText(int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
           return  UserActions.getTextFieldText(locator, wait_Seconds);

        }
        public void clearTextField(int wait_Seconds = Defaults.DEFAULT_WAIT_SECONDS)
        {
            UserActions.clearTextField(locator);
        }



        

    }
}