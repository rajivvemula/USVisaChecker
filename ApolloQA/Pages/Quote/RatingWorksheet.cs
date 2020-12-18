using System;
using System.Collections.Generic;
using System.Text;
using ApolloQA.Source.Driver;
using ApolloQA.Source.Helpers;

namespace ApolloQA.Pages.Quote
{
    public class RatingWorksheet
    {
        public static Element ResultList = new Element("//mat-label[b/text()='Risk:']/../..");




        public class Risk
        {
            string riskDisplayText;
            string ratingAlgorithm;

            public Risk(string riskDisplayText, string ratingAlgorithm)
            {
                this.riskDisplayText = riskDisplayText;
                this.ratingAlgorithm = ratingAlgorithm;
            }
            public Element Result
            {
                get
                {
                    return new Element(ResultList.Xpath + $"//div[mat-label[normalize-space(text())='{riskDisplayText}'] and mat-label[normalize-space(text())='{ratingAlgorithm}']]");
                }
            }
            public Element DataTable
            {
                get
                {
                    return new Element($"( {Result.Xpath} //ngx-datatable)[1]");
                }
            }

        }



    }
}

   

