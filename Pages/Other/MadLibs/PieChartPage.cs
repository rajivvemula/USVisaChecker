using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{ [Binding]
   
    public sealed class PieChartPage
    {
        /*
       * Headers--------------------------------------------------------------------------------------------------------
       */
        public static Element RecommendCoveragesTitle => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element RecommendCoveragesSubtitle => new Element(By.XPath("//p[@data-qa='page-message']"));
        public static Element DoesPieExist => new Element(By.XPath("//gaq-lob-pie[@id='lob_pie_1']"));

        //general way to find the Pie Chart accordian based on LOB text
        public static Element getAccordianByLOB(string lob) => new Element(By.XPath($"//span/mat-panel-title[@data-qa='available-lob-title-{lob}']"));

        //general way to find LOB button to press while going through the path
        public static Element getLOBbutton(string lob) => new Element(By.XPath($"//button[@data-qa='goto-pp-button-{lob}']"));

        /*
         * Pie Chart Graphic
         */
        public static Element PieWCSelected => new Element(By.XPath("//gaq-lob-pie[@class='selected ng-star-inserted']/div[@data-qa='lob-pie-piece-text-WC']"));
        public static Element PieWCAvailable => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted']/div[@data-qa='lob-pie-piece-text-WC']"));
        public static Element PieWCNotAvailable => new Element(By.XPath("//gaq-lob-pie[@class='unavailable ng-star-inserted']/div[@data-qa='lob-pie-piece-text-WC']"));
        public static Element PiePLSelected => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted selected']/div[@data-qa='lob-pie-piece-text-PL']"));
        public static Element PiePLAvailable => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted']/div[@data-qa='lob-pie-piece-text-PL']"));
        public static Element PiePLNotAvailable => new Element(By.XPath("//gaq-lob-pie[@class='unavailable ng-star-inserted']/div[@data-qa='lob-pie-piece-text-PL']"));
        public static Element PieGLSelected => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted selected']/div[@data-qa='lob-pie-piece-GL']"));
        public static Element PieGLAvailable => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted']/div[@data-qa='lob-pie-piece-GL']"));
        public static Element PieGLNotAvailable => new Element(By.XPath("//gaq-lob-pie[@class='unavailable ng-star-inserted']/div[@data-qa='lob-pie-piece-GL']"));
        public static Element PieCASelected => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted selected']/div[@data-qa='lob-pie-piece-CA']"));
        public static Element PieCAAvailable => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted']/div[@data-qa='lob-pie-piece-CA']"));
        public static Element PieCANotAvailable => new Element(By.XPath("//gaq-lob-pie[@class='unavailable ng-star-inserted']/div[@data-qa='lob-pie-piece-CA']"));
        public static Element PieBOPSelected => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted selected']/div[@data-qa='lob-pie-piece-BP']"));
        public static Element PieBOPAvailable => new Element(By.XPath("//gaq-lob-pie[@class='ng-star-inserted']/div[@data-qa='lob-pie-piece-BP']"));
        public static Element PieBOPNotAvailable => new Element(By.XPath("//gaq-lob-pie[@class='unavailable ng-star-inserted']/div[@data-qa='lob-pie-piece-BP']"));

        /*
        * Workers' Compensation Accordian--------------------------------------------------------------------------------
        */
        public static Element WCAccordianExpanded => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']/span/mat-panel-title[@data-qa='available-lob-title-WC']"));
        public static Element WCAccordianClosed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='available-lob-title-WC']"));
        public static Element WCWhatItIs => new Element(By.XPath("//p[@data-qa='what-it-is-WC']"));
        public static Element WCBestFor => new Element(By.XPath("//div[@data-qa='best-for-WC']"));
        public static Element WCExample => new Element(By.XPath("//p[@data-qa='example-WC']"));
        public static Element WCGetBTN => new Element(By.XPath("//button[@data-qa='goto-pp-button-WC']"));

        /*
        * Professional Liability (E&O) Accordian ------------------------------------------------------------------------
        */
        public static Element PLAccordianExpanded => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']/span/mat-panel-title[@data-qa='available-lob-title-PL']"));
        public static Element PLAccordianClosed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='available-lob-title-PL']"));
        public static Element PLWhatItIs => new Element(By.XPath("//p[@data-qa='what-it-is-PL']"));
        public static Element PLBestFor => new Element(By.XPath("//div[@data-qa='best-for-PL']"));
        public static Element PLExample => new Element(By.XPath("//p[@data-qa='example-PL']"));
        public static Element PLGetBTN => new Element(By.XPath("//button[@data-qa='goto-pp-button-PL']"));

        /*
        * General Liability Accordian-------------------------------------------------------------------------------------
        */
        public static Element GLAccordianExpanded => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']/span/mat-panel-title[@data-qa='available-lob-title-GL']"));
        public static Element GLAccordianClosed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='available-lob-title-GL']"));
        public static Element GLWhatItIs => new Element(By.XPath("//p[@data-qa='what-it-is-GL']"));
        public static Element GLBestFor => new Element(By.XPath("//div[@data-qa='best-for-GL']"));
        public static Element GLExample => new Element(By.XPath("//p[@data-qa='example-GL']"));
        public static Element GLGetBTN => new Element(By.XPath("//button[@data-qa='goto-pp-button-GL']"));

        /*
        * Commercial Auto Accordian----------------------------------------------------------------------------------------
        */
        public static Element CAAccordianExpanded => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']/span/mat-panel-title[@data-qa='available-lob-title-CA']"));
        public static Element CAAccordianClosed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='available-lob-title-CA']"));
        public static Element CAWhatItIs => new Element(By.XPath("//p[@data-qa='what-it-is-CA']"));
        public static Element CABestFor => new Element(By.XPath("//div[@data-qa='best-for-CA']"));
        public static Element CAExample => new Element(By.XPath("//p[@data-qa='example-CA']"));
        public static Element CAGetBTN => new Element(By.XPath("//button[@data-qa='goto-pp-button-CA']"));

        /*
        * Business Owners Accordian----------------------------------------------------------------------------------------
        */
        public static Element BOPAccordianExpanded => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']/span/mat-panel-title[@data-qa='available-lob-title-BP']"));
        public static Element BOPAccordianClosed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='available-lob-title-BP']"));
        public static Element BOPWhatItIs => new Element(By.XPath("//p[@data-qa='what-it-is-BOP']"));
        public static Element BOPBestFor => new Element(By.XPath("//div[@data-qa='best-for-BOP']"));
        public static Element BOPExample => new Element(By.XPath("//p[@data-qa='example-BOP']"));
        public static Element BOPGetBTN => new Element(By.XPath("//button[@data-qa='goto-pp-button-BP']"));

        /*
         * Coverages That Aren't a Match Accordian-------------------------------------------------------------------------
         */
        public static Element NotAMatchAccordianExpanded => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='true']/span/mat-panel-title[@data-qa='coverages-not-match-title']"));
        public static Element NotAMatchAccordianClosed => new Element(By.XPath("//mat-expansion-panel-header[@aria-expanded='false']/span/mat-panel-title[@data-qa='coverages-not-match-title']"));
        public static Element UnableToOfferCopy => new Element(By.XPath("//p[@data-qa='unable-to-offer-lobs-subtitle']"));
        public static Element WCNotMatch => new Element(By.XPath("//p[@data-qa='not-match-lob-container-WC']"));    
        public static Element WCNotMatchButAvailableBTN => new Element(By.XPath("//p[@data-qa='not-match-lob-container-WC']/span/button[@data-qa='goto-pp-button-WC']"));
        public static Element PLNotMatch => new Element(By.XPath("//p[@data-qa='not-match-lob-container-PL']"));
        //PL is currently always recommended, so this is currently not possible - see US14177
        //public static Element PLNotMatchButAvailableBTN => new Element(By.XPath(""));
        public static Element GLNotMatch => new Element(By.XPath("//p[@data-qa='not-match-lob-container-GL']"));
        public static Element GLNotMatchButAvailableBTN => new Element(By.XPath("//p[@data-qa='not-match-lob-container-GL']/span/button[@data-qa='goto-pp-button-GL']"));
        public static Element CANotMatch => new Element(By.XPath("//p[@data-qa='not-match-lob-container-CA']"));
        public static Element BOPNotMatch => new Element(By.XPath("//p[@data-qa='not-match-lob-container-BP']"));
        public static Element BOPNotMatchButAvailableBTN => new Element(By.XPath("//p[@data-qa='not-match-lob-container-BP']/span/button[@data-qa='goto-pp-button-BP']"));

    }
}
