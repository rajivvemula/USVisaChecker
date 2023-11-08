using ApolloQA.Source.Helpers;
using BiBerkLOB.Pages;
using BiBerkLOB.Pages.CommAuto;
using HitachiQA;
using HitachiQA.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using BiBerkLOB.Source.Helpers;
using TechTalk.SpecFlow;

namespace BiBerkLOB.StepDefinition.General.CommAuto
{
    [Binding]
    public sealed class CA_Gen_ContactDetailsZipVerification
    {

        [Then(@"user enters contact information to validate zip code error:")]
        public void ThenUserEntersContactInformation(Table table)
        {
            var row = table.Rows[0];

            CA_ContactDetailsPage.OwnersZipTxtbox.SetText(row["Owner's Zip Code"]);
            CA_ContactDetailsPage.OwnersCityTxtbox.Click(2);
            CA_ContactDetailsPage.OwnersZipError.AssertElementIsVisible(2);
        }
    }
}