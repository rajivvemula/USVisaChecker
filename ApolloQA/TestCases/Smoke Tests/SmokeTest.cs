using ApolloQA.Helpers;
using ApolloQA.Pages.Application;
using ApolloQA.Pages.Dashboard;
using ApolloQA.Pages.Fnol;
using ApolloQA.Pages.Login;
using ApolloQA.Pages.Organization;
using ApolloQA.Pages.Policy;
using ApolloQA.Pages.Shared;
using Microsoft.Azure.Cosmos;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApolloQA.TestCases.Smoke_Tests
{

    [TestFixture]
    class SmokeTest
    {

        public IWebDriver driver;
        MainNavBar mainNavBar;
        RightNavBar rightNavBar;
        HomePage homePage;
        OrganizationGrid organizationGrid;
        OrganizationInsert organizationInsert;
        Toaster toaster;
        Components components;
        OrganizationInformation organizationInformation;
        AddAddress addAddress;
        OrganizationAddress organizationAddress;
        OrganizationDriver organizationDriver;
        AddDriver addDriver;
        OrganizationVehicle organizationVehicle;
        AddVehicle addVehicle;
        SmokeTestHelpers helper;
        PolicyMain policyMain;
        PolicyGrid policyGrid;
        PolicyCreation policyCreation;
        PolicyContacts policyContacts;
        ApplicationGrid appGrid;
        ApplicationInformation appInfo;
        BusinessInformation appBusInfo;
        FNOLDashboard fnolDashboard;
        FNOLInsert fnolInsert;
        FNOLDetails fnolDetails;
        FNOLContact fnolContacts;
        Random rnd;

        //Cosmos Azure
        CosmosClient client;
        Database database;
        Container container;


        //Variables
        //Org Number is a string 
        string smokeOrganization = "10085";
        bool smokeOrgCreated = false;
        string createdOrgName = "Smoke Test";
        string createdOrgAddress = "";
        string taxName = "12-3489123";
        string createdAppID = "";
        string createdClaimID = "";
        bool queryFound = false;
        bool claimFound = false;
        public SmokeTest()
        {
            //driver = new ChromeDriver();
            //mainNavBar = new MainNavBar(driver);
        }
        [OneTimeSetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            rnd = new Random();
            Generator();
            mainNavBar = new MainNavBar(driver);
            rightNavBar = new RightNavBar(driver);
            homePage = new HomePage(driver);
            helper = new SmokeTestHelpers(driver);
            organizationGrid = new OrganizationGrid(driver);
            organizationInsert = new OrganizationInsert(driver);
            toaster = new Toaster(driver);
            components = new Components(driver);
            organizationInformation = new OrganizationInformation(driver);
            organizationAddress = new OrganizationAddress(driver);
            addAddress = new AddAddress(driver);
            organizationDriver = new OrganizationDriver(driver);
            organizationVehicle = new OrganizationVehicle(driver);
            addDriver = new AddDriver(driver);
            addVehicle = new AddVehicle(driver);
            policyMain = new PolicyMain(driver);
            policyGrid = new PolicyGrid(driver);
            policyCreation = new PolicyCreation(driver);
            policyContacts = new PolicyContacts(driver);
            appGrid = new ApplicationGrid(driver);
            appInfo = new ApplicationInformation(driver);
            appBusInfo = new BusinessInformation(driver);
            fnolDashboard = new FNOLDashboard(driver);
            fnolInsert = new FNOLInsert(driver);
            fnolDetails = new FNOLDetails(driver);
            fnolContacts = new FNOLContact(driver);

            //Cosmos Client Setup
            client = new CosmosClient("https://zbibaoazcdb1qa2.documents.azure.com:443/", "p9fiijwywnNpP4gRROO0NNA2sDMPyyjZ0OfMzJGriSCZIEKUGNrIyzut20ICyyGnGtbVwRr5rmgT57TIBE0LvQ==");
            database = client.GetDatabase("apollo");
        }

        [OneTimeTearDown]
        public void teardown()
        {
            driver.Quit();
        }

        public void Generator()
        {
            string taxRND = rnd.Next(100, 900).ToString();
            taxName = "12-3489" + taxRND;
        }

        public async Task GetQuery(string containerA, string queryA)
        {
            
            container = database.GetContainer(containerA);
            using (FeedIterator<dynamic> feedIterator = container.GetItemQueryIterator<dynamic>(
               queryA))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = await feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        //simple check for right now
                        Console.WriteLine(item);
                        switch(containerA)
                        {
                            case "Application":
                                    queryFound = true; 
                                    break;
                            case "Claim": 
                                    claimFound = true;
                                    break;
                            default: break;

                        }
                    }
                }
            }

        }
        /// <summary>
		/// Logs in As Admin
		/// </summary>
        [TestCase, Order(1)]
        public void LogIn()
        {
            LogInAsAdmin logInAsAdmin = new LogInAsAdmin(driver);
            logInAsAdmin.LoginAsValidUser();
        }

        /// <summary>
		/// Check If Admin Has appropriate Permissions
		/// </summary>
        [TestCase, Order(2)]
        public void AdminPermission()
        {
            bool verifyUser = homePage.VerifyLoggedInUser(Defaults.ADMIN_USERNAME);
            Assert.AreEqual(verifyUser, true);
            foreach (string i in Defaults.adminRoles)
            {
                bool verifyRole = homePage.CheckRole(i);
                Assert.AreEqual(verifyRole, true);
            }
        }


        /// <summary>
		/// Test 4  Main Nav Tabs(Home, Policy, Organization, and Application
		/// </summary>
        [TestCase, Order(3)]
        public void TestNav()
        {
            //bool atHome = driver.Url.Contains(Defaults.QA_URLS["Home"]);
            //Check If User is at Home if not go to Home
            //MainNavBar mainNavBar = new MainNavBar(driver);
            helper.CheckIfHome();
            mainNavBar.ClickHomeIcon();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Home"]), "Unable to Click Home");
            mainNavBar.ClickPolicyTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Policy"]), "Unable to Click Policy Tab");
            mainNavBar.ClickOrganizationTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Organization"]), "Unable to Click Organization Tab");
            mainNavBar.ClickApplicationTab();
            Assert.IsTrue(driver.Url.Contains(Defaults.QA_URLS["Application"]), "Unable to Click Application Tab");

            //Test Waffle Menu has all tabs present

            string[] waffleTabs = { "Underwriting", "Billing", "Administration", "Collections Center", "Claims" };

            rightNavBar.waffleMenu.Click();
            foreach(var i in waffleTabs)
            {
                bool verifyTab = helper.checkWaffleTab(i);
                Assert.IsTrue(verifyTab, i + " Tab not present");
            }
            rightNavBar.sideWaffleMenu.Click();


        }

        /// <summary>
		/// Navigate to Organization,Insert New Organization and Submit a New Organization
		/// </summary>
        [TestCase, Order(4)]
        public void InsertOrganization()
        {
            mainNavBar.ClickOrganizationTab();
            //Assert.IsTrue(driver.Title.Contains("Insert Organization"), "Didn't get to Insert Organization Screen");
            Assert.That(() => driver.Title, Is.EqualTo("Organization").After(3).Seconds.PollEvery(250).MilliSeconds, "Didn't get to Insert Organization Screen");
            //Click New Button
            organizationGrid.ClickNewButton();
            Assert.That(() => driver.Title, Is.EqualTo("Insert Organization").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click New Button");

            //Generate Org Name
            string orgRND = rnd.Next(100, 900).ToString();
            string orgName = "Smoke Test" + orgRND;

            //Input
            organizationInsert.EnterInput("name", orgName);
            createdOrgName = orgName;
            organizationInsert.EnterInput("dba", "Smoke");
            organizationInsert.EnterInput("businessphone", "123-456-7890");
            organizationInsert.EnterInput("businessemail", "smoketest@gmail.com");
            organizationInsert.EnterInput("businesswebsite", "smoketest.com");
            organizationInsert.EnterInput("yearstarted", "2010");
            organizationInsert.EnterInput("yearownership", "2011");
            organizationInsert.EnterSelect("orgtype", "Corporation");
            organizationInsert.EnterSelect("taxtype", "FEIN");
            organizationInsert.EnterInput("keyword", "Accountant");
            organizationInsert.keywordCode.SendKeys(Keys.Enter);
            organizationInsert.EnterInput("taxid", taxName);
            Thread.Sleep(3000);

            //Submit Ogrnaization and if it's created then test proceeds with the created organization
            //If it's not then test proceed with a preselected organization
            //Assert.That(() => organizationInsert.inputName.Text, Does.Contain(orgName).After(3).Seconds.PollEvery(250).MilliSeconds, "Incorrect Org Name Entered");
            organizationInsert.ClickSubmitButton();
            bool verifyTitle = components.GetTitle("Organization Details");
            Assert.IsTrue(verifyTitle, "Organization was not created");
            if (verifyTitle) {
                smokeOrgCreated = true;
                //if need be that we need to put orgnumber to a variable
                //string currentURL = driver.Url;
                //string orgNumber = currentURL.Remove(0, currentURL.Length - 5);
            }
            Thread.Sleep(3000);
        }

        /// <summary>
		/// Test Save Changes For Newly Created organization
		/// </summary>
        [TestCase, Order(5)]
        public void SaveOrganization()
        {
            if(smokeOrgCreated == false) {
                driver.Navigate().GoToUrl("https://biberk-apollo-qa2.azurewebsites.net/organization/" + smokeOrganization);
            }
            organizationInformation.EnterSelect("orgtype", "LLC");
            organizationInformation.saveButton.Click();

            //verify change saved  via toast
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("was saved."));
        }

        /// <summary>
		/// Test Adding an address to an organization
		/// </summary>
        [TestCase, Order(6)]
        public void AddAnAddressToOrganization()
        {
            organizationAddress.addressTab.Click();
            //check if dialog opens up prompting the user to navigate away
            if (components.CheckIfDialogPresent())
            {
                components.continueAnywayButton.Click();
            }
            Assert.That(() => driver.Url, Does.Contain("address").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Address Tab");

            //Click Add Address Button
            organizationAddress.addAddressButton.Click();
            Assert.That(() => components.GetDialogTitle(), Is.EqualTo("Add New Address").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add Address Button/Open Add Adress Dialog");

            //Inputs
            //| 39 Public Square | Wilkes Barre | Pennsylvania | 18703 | 
            addAddress.EnterInput("add1", "39 Public Square");
            addAddress.EnterInput("city", "Wilkes Barre");
            addAddress.EnterInput("zip", "18703");
            addAddress.EnterSelect("state", "PA");
            createdOrgAddress = "39 Public Sq, Wilkes Barre, PA, 18701";
            addAddress.saveButton.Click();
            //Select Default Address
            addAddress.defaultAddressInfo.Click();
            addAddress.useSelectedButton.Click();

            bool verifyAdd = organizationAddress.CheckAddress("39 Public Sq");
            Assert.IsTrue(verifyAdd, "Address was not added to the organization");

        }

        /// <summary>
		/// Test Adding a Driver to an organization
		/// </summary>
        [TestCase, Order(7)]
        public void AddDriverToOrganization()
        {
            //Navigate to Driver Tab
            organizationDriver.addressTab.Click();
            if (components.CheckIfDialogPresent())
            {
                components.continueAnywayButton.Click();
            }
            Assert.That(() => driver.Url, Does.Contain("driver").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Driver Tab");

            // Add Driver Button
            organizationDriver.addDriverButton.Click();
            Assert.That(() => components.GetDialogTitle(), Is.EqualTo("Add Driver").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add Driver Button/Open Add Driver Dialog");

            //generate random number for license plate
            string licenseRND = rnd.Next(100, 700).ToString();
            string licenseNumber = "AZ15" + licenseRND;

            //inputs 
            // | Jacob | Seed | J      | 01/02/1975 | AZ    | AZ15435 | 01/01/2022 | No  |
            addDriver.EnterInput("first", "Jacob");
            addDriver.EnterInput("last", "Seed");
            addDriver.EnterInput("middle", "J");
            addDriver.EnterInput("dob", "01/02/1975");
            addDriver.EnterSelect("licensestate", "AZ");
            addDriver.EnterInput("licensenumber", licenseNumber);
            addDriver.EnterInput("licenseexp", "01/01/2022");
            addDriver.EnterSelect("cdl", "No");

            //Driver Save And Toast
            addDriver.submitButton.Click();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Driver saved"), "Driver was not saved");
        }

        /// <summary>
		/// Test Adding a Vehicle to an organization
		/// </summary>
        [TestCase, Order(8)]
        public void AddVehicleToOrganization()
        {
            //Navigate to Vehicle Tab
            organizationVehicle.VehicleTab.Click();
            if (components.CheckIfDialogPresent())
            {
                components.continueAnywayButton.Click();
            }
            Assert.That(() => driver.Url, Does.Contain("vehicle").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Vehicle Tab");

            // Add Vehicle Button
            organizationVehicle.addDriverButton.Click();
            Assert.That(() => components.GetDialogTitle(), Is.EqualTo("Add vehicle for " + createdOrgName).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add Vehicle Button/Open Add Vehicle Dialog");

            // Generate a random Vin
            string vinRND = rnd.Next(100, 900).ToString();
            string vinNumber = "1FAFP34N97W156" + vinRND;
            string licenseRND = rnd.Next(100, 700).ToString();
            string licenseNumber = "AZ15" + licenseRND;



            //Vehicle Input
            addVehicle.EnterInput("VIN", vinNumber);
            addVehicle.EnterInput("Year", "2015");
            addVehicle.EnterInput("Make", "Toyota");
            addVehicle.EnterInput("Model", "Camry");
            addVehicle.EnterInput("Trim", "SE");
            //addVehicle.EnterSelect("State", "AZ");
            //addVehicle.EnterInput("Plate", licenseNumber);
            addVehicle.EnterSelect("Type", "Car");
            addVehicle.EnterSelect("Category", "Cars, Pickup, or SUV");
            addVehicle.EnterSelect("SubCategory", "Car - Coupe");
            //addVehicle.EnterSelect("Code", "Airport Limousines -826");
            //addVehicle.EnterSelect("Business", "Retail Vehicle");
            addVehicle.EnterSelect("Seating", "5 or less");
            addVehicle.EnterSelect("Gross", "0 - 5000");
            addVehicle.EnterInput("Cost", "10000");
            addVehicle.EnterInput("Value", "11000");
            addVehicle.EnterInput("Stated", "12000");

            // Vehicle Submit and Toast
            addVehicle.submitButton.Click();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Vehicle saved"), "Vehicle not added to organization");
        }

        /// <summary>
		/// Create an Application
		/// </summary>
        [TestCase, Order(9)]
        public void CreateApplication()
        {
            //Navigate To Application Tab and Click New 
            mainNavBar.ClickApplicationTab();
            Assert.That(() => driver.Title, Does.Contain("Application").After(9).Seconds, "Unable To Navigate To Application From Navbar");
            appGrid.newButton.Click();
            Assert.That(() => driver.Url, Does.Contain("quote/create").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Qoute Creation From App Grid");

            //Inputs
            appInfo.EnterBusinessName(createdOrgName);
            //Assert.That(() => appInfo.businessName.Text, Does.Contain(createdOrgName).After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Enter Correct Organization Name");

            //CLick Next and Confirm 
            appInfo.ClickNext();
            Assert.That(() => driver.Url, Does.Contain("section").After(9).Seconds.PollEvery(250).MilliSeconds, "Unable To Create a Qoute");

            //Verify Quote has correct Business Name and Tax Id
            Assert.That(() => appBusInfo.businessName, Does.Contain(createdOrgName).After(3).Seconds.PollEvery(250).MilliSeconds, "Quote has wrong Business Name");
            Assert.That(() => appBusInfo.taxNo, Does.Contain(taxName).After(1).Seconds.PollEvery(250).MilliSeconds, "Quote has wrong Tax Id No");
        }

        /// <summary>
		/// Check if the application was created in cosmos db 
		/// </summary>
        [TestCase, Order(10)]
        public async Task CheckCosmosApp()
        {
            createdAppID = appBusInfo.appIDNo.Text;
            string verifyCosmosApp = "SELECT * FROM c WHERE c.Id = " + createdAppID;
            await GetQuery("Application", verifyCosmosApp);
            Assert.IsTrue(queryFound, "A matching application was not found in cosmos db");
            /*
            database = client.GetDatabase("apollo");
            container = database.GetContainer("Application");

            
             using (FeedIterator<dynamic> feedIterator = container.GetItemQueryIterator<dynamic>(
                "select * from T where T.status = 'done'"))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            */
        }


        /// <summary>
		/// Verify Appropriate Tabs are present in Application
		/// </summary>
        [TestCase, Order(11)]
        public void VerifyApplicationTabs()
        {
            //List of tabs and for each loop to see if they are present
            string[] tabs = {   "Application Information","Business Information", "Contacts", "UW Questions",
                                "Policy Coverages", "Drivers", "Vehicles", "Additional Questions", 
                                "Summary", 

                            };
            foreach (string i in tabs)
            {
                bool verifyTab = components.CheckIfTabPresent(i);
                Assert.IsTrue(verifyTab, "Tab " + i + " not found");
            }
        }

        /// <summary>
		/// Apply a mailing address to application
		/// </summary>
        [TestCase, Order(12)]
        public void ApplyMailingAddress()
        {
            //Select address and click next
            appBusInfo.selectMailing.Click();
            helper.SelectOptionAddress(createdOrgAddress);
            Assert.That(() => helper.CheckIfAddressSelected(createdOrgAddress), Is.EqualTo(true).After(3).Seconds.PollEvery(250).MilliSeconds, "Correct Address Not Selected");
            appBusInfo.nextButton.Click();

        }



        /// <summary>
		/// Navigate to Fnol Via Waffle Menu(Confirms waffle link is working and new fnol butt is working in Manager Dashboard) and checks add new fnol button in navbar
		/// </summary>
        [TestCase, Order(32)]
        public void NavigateToFnol()
        {
            if (components.CheckIfDialogPresent())
            {
                components.continueAnywayButton.Click();
            }
            //Click Claims Tab in Waffle Menu
            mainNavBar.waffleMenu.Click();
            mainNavBar.waffleClaimTab.Click();
            Assert.That(() => driver.Title, Does.Contain("First Notice of Loss").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Claims Tab");

            //Click New Fnol
            fnolDashboard.newFNOL.Click();
            Assert.That(() => driver.Title, Does.Contain("Insert First Notice of Loss").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add New FNOl Button/Navigate to FNOL Insert");

            //Navigate Home and CLick Add New FNol Via Navbar
            mainNavBar.HomeIcon.Click();
            Assert.That(() => driver.Title, Does.Contain("Home").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Home");
            mainNavBar.AddIcon.Click();
            mainNavBar.addFnolButton.Click();
            Assert.That(() => driver.Title, Does.Contain("Insert First Notice of Loss").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add New FNOl Button In Navbar/Navigate to FNOL Insert");
        }

        /// <summary>
		/// Create a new FNOL, test follows previous NavigateToFNOL()
		/// </summary>
        [TestCase, Order(33)]
        public void CreateFNOL()
        {
            //Inputs
            
            fnolInsert.EnterSelect("received", "Phone");
            fnolInsert.EnterSelect("related", "No");
            fnolInsert.EnterInput("firstName", "Joseph");
            fnolInsert.EnterInput("lastName", "Seed");
            fnolInsert.EnterInput("suffixName", "Mr");
            fnolInsert.EnterInput("email", "jospehseed@email.com");
            fnolInsert.EnterSelect("phoneType", "Mobile");
            fnolInsert.EnterInput("phoneNumber", "5452156532");
            fnolInsert.EnterSelect("claimCategory", "Option 1");
            fnolInsert.EnterInput("lossDesc", "Sample Desc");
            fnolInsert.sameAsCheckbox.Click();
            fnolInsert.EnterSelect("policeInvolved", "Yes");
            fnolInsert.EnterInput("policeName", "PAPD");
            fnolInsert.EnterInput("policeNumber", "1234");
            fnolInsert.EnterSelect("fireInvolved", "Yes");
            fnolInsert.EnterInput("fireName", "PAFD");
            fnolInsert.EnterInput("fireNumber", "1234");

            Assert.That(() => fnolInsert.inputFirstName.GetAttribute("value"), Does.Contain("Joseph").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct First Name");
            Assert.That(() => fnolInsert.inputLastName.GetAttribute("value"), Does.Contain("Seed").After(1).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct Last Name");
            Assert.That(() => fnolInsert.lossDescInput.GetAttribute("value"), Does.Contain("Sample Desc").After(1).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct loss description");

            //Submit FNOL FNOL "100030" was successfully saved.
            fnolInsert.submitButton.Click();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("was successfully saved."), "FNOL was not created");
            string[] words = verifyToast.Split(' ');
            string claimNumber = words[1].Substring(1, 6);
            createdClaimID = claimNumber;
            Console.WriteLine(createdClaimID);

        }

        /// <summary>
		/// Create a new FNOL, test follows previous NavigateToFNOL()
		/// </summary>
        [TestCase, Order(33)]
        public async Task CheckCosmosClaim()
        {
            //Check apollo > CLaims and match claim number
            string verifyCosmosClaim = "SELECT * FROM c WHERE c.ClaimNumber = '" + createdClaimID + "'";
            await GetQuery("Claim", verifyCosmosClaim);
            Assert.IsTrue(claimFound, "A matching claim was not found in cosmos db");
        }
        /// <summary>
		/// After a new FNOL is created, check if all the tabs are present
		/// </summary>
        [TestCase, Order(35)]
        public void CheckFNOLTabs()
        {
            //List of tabs and for each loop to see if they are present
            string[] tabs = {   "Occurrence", "Loss Details", "Contacts", "Documents", "Supervisor Review"

                            };
            foreach (string i in tabs)
            {
                bool verifyTab = components.CheckIfTabPresent(i);
                Assert.IsTrue(verifyTab, "Tab " + i + " not found");
            }
        }


        /// <summary>
		/// Submits the details, test follows previous 
		/// </summary>
        [TestCase, Order(36)]
        public void FNOLLossDetails()
        {
            Assert.That(() => driver.Url, Does.Contain("loss-details").After(3).Seconds.PollEvery(250).MilliSeconds, "The driver is currently not at Loss Details page");

            //Inputs (First Party and Bodily Injury)
            fnolDetails.checkboxFirstParty.Click();
            fnolDetails.checkboxBodilyInjury.Click();
            fnolDetails.EnterSelect("Fault", "Insured Fault");
            fnolDetails.EnterInput("OtherInsurer", "AlphaC");
            fnolDetails.EnterInput("OtherInsurerPolicy", "1234");
            fnolDetails.EnterInput("OtherInsurerClaim", "112321");
            fnolDetails.EnterInput("OtherInsurerAdjuster", "Jacob");
            fnolDetails.EnterSelect("SuitFiled", "Yes");
            fnolDetails.EnterSelect("AttyRep", "Yes");
            fnolDetails.EnterSelect("ReportOnly", "No");
            fnolDetails.EnterInput("FirstName", "Joseph");
            fnolDetails.EnterInput("LastName", "Seed");
            fnolDetails.EnterInput("Email", "josephseed@email.com");
            fnolDetails.EnterInput("Occupation", "Space Pirate");
            fnolDetails.EnterSelect("PhoneType", "Mobile");
            fnolDetails.EnterInput("Phone", "2458634456");
            fnolDetails.EnterInput("DateOfBirth", "1/1/1980");
            fnolDetails.EnterSelect("Sex", "Male");
            fnolDetails.EnterSelect("MaritalStatus", "Married");
            fnolDetails.EnterInput("DamageDescription", "Sample Desc");
            fnolDetails.EnterInput("TreatmentFacility", "PAMD");
            fnolDetails.EnterSelect("Fatality", "Yes");
            fnolDetails.EnterSelect("Tort", "Yes");
            fnolDetails.EnterInput("AdditionalNotes", "Sample Notes");

            Assert.That(() => fnolDetails.inputOtherInsurer.GetAttribute("value"), Does.Contain("AlphaC").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct input in FNOl Details");
            Assert.That(() => fnolDetails.inputTreatmentFacility.GetAttribute("value"), Does.Contain("PAMD").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct input in FNOl Details");

            //Submit details 
            fnolDetails.submitButton.Click();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Loss Details were saved."), "FNOL Details Were Not Saved");
        }

        /// <summary>
		/// Create a new contact in FNOL
		/// </summary>
        [TestCase, Order(37)]
        public void FNOlContacts()
        {
            Assert.That(() => driver.Url, Does.Contain("contacts").After(3).Seconds.PollEvery(250).MilliSeconds, "The driver is currently not at FNOL contacts page");

            //Click on New Contact
            fnolContacts.newContact.Click();
            Assert.That(() => driver.Url, Does.Contain("contacts/insert").After(2).Seconds.PollEvery(250).MilliSeconds, "The driver is currently not at FNOL contacts Creation page");

            //Inputs
            fnolContacts.EnterSelect("partyType", "Person");
            fnolContacts.EnterSelect("partyRole", "External Adjuster");
            fnolContacts.EnterInput("first", "Nathan");
            fnolContacts.EnterInput("middle", "J");
            fnolContacts.EnterInput("last", "Drake");
            fnolContacts.EnterInput("suffix", "Mr");
            fnolContacts.EnterInput("email", "nathandrake@email.com");
            fnolContacts.EnterInput("remarks", "Sample Remarks");
            fnolContacts.EnterSelect("phonetype", "Mobile");
            fnolContacts.EnterSelect("phonenumber", "8568482132");

            Assert.That(() => fnolContacts.inputFirstName.GetAttribute("value"), Does.Contain("Nathan").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct input in FNOl Contacts");
            Assert.That(() => fnolContacts.inputRemarks.GetAttribute("value"), Does.Contain("Sample Remarks").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct input in FNOl Contacts");

            //Submit Contact and Verify
            fnolContacts.addDocumentButton.Click();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Contact was successfully saved."), "FNOL Contact Was Not Saved");
            

        }



        /// <summary>
		/// Verify all tabs for policy are present
		/// </summary>
        [TestCase, Order(90)]
        public void VerifyPolicyTabs()
        {
            //List of tabs and for each loop to see if they are present
            string[] tabs = {   "Business Information", "Contacts", "UW Questions", 
                                "Policy Coverages", "Drivers", "Vehicles", "Trailers", 
                                "Additional Questions", "Modifiers", "Additional Interests",
                                "Summary", "Rate Calculation", "Documents", "Activities",
                                "Loss History","Policy History"
                                
                            };
            //foreach (string i in tabs)
            //{
            //    bool verifyTab = components.CheckIfTabPresent(i);
            //    Assert.IsTrue(verifyTab, "Tab " + i + " not found");
            //}
        }

        /// <summary>
		/// Verify all tabs for policy are present
		/// </summary>
        [TestCase, Order(91)]
        public void CreatePolicyContact()
        {
            //Navigate to contacts tab in policy details
            policyMain.contactsLink.Click();
            Assert.That(() => driver.Url, Does.Contain("contacts").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Navigate To Contacts Tab");

            //Click New Contact
            policyContacts.ClickAddContact();
            Assert.That(() => driver.Url, Does.Contain("contacts/insert").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable To Click Add New Button/Navigate to contact insert screen");

            //inputs
            policyContacts.EnterInput("first", "John");
            policyContacts.EnterSelect("party", "Customer Service Representative");
            policyContacts.EnterInput("middle", "J");
            policyContacts.EnterInput("last", "Smith");
            policyContacts.EnterInput("suffix", "Mr");
            policyContacts.EnterInput("email", "Jsmith@gmail.com");
            policyContacts.EnterInput("job", "Developer");
            policyContacts.EnterInput("company", "BiBerk");
            policyContacts.EnterInput("internet", "Biberk.com");
            policyContacts.EnterInput("remarks", "Mobile");
            policyContacts.EnterInput("phonenumber", "3469994485");
            policyContacts.EnterSelect("phonetype", "Mobile");
            Assert.That(() => policyContacts.inputFirstName.Text, Is.EqualTo("John").After(3).Seconds.PollEvery(250).MilliSeconds, "Unable to enter correct input");

            //Submit contact and verify via toast
            policyContacts.SubmitContact();
            string verifyToast = toaster.GetToastTitle();
            Assert.That(verifyToast, Does.Contain("Contact was successfully saved."), "Contact was not submitted");
        }



    }
}
