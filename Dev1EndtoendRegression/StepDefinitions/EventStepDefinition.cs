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
            //string selector = "input#billing-email";
            //await _pageObject.Page.WaitForSelectorAsync(selector);
            //string email = "hgalan@axs.com";
            //await _pageObject.Page.FillAsync(selector, email);
        }


        [When(@"write my post")]
        public async Task WhenWriteMyPostAsync()
        {
            //string selector = "billing-postal_code";
            //string post = "61138";
            //await _pageObject.Page.FillAsync(selector, post);
        }

        [When(@"press the button '([^']*)' in Klarna checkout")]
        public void WhenPressTheButtonInKlarnaCheckout(string fORTSÄTT)
        {
            
        }

        [When(@"press the button '([^']*)' to continue Klarna checkout")]
        public void WhenPressTheButtonToContinueKlarnaCheckout(string p0)
        {
            
        }

        [When(@"press the button '([^']*)' to finish the purchase")]
        public void WhenPressTheButtonToFinishThePurchase(string p0)
        {
            
        }

        [Then(@"I get to the success page '([^']*)'")]
        public void ThenIGetToTheSuccessPage(string p0)
        {
            
        }

    }
}
