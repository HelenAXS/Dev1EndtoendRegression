using Dev1EndtoendRegression.Objects;
using Microsoft.Playwright;


namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    [Scope(Tag = "season")]
    internal class SeasonStepDefinition
    {
        private readonly PageObject _pageObject;

        public SeasonStepDefinition(PageObject pageObject)
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
            string selector = $".nav-desktop a[href='/List/Seasons']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button '([^']*)'")]
        public async Task WhenIPressTheButtonAsync(string buyTicket)
        {
            string selector = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=63&IsSeason=True']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket")]
        public async Task WhenISelectATicketTypeByPressingTheButtonOnceForOneTicketAsync(string pressPlus)
        {
            string selector = $"button:text('+')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button '([^']*)' to find the seats")]
        public async Task WhenIPressTheButtonToFindTheSeats(string findSeats)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets:text('Hitta 1 Biljett(er)')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"press the one section on the map")]
        public async Task WhenPressTheOneSectionOnTheMapAsync()
        {
            string sectionSelector = $"#svgareamap #SektionF";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(sectionSelector);
        }

        [When(@"press the button to select a seat")]
        public async Task WhenPressTheButtonToSelectASeatAsync()
        {
            string sectionSelector = $"#svg g[data-id='F/1/27'][id='F-1-27']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(sectionSelector);
        }

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCart(string goFurther)
        {
            string selector = $"[data-event-id='63'] a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash[href='/Cart']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPage()
        {
            string email = "hgalan@axs.com";
            await _pageObject.KlarnaPaymentAsync(email);
        }

    }
}
