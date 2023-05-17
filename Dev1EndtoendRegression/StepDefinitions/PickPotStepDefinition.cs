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
    [Scope(Tag = "pickpot")]
    internal class PickPotStepDefinition
    {
        private readonly PageObject _pageObject;

        public PickPotStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDevAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenuAsync(string menuLogin)
        {
            menuLogin = $".nav-desktop a[href='/Account']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(menuLogin);
        }

        [When(@"I write the e-mail for my login")]
        public async Task WhenIWriteTheE_MailForMyLoginAsync()
        {
            string selector = "#email";
            string email = "hgalan+autotest3@axs.com";
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
        public async Task WhenIPressTheButtonToConfirmAsync(string confirmationLogin)
        {
            confirmationLogin = $"button.form-primary-cta[type='submit']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(confirmationLogin);
        }

        [When(@"I get to the main account page")]
        public async Task WhenIGetToTheMainAccountPageAsync()
        {
            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Account/Dashboard";
            var actualUrl = _pageObject.Page.Url;

            Assert.IsTrue(actualUrl.Equals(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }

        [When(@"I press the button ""([^""]*)"" to get to the pot page")]
        public async Task WhenIPressTheButtonToGetToThePotPageAsync(string pickPot)
        {
            pickPot = $"a.acc-button[href='/Pot/View/15']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(pickPot);
        }

        [When(@"I press the button ""([^""]*)"" to choose the event and get to the ticket type page")]
        public async Task WhenIPressTheButtonToChooseTheEventAndGetToTheTicketTypePageAsync(string ticketType)
        {
            ticketType = $"a[href*='/Pot/Add/'].tickets";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(ticketType);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket")]
        public async Task WhenISelectATicketTypeByPressingTheButtonOnceForOneTicketAsync(string plusButton)
        {
            plusButton = $"button:text('+')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(plusButton);
        }

        [When(@"I press the button '([^']*)' to get to the cart")]
        public async Task WhenIPressTheButtonToGetToTheCartAsync(string findTicket)
        {
            findTicket = $"a.link-btn-regular.btn-find-tickets";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(findTicket);
        }

        [Then(@"I get to the Klarna flow for free until the succeed page")]
        public async Task ThenIGetToTheKlarnaFlowForFreeUntilTheSucceedPageAsync()
        {
            //Opening the iFrame
            string selectorIframe = "#klarna-checkout-iframe";

            //Write the postal-code in KLarna field
            string selectorFieldPostal = "#billing-postal_code";
            await _pageObject.Page.WaitForSelectorAsync(selectorIframe);
            string post = "61135";
            await _pageObject.Page.FrameLocator(selectorIframe).Locator(selectorFieldPostal).FillAsync(post);
            for (int i = 0; i < 12; i++)
            {
                await _pageObject.Page.Keyboard.PressAsync("Tab");
            }
            await _pageObject.Page.Keyboard.PressAsync("Enter");

            //Press the button in the cart to confirm the purchase
            string selector = $"button[data-cid='button.buy_button']";
            await _pageObject.Page.WaitForSelectorAsync(selectorIframe);
            await _pageObject.Page.FrameLocator(selectorIframe).Locator(selector).ClickAsync();

            //Checking if I get to the right URL
            await Task.Delay(5000);
            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess";
            var actualUrl = _pageObject.Page.Url;
            Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }
    }
}
