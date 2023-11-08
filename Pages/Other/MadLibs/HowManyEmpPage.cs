using HitachiQA.Driver;
using OpenQA.Selenium;
using BiBerkLOB.Source.Driver;
using HitachiQA.Driver.Input;

namespace BiBerkLOB.Pages
{
    class HowManyEmpPage : Reusable_PurchasePath
    {
        //Small Business Insurance
        public static Element PageHeader => new Element(By.XPath("//h1[@data-qa='page-title']"));
        // How many employees do you have?
        public static Element HowManyEmpDoYouHaveQst => new Element(By.XPath("//label[@data-qa='numEmployees-label']"));
        public static Element HowManyEmpDoYouHaveTxtbox => new Element(By.XPath("//input[@data-qa='numEmployees']"));
        public static Element HowManyEmpDoYouHaveHelper => new Element(By.XPath("//button[@data-qa='buttonShowHelpToggle-numEmployees']"));
        public static Element HowManyEmpDoYouHaveHelperText => new Element(By.XPath("//p[@data-qa='bbHelpText-numEmployees-label']"));
        public static Element HowManyEmpDoYouHaveHelperX => new Element(By.XPath("//button[@data-qa='buttonClose-bbHelpText-numEmployees']"));

        public static YesNoGatedNumericQuestion HowManyEmployeesPath =>
            new YesNoGatedNumericQuestionBuilder(DoYouHaveEmpPage.DoYouHaveEmpQST, DoYouHaveEmpPage.DoYouHaveEmpGroup, HowManyEmpDoYouHaveQst, HowManyEmpDoYouHaveTxtbox)
                .WithYesOrNoElements(DoYouHaveEmpPage.SmallBusInsTitle)
                .WithNumQuestionCondition(num => num > 0)
                .WithPostYesOrNoAction(() => DoYouHaveEmpPage.NextCTA.Click())
                .WithPostNumAction(() => HowManyEmpPage.NextCTA.Click())
                .Build();

        //Over 1,000 employees modal
        public static Element Over1000EmployeesQuestion => new Element(By.XPath("//div[@data-qa='email-link-later-text']"));
        public static Element Over1000EmployeesNo => new Element(By.XPath("//button[@data-qa='modal-secondary-btn']"));
        public static Element Over1000EmployeesYes => new Element(By.XPath("//button[@data-qa='modal-primary-btn']"));
        public static YesOrNoGroup Over1000EmployeesGroup=> new YesOrNoGroup(Over1000EmployeesYes, Over1000EmployeesNo);
        public static InputSection Over1000EmployeesModal =>
            new YesOrNoInput(Over1000EmployeesGroup)
            .AsAQuestion(Over1000EmployeesQuestion);

        //Exclude business owners and officers.
        public static Element HowManyEmpDoYouHaveTextBelow => new Element(By.XPath("//mat-hint[@data-qa='num-employees-hint']"));
        //Please enter a valid number.
        public static Element HowManyEmpError => new Element(By.XPath("//mat-error[@data-qa='num-employees-error']"));

        // Next CTA
        public static Element NextCTA => new Element(By.XPath("//button[@data-qa='bbnav-navNext-tablet']"));

        // Back CTA
        public static Element BackCTA => new Element(By.XPath("//button[@data-qa='bbnav-navBack']"));
    }
}