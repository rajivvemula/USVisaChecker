using BiBerkLOB.Pages;
using HitachiQA.Driver;
using HitachiQA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using BiBerkLOB.StepDefinition.General;
using HitachiQA;

namespace BiBerkLOB.General
{
    [Binding]
    public sealed class General_WorkersCompQuestions
    {
        //When do you want your policy to start?
        [Given(@"user selects When do you want your policy to start")]
        public void GivenUserSelectsPolicyStartDate()
        {
            //verifies URL is still on the correct environment
            General_SiteWide.AssertEnvironmentURL();
            UnderwritersQuestionPage.PolicyStartDate.AssertElementIsVisible();
            UnderwritersQuestionPage.PolicyStartDate.ClearTextField();
            UnderwritersQuestionPage.PolicyStartDate.SetText(Functions.GetNextDay("MM/dd/yyyy"));
        }

        //When did you start your business?
        [Given(@"user selects When did you start your business (.*)")]
        public void GivenWhenUserStartedBusiness(string p0, Table table)
        {
            UnderwritersQuestionPage.WhenDidStartYourBusQST.AssertElementIsVisible();
            UnderwritersQuestionPage.YearsBusinessDD.SelectDropdownOptionByText(p0);
        }

        //How is your business structured?
        [Given(@"user selects How is your business structured (.*)")]
        public void GivenBusinessStructure (string p0, Table table)
        {
            UnderwritersQuestionPage.BusinessStructuredQst.AssertElementIsVisible();
            UnderwritersQuestionPage.BusinessTypeDD.SelectDropdownOptionByText(p0);
        }

        // (Optional) Do you want to include coverage for any owners/officers?
        [Given(@"user selects Do you want to include coverage for any owners/officers (.*)")]
        public void OwnerOfficerCoverage(string option, Table table)
        {
            UnderwritersQuestionPage.IncludedCoverageForAnyOwnersOfficersQst.AssertElementIsVisible();
            UnderwritersQuestionPage.IncludedCoverageForAnyOwnersOfficersDD.SelectDropdownOptionByText(option);
        }

        // (Optional) Do you want to buy coverage for the business owners?
        [Given(@"user selects (.*) for Do you want to buy coverage for the business owners")]
        public void BuyCoverageBusinessOwners(string option)
        {
            UnderwritersQuestionPage.DoYouWantCoverageForBusOwnersQST.AssertElementIsVisible();
            UnderwritersQuestionPage.DoYouWantCoverageForBusOwnersDD.SelectDropdownOptionByText(option);
        }

        // (Optional) How many owners/officers are there?
        [Given(@"user selects (.*) for How many owners/officers are there")]
        public void HowManyOwnerOfficersAreThere (string option)
        {
            UnderwritersQuestionPage.HowManyOwnersOfficersAreThereQST.AssertElementIsVisible();
            UnderwritersQuestionPage.HowManyOwnersOfficersAreThereDD.SelectDropdownOptionByText(option);
        }

        // Do any included owners/officers only do general office work and rarely travel?
        [Given(@"user selects option (.*) for Do any included owners/officers only do general office work and rarely travel")]
        public void GivenUserSelectsOption_ForDoAnyIncludedOwnersOfficersOnlyDoGeneralOfficeWorkAndRarelyTravel(string option, Table table)
        {
            UnderwritersQuestionPage.IncludedOwnerOfficersRarelyTravelQST.AssertElementIsVisible();
            UnderwritersQuestionPage.IncludedOwnerOfficersRarelyTravelDD.SelectDropdownOptionByText(option);               
        }

        // Do any owners/officers only do general office work and do not work a cash register?
        [Given(@"user selects option (.*) for Do any owners/officers only do general office work and do not work a cash register")]
        public void GivenUserSelectsOption_ForDoAnyIncludedOwnersOfficersOnlyDoGeneralOfficeWorkAndNoCashRegister(string option)
        {
            UnderwritersQuestionPage.IncludedOwnerOfficerDoNOtWorkCashRegisterQST.AssertElementIsVisible();
            UnderwritersQuestionPage.IncludedOwnerOfficerDoNOtWorkCashRegisterDD.SelectDropdownOptionByText(option);
        }

        //Do any owners/officers only do general office work and rarely travel?
        [Given(@"user selects option (.*) for Do any owners/officers only do general office work and rarely travel")]
        public void GivenUserSelects_AnyOwnerOffOnlyDoGeneralOfficeWorkRarelyTravel (string option)
        {
            UnderwritersQuestionPage.OwnerOfficerRarelyTravelQST.AssertElementIsVisible();
            UnderwritersQuestionPage.OwnerOfficerRarelyTravelDD.SelectDropdownOptionByText(option);
        }

        //What is the total annual payroll for W-2 employees? (exclude business owners/officers)
        [Given(@"user enters What is the total annual payroll for W-2 employees (.*)")]
        public void PayrollAmount(string p0)
        {
            UnderwritersQuestionPage.PayrollW2Qst.AssertElementIsVisible();
            UnderwritersQuestionPage.MoreAboutPayrollInfo.Click();
            UnderwritersQuestionPage.Info1.AssertElementIsVisible();
            UnderwritersQuestionPage.Info2.AssertElementIsVisible();
            UnderwritersQuestionPage.Info3.AssertElementIsVisible();
            UnderwritersQuestionPage.LessAboutPayrollInfo.Click();
            UnderwritersQuestionPage.PayrollAmount.SetText(p0);
        }

        //user clicks on Yes CTA for Do any employees only do general office work and do not work a cash register
        [Given(@"user clicks on (.*) CTA for Do any employees only do general office work and do not work a cash register")]
        public void EmployeeGeneralWork(string option)
        {
            UnderwritersQuestionPage.RegisterCashQST.AssertElementIsVisible();
            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.RegisterCashYesCTA.Click();
                UnderwritersQuestionPage.RegisterCashTAP.SetText((Functions.GetRandomStringWithRestrictions(4, "numeric")));
            }
            else
            {
                UnderwritersQuestionPage.RegisterCashNoCTA.Click();
            }

        }
        //Do any employees only do general office work and rarely travel?
        [Given(@"user clicks on (.*) for Do any employees only do general office work and rarely travel and for annual payroll \$([0-9]*)")]
        public void GivenUserClicksOnNoForDoAnyEmployeesOnlyDoGeneralOfficeWorkAndRarelyTravelAndForAnnualPayroll(string option, string amount)
        {
            UnderwritersQuestionPage.EmployeeTravelQST.AssertElementIsVisible();

            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.EmployeeTravelYesCTA.Click();
                UnderwritersQuestionPage.EmployeeTravelAmount.SetText(amount);
            }
            else
            {
                UnderwritersQuestionPage.EmployeeTravelNoCTA.Click();
            }
        }

        //Are there any employees that never travel to job sites or do any construction work? 
        [Given(@"user clicks (.*) for Are there any employees that never travel to job sites or do any construction work")]
        public void GivenUserClicks_ForAreThereAnyEmployeesThatNeverTravelToJobSitesOrDoAnyConstructionWork(string option)
        {
            UnderwritersQuestionPage.AnyEmployeesNeverTrvlToJobSitesOrConstrWorkQST.AssertElementIsVisible();

            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.AnyEmployeesNeverTrvlToJobSitesOrConstrWorkYes.AssertElementIsVisible();
                UnderwritersQuestionPage.AnyEmployeesNeverTrvlToJobSitesOrConstrWorkYes.Click();
            }
            else
            {
                UnderwritersQuestionPage.AnyEmployeesNeverTrvlToJobSitesOrConstrWorkNo.AssertElementIsVisible();
                UnderwritersQuestionPage.AnyEmployeesNeverTrvlToJobSitesOrConstrWorkNo.Click();
            }
        }

        //Does your business have a state-issued experience modification factor (XMOD)?
        [Given(@"user clicks (.*) for Does your business have a state-issued experience modification factor \(XMOD\)\?")]
        public void AndUserClicks_DoesYourBusinessHaveAStateIssuedXMOD(string option)
        {
            AndUserClicks_DoesYourBusinessHaveXMODAndXMODIs(option, "");
        }

        //Does your business have a state-issued experience modification factor (XMOD)? Enter the value for experience modification factor:
        [Given(@"user clicks (.*) for Does your business have a state-issued experience modification factor \(XMOD\)\? and the XMOD is (.*)")]
        public void AndUserClicks_DoesYourBusinessHaveXMODAndXMODIs(string option, string xmod)
        {
            UnderwritersQuestionPage.XMODQST.AssertElementIsVisible();

            if (option.Equals("no")) { UnderwritersQuestionPage.XMODNoCTA.Click(); }
            else if (option.Equals("don't know")) { UnderwritersQuestionPage.XMODDontKnowCTA.Click(); }
            else
            {
                UnderwritersQuestionPage.XMODYesCTA.Click();
                UnderwritersQuestionPage.XMODInput.SetText(xmod);
            }
        }

        //Do you build any load-bearing concrete walls?
        [Then(@"user clicks (.*) for Do You build any load-bearing concrete walls")]
        public void ThenUserClicksBuildAnyLoadBearingConcreteWalls(string option)
        {
            UnderwritersQuestionPage.BuildLoadBearingConcreteWallsQST.AssertElementIsVisible();

            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.BuildLoadBearingConcreteWallsYes.AssertElementIsVisible();
                UnderwritersQuestionPage.BuildLoadBearingConcreteWallsYes.Click();
            }
            else
            {
                UnderwritersQuestionPage.BuildLoadBearingConcreteWallsNo.AssertElementIsVisible();
                UnderwritersQuestionPage.BuildLoadBearingConcreteWallsNo.AssertElementIsVisible();
            }

        }

        //Do you do any masonry work such as manual brick or stone laying?
        [Given(@"user clicks (.*) for Do you do any masonry work such as manual brick or stone laying")]
        public void ThenUserClicksMasonryWorkLikeManualBrickOrStoneLaying(string option)
        {
            UnderwritersQuestionPage.MasonryWorkSuchManualBrickOrStoneLayingQST.AssertElementIsVisible();

            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.MasonryWorkSuchManualBrickOrStoneLayingYes.AssertElementIsVisible();
                UnderwritersQuestionPage.MasonryWorkSuchManualBrickOrStoneLayingYes.Click();
            }
            else
            {
                UnderwritersQuestionPage.MasonryWorkSuchManualBrickOrStoneLayingNo.AssertElementIsVisible();
                UnderwritersQuestionPage.MasonryWorkSuchManualBrickOrStoneLayingNo.Click();
            }

        }

        //Do you do residential foundation work?
        [Then(@"user clicks (.*) for Do you do residential foundation work")]
        public void ThenUserClicksDoResidentialFoundationWork(string option)
        {
            UnderwritersQuestionPage.ResidentialFoundationWorkQST.AssertElementIsVisible();

            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.ResidentialFoundationWorkYes.AssertElementIsVisible();
                UnderwritersQuestionPage.ResidentialFoundationWorkYes.Click();
            }
            else
            {
                UnderwritersQuestionPage.ResidentialFoundationWorkNo.AssertElementIsVisible();
                UnderwritersQuestionPage.ResidentialFoundationWorkNo.Click();
            }
        }


        //Enter the value for experience modification factor:
        [Given(@"user enters (.*) for Enter the value for experience modification factor")]
        public void EnterValueForExpModFactor(string modFactor)
        {
            UnderwritersQuestionPage.TitleEnterValueForExperienceXMOD.AssertElementIsVisible();
            UnderwritersQuestionPage.XMODInput.SetText(modFactor);
        }

        //Federal Employer Identification Number (FEIN)
        [Given(@"user enters their Tax id type Federal Employer Identification Number is (.*)")]
        public void FEIN(string p0)
        {
            UnderwritersQuestionPage.MoreAboutXMODCTA.Click();
            UnderwritersQuestionPage.MoreAboutXMODInfo.AssertElementIsVisible();
            UnderwritersQuestionPage.LessAboutXMODCTA.Click();
            UnderwritersQuestionPage.FEINOrSSN.SetText(p0);
        }

        //In the past 3 years how many Workers' Compensation claims were reported?
        [Given(@"user clicks In the past 3 years how many Workers Compensation claims were reported (.*)")]
        public void WCClaims(string p0, Table table)
        {
            UnderwritersQuestionPage.PastThreeYearsWCClaimsRepotedQst.AssertElementIsVisible();
            UnderwritersQuestionPage.ClaimWereReportedDD.SelectDropdownOptionByText(p0);
        }

        //Do you currently have a Workers Compensation insurance policy in effect? 
        [Given(@"user clicks (.*) for Do you currently have a Workers Compensation insurance policy in effect and user select (.*) from the When was your last policy in effect dropdown and user select option (.*) for Has there been any worker injuries or accidents since the last policy was in effect General")]
        public void WCPolicy(string option, string select, string hasThereBeenInjuries, Table table)
        {
            UnderwritersQuestionPage.WCInsurancePolicyInEffectQst.AssertElementIsVisible();
            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.WCInsurancePolicyInEffectYes.Click();
            }

            else
            {
                UnderwritersQuestionPage.WCInsurancePolicyInEffectNo.Click();
                UnderwritersQuestionPage.WhenWasYourPolInEffectQst.AssertElementIsVisible();
                UnderwritersQuestionPage.WhenWasYourPolicyInEffectDD.SelectDropdownOptionByText(select);
                if(select.Equals("30 days to 6 months ago") || select.Equals("More than 6 months ago"))
                {
                    UnderwritersQuestionPage.HasThereBeenWorkersInjuriesQST.AssertElementIsVisible();
                    UnderwritersQuestionPage.HasThereBeenWorkersInjuriesDD.SelectDropdownOptionByText(hasThereBeenInjuries);
                }
            }

        }

        //Do any owner operators or sub-haulers transport goods on your behalf?
        [Given(@"user clicks (.*) for Do any owner operators or sub-haulers transport goods on your behalf")]
        public void OOSubHaulersTransportGoodsOnBehalf(string answer)
        {
            UnderwritersQuestionPage.SubHaulersTransportQST.AssertElementIsVisible();
            if (answer.Equals("Yes"))
            {
                UnderwritersQuestionPage.SubHaulersTransportYesCTA.Click();
            }
            else
            {
                UnderwritersQuestionPage.SubHaulersTransportNoCTA.Click();
            }
        }

        [Given(@"user clicks on (.*) CTA for Do you use any volunteers or donated labor and user enters percantage (.*) for What percentage of workers are volunteers or donated labor donated labor")]
        public void GivenUserClicksOnNoCTAForDoYouUseAnyVolunteersOrDonatedLaborAndUserEntersPercantageForWhatPercentageOfWorkersAreVolunteersOrDonatedLaborDonatedLabor(string option, string percantage)
        {
            UnderwritersQuestionPage.VolunteersOrDonatedQST.AssertElementIsVisible();
            if (option.Equals("Yes"))
            {
                UnderwritersQuestionPage.VolunteersOrDonatedYesCTA.Click();
                UnderwritersQuestionPage.PercentageOfWorkersAreVolunteersOrDonatedLaborQST.AssertElementIsVisible();
                UnderwritersQuestionPage.VolunteersOrDonatedInput.SetText(percantage);
            }
            else
            {
                UnderwritersQuestionPage.VolunteersOrDonatedNoCTA.Click();
            }
        }

        //Do you have multiple locations in more than one state?
        [Given(@"user clicks (.*) for Do you have multiple locations in more than one state")]
        public void MultipleLoc(string p0)
        {
            UnderwritersQuestionPage.DoYouHaveMultLocationQst.AssertElementIsVisible();
            if (p0.Equals("Yes"))
            {
                UnderwritersQuestionPage.DoYouHaveMultLocationYes.Click();
            }
            else
            {
                UnderwritersQuestionPage.DoYouHaveMultLocationNo.Click();
            }
        }

        ///----------------------------------------------------------------------------------------------------------------------------------
        ///----------------------------------------------------------------------------------------------------------------------------------
        ///-----------This section is for various permutations of Business name, address-----------------------------------------------------

        //Business name, DBA, website
        [Given(@"user enters Business name (.*), DBA (.*) and website (.*)")]
        public void BusinessName(string businessName, string DBA, string website)
        {   if (businessName != DBA)
            {
                UnderwritersQuestionPage.BusinessName.SetText(businessName);
                UnderwritersQuestionPage.DoingBusinessAs.SetText(DBA);
                UnderwritersQuestionPage.BusinessWebsite.SetText(website);
            }
            else
            {
                UnderwritersQuestionPage.BusinessName.SetText(businessName);
                UnderwritersQuestionPage.BusinessWebsite.SetText(website);
            }   
        }

        [Given(@"user selects city from dropdown (.*)")]
        public void GivenUserSelectsCityFromDropdownSouthPlainfield(string city)
        {
            UnderwritersQuestionPage.CityDD.SelectDropdownOptionByText(city);
        }

        //Business address line 1
        //City
        [Given(@"user enters their Business address line 1 is (.*), and City is (.*)")]
        public void AddLine1City(string p0, string p1)
        {
            UnderwritersQuestionPage.BusinessAddressLine1.SetText(p0);
            UnderwritersQuestionPage.CityDD.SelectDropdownOptionByText(p1);
        }

        //Business address line 1
        //City is left as the one that gets populated automatically
        [Given(@"user enters their Business address is (.*)")]
        public void AddLine1(string p0)
        {
            UnderwritersQuestionPage.BusinessAddressLine1.SetText(p0);
        }

        [Given(@"user enters DBA (.*), website (.*)")]
        public void GivenUserEntersDBABakeryshopTestDBAWebsiteWww_BakeryshopTest_Com(string DBA, string website)
        {
            UnderwritersQuestionPage.DoingBusinessAs.SetText(DBA);
            UnderwritersQuestionPage.BusinessWebsite.SetText(website);
        }

        [Given(@"user enters adress line1 (.*), line2 (.*) and City is (.*)")]
        public void GivenAdressLineBakeryShopTestStAndLineAPTAndCityIsCliffsidePark(string addressLine1, string addressLine2, string city)
        {
            UnderwritersQuestionPage.BusinessAddressLine1.SetText(addressLine1);
            UnderwritersQuestionPage.BusinessAddressLine2.SetText(addressLine2);
            UnderwritersQuestionPage.CityDD.SelectDropdownOptionByText(city);           
        }

        [Given(@"user enters address line1 (.*), line2 (.*)")]
        public void GivenAdressLineAPTAndCity(string addressLine1, string addressLine2)
        {
            UnderwritersQuestionPage.BusinessAddressLine1.SetText(addressLine1);
            UnderwritersQuestionPage.BusinessAddressLine2.SetText(addressLine2);
        }

        [Given(@"user verifies State and ZIP Code")]
        public void GivenUserVerifiesStateAndZIPCode()
        {
            Log.Info(UnderwritersQuestionPage.State.GetAttribute("value"));
            Log.Info(UnderwritersQuestionPage.ZipCode.GetAttribute("value"));
        }

        ///-----------End of section for various permutations of Business name, address-----------------------------------------------------
        ///----------------------------------------------------------------------------------------------------------------------------------
        ///----------------------------------------------------------------------------------------------------------------------------------

        //Contact first name
        //Contact last name
        [Given(@"user enters their Contact first name, Contact last name is (.*), (.*)")]
        public void FirstLastName(string p0, string p1)
        {
            UnderwritersQuestionPage.ContactFirstName.SetText(p0);
            UnderwritersQuestionPage.ContactLastName.SetText(p1);
        }

        //Contact email
        [Given(@"user enters their Contact email (.*)")]
        public void Email(string p0)
        {
            UnderwritersQuestionPage.ContactEmail.SetText(p0);
        }

        //Contact phone
        [Given(@"user enters their Contact phone (.*)")]
        public void Phone(string p0)
        {
            UnderwritersQuestionPage.ContactPhone.SetText(p0);
        }

        [Given(@"user select (.*) for Are any owners/officers cost estimators that wouldn't do any direct physical work\?")]
        public void GivenUserSelectOptionForAreAnyOwnersOfficersCostEstimatorsThatWouldnTDoAnyDirectPhysicalWork(string option, Table table)
        {
            UnderwritersQuestionPage.CostEstimatorsQST.AssertElementIsVisible();
            UnderwritersQuestionPage.CostEstimatorsDD.SelectDropdownOptionByText(option);
        }

        //Submit
        [Given(@"user submits WC questions")]
        public void Submit()
        {
            UnderwritersQuestionPage.SubmitCTA.Click();
        }
    }
}
