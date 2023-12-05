using HitachiQA.Driver;

namespace ApolloQAAutomation.Pages.Quote.New_Quote
{
    public sealed class NewQuote_BusinessInformation
    {
        public static Element NewQuoteHeader => new("//h2[@data-qa='qc-form-title']");

        /**************************************
        *                                    *
        *        QUOTE INFORMATION           *
        *                                    *
        **************************************/
        public static Element QuoteInformationHeader => new("//h4[@data-qa='qc-form-subtitle-1']");
        public static Element LineOfBusinessDD => new("//mat-select[@data-qa='qc-bc-line-of-business-value']");
        public static Element SubLineDD => new("//mat-select[@data-qa='qc-bc-subline-value']");
        public static Element AgencyDD => new("//mat-select[@data-qa='qc-bc-agency-value']");
        public static Element ProducerDD => new("//mat-select[@data-qa='qc-bc-producer-value']");
        public static Element CarrierDD => new("//mat-select[@data-qa='qc-bc-carrier-value']");
        public static Element EffectiveDate => new("//input[@data-qa='qc-bc-effective-date-input']");
        public static Element ExpirationDate => new("//input[@data-qa='qc-bc-expiration-date-value']");

        /**************************************
        *                                    *
        *        BUSINESS OVERVIEW           *
        *                                    *
        **************************************/
        public static Element BusinessOverviewHeader => new("//h4[@data-qa='qc-bi-title']");
        public static Element NamedInsured => new("//input[@data-qa='qc-bi-name-insured-input']");
        public static Element DBA => new("//input[@data-qa='qc-bi-dba-input']");
        public static Element OrganizationTypeDD => new("//mat-select[@data-qa='qc-bi-organization-type-select']");
        public static Element NAICS => new("//input[@data-qa='qc-bi-naics-input']");
        public static Element TaxIDTypeDD => new("//mat-select[@data-qa='qc-bi-tax-id-type-select']");
        public static Element TaxIDNo => new("//input[@data-qa='qc-bi-tax-id-no-input']");
        public static Element TaxIDNoVisibilityBtn => new("//a[@data-qa='qc-bi-tax-id-no-icon']");
        public static Element BusinessPhNo => new("//input[@data-qa='qc-bi-business-phone-no-input']");
        public static Element Ext => new("//input[@data-qa='qc-bi-ext-input']");
        public static Element BusinessEmail => new("//input[@data-qa='qc-bi-business-email-input']");
        public static Element BusinessWebsite => new("//input[@data-qa='qc-bi-business-website-input']");
        public static Element Keyword => new("//input[@data-qa='qc-bi-kp-form-ac-field-input']");
        public static Element ClassTaxonomy => new("//input[@data-qa='qc-bi-kp-class-taxonomy-input']");
        public static Element YearBusinessStarted => new("//input[@data-qa='qc-bi-year-business-started-input']");
        public static Element YearOwnershipStarted => new("//input[@data-qa='qc-bi-year-ownership-started-input']");

        /**************************************
        *                                    *
        *        ADD ADDRESS                 *
        *                                    *
        **************************************/
        public static Element AddAddressBtn=> new("//button[@data-qa='qc-bac-add-address-button']");
        public static Element AddNewAddressHeader => new("");
        public static Element StreetAddress1 => new("");
        public static Element StreetAddress1ErrorMsg => new("");
        public static Element StreetAddress2 => new("");
        public static Element City => new("");
        public static Element CityErrorMsg => new("");
        public static Element StateRegionDD => new("");
        public static Element ZipCode => new("");
        public static Element ZipCodeErrorMsg => new("");
        public static Element CountryDD => new("");
        public static Element PrimaryCheckBox => new("");
        public static Element MailingCheckBox => new("");
        public static Element GaragingCheckBox => new("");
        public static Element AddNewAddressCancelBtn => new("");
        public static Element AddNewAddressSaveBtn => new("");
        public static Element SaveBtn => new("//button[@data-qa='qc-questionnaire-new-quote-next-button']");

    }
}
