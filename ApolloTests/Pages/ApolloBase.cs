using HitachiQA.Driver;


namespace ApolloTests.Pages
{
    public class ApolloBase : BasePage
    {
        public ApolloBase(ObjectContainer OC) : base(OC)
        {

        }

        public Element GetTopNavBarElement(string displayName) => Element($"//bh-top-navbar //a[.//*[normalize-space(text())='{displayName}']]/..");
        public Element GetElementByText(string displayText) => Element($"//*[normalize-space(text())='{displayText}'] | //button[.//*[normalize-space(text())='{displayText}']]");
        public string[] elementXPaths = new string[]
        {
            "//*[normalize-space(text())='{displayText}']",
            "//button[.//*[normalize-space(text())='{displayText}']]",
            "//a[.//*[normalize-space(text())='{displayText}']]"
        };
        public Element GetElementByText(string parentXPath, string displayText) => Element($"{string.Join(" | ", elementXPaths.Select(xpath=> $"{parentXPath+xpath.Replace("{displayText}", displayText)}"))}");

        public new Element GetField(string displayLabel) => Element($"//mat-form-field[.//mat-label[normalize-space(text())='{displayLabel}']]");

        public Element GetNavSection(string sectionName) => GetElementByText("//bh-left-navbar", sectionName);

        /// <summary>
        /// Login 
        /// </summary>
        public Element SubmitButton => Element("//input[@type='submit']");
        public Element UsernameTextField => Element("//input[@name='loginfmt']");
        public Element PasswordTextField => Element("//input[@name='passwd']");

    }
}
