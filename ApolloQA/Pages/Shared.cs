﻿using System;
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
                case "button":
                    return GetButton(fieldDisplayName);
                case "checkbox":
                    return GetCheckbox(fieldDisplayName);
                default:
                    Functions.handleFailure(new NotImplementedException($"Field type: {fieldType} is not implemented"));
                    return null;
            }
        }

        public static Element GetHeaderButton(string DisplayName)
        {
            return new Element($"//bh-top-navbar //button[descendant::*[normalize-space(text())='{DisplayName}']]");

        }
        public static Element GetQuoteHeaderField(string DisplayName)
        {
            return new Element($"//bh-quote-header//*[contains(text(), '{DisplayName}')]//preceding-sibling::div/descendant::*");

        }

        public static Element GetLeftSideTab(string DisplayName)
        {
            return new Element($"//bh-left-navbar //div[@class='mat-list-item-content' and normalize-space(text())='{DisplayName}'] |" +
                               $"//a[@routerlinkactive='active-link']//*[contains(text(), '{DisplayName}')] |" +
                               $"//mat-nav-list[@role='navigation'] //*[contains(text(), '{DisplayName}')]");
        }

        public static Element GetRightSideTab(string DisplayName)
        {
            return new Element($"//mat-nav-list//*[contains(text(), '{DisplayName}')]");
        }

        public static Element GetDropdownField(string DisplayName)
        {
            return new Element($"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::mat-select | " +
                               $"//*[@class='mat-option-text']//*[contains(text(), '{DisplayName}')] | " +
                               $"//mat-form-field[descendant::*[text()='{DisplayName}']] //input ");

        }
        public static Element GetInputField(string DisplayName)
        {
            return new Element($"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::input | " +
                               $"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::textarea | " +
                               $"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::*/input | " +
                               $"//bh-question-number[descendant::*[text()='{DisplayName}']] //input | " +
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

        public static Element GetCheckbox(string displayText)
        {
            return new Element($"//mat-checkbox[descendant::*[normalize-space(text())='{displayText}']]");
        }

        public static Element GetIconButton(string iconText)
        {
            return new Element($"//mat-icon[contains(text(), '{iconText}')]");
        }

        public static Element GetRadioButton(string buttonText)
        {
            return new Element($"//mat-radio-button[descendant::*[text()='{buttonText}']]//input");
        }

        public static Element Table = new Element($"//ngx-datatable");


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
        public static Element GetToast(string message)
        {
            return new Element($"//div[@class='toast-content']/descendant::*[text()='{message}']");
        }
        public static Element GetToastContaining(string message)
        {
            return new Element($"//div[@class='toast-content']/descendant::*[contains(text(),'{message}' )]");
        }

        //
        // Errors
        //

        public static Element GetError(string ErrorText)
        {
            return new Element($"//mat-error[@role='alert' and contains(text(), '{ErrorText}')]");
        }

        public static Element GetQuestionAnswer(string QuestionDisplayText, string AnswerDisplayText)
        {
            return new Element($"//bh-question-singleselect[descendant::*[normalize-space(text())=\"{QuestionDisplayText}\"]] //mat-radio-button[descendant::*[normalize-space(text())=\"{AnswerDisplayText}\"]] |" +
                               $"//bh-question-boolean[descendant::*[normalize-space(text())=\"{QuestionDisplayText}\"]] //mat-radio-button[descendant::*[normalize-space(text())=\"{AnswerDisplayText}\"]]");
        }
        public static Element GetQuestionTextField(string QuestionDisplayText)
        {
            return new Element($"//bh-question-number[descendant::*[normalize-space(text())='{QuestionDisplayText}']] //input |" +
                               $"//bh-question-text[descendant::*[normalize-space(text())='{QuestionDisplayText}']] //input");
        }
        public static Element GetCoverageCheckbox(string CoverageDisplayText)
        {
            return new Element($"//bh-coverage-map[descendant::*[text()='{CoverageDisplayText}']]//mat-checkbox");
        }
        public static Element GetCoverageLimitButton(string CoverageDisplayText, string CoverageLimitDisplayText)
        {
            return new Element($"//bh-coverage-map[descendant::*[text()='{CoverageDisplayText}']] //bh-coverage-limit-definition[descendant::*[normalize-space(text())='{CoverageLimitDisplayText}']]//mat-radio-button | " +
                               $"//bh-coverage-map[descendant::*[text()='{CoverageDisplayText}']] //bh-coverage-deductible-definition[descendant::*[normalize-space(text())='{CoverageLimitDisplayText}']]//mat-radio-button");
        }
        public static Element GetCoverageLimitDropdown(string CoverageDisplayText, string CoverageLimitDisplayText)
        {
            return new Element($"//bh-coverage-map[descendant::*[text()='{CoverageDisplayText}']] //bh-coverage-limit-definition[descendant::*[normalize-space(text())='{CoverageLimitDisplayText}']]//mat-select | " +
                               $"//bh-coverage-map[descendant::*[text()='{CoverageDisplayText}']] //bh-coverage-deductible-definition[descendant::*[normalize-space(text())='{CoverageLimitDisplayText}']]//mat-select");
        }


        //
        // Specific Shared Elements
        //
        public static Element SuggestedAddressCTA => new Element("//bh-address-details/*");
        public static Element SpinnerLoad => new Element("//bh-mat-spinner-overlay/*");
        public static Element GridskipToLastButton => new Element("//a[@role='button' and @aria-label='go to last page']");
        public static Element LastGridItem => new Element("(//a[@class='nav-link'])[last()]");
        public static Element toastrMessage => new Element("//div[@class='toast-content']/descendant::*");
    }
}
