using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver.Input;
using TechTalk.SpecFlow;

namespace BiBerkLOB.Pages.PL
{
    [Binding]
    public sealed class PL_IntroductionPage : Reusable_PurchasePath
    {
        //A Quick Introduction
        public static Element QuickIntro => new Element(By.XPath("//h1[@data-qa='PL-intro-header']"));
        //Please tell us a little bit about your company.
        //We'll only use this information to provide you with a quote.
        public static Element QuickIntroParagraph => new Element(By.XPath("//h6[@data-qa='PL-intro-subheader']"));
        public static LoadingRequirements LoadingRequirements => new LoadingRequirements(Reusable_PurchasePath.YourPLQuoteID, QuickIntro, QuickIntroParagraph);

        //How is your business structured?
        public static Element BusStructQstTxt => new Element(By.XPath("//span[@data-qa='business-structure-question-label']"));
        public static Element BusStructBTN(string type) => new Element(By.XPath($"//label[@data-qa='button-business-type-{type}']"));
        public static Element BusStructHelper => new Element(By.XPath("//i[@data-qa='business-structure-question-help-icon']"));
        public static Element BusStructHelperText => new Element(By.XPath("//div[@data-qa='business-structure-question-help-text']"));
        public static Element BusStructHelperX => new Element(By.XPath("//i[@data-qa='business-structure-question-help-text-close-icon']"));
        public static InputSection BusStructQuestion => 
            new SingleChoiceGroupInput(new ChoiceGroup(BusStructBTN))
                .AsAQuestion(BusStructQstTxt)
                .WithHelpText(BusStructHelper, BusStructHelperText, BusStructHelperX);
        
        //What's the name of your business?
        public static Element NameOfBusinessQstTxt => new Element(By.XPath("//span[@data-qa='business-name-label']"));
        public static Element NameOfBusinessTxtbox => new Element(By.XPath("//md-input[@data-qa='business-name-input']/div/input"));
        public static Element NameOfBusinessError => new Element(By.XPath("//span[@data-qa='business-name-input-validation-error']"));
        public static InputSection NameOfBusinessQuestion => 
            new TextBoxInput(NameOfBusinessTxtbox)
                .AsAQuestion(NameOfBusinessQstTxt);

        //What's the name you do business under?
        public static Element BusinessNameQstTxt => new Element(By.XPath("//span[@data-qa='businessname-label']"));
        public static Element InsuredFirstTxtbox => new Element(By.XPath("//md-input[@data-qa='firstname-input']/div/input"));
        public static Element InsuredLastTxtbox => new Element(By.XPath("//md-input[@data-qa='lastname-input']/div/input"));
        public static InputSection InsuredFullNameQuestion => 
            new MultiTextBoxInput(InsuredFirstTxtbox, InsuredLastTxtbox)
                .AsAQuestion(BusinessNameQstTxt);
        public static Element InsuredAddressTxtbox => new Element(By.XPath("//md-input[@data-qa='business-address-input']/div/input"));
        public static Element InsuredAddressTxtboxError => new Element(By.XPath("//span[@data-qa='business-address-input-validation-error']"));
        
        //Do you do business under another name?
        public static Element DoDBAQstTxt => new Element(By.XPath("//span[@data-qa='another-business-name-label']"));
        public static Element DoDBABTN_Yes => new Element(By.XPath("//label[@data-qa='button-dba-Y']"));
        public static Element DoDBABTN_No => new Element(By.XPath("//label[@data-qa='button-dba-N']"));
        public static YesOrNoGroup DoDBABTNGroup => new YesOrNoGroup(DoDBABTN_Yes, DoDBABTN_No);
        public static Element DoDBAHelper => new Element(By.XPath("//i[@data-qa='another-business-name-help-icon']"));
        public static Element DoDBAHelperText => new Element(By.XPath("//div[@data-qa='another-business-name-help-text']"));
        public static Element DoDBAHelperX => new Element(By.XPath("//i[@data-qa='another-business-name-help-text-close-icon']"));
        public static InputSection DoDBAQuestion => 
            new YesOrNoInput(DoDBABTNGroup)
                .AsAQuestion(DoDBAQstTxt)
                .WithHelpText(DoDBAHelper, DoDBAHelperText, DoDBAHelperX);

        //What is the other business name?
        public static Element WhatIsDBAQstTxt => new Element(By.XPath("//span[@data-qa='other-business-name-label']"));
        public static Element WhatIsDBATxtbox => new Element(By.XPath("//md-input[@data-qa='DBA-input']/div/input"));
        public static Element WhatIsDBATextBelow => new Element(By.XPath("//span[@data-qa='additional-business-name-text']"));
        public static Element WhatIsDBAError => new Element(By.XPath("//span[@data-qa='DBA-input-validation-error']"));
        public static InputSection WhatIsDBAQuestion => 
            new TextBoxInput(WhatIsDBATxtbox)
                .AsAQuestion(WhatIsDBAQstTxt)
                .WithExtraText(WhatIsDBATextBelow);

        //Your business name includes "LLC" but you chose Corporation for business type. Should it be Limited Liability Co. (LLC)?
        public static Element AreYouSureLLCQstTxt => new Element(By.XPath("//span[@data-qa='LLC-question-label']"));
        public static Element AreYouSureLLCYes => new Element(By.XPath("//label[@data-qa='button-LLC-Yes']"));
        public static Element AreYouSureLLCNo => new Element(By.XPath("//label[@data-qa='button-LLC-No']"));
        public static YesOrNoGroup AreYouSureLLCGroup => new YesOrNoGroup(AreYouSureLLCYes, AreYouSureLLCNo);
        public static InputSection AreYouSureLLCQuestion => 
            new YesOrNoInput(AreYouSureLLCGroup)
                .AsAQuestion(AreYouSureLLCQstTxt);

        /*
        * Page CTA----------------------------------------------------------
        */
        public static Element StartOverCTA => new Element(By.XPath("//button[@data-qa='start-over-button']"));
        public static Element LetsGoCTA => new Element(By.XPath("//button[@data-qa='validate-button']"));

    }
}