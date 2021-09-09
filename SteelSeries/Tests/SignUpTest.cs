using NUnit.Framework;
using SteelSeries.Pages;
using Utils;

namespace SteelSeries.Tests
{
    class SignUpTest : BaseTest
    {

        [TestCase]
        public void signUpTest()
        {
            var randomGenerator = new GenerationHelper();
            var mainPage = new MainPage(Browser);
            var signUpPage = new SignUpPage(Browser);
            string email = randomGenerator.getRandomEmail(20);
            string password = randomGenerator.GetRandomPassword(20);
            mainPage.OpenMainPage();
            mainPage.SignUpButtonClick();
            signUpPage.fillEmailField(email);
            signUpPage.fillPasswordField(password);
            signUpPage.fillConfirmPasswordField(password);
            signUpPage.acceptPrivacyCheckBoxClick();
            signUpPage.createAccountButtonClick();
            mainPage.verifyUserIsLoggedIn();



        }
    }
}
