using Dev1EndtoendRegression.Objects;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    [Scope(Tag = "potAndProduct")]
    internal class PotStepDefinition
    {
        private readonly PageObject _pageObject;

        public PotStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDev()
        {
            await _pageObject.NavigateAsync();
            //await Task.Delay(5000); //deactivate it when not using Queue-it
        }

        [Given(@"I press menu '([^']*)'")]
        public async Task GivenIPressTheMenu(string menuProductSelector)
        {
            menuProductSelector = $".nav-desktop a[href='/Products']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(menuProductSelector);
        }

        [Given(@"I press the menu '([^']*)' for product")]
        public async Task GivenIPressTheMenuForProductAsync(string menuProductSelector)
        {
            menuProductSelector = $".nav-desktop a[href='/Products']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(menuProductSelector);
        }


        [Given(@"I press the option '([^']*)'")]
        public async Task GivenIPressTheOption(string optionPotMenuSelector)
        {
            optionPotMenuSelector = "ul li a[href='/Products/Category/22']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(optionPotMenuSelector);
        }

        [Given(@"I press the button '([^']*)'")]
        public async Task GivenIPressTheButtonAsync(string plusSelector)
        {
            plusSelector = $"//div[2]/div[2]/div[2]/div/div/div[14]/form/div[2]/div[1]/span[2]"; //change position
            await _pageObject.ClickButtonsAndMenuOptionsAsync(plusSelector);
        }

        [Given(@"I press the button '([^']*)' for product")]
        public async Task GivenIPressTheButtonForProductAsync(string plusSelector)
        {
            plusSelector = $"//div[2]/div[2]/div[2]/div/div/div[20]/form/div[2]/div[1]/span[2]"; //change position
            await _pageObject.ClickButtonsAndMenuOptionsAsync(plusSelector);
        }

        [When(@"I press '([^']*)' to buy a pot")]
        public async Task WhenIPressToBuyAPotAsync(string buyButtonSelector)
        {
            buyButtonSelector = $"button.modaltrigger[data-target='buyModal-334']"; //change ID
            await _pageObject.ClickButtonsAndMenuOptionsAsync(buyButtonSelector);
        }

        [When(@"I press '([^']*)' to buy a product")]
        public async Task WhenIPressToBuyAProductAsync(string buyButtonSelector)
        {
            buyButtonSelector = $"button.modaltrigger[data-target='buyModal-357']"; //change ID
            await _pageObject.ClickButtonsAndMenuOptionsAsync(buyButtonSelector);
        }


        [When(@"I press '([^']*)' to keep buying")]
        public async Task WhenIPressToKeepBuyingAsync(string keepBuyingSelector)
        {
            keepBuyingSelector = $"//*[@id=\"buyModal-334\"]/div/div[2]/div/div/div[1]/button";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(keepBuyingSelector);
        }

        [When(@"I press '([^']*)' to keep buying for product")]
        public async Task WhenIPressToKeepBuyingForProductAsync(string keepBuyingSelector)
        {
            keepBuyingSelector = $"//*[@id=\"buyModal-357\"]/div/div[2]/div/div/div[1]/button";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(keepBuyingSelector);
        }

        [When(@"I press the button '([^']*)' again")]
        public async Task WhenIPressTheButtonAgainAsync(string plusSelector)
        {
            plusSelector = $"//div[2]/div[2]/div[2]/div/div/div[34]/form/div[2]/div[1]/span[2]"; //change position
            await _pageObject.ClickButtonsAndMenuOptionsAsync(plusSelector);
        }

        [When(@"I press the button '([^']*)' for product again")]
        public async Task WhenIPressTheButtonForProductAgainAsync(string plusSelector)
        {
            plusSelector = $"//div[2]/div[2]/div[2]/div/div/div[20]/form/div[2]/div[1]/span[2]"; //change position
            await _pageObject.ClickButtonsAndMenuOptionsAsync(plusSelector);
        }


        [When(@"I press '([^']*)' to buy a pot again")]
        public async Task WhenIPressToBuyAPotAgainAsync(string buyButtonSelector)
        {
            buyButtonSelector = $"button.modaltrigger[data-target='buyModal-334']"; //change ID
            await _pageObject.ClickButtonsAndMenuOptionsAsync(buyButtonSelector);
        }

        [When(@"I press '([^']*)' to buy a product again")]
        public async Task WhenIPressToBuyAProductAgainAsync(string buyButtonSelector)
        {
            buyButtonSelector = $"button.modaltrigger[data-target='buyModal-357']"; //change ID
            await _pageObject.ClickButtonsAndMenuOptionsAsync(buyButtonSelector);
        }


        [When(@"I press '([^']*)' to proceed to cart")]
        public async Task WhenIPressToProceedToCartAsync(string goFurtherButtonSelector)
        {
            goFurtherButtonSelector = $"#buyModal-334 button[name='productsubmit']:text('Gå vidare')"; //change ID
            await _pageObject.ClickButtonsAndMenuOptionsAsync(goFurtherButtonSelector);
        }

        [When(@"I press '([^']*)' to proceed to cart for product")]
        public async Task WhenIPressToProceedToCartForProductAsync(string goFurtherButtonSelector)
        {
            goFurtherButtonSelector = $"#buyModal-357 button[name='productsubmit']:text('Gå vidare')"; //change ID
            await _pageObject.ClickButtonsAndMenuOptionsAsync(goFurtherButtonSelector);
        }


        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPageAsync()
        {
            string email = "hgalan@axs.com";
            await _pageObject.KlarnaPaymentAsync(email);
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

