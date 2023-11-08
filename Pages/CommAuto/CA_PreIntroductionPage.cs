using BiBerkLOB.Pages.Other;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages
{
    [Mapping("CA Let's Start Your Quote")]
    class CA_PreIntroductionPage
    {
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(LetsStartYourQuoteTitle, PleaseTellUsYourBusinessNameAnd);
        /*
         * Headers----------------------------------------------------------
         */
        // Your Commercial Auto Quote ID: ######
        public static Element CAQuoteID => new Element(By.XPath("//div[@data-qa='quoteID-ribbon']"));

        //Let's Start Your Quote title
        public static Element LetsStartYourQuoteTitle => new Element(By.XPath("//h1[@data-qa='preIntro-label']"));

        //Please tell us your business name and coverage start date.  We'll only use...
        public static Element PleaseTellUsYourBusinessNameAnd => new Element(By.XPath("//p[@data-qa='preIntro-subLabel']"));

        /*
        * Questions----------------------------------------------------------
        */

        //What's the name of your business?
        public static Element NameOfBusinessQST => new Element(By.XPath("//label[@data-qa='businessName-label']"));
        public static Element NameOfBusinessTxtbox => new Element(By.XPath("//input[@data-qa='businessName']"));
        public static Element NameOfBusinessTextBelow => new Element(By.XPath("//mat-hint[@data-qa='businessName-hint']"));
        public static InputSection NameOfBusinessInput => new TextBoxInput(NameOfBusinessTxtbox)
            .AsAQuestion(NameOfBusinessQST)
            .WithExtraText(NameOfBusinessTextBelow);
        public static Element NameOfBusinessError => new Element(By.XPath("//mat-error[@data-qa='businessName-error']"));

        //Do you do business under another name?
        public static Element AnotherNameQST => new Element(By.XPath("//label[@data-qa='hasDBA-label']"));
        public static Element AnotherNameHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-hasDBA']"));
        public static Element AnotherNameHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-hasDBA']"));
        public static Element AnotherNameHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-hasDBA-label']"));
        public static Element AnotherNameYes => new Element(By.XPath("//button[@data-qa='hasDBA-yes-button']"));
        public static Element AnotherNameNo => new Element(By.XPath("//button[@data-qa='hasDBA-no-button']"));
        public static InputSection DoesBusinessAnotherNameInput => new YesOrNoInput(AnotherNameYes, AnotherNameNo)
            .AsAQuestion(AnotherNameQST)
            .WithHelpText(AnotherNameHelper, AnotherNameHelperText, AnotherNameHelperX);
        public static Element AnotherNameError => new Element(By.XPath("//mat-error[@data-qa='hasDBA-error']"));
        
        //What's the other busuiness name?
        public static Element OtherBusinessNameQST => new Element(By.XPath("//label[@data-qa='dbaName-label']"));
        public static Element OtherBusinessNameTxtbox => new Element(By.XPath("//input[@data-qa='dbaName']"));
        public static Element OtherBusinessNameTextBelow => new Element(By.XPath("//mat-hint[@data-qa='other-businessName-hint']"));
        public static InputSection OtherBusinessNameInput => new TextBoxInput(OtherBusinessNameTxtbox)
            .AsAQuestion(OtherBusinessNameQST)
            .WithExtraText(OtherBusinessNameTextBelow);
        public static Element OtherBusinessNameError => new Element(By.XPath("//mat-error[@data-qa='dbaName-error']"));
        
        //When should your policy start?
        public static Element PolicyStartQST => new Element(By.XPath("//label[@data-qa='startDate-label']"));
        public static Element PolicyStartHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-startDate']"));
        public static Element PolicyStartHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-startDate']"));
        public static Element PolicyStartHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-startDate-label']"));
        public static Element PolicyStartTxtbox => new Element(By.XPath("//input[@data-qa='policyStart']"));
        public static IDatePicker PolicyDatePicker => new TextEnterDatePicker(PolicyStartTxtbox);
        public static InputSection PolicyStartInput => new DatePickerInput(PolicyDatePicker)
            .AsAQuestion(PolicyStartQST)
            .WithHelpText(PolicyStartHelper, PolicyStartHelperText, PolicyStartHelperX);
        public static Element PolicyStartError => new Element(By.XPath("//mat-error[@data-qa='policyStart-error']"));

        //"Please fix the following" error messages
        public static Element PleaseFixErrorTxt => new Element(By.XPath("//div[@data-qa='bbnav-error-title']"));
        public static Element OneOrMoreQuestionsTxt => new Element(By.XPath("//div[@data-qa='bbnav-error-message']"));

        /*
        * Page CTA----------------------------------------------------------
        */

        //Start Over
        public static Element StartOverCTA => new Element(By.XPath("//div[@class='level-left']/button[@data-qa='bbnav-navBack']"));

        //Let's Go
        public static Element LetsGoCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

    }
}
