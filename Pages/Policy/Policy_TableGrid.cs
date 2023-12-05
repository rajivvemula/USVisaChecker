using System.Collections.Generic;
using HitachiQA.Driver;

namespace ApolloQAAutomation.Pages.Policy
{
    public sealed class Policy_TableGrid
    {
        /**************************************
        *                                    *
        *        POLICY GRID COLUMNS         *
        *                                    *
        **************************************/
        public static Element PolicyNo => new("//datatable-header-cell[@title='Policy No.']");
        public static Element Term => new("//datatable-header-cell[@title='Term']");
        public static Element NamedInsured => new("//datatable-header-cell[@title='Named Insured']");
        public static Element DBA => new("//datatable-header-cell[@title='DBA']");

        public static Element PolicyStatus => new("//datatable-header-cell[@title='Policy Status']");
        public static Element PolicyPeriod => new("//datatable-header-cell[@title='Policy Period']");
        public static Element LOB => new("//datatable-header-cell[@title='LOB']");
        public static Element Premium => new("//datatable-header-cell[@title='Premium']");
        public static Element StateRegion => new("//datatable-header-cell[@title='State/Region']");

        /**************************************
        *                                    *
        *        POLICY ROW DATA             *
        *                                    *
        **************************************/
        public static Element PolicyNoRowData(int index) => new($"//datatable-row-wrapper[{index}]//datatable-body-cell[1]/div//a");
        public static Element DBARowData(int index) => new($"//datatable-row-wrapper[{index}]//datatable-body-cell[4]/div//span");
        public static Element PolicyPeriodRowData(int index) => new($"//datatable-row-wrapper[{index}]//datatable-body-cell[6]/div");
        public static Element LOBRowData(int index) => new($"//datatable-row-wrapper[{index}]//datatable-body-cell[7]/div//span");
        public static Element PremiumRowData(int index) => new($"//datatable-row-wrapper[{index}]//datatable-body-cell[8]/div");


        public static List<Element> PolicyGridColumns = new()
        {
            PolicyNo,
            Term,
            NamedInsured,
            DBA,
            PolicyStatus,
            PolicyPeriod,
            LOB,
            Premium,
            StateRegion
        };

    }
}
