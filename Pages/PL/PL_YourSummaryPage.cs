using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_YourSummaryPage : Reusable_PurchasePath
    {
        /*
        *  Top of the Your Summary page ---------------------------------------------------------------------------------------
        */

        public static Element YourSummaryHeader => new Element(By.XPath("//h1[@data-qa='summary-header']"));
        public static Element YourSummarySubHeader => new Element(By.XPath("//h6[@data-qa='summary-subheader']"));
        public static Element YourSummaryTopViewQuoteButton => new Element(By.XPath("//button[@data-qa='go-to-quote-button']"));

        /*
         * A Quick Introduction -----------------------------------------------------------------------------------------------
         */
        public static Element QuickIntroduction => new Element(By.XPath("//span[@data-qa='summary-intro-label']"));
        public static Element QuickIntroductionEdit => new Element(By.XPath("//i[@data-qa='summary-go-to-intr-button']"));

        //The structure of your business is:
        public static Element StructOfBusQST => new Element(By.XPath("//div[@data-qa='summary-business-structure-title']"));
        public static Element StructOfBusAnswer => new Element(By.XPath("//div[@data-qa='summary-business-type']"));

        //The name of your business is:
        public static Element NameOfBusQST => new Element(By.XPath("//div[@data-qa='summary-business-name-title']"));
        public static Element NameOfBusAnswer => new Element(By.XPath("//div[@data-qa='summary-business-name']"));

        //The name you do business under is:
        public static Element BusNameQST => new Element(By.XPath("//div[@data-qa='summary-business-title2']"));
        public static Element BusNameAnswer => new Element(By.XPath("//div[@data-qa='summary-business-title2-name']"));

        //Other business names you use include:
        public static Element OtherBusNameQST => new Element(By.XPath("//div[@data-qa='summary-other-business-name-title']"));
        public static Element OtherBusNameAnswer => new Element(By.XPath("//div[@data-qa='summary-other-business-name']"));

        /*
         * Business Details -----------------------------------------------------------------------------------------------------
         */
        public static Element BusDetails => new Element(By.XPath("//span[@data-qa='summary-business-details-title']"));
        public static Element BusDetailsEdit => new Element(By.XPath("//i[@data-qa='summary-edit-business-details-button']"));

        //Your business was started in the year:
        public static Element BusStartedYearQST => new Element(By.XPath("//div[@data-qa='summary-business-started-title']"));
        public static Element BusStartedYearAnswer => new Element(By.XPath("//div[@data-qa='summary-business-start-year']"));

        //You currently work as an independent contractor (paid via 1099) OR You currently work as an employee of a health organization (paid via W-2).
        public static Element HealthCareWorkerStatus => new Element(By.XPath("//div[@data-qa='summary-healthcare-contractor-text']"));

        //You currently have obtained this professional healthcare designation within the last two years. OR You currently have not obtained this professional healthcare designation within the last two years.
        public static Element HealthCareDesignation => new Element(By.XPath("//div[@data-qa='summary-healthcare-designation']"));

        //Your healthcare designation date is: 
        public static Element HealthCareDesignationDateTitle => new Element(By.XPath("//div[@data-qa='summary-healthcare-designation-date-title']"));
        public static Element HealthCareDesignationDate => new Element(By.XPath("//div[@data-qa='summary-healthcare-designation-date']"));

        // # of healthcare professionals working for your business
        public static Element NumOfHealthProf_Stmnt => new Element(By.XPath("//div[@data-qa='summary-num-healthcare-pro']"));
        // if you do have healthcare students 
        public static Element HealthStudents_Stmnt => new Element(By.XPath("//div[@data-qa='summary-num-healthcare-students']"));
        // # of healthcare students
        public static Element NumOfHealthStudents_Stmnt => new Element(By.XPath("//div[@data-qa='summary-num-healthcare-student-employees']"));

        //# of attorneys in your firm.
        public static Element NumAttorneysStmt => new Element(By.XPath("//div[@data-qa='summary-num-on-staff-attorneys']"));

        // You currently use of counsel or independent contractor attorneys. OR You currently do not use of counsel or independent contractor attorneys. 
        public static Element UseCounselIndepConAttorneys => new Element(By.XPath("//div[@data-qa='summary-any-attorneys']"));

        //# of full-time of counsel or independent contractor attorneys.
        public static Element FTCounselIndepConAttorneys => new Element(By.XPath("//div[@data-qa='summary-num-fulltime-attorneys']"));

        //# of part-time of counsel or independent contractor attorneys.
        public static Element PTCounselIndepConAttorneys => new Element(By.XPath("//div[@data-qa='summary-num-parttime-attorneys']"));

        //Your estimated gross annual revenue is:
        public static Element EstGrossAnnualRevQST => new Element(By.XPath("//div[@data-qa='summary-gross-revenue-title']"));
        public static Element EstGrossAnnualRevAnswer => new Element(By.XPath("//div[@data-qa='summary-gross-revenue-amount']"));

        //You use a written contract or statement of work (SOW):
        public static Element UseSOWQST => new Element(By.XPath("//div[@data-qa='summary-use-SOW']"));
        public static Element UseSOWAnswer => new Element(By.XPath("//div[@data-qa='summary-written-contract-details']"));

        //Changes to written contracts or SOWs are approved by:
        public static Element ChangesToSOWsQST => new Element(By.XPath("//div[@data-qa='summary-approve-SOW-change']"));
        public static Element ChangesToSOWsAnswer => new Element(By.XPath("//div[@data-qa='summary-approve-contract-name']"));

        /*
         * Coverage Details
         */
        public static Element CoverageDetailsTitle => new Element(By.XPath("//span[@data-qa='coverage-title']"));
        public static Element CoverageDetailsEdit => new Element(By.XPath("//i[@data-qa='coverage-edit-button']"));
        //Your policy should start:
        public static Element PolicyStartQST => new Element(By.XPath("//div[@data-qa='coverage-policy-start-title']"));
        public static Element PolicyStartAnswer => new Element(By.XPath("//div[@data-qa='coverage-policy-start-date']"));
        //You currently [do not] have a Professional Liability (E&O) policy.
        public static Element CurrentlyHavePL_Stmt => new Element(By.XPath("//div[@data-qa='coverage-current-policy-title']"));
        //Your current policy has a retroactive date.
        public static Element RetroDate_Stmt => new Element(By.XPath("//div[@data-qa='coverage-any-retro']"));
        //Your retroactive date is:
        public static Element RetroDateQST => new Element(By.XPath("//div[@data-qa='coverage-retro-date-title']"));
        public static Element RetroDateAnswer => new Element(By.XPath("//div[@data-qa='coverage-retro-date']"));
        //You have had # claim(s) in the last three years.
        public static Element NumClaims_Stmt => new Element(By.XPath("//div[@data-qa='coverage-claims-count']"));

        /*
         *Your Services
         */
        public static Element YourServicesTitle => new Element(By.XPath("//span[@data-qa='your-services-title']"));
        public static Element YourServicesEdit => new Element(By.XPath("//i[@data-qa='your-services-edit-button']"));

        //general mapper for question/answer pairings
        public static Element YourServicesQST(string id) => new Element(By.XPath($"//div[@data-qa='{id}-services-question-text']"));
        public static Element YourServicesAnswer(string id) => new Element(By.XPath($"//div[@data-qa='{id}-services-answer-text']"));

        //You DO do the following:
        public static Element DoTheFollowing_Stmt => new Element(By.XPath("//div[@data-qa='services-DO']"));
        //You do NOT do the following:
        public static Element DNDoTheFollowing_Stmt => new Element(By.XPath("//div[@data-qa='services-DO-NOT']"));

        //general mapper to find services under "You DO the following:"
        public static Element YourServicesYouDO(string sentence) => new Element(By.XPath($"//li[@data-qa='services-do-{sentence}']"));
        //general mapper to find services under "You do NOT do the following:"
        public static Element YourServicesYouDoNOT(string sentence) => new Element(By.XPath($"//li[@data-qa='services-do-not-{sentence}']"));

        //------QST/Answer Pair covered by the general mapper-----------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //---MPL--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //Do you do workplace safety consulting for occupational hazards?
        //To whom do you provide training?
        //What training do you provide?
        //Describe the training you provide:
        //In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee?
        //Do you sell any Property & Casualty Insurance?
        //Which types of Property & Casualty insurance do you sell?
        //Which types of Life & Health insurance do you sell?
        //Do you provide security services for any of these?
        //Do you engage in bail bond recovery, bounty hunting, car reposession, or evictions?
        //Do Statements of Actuarial Opinion require peer review before sign off and release?
        //Do you make recommendations on the pricing or managing of Catastrophe risk?
        //Do you provide advice regarding what reinsurance structure an insurance company should purchase?
        //What percentage of revenue comes from sales of commercial properties or vacant land?
        //What percentage of revenue comes from short sales?
        //What types of customers do you serve?
        //Do you inspect commercial buildings?
        //Do you advise on the contamination risk, presence of, or clean up of mold or any pollutants?
        //Do you inspect for termites or any other pests?
        //If an infestation is found do you provide services to remove or control the termites or pests?
        //Do you publish any product manuals or technical specification manuals?
        //Do you record all calls with customers?
        //Do you provide social work services?
        //Are you an active or retired healthcare professional?
        //This policy does not cover past, present, or future work done that requires a healthcare license.
        //Do you sell any health or life insurance?
        //Do you provide loan document notarization services?
        //Do you provide any title related services such as closing agent, escrow agent, title abstractor, title agent, or title search?
        //Which property services are provided?
        //--------------------------------------------------------------------------------------------------------------------
        //LPL-----------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?
        //Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?
        //Do you practice in these areas of law?
        //Please describe the type of law practiced
        //For personal injury cases, whom do you represent?
        //For insurance cases, whom do you represent
        //Do you handle divorce cases?
        //In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you




        //------Statements covered by the general mapper (either under DO or DO NOT)------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //MPL-----------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //BUSINESS CONSULTING-------------------------------------------------------------------------------------------------
        //Do you provide architectural or engineering advice?	Provide architectural or engineering advice
        //Do you have attorneys on staff that provide legal advice to others?	Have attorneys on staff that provide legal advice to others
        //Do you provide advice or services that require a Certified Public Accountant?	Provide advice or services that require a Certified Public Accountant
        //Do you create advertisements or provide brand advice for your clients?	Create advertisements or provide brand advice for your clients
        //Do your clients sign off on all press releases or advertising materials prior to release?	Your clients sign off on all press releases or advertising materials prior to release
        //Do you provide forensic accounting including litgation support or investigative services?	Provide forensic accounting including litgation support or investigative services
        //Do you serve as a trustee or executor?	Serve as a trustee or executor
        //Do you provide business valuations or aid in mergers & acquisitions?	Provide business valuations or aid in mergers & acquisitions
        //Do you help set up tax shelters or Limited Partnerships?	Help set up tax shelters or Limited Partnerships
        //Do you provide financial investment advice?	Provide financial investment advice
        //Do you provide staffing services?	Provide staffing services
        //Do you do work involving aerospace engineering?	Work involving aerospace engineering
        //Do you advise on Geotechnical, Soils, or Structural Engineering?	Advise on Geotechnical, Soils, or Structural Engineering
        //Do you give advice on nuclear materials?	Give advice on nuclear materials
        //Do you directly perform physical work for others?	Directly perform physical work for others
        //Do you design amusement rides or playgrounds?	Design amusement rides or playgrounds
        //Do you advise on the contamination risk, presence of, or clean up of any pollutants?	Advise on the contamination risk, presence of, or clean up of any pollutants
        //Do you offer asbestos evaluation or abatement services?	Offer asbestos evaluation or abatement services
        //Do you develop medical diagnostic machines or artificial organs?	Develop medical diagnostic machines or artificial organs
        //Do you design bridges?	Design bridges
        //Do you provide emergency response services?	Provide emergency response services
        //Do you manufacture, sell, or distribute products under your business name?	Manufacture, sell, or distribute products under your business name
        //Do you have a written procedure to check materials for copyright or trademark violations?	Have a written procedure to check materials for copyright or trademark violations
        //Do you place clients' funds in any options or leveraged ETFs?	Place clients' funds in any options or leveraged ETFs
        //Do you offer any products that guarantee a minimum return on investment?	Offer any products that guarantee a minimum return on investment
        //Do you provide health care services or advice that requires a licensed health care professional?	Provide health care services or advice that requires a licensed health care professional
        //Do you do Human Resources (HR) consulting or management for clients?	Human Resources (HR) consulting or management for clients
        //Other----------------------------------------------------------------------------------------------------------
        //Sell dietary supplements, vitamins, or performance-enhancing substances
        //Help train clients for athletic competitions
        //Train professional athletes
        //Operate tanning beds
        //Adjust claims
        //Work as a public adjustor
        //Adjust Asbestos, Energy, Environmental, or Marine claims
        //Sell insurance products directly over the internet
        //Act as a broker for any reinsurance contracts such as quote shares or excess losss treaties
        //Function as a Managing General Agent/Underwriter (MGA)
        //Provide financial investment advice
        //Provide advice or servies that require a Certified Public Accountant
        //Enter into an MGA agreement with an insurer having an A.M.Best Rating worse than A-
        //Create, manage, or provide services for a Health Maintenance Organization (HMO) plan
        //Work outside the U.S. and Canada
        //Provide bodyguard services
        //Have users upload content to website I own or operate
        //Develop software that aids architects or engineers in product design
        //Design, integrate, or maintain networks for clients
        //Develop software that provides or assists with medical diagnoses
        //Electronically store private data
        //Provide website hosting or domain registration
        //Give opinions on the adequacy of Asbestos or Environmental reserves
        //Have all translators native speakers in at least one of the languages being translated to/from
        //Help businesses develop international marketing campaigns
        //Your business own any properties
        //Your business manage any properties
        //Help set up or service self-insurance, risk retention groups, or captives
        //Operate tour buses or boats
        //Provide home inspection services
        //Provide home healthcare services
        //Babysit children
        //Offer IPOs
        //Broke the buying or selling of public companies
        //Perform services as an emergency medical technician or lifeguard
        //Alter, create, or own material that is published or printed
        //Print lottery tickets
        //Develop software for clients or for sale
        //Comply with applicable "Do Not Call" laws/regulations
        //Collect private data
        //Provide body massage services
        //Offer services at client locations
        //Provide tattoo services
        //Provide acupuncture, facial injection, or laser treatment services
        //Keratin hair-straightening procedures or brazilian blowouts
        //Body piercings
        //Work for Child Protective Services
        //Volunteers give advice or provide care on your behalf
        //Prescribe or sell over-the-counter or prescription drugs
        //Diagnose or treat mental illnesses
        //Provide drug addiction or rehabilitation services
        //Sell or broke subprime mortgages
        //Sell or broke reverse mortgages
        //Provide appraisals
        //Provide remote or electronic notary services
        //Advise on building or moving load-bearing walls
        //Auction airplanes, cars, boats, or real estate
        //Act as a real estate agent/broker
        //Represent any manufacturer's outside the U.S. and Canada
        //Do you sell or broke any loans/mortgages?
        //Provide ecommerce/online sales services for others
        //--------------------------------------------------------------------------------------------------------------------
        //LPL-----------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //Your business owns a Title Agency
        //File patents on behalf of clients
        //For Insurance cases, require an attorney to meet with all clients in person before agreeing to represent them.
        //For personal injury cases, require an attorney to meet with all clients in person before agreeing to represent them.
        //Help handle Mergers & Acquisitions
        //Practice in Securities Law (financial transactions)
        //Have members of your firm been suspended or disbarred in the past 5 years
        //Have members of your firm engaged in mass tort or class action cases in the past 5 years
        //Serve as a trustee or executor




        /*
         * About You
         */
        public static Element AboutYouTitle => new Element(By.XPath("//span[@data-qa='about-you-title']"));
        public static Element AboutYouEdit => new Element(By.XPath("//i[@data-qa='about-you-edit-button']"));

        //Your name is:
        public static Element YourNameQST => new Element(By.XPath("//div[@data-qa='your-name-title']"));
        public static Element YourNameAnswer => new Element(By.XPath("//div[@data-qa='contact-name']"));
        //Manager's name is:
        public static Element MngrNameQST => new Element(By.XPath("//div[@data-qa='manager-name']"));
        public static Element MngrNameAnswer => new Element(By.XPath("//div[@data-qa='broker-name']"));
        public static Element ManagerEmail => new Element(By.XPath("//div[@data-qa='broker-email']"));
        //Your Address is:
        public static Element YourAddressQST => new Element(By.XPath("//div[@data-qa='your-address-title']"));
        public static Element YourAddressAnswer => new Element(By.XPath("//div[@data-qa='contact-address']"));
        //We can contact the manager at:
        public static Element MngrContactQST => new Element(By.XPath("//div[@data-qa='contact-manager-title']"));
        public static Element MngrEmailAnswer => new Element(By.XPath("//div[@data-qa='broker-email']"));
        public static Element MngrPhoneNumAnswer => new Element(By.XPath("//div[@data-qa='broker-phone']"));
        //We can contact you at:
        public static Element ContactYouQST => new Element(By.XPath("//div[@data-qa='contact-you-title']"));
        public static Element YourEmailAnswer => new Element(By.XPath("//div[@data-qa='contact-email']"));
        public static Element YourPhoneNumAnswer => new Element(By.XPath("//div[@data-qa='contact-phone']"));
        //Your Website is:
        public static Element YourWebsiteQST => new Element(By.XPath("//div[@data-qa='your-website-title']"));
        public static Element YourWebsiteAnswer => new Element(By.XPath("//div[@data-qa='your-website']"));


        /*
         * Bottom of your summary page ----------------------------------------------------------------
         */

        public static Element YourSummaryBackButton => new Element(By.XPath("//button[@data-qa='summary-go-back-button']"));
        public static Element YourSummaryBottomViewQuoteButton => new Element(By.XPath("//button[@data-qa='summary-go-to-quote-button']"));
    }
}