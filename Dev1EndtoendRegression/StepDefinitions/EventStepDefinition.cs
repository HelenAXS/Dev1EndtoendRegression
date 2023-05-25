using Dev1EndtoendRegression.Objects;
using Microsoft.Playwright;

//[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]
namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    [Scope(Tag = "event")]
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
        public async Task GivenIPressTheMenuAsync(string menuMatches)
        {
            menuMatches = $".nav-desktop a[href='/List/Events']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(menuMatches);
        }

        [When(@"I press the button '([^']*)'")]
        public async Task WhenIPressTheButtonAsync(string buyTicket)
        {
            buyTicket = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=332&IsSeason=False']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(buyTicket);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket")]
        public async Task WhenISelectATicketTypeByPressingTheButtonOnceForOneTicketAsync(string pressPlus)
        {
            pressPlus = $"button:text('+')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(pressPlus);
        }

        [When(@"I press the button '([^']*)' to find the seats")]
        public async Task WhenIPressTheButtonToFindTheSeats(string findSeats)
        {
            findSeats = $"a.link-btn-regular.btn-find-tickets";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(findSeats);
        }

        [When(@"press the one section on the map")]
        public async Task WhenPressTheOneSectionOnTheMapAsync()
        {
            string sectionSelector = $"#svgareamap #SektionF";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(sectionSelector);
        }

        [When(@"press the one seat on the map")]
        public async Task WhenPressTheOneSeatOnTheMapAsync()
        {
            string sectionSelector = $"#svg g[data-id='F/1/23'][id='F-1-23']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(sectionSelector);
        }

        [When(@"press the button to select a seat")]
        public async Task WhenPressTheButtonToSelectASeatAsync()
        {
            string goFurther = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash[href='/Cart']:first-of-type";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(goFurther);
        }

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPage()
        {
            string email = "hgalan@axs.com";
            await _pageObject.KlarnaPaymentAsync(email);
        }
    }
}
