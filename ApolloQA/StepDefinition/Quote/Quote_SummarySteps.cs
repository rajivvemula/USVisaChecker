using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;
using System;
using Entity_Quote = ApolloQA.Data.Entity.Quote;
using Entity_Tether = ApolloQA.Data.Entity.Tether;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using ApolloQA.Pages;

namespace ApolloQA.StepDefinition.Quote
{
    [Binding]
    public class Quote_SummarySteps
    {
        long quoteTetherID;
        Entity_Quote _quote;




        [When(@"User creates a Quote using Entity Package")]
        public void WhenUserCreatesAQuoteUsingEntityPackage()
        {
            _quote = Functions.GetQuotedQuoteThroughAPI();

            Log.Info(_quote);
            var TetherIDQuote = Entity_Tether.GetTether(_quote.Id);
            Log.Info(TetherIDQuote.Id);
            quoteTetherID = TetherIDQuote.Id;
            UserActions.Navigate($"quote/{_quote.Id}/section/9000");


        }

        [Then(@"User verifies correct rating package is selected")]
        public void ThenUserVerifiesCorrectRatingPackageIsSelected()
        {
            int paymentPlanType = _quote.RatingPackageId;
            Log.Info(paymentPlanType);


            if (paymentPlanType == 10001)
            {
                bool RadioCheck = UserActions.IsRadioButtonSelected(By.XPath("//span[normalize-space(text())='Monthly']/../*/input"));
                Assert.IsTrue(RadioCheck);
            }
            else
            {
                bool RadioCheck = UserActions.IsRadioButtonSelected(By.XPath("//span[normalize-space(text())='Yearly']/../*/input"));
                Assert.IsTrue(RadioCheck);
            }
        }

        [Then(@"User verifies Premium Details grid is displayed")]
        public void ThenUserVerifiesPremiumDetailsGridIsDisplayed()
        {
            Element premiumGrid = new Element("//h5[normalize-space(text())='Premium Details']/../ngx-datatable");
            bool assertPresent = premiumGrid.assertElementIsVisible();
            Assert.IsTrue(assertPresent);
            premiumGrid.Click();
        }

        [Then(@"User verifies correct amount of vehicles are listed in the premium")]
        public void ThenUserVerifiesCorrectAmountOfVehiclesAreListedInThePremium()
        {
            var parsedPremium = UserActions.parseUITable("//h5[normalize-space(text())='Premium Details']/../ngx-datatable");
            var listOfVehicles = _quote.GetVehicles();

            //Check whether the Vehicle is listed in Grid
            foreach (var vehicle in listOfVehicles)
            {
                //implement contains instead of first
                var rowsForVehicle = parsedPremium.First(row => row["Risk"] == vehicle.ToString());
                //If Value was found then vehicle exists
                Assert.IsFalse(rowsForVehicle.Count() == 0);
            }

            foreach (var vehicle in listOfVehicles)
            {
                //Get a list of coverages and see if the coverage exists and is contained with the same row as the vehicle
                var ListOfCoverages = _quote.getCoverageTypes(vehicle);
                foreach (var cov in ListOfCoverages)
                {
                    bool rowsForVehicle = parsedPremium.Any(row => row["Coverage"] == cov.ToString());     //Simple Check for just if cov exists
                    //bool rowsForVehicle = parsedPremium.Any(row => row["Coverage"] == cov.ToString() && row["Risk"] == vehicle.ToString() );
                    Assert.IsTrue(rowsForVehicle);
                }
            }
        }


        [Then(@"User verifies Coverage Summary grid is displayed")]
        public void ThenUserVerifiesCoverageSummaryGridIsDisplayed()
        {
            Element coverageGrid = new Element("//bh-coverage-summary");
            bool assertPresent = coverageGrid.assertElementIsVisible();
            Assert.IsTrue(assertPresent);
        }

        [Then(@"User verifies correct coverages are listed")]
        public void ThenUserVerifiesCorrectCoveragesAreListed()
        {
            var parsedCoverages = UserActions.parseUITable("//bh-coverage-summary");
            var listOfVehicles = _quote.GetVehicles();

            foreach (var vehicle in listOfVehicles)
            {
                //Make a list of coverages and see if Grid is displaying it
                var ListOfCoveragesIE = _quote.getCoverageTypes(vehicle);
                var listOfCoverages = ListOfCoveragesIE.ToList();
                foreach (var cov in listOfCoverages)
                {
                    if (cov.Description == "Bodily Injury Property Damage (BIPD)")
                    {
                        var coverageToBeChecked = parsedCoverages.First(row => row["Policy Coverage"] == "Bodily Injury Property Damage (BIPD)").ToString();
                        Assert.IsFalse(coverageToBeChecked.Length == 0);
                        Log.Info(cov);
                    }
                    else
                    {
                        var coverageToBeChecked = parsedCoverages.First(row => row["Policy Coverage"] == cov.Description).ToString();
                        Assert.IsFalse(coverageToBeChecked.Length == 0);
                    }




                }
            }


        }

        [Then(@"User verifies Vehicle grid is displayed")]
        public void ThenUserVerifiesVehicleGridIsDisplayed()
        {
            Element vehicleGrid = new Element("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[1]//bh-grid//ngx-datatable");
            bool assertPresent = vehicleGrid.assertElementIsVisible();
            Assert.IsTrue(assertPresent);
        }

        [Then(@"User verifies correct amount of vehicles in vehicles Grid")]
        public void ThenUserVerifiesCorrectAmountOfVehiclesInVehiclesGrid()
        {
            var parsedVehicles = UserActions.parseUITable("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[1]//bh-grid//ngx-datatable");
            //parsedVehicles.ToList().ForEach(it => Log.Info(it));
            Log.Info(parsedVehicles);
            var listOfVehicles = _quote.GetVehicles();

            //Remove Trailer From List
            var vehicleToRemove = listOfVehicles.Single(r => r.Make == "GENERAL TRAILER CO");
            listOfVehicles.Remove(vehicleToRemove);
            Log.Info(listOfVehicles);

            string listOfVehicleString = string.Join(", ", listOfVehicles);
            int amountOfVehicles = listOfVehicles.Count;
            int amountofVehiclesListedInGrid = parsedVehicles.Where(x => x["Model"] != null).Count();

            Assert.AreEqual(amountOfVehicles, amountofVehiclesListedInGrid);

            //Verify the listed Vehicle In Grid Is Correct


            foreach (var item in listOfVehicles)
            {
                var vehicleBeingChecked = parsedVehicles.Where(x => x["Model"] == item.Model && x["Make"] == item.Make).ToString();

                Log.Info(vehicleBeingChecked);

                Assert.IsFalse(vehicleBeingChecked.Length == 0);


            }



        }

        [Then(@"User verifies vehicle grid can be expanded and VIN is listed")]
        public void ThenUserVerifiesVehicleGridCanBeExpandedAndVINIsListed()
        {
            Shared.GetButton("Expand All").Click();
            var parsedVehicles = UserActions.parseUITable("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[1]//bh-grid//ngx-datatable");
            parsedVehicles.ToList().ForEach(it => Log.Info(it));
            var listOfVehicles = _quote.GetVehicles();
            listOfVehicles.ForEach(it => Log.Info(it.VinNumber));

            //list workaround for vin
            List<string> listofVins = new List<string>();
            listOfVehicles.ForEach(it => listofVins.Add(it.VinNumber));
            Log.Info(listofVins);
            foreach (var uiRow in parsedVehicles)
            {

                //Get current Grid Values when expand all button is clicked
                var rowNumber = uiRow["No."];
                Element vinNumberXpath = new Element($"//bh-quote-vehicle-list/*//div[contains(text(), '{rowNumber}')]//ancestor::datatable-body-row/..//div[@class='datatable-row-detail ng-star-inserted'] //*[text()='VIN']/../following-sibling::*");
                Element dateAddedXpath = new Element($"//bh-quote-vehicle-list/*//div[contains(text(), '{rowNumber}')]//ancestor::datatable-body-row/..//div[@class='datatable-row-detail ng-star-inserted'] //*[text()='Date Added']/../following-sibling::*");
                Element dateRemovedXpath = new Element($"//bh-quote-vehicle-list/*//div[contains(text(), '{rowNumber}')]//ancestor::datatable-body-row/..//div[@class='datatable-row-detail ng-star-inserted'] //*[text()='Date Removed']/../following-sibling::*");


                var vinNumber = vinNumberXpath.GetElementText();


                Assert.Contains(listofVins, vinNumber);

                //Check the date from Grid 
                var dateAddedValue = dateAddedXpath.GetElementText();

                //Get Tether Value
                string dateFromTether = _quote.Tether.EffectiveDate.UtcDateTime.ToString("MM/dd/yyyy");
                Assert.AreEqual(dateAddedValue, dateFromTether);
                //Check Date Removed, should be N/A for this test case
                var dateRemovedValue = dateRemovedXpath.GetElementText();
                string dateRemovedNA = "N/A";
                Assert.AreEqual(dateRemovedValue, dateRemovedNA);

            }
        }


        [Then(@"User verifies Trailers grid is displayed")]
        public void ThenUserVerifiesTrailersGridIsDisplayed()
        {
            Element trailerGrid = new Element("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[2]//bh-grid//ngx-datatable ");
            bool assertPresent = trailerGrid.assertElementIsVisible();
            Assert.IsTrue(assertPresent);
        }

        [Then(@"User verifies correct amount of trailers in trailers Grid")]
        public void ThenUserVerifiesCorrectAmountOfTrailersInTrailersGrid()
        {
            var parsedTrailers = UserActions.parseUITable("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[2]//bh-grid//ngx-datatable ");
            var listOfVehicles = _quote.GetVehicles();

            //Remove Honda
            var vehicleToRemove = listOfVehicles.Single(r => r.Make == "Honda");
            listOfVehicles.Remove(vehicleToRemove);
            Log.Info(listOfVehicles);


            string listOfVehicleString = string.Join(", ", listOfVehicles);
            int amountOfVehicles = listOfVehicles.Count;
            int amountofVehiclesListedInGrid = parsedTrailers.Where(x => x["Make"] != null).Count();

            Assert.AreEqual(amountOfVehicles, amountofVehiclesListedInGrid);

            //Verify the listed Vehicle In Grid Is Correct
            if (parsedTrailers.Count() > 1)
            {
                foreach (var item in listOfVehicles)
                {
                    //string
                    var vehicleBeingChecked = parsedTrailers.Where(x => x["Make"] == item.Make
                                                                     && x["Year"] == item.YearOfManufacture.ToString()).ToString();

                    //int


                    Assert.IsFalse(vehicleBeingChecked.Length == 0);


                    /*
                    bool checkVehicleString = listOfVehicleString.Contains(vehicleBeingChecked);
                    Assert.IsTrue(checkVehicleString);
                    Assert.AreEqual(vehicleBeingChecked, item.Model);
                    */


                }
            }

        }

        [Then(@"User verifies Trailers grid can be expanded and VIN is listed")]
        public void ThenUserVerifiesTrailersGridCanBeExpandedAndVINIsListed()
        {


            Element secondExpandButton = new Element("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[2]//button[./*[normalize-space(text())='Expand All']] ");

            secondExpandButton.Click();



            var parsedVehicles = UserActions.parseUITable("//h5[normalize-space(text())='Vehicles']/following-sibling::bh-quote-vehicle-list[2]//bh-grid//ngx-datatable ");
            parsedVehicles.ToList().ForEach(it => Log.Info(it));
            var listOfVehicles = _quote.GetVehicles();
            listOfVehicles.ForEach(it => Log.Info(it.VinNumber));

            //list workaround for vin
            List<string> listofVins = new List<string>();
            listOfVehicles.ForEach(it => listofVins.Add(it.VinNumber));
            Log.Info(listofVins);
            foreach (var uiRow in parsedVehicles)
            {

                //Get current UI
                var rowNumber = uiRow["No."];
                Element vinNumberXpath = new Element($"//bh-quote-vehicle-list[2]/*//div[contains(text(), '{rowNumber}')]//ancestor::datatable-body-row/..//div[@class='datatable-row-detail ng-star-inserted'] //*[text()='VIN']/../following-sibling::*");
                Element dateAddedXpath = new Element($"//bh-quote-vehicle-list[2]/*//div[contains(text(), '{rowNumber}')]//ancestor::datatable-body-row/..//div[@class='datatable-row-detail ng-star-inserted'] //*[text()='Date Added']/../following-sibling::*");
                Element dateRemovedXpath = new Element($"//bh-quote-vehicle-list[2]/*//div[contains(text(), '{rowNumber}')]//ancestor::datatable-body-row/..//div[@class='datatable-row-detail ng-star-inserted'] //*[text()='Date Removed']/../following-sibling::*");


                var vinNumber = vinNumberXpath.GetElementText();

                Assert.Contains(listofVins, vinNumber);

                //Check the date from Grid 
                var dateAddedValue = dateAddedXpath.GetElementText();
                //Get Tether Value
                string dateFromTether = _quote.Tether.EffectiveDate.UtcDateTime.ToString("MM/dd/yyyy");
                Assert.AreEqual(dateAddedValue, dateFromTether);

                //Check Date Removed, should be N/A for this test case
                var dateRemovedValue = dateRemovedXpath.GetElementText();
                string dateRemovedNA = "N/A";
                Assert.AreEqual(dateRemovedValue, dateRemovedNA);

            }
        }

    }
}

