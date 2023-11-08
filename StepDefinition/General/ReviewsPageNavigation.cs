using BiBerkLOB.Pages;
using DocumentFormat.OpenXml.Bibliography;
using HitachiQA.Driver;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General
{
    [Binding]
    public class ReviewsPageNavigation
    {
        [Then(@"user verifies the navigation to Reviews Page")]
        public void CustomerReviewRatingLinkToReviewsPage()
        {
            Reusable_PurchasePath.CustomerReviewRatingLink.AssertElementIsVisible();
            Reusable_PurchasePath.CustomerReviewRatingLink.Click();
           
            String ReviewsPageTitle = Setup.driver.Title;
            if (ReviewsPageTitle.StartsWith("Read What"))
            {
                Reusable_PurchasePath.Logo.Click();
            }
        }
    }
}