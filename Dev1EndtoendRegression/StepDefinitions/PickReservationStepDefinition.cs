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
    [Scope(Tag = "pickreservation")]
    internal class PickReservationStepDefinition
    {
        private readonly PageObject _pageObject;

        public PickReservationStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDevAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenuAsync(string p0)
        {
            string selector = $".nav-desktop a[href='/Account']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I write the e-mail for my login")]
        public async Task WhenIWriteTheE_MailForMyLoginAsync()
        {
            string selector = "#email";
            string email = "hgalan+automation@axs.com";
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

        [When(@"I get to the main account page")]
        public async Task WhenIGetToTheMainAccountPageAsync()
        {
            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Account/Dashboard";
            var actualUrl = _pageObject.Page.Url;

            Assert.IsTrue(actualUrl.Equals(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }

        [When(@"I press the button ""([^""]*)"" to get to the reservation page")]
        public async Task WhenIPressTheButtonToGetToTheReservationPageAsync(string reservationer)
        {
            string selector = $"a.account-tab[href='Reservations']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync (selector);
        }

        [When(@"press the button ""([^""]*)"" to pick up the reservation order")]
        public async Task WhenPressTheButtonToPickUpTheReservationOrderAsync(string p0)
        {
            string selector = $"button.cta.acc-button.acc-button-release[name='mode'][value='1']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"confirm the picking to get to the cart")]
        public async Task WhenConfirmThePickingToGetToTheCartAsync()
        {
            string selector = $"button.link-btn-regular.acc-button-confirm-release.mb-5[name='mode'][value='1']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPageAsync()
        {
            await _pageObject.KlarnaPaymentFlowFromAccountAsync();
        }

    }
}
