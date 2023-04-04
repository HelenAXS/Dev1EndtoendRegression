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
            await _pageObject.ClickMatcherMenuOptionAsync(selector);
        }

        [When(@"I press the button '([^']*)'")]
        public async Task WhenIPressTheButtonAsync(string buyTicket)
        {
            string selector = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=332&IsSeason=False']";
            await _pageObject.ClickMatcherMenuOptionAsync(selector);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket")]
        public void WhenISelectATicketTypeByPressingTheButtonOnceForOneTicket(string p0)
        {
            
        }

        [When(@"I press the button 'HITTA (.*) BILJETT\(ER\)")]
        public void WhenIPressTheButtonHITTABILJETTER(int p0)
        {
            
        }

        [When(@"it choose a seat of chose it myself")]
        public void WhenItChooseASeatOfChoseItMyself()
        {
            
        }

        [When(@"press the button '([^']*)' to the cart")]
        public void WhenPressTheButtonToTheCart(string p0)
        {
            
        }

        [When(@"write my e-mail and post")]
        public void WhenWriteMyE_MailAndPost()
        {
            
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
