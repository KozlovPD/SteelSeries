using OpenQA.Selenium;
using WD;

namespace SteelSeries.Pages
{
    class SignUpPage : BasePage
    {

        private IWebElement EmailInput => Browser.GetElement(By.XPath("//form[@id='registration-form']//input[@name='email']"));
        private IWebElement PasswordInput => Browser.GetElement(By.XPath("//form[@id='registration-form']//input[@name='password1']"));
        private IWebElement ConfirmPasswordInput => Browser.GetElement(By.XPath("//form[@id='registration-form']//input[@name='password2']"));
        private IWebElement AcceptPrivacyCheckBox => Browser.GetElement(By.XPath("//input[@name='accepted_privacy_policy']"));
        private IWebElement CreateAccountButton => Browser.GetElement(By.XPath("//button[text() = 'Create account']"));

        public SignUpPage(Browser browser) : base(browser)
        {

        }

        public void fillEmailField(string email)
        {
            Browser.Type(EmailInput, email);
        }

        public void fillPasswordField(string password)
        {
            Browser.Type(PasswordInput, password);
        }

        public void fillConfirmPasswordField(string password)
        {
            Browser.Type(ConfirmPasswordInput, password);
        }

        public void acceptPrivacyCheckBoxClick()
        {
            Browser.Click(AcceptPrivacyCheckBox);
        }
        public void createAccountButtonClick()
        {
            Browser.Click(CreateAccountButton);
        }
    }
}
