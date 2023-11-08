using HitachiQA.Driver;
using HitachiQA.Driver.Input;
using OpenQA.Selenium;

namespace BiBerkLOB.Pages.Other.BSP
{
    public sealed class BSP_SettingsPage : BSP_Reusable
    {
        public static Element ImpersonateHeader => new Element(By.XPath("//h1[text()='Impersonate']"));
        public static Element AgencyHeader => new Element(By.XPath("//label[text()='Agency']"));
        public static Element AgencySelectionDD => new Element(By.XPath("//bb-select[@data-qa='impersonate-agency-select']//select"));
        public static InputSection AgencySelectionDDInput => new HtmlDropdownInput(AgencySelectionDD)
            .AsAQuestion(AgencyHeader);
        public static Element UseApolloAgentLabel => new Element(By.XPath("//span[text()='Use Apollo Agent']"));
        public static Element UseApolloAgentChkbox => new Element(By.XPath("//input[@data-qa='impersonate-agency-use-apollo-checkbox']"));
        public static InputSection UseApolloAgentInput =>
            new HtmlCheckBoxToggleInput(UseApolloAgentChkbox)
                .AsAQuestion(UseApolloAgentLabel);

        //Role(s)
        public static Element RoleLabel(string role) => new Element(By.XPath($"//input[@data-qa='impersonate-role-checkbox-{role}']"));
        public static Element RoleChkbox(string role) => new Element(By.XPath($"//input[@data-qa='impersonate-role-checkbox-{role}']"));
        public static InputSection RoleInput(string role) =>
            new HtmlCheckBoxToggleInput(RoleChkbox(role))
                .AsAQuestion(RoleLabel(role));

        public static Element CSRLabel => new Element(By.XPath("//span[text()='CSR']"));
        public static Element CSRChkbox => new Element(By.XPath("//input[@data-qa='impersonate-role-checkbox-CSR']"));
        public static InputSection CSRInput =>
            new HtmlCheckBoxToggleInput(CSRChkbox)
                .AsAQuestion(CSRLabel);
        public static Element ProducerLabel => new Element(By.XPath("//span[text()='Producer']"));
        public static Element ProducerChkbox => new Element(By.XPath("//input[@data-qa='impersonate-role-checkbox-Producer']"));
        public static InputSection ProducerInput =>
            new HtmlCheckBoxToggleInput(ProducerChkbox)
                .AsAQuestion(ProducerLabel);
        public static Element ManagerLabel => new Element(By.XPath("//input[text()='Manager']"));
        public static Element ManagerChkbox => new Element(By.XPath("//input[@data-qa='impersonate-role-checkbox-Manager']"));
        public static InputSection ManagerInput =>
            new HtmlCheckBoxToggleInput(ManagerChkbox)
                .AsAQuestion(ManagerLabel);
        public static Element PartnerAssitanceLabel => new Element(By.XPath("//input[text()='PartnerAssistance']"));
        public static Element PartnerAssitanceChkbox => new Element(By.XPath("//input[@data-qa='impersonate-role-checkbox-PartnerAssistance']"));
        public static InputSection PartnerAssitanceInput =>
            new HtmlCheckBoxToggleInput(PartnerAssitanceChkbox)
                .AsAQuestion(PartnerAssitanceLabel);
        public static Element PartnerApiAdminLabel => new Element(By.XPath("//input[text()='PartnerApiAdmin']"));
        public static Element PartnerApiAdminChkbox => new Element(By.XPath("//input[@data-qa='impersonate-role-checkbox-PartnerApiAdmin']"));
        public static InputSection PartnerApiAdminInput =>
            new HtmlCheckBoxToggleInput(PartnerApiAdminChkbox)
                .AsAQuestion(PartnerApiAdminLabel);
        public static Element ImpersonateCTA => new Element(By.XPath("//button[@data-qa='impersonate-impersonate-button']"));
    }
}