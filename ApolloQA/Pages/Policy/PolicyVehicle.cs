using ApolloQA.Helpers;
using ApolloQA.Pages.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ApolloQA.Pages.Policy
{
    class PolicyVehicle
    {
        private IWebDriver policyDriver;
        private Functions functions;
        private Components components;
        private Toaster toaster;

        public PolicyVehicle(IWebDriver driver)
        {
            policyDriver = driver;
            functions = new Functions(driver);
            components = new Components(driver);
            toaster = new Toaster(driver);
        }
        public IWebElement newVehicleButton => functions.FindElementWait(5, By.XPath("//span[@class = 'mat-button-wrapper' and normalize-space(text())='New Vehicle']"));
        public IWebElement addExistingeButton => functions.FindElementWait(10, By.XPath("//span[@class = 'mat-button-wrapper' and normalize-space(text())='Add Existing Vehicle']"));
        public IWebElement inputVin => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='vinNumber']"));
        public IWebElement searchVinButton => functions.FindElementWait(10, By.XPath("//button/span[normalize-space(text())='Search VIN']"));
        public IWebElement cancelButton => functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Cancel']"));
        public IWebElement submitButton =>functions.FindElementWait(10, By.XPath("//span[@class='mat-button-wrapper' and normalize-space(text())='Submit']"));
        public IWebElement LicensePlateNumber => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='plateNumber']"));
        public IWebElement OperationRadius => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='radiusOfOperation']"));
        public IWebElement Trim => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='trim']"));
        public IWebElement CostNew => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='costNew']"));
        public IWebElement EstimatedValue => functions.FindElementWait(10, By.XPath("//input[@formcontrolname='estimatedCurrentValue']"));


        public bool ClickNewVehicle()
        {
            try
            {
                newVehicleButton.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void ClickExistingButton()
        {
            addExistingeButton.Click();
        }

        public void ClickSearchVIN()
        {
            searchVinButton.Click();
            Thread.Sleep(3000);
        }

        public void SelectState(string state)
        {
            components.UpdateDropdown("plateStateProvinceId", state);
        }

        public void SelectVehicleType(string type)
        {
            components.UpdateDropdown("typeId", type);
        }

        public void SelectBodyCategory(string category)
        {
            components.UpdateDropdown("bodyCategoryTypeId", category);
        }

        public void SelectBodySubcategory(string subcategory)
        {
            components.UpdateDropdown("bodySubCategoryTypeId", subcategory);
        }

        public void SelectClassCode(string classcode)
        {
            components.UpdateDropdown("classCode", classcode);
        }

        public void SelectBusinessUse(string businessuse)
        {
            components.UpdateDropdown("businessUseId", businessuse);
        }

        //select coverage by checkbox number
        public void SelectCoverage(int checkboxNum)
        {
            WebDriverWait wait = new WebDriverWait(policyDriver, TimeSpan.FromSeconds(10));
            IList<IWebElement> checkBoxes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[@type ='checkbox']")));
            checkBoxes[checkboxNum].Click();
        }

        //select coverage by coverage name
        public void SelectCoverageOutput(string coverage)
        {
            IWebElement target = functions.FindElementWait(10, By.XPath("//mat-checkbox/label/span[normalize-space(text())='" + coverage + "']/../.."));
            target.Click();
        }

        public void ClickSubmit()
        {
            submitButton.Click();
        }
        public void ClickCancel()
        {
            cancelButton.Click();
        }
        public bool CheckModalTitle()
        {
            bool title = functions.FindElementWait(10, By.XPath("//h1[contains(text(),'Add vehicle for')]")).Displayed;
            return title;
        }

        public void EnterVin(string vin)
        {
            inputVin.Click();
            inputVin.SendKeys(vin);
        }
        

        //add grid actions



        public bool CanAddNewVehicle()
        {
            // if we can't click New Contact button, return false
            if (!ClickNewVehicle())
            {
                Console.WriteLine("could not add new vehicle - add vehicle button is disabled");
                return false;
            }


            //grabs random vin
            //grabs random vin
            ChromeDriver vinDriver = new ChromeDriver();
            vinDriver.Navigate().GoToUrl("https://randomvin.com/");
            Thread.Sleep(2000);
            string randomVin = vinDriver.FindElement(By.XPath("//span[@id='Result']/h2")).Text;
            vinDriver.Quit();


            EnterVin(randomVin);
            ClickSearchVIN();
            SelectState("PA");
            LicensePlateNumber.SendKeys("APO12345");
            OperationRadius.SendKeys("50");
            SelectVehicleType("Car");
            SelectBodyCategory("Trucks");
            SelectBodySubcategory("Agriculture Truck");
            SelectClassCode("Airport Limousines -826");
            SelectBusinessUse("Commercial Use");
            Trim.SendKeys("Sport");
            CostNew.SendKeys("50000");
            EstimatedValue.SendKeys("30000");
            SelectCoverageOutput("Additional Insured - Named Entity");
            ClickSubmit();

            string toastTitle = toaster.GetToastTitle();
            if (toastTitle.Contains("Vehicle saved successfully"))
                return true;
            else return false;
        }
    }
}
