using Dev1EndtoendRegression.Objects;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    [Scope(Tag = "logIn")]
    internal class LoginStepDefinition
    {

        private readonly PageObject _pageObject;

        public LoginStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDevAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenuAsync(string logIn)
        {
            string selector = $".nav-desktop a[href='/Account']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I write the e-mail for my login")]
        public async Task WhenIWriteTheE_MailForMyLoginAsync()
        {
            string selector = "#email";
            string email = "hgalan@axs.com";
            await _pageObject.Page.Locator(selector).FillAsync(email);
        }

        [When(@"I write the password for my login")]
        public async Task WhenIWriteThePasswordForMyLoginAsync()
        {
            string selector = "#password";
            string password = "hgalan@axs.com";
            await _pageObject.Page.Locator(selector).FillAsync(password);
        }

        [When(@"I press the button ""([^""]*)"" to confirm")]
        public async Task WhenIPressTheButtonToConfirmAsync(string p0)
        {
            string selector = $"button.form-primary-cta[type='submit']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I get to the main account page")]
        public async Task ThenIGetToTheMainAccountPageAsync()
        {
            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Account/Dashboard";
            var actualUrl = _pageObject.Page.Url;

            Assert.IsTrue(actualUrl.Equals(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }

        [Then(@"I press the drop down menu ""([^""]*)"" to log out")]
        public async Task ThenIPressTheDropDownMenuToLogOutAsync(string p0)
        {
            string hoverSelector = $".nav-desktop a[href='/Account']";
            string selector = $".dropdown .content a[href='/Account/Logout']";
            await _pageObject.Page.HoverAsync(hoverSelector);
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I come back to the index page")]
        public async Task ThenIComeBackToTheIndexPageAsync()
        {
            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/";
            var actualUrl = _pageObject.Page.Url;

            Assert.IsTrue(actualUrl.Equals(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }

    }
}
