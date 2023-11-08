using BiBerkLOB.Pages.PL;
using HitachiQA.Helpers;
using System.Linq;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BiBerkLOB.StepDefinition.General.PL.Automation;
using HitachiQA.Driver;
using OpenQA.Selenium;

namespace BiBerkLOB.StepDefinition.General.PL
{
    [Binding]
    public sealed class PL_Gen_Summary
    {
        private readonly PLSummaryObject _plSummaryObject;

        public PL_Gen_Summary(PLSummaryObject plSummaryObject)
        {
            _plSummaryObject = plSummaryObject;
        }

        [Then(@"user verifies the appearance of the PL Summary page")]
        public void ThenUserVerifiesPLSummaryPage()
        {
            var summaryCards = new List<SummaryCardObj>();

            foreach (var section in SummarySections)
            {
                summaryCards.Add(CreateSummaryCard(section));
            }

            foreach (var card in summaryCards)
            {
                card.TitleElement.AssertElementIsVisible();
                card.TitleElement.AssertElementContainsText(card.Title);
                card.EditIcon.AssertElementIsVisible();
                ValidateStatments(card.SummaryStatements);
            }

            PL_YourSummaryPage.YourSummaryBottomViewQuoteButton.AssertElementIsVisible();
            PL_YourSummaryPage.YourSummaryBottomViewQuoteButton.Click();
        }

        public SummaryCardObj CreateSummaryCard(string section)
        {
            var summaryCard = new SummaryCardObj();
            summaryCard.Title = section;

            switch (section)
            {
                case "A Quick Introduction":
                    summaryCard.TitleElement = PL_YourSummaryPage.QuickIntroduction;
                    summaryCard.EditIcon = PL_YourSummaryPage.QuickIntroductionEdit;
                    summaryCard.SummaryStatements = GetListOfStatements(CreateQuickIntroPropMap());
                    break;
                case "Business Details":
                    summaryCard.TitleElement = PL_YourSummaryPage.BusDetails;
                    summaryCard.EditIcon = PL_YourSummaryPage.BusDetailsEdit;
                    summaryCard.SummaryStatements = GetListOfStatements(CreateBusDetailsPropMap());
                    break;
                case "Coverage Details":
                    summaryCard.TitleElement = PL_YourSummaryPage.CoverageDetailsTitle;
                    summaryCard.EditIcon = PL_YourSummaryPage.CoverageDetailsEdit;
                    summaryCard.SummaryStatements = GetListOfStatements(CreateCovDetailsPropMap());
                    break;
                case "Your Services":
                    summaryCard.TitleElement = PL_YourSummaryPage.YourServicesTitle;
                    summaryCard.EditIcon = PL_YourSummaryPage.YourServicesEdit;
                    summaryCard.SummaryStatements = GetYourServicesStatements();
                    break;
                case "About You":
                    summaryCard.TitleElement = PL_YourSummaryPage.AboutYouTitle;
                    summaryCard.EditIcon = PL_YourSummaryPage.AboutYouEdit;
                    summaryCard.SummaryStatements = GetListOfStatements(CreateAboutYouPropMap());
                    break;
            }
            return summaryCard;
        }

        public void ValidateStatments(List<SummaryStatementObj> listOfStatements)
        {
            foreach (var statement in listOfStatements)
            {
                if (statement.QuestionElement != null)
                {
                    statement.QuestionElement.AssertElementIsVisible();
                    statement.QuestionElement.AssertElementContainsText(statement.QuestionText);
                }

                statement.AnswerElement.AssertElementIsVisible();
                statement.AnswerElement.AssertElementContainsText(statement.AnswerText);
            }
        }
        public List<SummaryStatementObj> GetYourServicesStatements()
        {
            var questAnswerList = _plSummaryObject.PLServicesObjectList.Where(e => e.QuestionSentence.Equals("")).ToList();
            var sentenceList = _plSummaryObject.PLServicesObjectList.Where(e => e.QuestionSentence != string.Empty);
            var sentenceListYes = sentenceList.Where(e => e.QuestionAnswer.Equals("Yes")).ToList();
            var sentenceListNo = sentenceList.Where(e => e.QuestionAnswer.Equals("No")).ToList();
            var listOfStatements = new List<SummaryStatementObj>();

            foreach (var questAnswer in questAnswerList)
            {
                var questionElement = PL_YourSummaryPage.YourServicesQST(questAnswer.QuestionID);
                var answerElement = PL_YourSummaryPage.YourServicesAnswer(questAnswer.QuestionID);
                var parsedSentence = ParseCheckListOptions(questAnswer.QuestionAnswer);

                var yourServicesStatement = new SummaryStatementObj(questAnswer.QuestionText, parsedSentence, questionElement, answerElement);

                listOfStatements.Add(yourServicesStatement);
            }

            foreach (var sentence in sentenceListYes)
            {
                var answerElement = PL_YourSummaryPage.YourServicesYouDO(sentence.QuestionSentence);
                var yourServicesStatement = new SummaryStatementObj(sentence.QuestionText, sentence.QuestionSentence, null, answerElement);

                listOfStatements.Add(yourServicesStatement);
            }

            foreach (var sentence in sentenceListNo)
            {
                var answerElement = PL_YourSummaryPage.YourServicesYouDoNOT(sentence.QuestionSentence);
                var yourServicesStatement = new SummaryStatementObj(sentence.QuestionText, sentence.QuestionSentence, null, answerElement);

                listOfStatements.Add(yourServicesStatement);
            }

            return listOfStatements;
        }

        public string ParseCheckListOptions(string rawString)
        {
            if (rawString.Contains(';'))
            {
                var rgx = new Regex(@"[^;]+");
                var match = rgx.Match(rawString);
                var listOfOptions = new List<string>();

                while (match.Success)
                {
                    listOfOptions.Add(match.ToString());
                    match = match.NextMatch();
                }

                return string.Join(", ", listOfOptions);
            }
            else
            {
                return rawString;
            }
        }

        public List<SummaryStatementObj> GetListOfStatements(Dictionary<string, string> propertiesMap)
        {
            var rawStatements = CreatePropertyToSummaryStatementMap();
            var listOfStatements = new List<SummaryStatementObj>();

            foreach (var entry in propertiesMap)
            {
                if (entry.Value != "")
                {
                    foreach (var StatementEntry in rawStatements)
                    {
                        if (StatementEntry.Key == entry.Key)
                        {
                            listOfStatements.Add(StatementEntry.Value);
                        }
                    }
                }
            }

            return listOfStatements;
        }

        public string ParsePhoneNumber(string rawPhoneNumber)
        {
            var regex = new Regex(@"\d");
            var i = 1;
            var areaCode = "";
            var prefix = "";
            var suffix = "";
            var ext = "";
            var match = regex.Match(rawPhoneNumber);

            while (match.Success)
            {
                if (i < 4) areaCode = $"{areaCode}{match}";
                if (i >= 4 && i < 7) prefix = $"{prefix}{match}";
                if (i >= 7 && i < 11) suffix = $"{suffix}{match}";
                if (i >= 11) ext = $"{ext}{match}";
                i++;
                match = match.NextMatch();
            }

            if (ext != "")
            {
                return $"({areaCode}) {prefix}-{suffix} x{ext}";
            }
            else
            {
                return $"({areaCode}) {prefix}-{suffix}";
            }
        }

        public string GetSummaryDate(string unformattedDate)
        {
            if (unformattedDate != string.Empty)
            {
                return Functions.ReformatDateString(unformattedDate, "MMMM d, yyyy");
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetFullName(string a, string b)
        {
            if (a != "" && b != "")
            {
                return $"{a} {b}";
            }
            else
            {
                return string.Empty;
            }
        }

        public string ParseAddress()
        {
            var Add = _plSummaryObject.BusAddress;
            var City = _plSummaryObject.BusCity;
            var St = _plSummaryObject.BusState;
            var Zip = _plSummaryObject.BusZipCode;
            var Add2 = _plSummaryObject.BusAddress2;
            string theAddress = "";

            if (_plSummaryObject.BusAddress2.Equals(""))
            {
                //parse without address2
                theAddress = $"{Add}, {City}, {St} {Zip}";
            }
            else
            {
                //parse with address2
                theAddress = $"{Add}, {Add2}, {City}, {St} {Zip}";
            }
            return theAddress;
        }

        public List<string> SummarySections = new List<string>
        {
            "A Quick Introduction",
            "Business Details",
            "Coverage Details",
            "Your Services",
            "About You",
        };

        public Dictionary<string, string> CreateQuickIntroPropMap()
        {
            return new Dictionary<string, string>
            {
                { "BusStruct", _plSummaryObject.BusinessStruct },
                { _plSummaryObject.BusinessNameLabel, _plSummaryObject.BusinessName },
                { "DBA", _plSummaryObject.DBA }
            };
        }

        public Dictionary<string, string> CreateBusDetailsPropMap()
        {
            return new Dictionary<string, string>
            {
                { "YearBusStarted", _plSummaryObject.YearBusStarted },
                { "GrossRev", _plSummaryObject.GrossRev },
                { "SOW", _plSummaryObject.SOW },
                { "HowManyAttorneys", _plSummaryObject.HowManyAttorneys },
                { "ContractAttorneys", _plSummaryObject.ContractAttorneys },
                { "FTCounselIndepenAttorneys", _plSummaryObject.FTCounselIndepenAttorneys },
                { "PTCounselIndepenAttorneys", _plSummaryObject.PTCounselIndepenAttorneys },
                { "SignOffWrittenContracts", _plSummaryObject.SignOffWrittenContracts },
                { "HowManyHealthProf", _plSummaryObject.HowManyHealthProf },
                { "AnyHealthStudents", _plSummaryObject.AnyHealthStudents },
                { "NumOfHealthStudents", _plSummaryObject.NumOfHealthStudents },
                { "HealthContractorOrEmployee", _plSummaryObject.HealthContractorOrEmployee },
                { "HealthCareDesignationWithin2Years", _plSummaryObject.HealthCareDesignationWithin2Years },
                { "HealthCareDesignationDate", _plSummaryObject.HealthCareDesignationDate },
            };
        }

        public Dictionary<string, string> CreateCovDetailsPropMap()
        {
            return new Dictionary<string, string>
            {
                { "DateCovStarts", _plSummaryObject.DateCovStarts },
                { "RetroDate", _plSummaryObject.RetroDate },
                { "PLIn3years", _plSummaryObject.PLIn3years },
                { "CurrentRetroDate", _plSummaryObject.CurrentRetroDate },
                { "CurrentlyHavePL", _plSummaryObject.CurrentlyHavePL },
                { "HowManyClaims", _plSummaryObject.HowManyClaims },
                { "CurrentlyProLiability", _plSummaryObject.CurrentlyProLiability }
            };
        }

        public Dictionary<string, string> CreateAboutYouPropMap()
        {
            return new Dictionary<string, string>
            {
                { "ContactName", _plSummaryObject.ContactFirstName },
                { "BusAddress", _plSummaryObject.BusAddress },
                { "BusAddress2", _plSummaryObject.BusAddress2 },
                { "BusCity", _plSummaryObject.BusCity },
                { "BusState", _plSummaryObject.BusState },
                { "BusZipCode", _plSummaryObject.BusZipCode },
                { "BusEmail", _plSummaryObject.BusEmail },
                { "BusPhone", _plSummaryObject.BusPhone },
                { "BusExtPhone", _plSummaryObject.BusExtPhone },
                { "BusWebSocialPage", _plSummaryObject.BusWebSocialPage },
                { "HaveBrokerAccount", _plSummaryObject.HaveBrokerAccount },
                { "ManagerName", _plSummaryObject.ManagerFirstName },
                { "ManagerPhone", _plSummaryObject.ManagerPhone },
                { "ManagerPhoneExt", _plSummaryObject.ManagerPhoneExt },
                { "ManagerEmail", _plSummaryObject.ManagerEmail },
                { "YearlyOrMonthly", _plSummaryObject.YearlyOrMonthly },
            };
        }

        public Dictionary<string, SummaryStatementObj> CreatePropertyToSummaryStatementMap()
        {
            return new Dictionary<string, SummaryStatementObj>
            {
                // A Quick Introduction
                { "BusStruct", new SummaryStatementObj("The structure of your business is:", _plSummaryObject.BusinessStruct, PL_YourSummaryPage.StructOfBusQST, PL_YourSummaryPage.StructOfBusAnswer) },
                { "BusName", new SummaryStatementObj("The name of your business is:", _plSummaryObject.BusinessName, PL_YourSummaryPage.NameOfBusQST, PL_YourSummaryPage.NameOfBusAnswer) },
                { "IndiBusName", new SummaryStatementObj("The name you do business under is:", $"{_plSummaryObject.InsuredFirstName} {_plSummaryObject.InsuredLastName}", PL_YourSummaryPage.BusNameQST, PL_YourSummaryPage.BusNameAnswer) },
                { "DBA", new SummaryStatementObj("Other business names you use include:", _plSummaryObject.DBA, PL_YourSummaryPage.OtherBusNameQST, PL_YourSummaryPage.OtherBusNameAnswer) },
                // Business Details
                { "YearBusStarted", new SummaryStatementObj("Your business was started in the year:", _plSummaryObject.YearBusStarted, PL_YourSummaryPage.BusStartedYearQST, PL_YourSummaryPage.BusStartedYearAnswer) },
                { "GrossRev", new SummaryStatementObj("Your estimated gross annual revenue is:", _plSummaryObject.GrossRev, PL_YourSummaryPage.EstGrossAnnualRevQST, PL_YourSummaryPage.EstGrossAnnualRevAnswer) },
                { "SOW", new SummaryStatementObj("You use a written contract or statement of work (SOW):", _plSummaryObject.SOW, PL_YourSummaryPage.UseSOWQST, PL_YourSummaryPage.UseSOWAnswer) },
                { "HowManyAttorneys", new SummaryStatementObj(null, _plSummaryObject.HowManyAttorneys, null, PL_YourSummaryPage.NumAttorneysStmt) },
                { "ContractAttorneys", new SummaryStatementObj(null, _plSummaryObject.ContractAttorneys, null, PL_YourSummaryPage.UseCounselIndepConAttorneys) },
                { "FTCounselIndepenAttorneys", new SummaryStatementObj(null, _plSummaryObject.FTCounselIndepenAttorneys, null, PL_YourSummaryPage.FTCounselIndepConAttorneys) },
                { "PTCounselIndepenAttorneys", new SummaryStatementObj(null, _plSummaryObject.PTCounselIndepenAttorneys, null, PL_YourSummaryPage.PTCounselIndepConAttorneys) },
                { "SignOffWrittenContracts", new SummaryStatementObj("Changes to written contracts or SOWs are approved by:", _plSummaryObject.SignOffWrittenContracts, PL_YourSummaryPage.ChangesToSOWsQST, PL_YourSummaryPage.ChangesToSOWsAnswer) },
                { "HowManyHealthProf", new SummaryStatementObj(null, _plSummaryObject.HowManyHealthProf, null, PL_YourSummaryPage.NumOfHealthProf_Stmnt) },
                { "AnyHealthStudents", new SummaryStatementObj(null, _plSummaryObject.AnyHealthStudents, null, PL_YourSummaryPage.HealthStudents_Stmnt) },
                { "NumOfHealthStudents", new SummaryStatementObj(null, _plSummaryObject.NumOfHealthStudents, null, PL_YourSummaryPage.NumOfHealthStudents_Stmnt) },
                { "HealthContractorOrEmployee", new SummaryStatementObj(null, _plSummaryObject.HealthContractorOrEmployee, null, PL_YourSummaryPage.HealthCareWorkerStatus) },
                { "HealthCareDesignationWithin2Years", new SummaryStatementObj(null, _plSummaryObject.HealthCareDesignationWithin2Years, null, PL_YourSummaryPage.HealthCareDesignation) },
                { "HealthCareDesignationDate", new SummaryStatementObj("Your healthcare designation date is:", _plSummaryObject.HealthCareDesignationDate, PL_YourSummaryPage.HealthCareDesignationDateTitle, PL_YourSummaryPage.HealthCareDesignationDate) },
                // Coverage Details
                { "DateCovStarts", new SummaryStatementObj("Your policy should start:", GetSummaryDate(_plSummaryObject.DateCovStarts), PL_YourSummaryPage.PolicyStartQST, PL_YourSummaryPage.PolicyStartAnswer) },
                { "CurrentlyHavePL", new SummaryStatementObj(null, _plSummaryObject.CurrentlyHavePL, null, PL_YourSummaryPage.CurrentlyHavePL_Stmt) },
                { "CurrentlyProLiability", new SummaryStatementObj(null, _plSummaryObject.CurrentlyProLiability, null, PL_YourSummaryPage.CurrentlyHavePL_Stmt) },
                { "RetroDate", new SummaryStatementObj("Your retroactive date is", GetSummaryDate(_plSummaryObject.RetroDate), PL_YourSummaryPage.RetroDateQST, PL_YourSummaryPage.RetroDateAnswer) },
                { "CurrentRetroDate", new SummaryStatementObj(null, _plSummaryObject.CurrentRetroDate, null, PL_YourSummaryPage.RetroDate_Stmt) },
                { "HowManyClaims", new SummaryStatementObj(null, _plSummaryObject.HowManyClaims, null, PL_YourSummaryPage.NumClaims_Stmt) },
                // About You
                { "ContactName", new SummaryStatementObj("Your name is:", GetFullName(_plSummaryObject.ContactFirstName, _plSummaryObject.ContactLastName), PL_YourSummaryPage.YourNameQST, PL_YourSummaryPage.YourNameAnswer) },
                { "BusAddress", new SummaryStatementObj("Your address is:", ParseAddress(), PL_YourSummaryPage.YourAddressQST, PL_YourSummaryPage.YourAddressAnswer) },
                { "BusEmail", new SummaryStatementObj("We can contact you at:", _plSummaryObject.BusEmail, PL_YourSummaryPage.ContactYouQST, PL_YourSummaryPage.YourEmailAnswer) },
                { "BusPhone", new SummaryStatementObj(null, ParsePhoneNumber($"{_plSummaryObject.BusPhone}x{_plSummaryObject.BusExtPhone}"), null, PL_YourSummaryPage.YourPhoneNumAnswer) },
                { "BusWebSocialPage", new SummaryStatementObj("Your website is:", _plSummaryObject.BusWebSocialPage, PL_YourSummaryPage.YourWebsiteQST, PL_YourSummaryPage.YourWebsiteAnswer) },
                { "ManagerName", new SummaryStatementObj("Manager’s name is:", GetFullName(_plSummaryObject.ManagerFirstName, _plSummaryObject.ManagerLastName), PL_YourSummaryPage.MngrNameQST, PL_YourSummaryPage.MngrNameAnswer) },
                { "ManagerEmail", new SummaryStatementObj("We can contact the manager at:", _plSummaryObject.ManagerEmail, PL_YourSummaryPage.MngrContactQST, PL_YourSummaryPage.ManagerEmail) },
                { "ManagerPhone", new SummaryStatementObj(null, ParsePhoneNumber($"{_plSummaryObject.ManagerPhone}x{_plSummaryObject.ManagerPhoneExt}"), null, PL_YourSummaryPage.MngrPhoneNumAnswer) },
            };
        }
    }
}