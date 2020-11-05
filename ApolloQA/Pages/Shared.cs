﻿using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages
{
    class Shared
    {

        public static Element GetHeaderField(string DisplayName)
        {
            return new Element($"//bh-quote-header//*[contains(text(), '{DisplayName}')]//preceding-sibling::div/descendant::*");
        }

        public static Element GetSideTab(string DisplayName)
        {
            return new Element($"//bh-left-navbar //div[@class='mat-list-item-content' and normalize-space(text())='{DisplayName}']");
        }

        public static Element GetDropdownField(string DisplayName)
        {
            return new Element($"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::mat-select");

        }
        public static Element GetInputField(string DisplayName)
        {
            return new Element($"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::input | " +
                               $"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::textarea |" +
                               $"//mat-label[normalize-space(text())='{DisplayName}']/../../preceding-sibling::*/input");
        }
        public static Element GetButton(string displayName)
        {
            return new Element($"//button[./*[normalize-space(text())='{displayName}']] | //button[normalize-space(text())='{displayName}']");
        }


    }
}
