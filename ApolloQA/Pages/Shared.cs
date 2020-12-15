using System;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages
{
    class Shared
    {
        public static Element GetField(string fieldDisplayName, string fieldType)
        {
            switch(fieldType.ToLower())
            {
                case "input":
                    return GetInputField(fieldDisplayName);
                case "dropdown":
                    return GetDropdownField(fieldDisplayName);
                default:
                    Functions.handleFailure(new NotImplementedException($"Field type: {fieldType} is not implemented"));
                    return null;
            }
        }
        public static Element GetHeaderField(string DisplayName)
        {
            return new Element($"//bh-quote-header//*[contains(text(), '{DisplayName}')]//preceding-sibling::div/descendant::*");

        }

        public static Element GetLeftSideTab(string DisplayName)
        {
            return new Element($"//bh-left-navbar //div[@class='mat-list-item-content' and normalize-space(text())='{DisplayName}'] |" +
                               $"//a[@routerlinkactive='active-link']//*[contains(text(), '{DisplayName}')]");
        }

        public static Element GetRightSideTab(string DisplayName)
        {
            return new Element($"//*[contains(text(), '{DisplayName}')]");
        }

        public static Element GetDropdownField(string DisplayName)
        {
            return new Element($"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::mat-select |" +
                               $"//*[@class='mat-option-text']//*[contains(text(), '{DisplayName}')]");

        }
        public static Element GetInputField(string DisplayName)
        {
            return new Element($"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::input | " +
                               $"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::textarea |" +
                               $"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::*/input |" +
                               $"//input[@name='{DisplayName}']");
        }
        public static Element GetButton(string displayName)
        {
            return new Element($"//button[./*[normalize-space(text())='{displayName}']] |" +
                               $"//button[normalize-space(text())='{displayName}'] |" +
                               $"//button//*[contains(text(), '{displayName}')] |" +
                               $"//mat-radio-button //*[contains(text(), '{displayName}')] |" +
                               $"//a[@role='button' and @class='nav-link' and contains(text(), '{displayName}')]");
        }

        public static Element GetIconButton(string iconText)
        {
            return new Element($"//mat-icon[contains(text(), '{iconText}')]");
        }

        // Grid Titles Verify
        public static Element GetColumnTitle(string gridTitle)
        {
            return new Element($"//datatable-header-cell[@title='{gridTitle}']");
        }

        public static Element GetGridValue(string gridValue)
        {
            return new Element($"//span[@title='{gridValue}']");
        }

        //Toast 
        public static Element GetToast()
        {
            return new Element($"//*[@class='toast-title']");
        }

        //
        // Errors
        //

        public static Element GetError(string ErrorText)
        {
            return new Element($"//mat-error[@role='alert' and contains(text(), '{ErrorText}')]");
        }

        //
        // Specific Shared Elements
        //
        public static Element SuggestedAddressCTA => new Element("//bh-address-details/*");
        public static Element SpinnerLoad => new Element("//bh-mat-spinner-overlay");
        public static Element GridskipToLastButton => new Element("//a[@role='button' and @aria-label='go to last page']");
        public static Element LastGridItem => new Element("(//a[@class='nav-link'])[last()]");
        public static Element toastrMessage => new Element("//div[@class='toast-content']/descendant::*");
    }
}
