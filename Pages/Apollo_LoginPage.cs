using HitachiQA.Driver;

namespace ApolloQAAutomation.Pages
{
    public sealed class Apollo_LoginPage
    {
        public static Element SubmitButton => new("//input[@type='submit']");
        public static Element UsernameTextField => new("//input[@name='loginfmt']");
        public static Element PasswordTextField => new("//input[@name='passwd']");
        public static Element PasswordError => new("//*[@id='passwordError']");
    }
}