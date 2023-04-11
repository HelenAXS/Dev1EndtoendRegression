using Dev1EndtoendRegression.Objects;
using Microsoft.Playwright;
using Microsoft.Playwright.Helpers;


namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    internal class EventStepDefinition
    {
        private readonly PageObject _pageObject;

        public EventStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDevAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenuAsync(string matches)
        {
            string selector = $".nav-desktop a[href='/List/Events']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button '([^']*)'")]
        public async Task WhenIPressTheButtonAsync(string buyTicket)
        {
            string selector = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=332&IsSeason=False']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket")]
        public async Task WhenISelectATicketTypeByPressingTheButtonOnceForOneTicketAsync(string pressPlus)
        {
            string selector = $"button:text('+')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button 'HITTA (.*) BILJETT\(ER\)")]
        public async Task WhenIPressTheButtonHITTABILJETTERAsync(string pressFind)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets:text('Hitta 1 Biljett(er)')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCart(string goFurther)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash:text('Gå vidare')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"write my e-mail")]
        public async Task WhenWriteMyE_MailAsync()
        {
            string selectorIframe = "#klarna-checkout-iframe";
            string selectorField = "#billing-email";
            await _pageObject.Page.WaitForSelectorAsync(selectorIframe);
            string email = "hgalan@axs.com";
            await _pageObject.Page.FrameLocator(selectorIframe).Locator(selectorField).FillAsync(email);
        }

        [When(@"write my post")]
        public async Task WhenWriteMyPostAsync()
        {
            string selectorIframe = "#klarna-checkout-iframe";
            string selectorField = "#billing-postal_code";

            await _pageObject.Page.WaitForSelectorAsync(selectorIframe);
            string post = "61138";
            await _pageObject.Page.FrameLocator(selectorIframe).Locator(selectorField).FillAsync(post);
            await _pageObject.Page.Keyboard.PressAsync("Tab");
        }

        [When(@"press the button '([^']*)' to continue Klarna checkout")]
        public async Task WhenPressTheButtonToContinueKlarnaCheckout(string buttonPayPurchase)
        {
            string selector = $"button:has-text('Betala köp')";
            string iFrameSelector = $"#klarna-checkout-iframe";

            await _pageObject.Page.WaitForSelectorAsync(iFrameSelector);
            await _pageObject.Page.FrameLocator(iFrameSelector).Locator(selector).ClickAsync();
        }

        [When(@"press the button '([^']*)' to finish the purchase")]
        public async Task WhenPressTheButtonToFinishThePurchase(string payment)
        {
            //string paymentSelector = $"button:has-text('Betala {payment} kr idag med K.')";
            string iFrameSelector = $"#klarna-checkout-iframe";
            string bankIDselector = $"button#signInWithBankId[data-testid='kaf-button']";

            await _pageObject.Page.WaitForSelectorAsync(iFrameSelector);
            //await _pageObject.Page.FrameLocator(iFrameSelector).Locator(paymentSelector).ClickAsync();
            await _pageObject.Page.FrameLocator(iFrameSelector).Locator(bankIDselector).ClickAsync();
        }

        [Then(@"I get to the success page '([^']*)'")]
        public void ThenIGetToTheSuccessPage(string p0)
        {
            
        }

    }
}
