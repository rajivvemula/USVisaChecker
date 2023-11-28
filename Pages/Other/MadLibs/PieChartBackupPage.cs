using HitachiQA.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages
{
    [Binding]
    public sealed class PieChartBackupPage
    {
        /*
         * Headers--------------------------------------------------------------------------------------------------------
         */
        public static Element RecommendCoveragesTitle => new Element(By.XPath("//h1[@data-qa='page-title']"));
        public static Element RecommendCoveragesSubtitle => new Element(By.XPath("//h5[@data-qa='page-sub-title']"));
        /*
         * Body
         */
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='btn-back'"));
        public static Element PLOfferedCTA => new Element(By.XPath("(//button[@data-qa='lob-card-PL-button'])[last()]"));
        public static Element WCOfferedCTA => new Element(By.XPath("(//button[@data-qa='lob-card-WC-button'])[last()]"));
        public static Element GLOfferedCTA => new Element(By.XPath("(//button[@data-qa='lob-card-GL-button'])[last()]"));
        public static Element CAOfferedCTA => new Element(By.XPath("(//button[@data-qa='lob-card-CA-button'])[last()]"));
        public static Element BPOfferedCTA => new Element(By.XPath("(//button[@data-qa='lob-card-BP-button'])[last()]"));

        //Coverages that aren't a match
        public static Element CoveragesNotAMatch => new Element(By.XPath("//h3[@data-qa='not-recommended-subtitle' and contains(text(),'Other ways to protect your business')]"));
        public static Element GetNotRecomendedLOBbutton(string lob) => new Element(By.XPath($"//button[@data-qa='btn-not-recommended-{lob}']"));
        //Worker's Compensation:
        public static Element WCNotMatchHeader => new Element(By.XPath("//div[@data-qa='unavailable-lob-WC-display-name']"));
        public static Element WCNotMatchTxt => new Element(By.XPath("//div[@data-qa='unavailable-lob-WC-description']"));
        public static Element WCNotMatchCTA => new Element(By.XPath("//button[@data-qa='unavailable-lob-card-WC-button']"));

        public static Element WCLobCardHelpButton => new Element(By.XPath("//button[@data-qa='lob-card-WC-help-button']"));
        public static Element WCLobCardIconDesktop => new Element(By.XPath("//button[@data-qa='lob-card-WC-icon-desktop']"));
        public static Element WCLobCardIconMobile => new Element(By.XPath("//span[@data-qa='lob-card-WC-icon-mobile']"));
        public static Element WCLobCardTitle => new Element(By.XPath("//span[@data-qa='lob-card-WC-title']"));
        public static Element WCLobCardDescription => new Element(By.XPath("//p[@data-qa='lob-card-WC-description']"));
        public static Element WCLobCardGaqButton => new Element(By.XPath("//button[@data-qa='lob-card-gaq-button']"));
        //General Liability:
        public static Element GLNotMatchHeader => new Element(By.XPath("//div[@data-qa='unavailable-lob-GL-display-name']"));
        public static Element GLNotMAtchTxt => new Element(By.XPath("//div[@data-qa='unavailable-lob-GL-description']"));
        public static Element GLNotMatchCTA => new Element(By.XPath("//button[@data-qa='unavailable-lob-card-GL-button']"));

        public static Element GLLobCardHelpButton => new Element(By.XPath("//button[@data-qa='lob-card-GL-help-button']"));
        public static Element GLLobCardIconDesktop => new Element(By.XPath("//div[@data-qa='lob-card-GL-icon-desktop']"));
        public static Element GLLobCardIconMobile => new Element(By.XPath("//span[@data-qa='lob-card-GL-icon-mobile']"));
        public static Element GLLobCardTitle => new Element(By.XPath("//span[@data-qa='lob-card-GL-title']"));
        public static Element GLLobCardDescription => new Element(By.XPath("//p[@data-qa='lob-card-GL-description']"));
        public static Element GLLobCardGaqButton => new Element(By.XPath("//button[@data-qa='lob-card-gaq-button']"));
        //We are unable to offer the insurance products below:
        public static Element UnableToOfferTxt => new Element(By.XPath("//p[@data-qa='title-unavailable-lobs']"));
        //BOP Not Offered
        public static Element BPNotOfferedTitle => new Element(By.XPath("//div[@data-qa='unavailable-lob-BP-display-name']"));
        public static Element BPNotOfferedTxt => new Element(By.XPath("//div[@data-qa='unavailable-lob-BP-description']"));
        public static Element BPNotOfferedCTA => new Element(By.XPath("//button[@data-qa='unavailable-lob-card-BP-button']"));
        public static Element BPLobCardHelpButton => new Element(By.XPath("//button[@data-qa='lob-card-BP-help-button']"));
        public static Element BPLobCardIconDesktop => new Element(By.XPath("//div[@data-qa='lob-card-BP-icon-desktop']"));
        public static Element BPLobCardIconMobile => new Element(By.XPath("//span[@data-qa='lob-card-BP-icon-mobile']"));
        public static Element BPLobCardTitle => new Element(By.XPath("//span[@data-qa='lob-card-BP-title']"));
        public static Element BPLobCardDescription => new Element(By.XPath("//p[@data-qa='lob-card-BP-description']"));
        public static Element BPLobCardGaqButton => new Element(By.XPath("//button[@data-qa='lob-card-gaq-button']"));
        //Comm Auto
        public static Element CALobCardHelpButton => new Element(By.XPath("//button[@data-qa='lob-card-CA-help-button']"));
        public static Element CALobCardIconDesktop => new Element(By.XPath("//div[@data-qa='lob-card-CA-icon-desktop']"));
        public static Element CALobCardIconMobile => new Element(By.XPath("//span[@data-qa='lob-card-CA-icon-mobile']"));
        public static Element CALobCardTitle => new Element(By.XPath("//span[@data-qa='lob-card-CA-title']"));
        public static Element CALobCardDescription => new Element(By.XPath("//p[@data-qa='lob-card-CA-description']"));
        public static Element CALobCardGaqButton => new Element(By.XPath("//button[@data-qa='lob-card-gaq-button']"));
        //Professional Liability
        public static Element PLLobCardHelpButton => new Element(By.XPath("//button[@data-qa='lob-card-PL-help-button']"));
        public static Element PLLobCardIconDesktop => new Element(By.XPath("//div[@data-qa='lob-card-PL-icon-desktop']"));
        public static Element PLLobCardIconMobile => new Element(By.XPath("//span[@data-qa='lob-card-PL-icon-mobile']"));
        public static Element PLLobCardTitle => new Element(By.XPath("//span[@data-qa='lob-card-PL-title']"));
        public static Element PLLobCardDescription => new Element(By.XPath("//p[@data-qa='lob-card-PL-description']"));
        public static Element PLLobCardGaqButton => new Element(By.XPath("//button[@data-qa='lob-card-gaq-button']"));
        //Comm Auto Not offered
        public static Element CANotOfferedTitle => new Element(By.XPath("//div[@data-qa='unavailable-lob-CA-display-name']"));
        public static Element CANotOfferedTxt => new Element(By.XPath("//div[@data-qa='unavailable-lob-CA-description']"));
        public static Element CAUnavailableHelpButton => new Element(By.XPath("//button[@data-qa='unavailable-lob-CA-help-button']"));
        public static Element CAUnavailableIcon => new Element(By.XPath("//div[@data-qa='unavailable-lob-CA-icon']"));
        public static Element CAUnavailableText => new Element(By.XPath("//div[@data-qa='unavailable-lob-CA-unavailable-text']"));

        //Professional Liability Not Offered
        public static Element PLNotOfferedTitle => new Element(By.XPath("//div[@data-qa='unavailable-lob-PL-display-name']"));
        public static Element PLNotOfferedTxt => new Element(By.XPath("//div[@data-qa='unavailable-lob-PL-description']"));
        public static Element PLUnavailableHelpButton => new Element(By.XPath("//button[@data-qa='unavailable-lob-PL-help-button']"));
        public static Element PLUnavailableIcon => new Element(By.XPath("//div[@data-qa='unavailable-lob-PL-icon']"));
        public static Element PLUnavailableDisplayName => new Element(By.XPath("//div[@data-qa='unavailable-lob-PL-display-name']"));
        public static Element PLUnavailableText => new Element(By.XPath("//div[@data-qa='unavailable-lob-PL-unavailable-text']"));
        public static Element PLUnavailableDescription => new Element(By.XPath("//div[@data-qa='unavailable-lob-PL-description']"));

        //General Liability Not Offered
        public static Element GLUnavailableDisplayName => new Element(By.XPath("//div[@data-qa='unavailable-lob-GL-display-name']"));
        public static Element GLUnavailableDescription => new Element(By.XPath("//div[@data-qa='unavailable-lob-GL-description']"));
        public static Element GLUnavailableHelpButton => new Element(By.XPath("//button[@data-qa='unavailable-lob-GL-help-button']"));
        public static Element GLUnavailableIcon => new Element(By.XPath("//div[@data-qa='unavailable-lob-GL-icon']"));
        public static Element GLUnavailableText => new Element(By.XPath("//div[@data-qa='unavailable-lob-GL-unavailable-text']"));
        //BOP Not Offered
        public static Element BPUnavailableHelpButton => new Element(By.XPath("//button[@data-qa='unavailable-lob-BP-help-button']"));
        public static Element BPUnavailableIcon => new Element(By.XPath("//div[@data-qa='unavailable-lob-BP-icon']"));
        public static Element BPLUnavailableDisplayName => new Element(By.XPath("//div[@data-qa='unavailable-lob-BP-display-name']"));
        public static Element BPUnavailableText => new Element(By.XPath("//div[@data-qa='unavailable-lob-BP-unavailable-text']"));
        public static Element BPUnavailableDescription => new Element(By.XPath("//div[@data-qa='unavailable-lob-BP-description']"));
        //Worker's Comp Not Offered
        public static Element WCUnavailableHelpButton => new Element(By.XPath("//button[@data-qa='unavailable-lob-WC-help-button']"));
        public static Element WCUnavailableIcon => new Element(By.XPath("//div[@data-qa='unavailable-lob-WC-icon']"));
        public static Element WCLUnavailableDisplayName => new Element(By.XPath("//div[@data-qa='unavailable-lob-WC-display-name']"));
        public static Element WCUnavailableText => new Element(By.XPath("//div[@data-qa='unavailable-lob-WC-unavailable-text']"));
        public static Element WCUnavailableDescription => new Element(By.XPath("//div[@data-qa='unavailable-lob-WC-description']"));
    }
}
