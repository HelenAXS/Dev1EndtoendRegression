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
            string[] seatSelectors = new string[]
            {
            "#svg g[data-id='F/9/38'][id='F-9-38']",
            "#svg g[data-id='F/8/38'][id='F-8-38']",
            "#svg g[data-id='F/7/38'][id='F-7-38']",
            "#svg g[data-id='F/6/38'][id='F-6-38']",
            "#svg g[data-id='F/5/38'][id='F-5-38']",
            "#svg g[data-id='F/4/38'][id='F-4-38']",
            "#svg g[data-id='F/3/38'][id='F-3-38']",
            "#svg g[data-id='F/2/38'][id='F-2-38']",
            "#svg g[data-id='F/1/38'][id='F-1-38']",
            "#svg g[data-id='F/9/39'][id='F-9-39']",
            "#svg g[data-id='F/8/39'][id='F-8-39']",
            "#svg g[data-id='F/7/39'][id='F-7-39']",
            "#svg g[data-id='F/6/39'][id='F-6-39']",
            "#svg g[data-id='F/5/39'][id='F-5-39']",
            "#svg g[data-id='F/4/39'][id='F-4-39']",
            "#svg g[data-id='F/3/39'][id='F-3-39']",
            "#svg g[data-id='F/2/39'][id='F-2-39']",
            "#svg g[data-id='F/1/39'][id='F-1-39']",
            "#svg g[data-id='F/9/40'][id='F-9-40']",
            "#svg g[data-id='F/8/40'][id='F-8-40']",
            "#svg g[data-id='F/7/40'][id='F-7-40']",
            "#svg g[data-id='F/6/40'][id='F-6-40']",
            "#svg g[data-id='F/5/40'][id='F-5-40']",
            "#svg g[data-id='F/4/40'][id='F-4-40']",
            "#svg g[data-id='F/3/40'][id='F-3-40']",
            "#svg g[data-id='F/2/40'][id='F-2-40']",
            "#svg g[data-id='F/1/40'][id='F-1-40']",
            "#svg g[data-id='F/9/45'][id='F-9-45']",
            "#svg g[data-id='F/8/45'][id='F-8-45']",
            "#svg g[data-id='F/7/45'][id='F-7-45']",
            "#svg g[data-id='F/6/45'][id='F-6-45']",
            "#svg g[data-id='F/5/45'][id='F-5-45']",
            "#svg g[data-id='F/4/45'][id='F-4-45']",
            "#svg g[data-id='F/3/45'][id='F-3-45']",
            "#svg g[data-id='F/2/45'][id='F-2-45']",
            "#svg g[data-id='F/1/45'][id='F-1-45']"
            };

            foreach (string seatSelector in seatSelectors)
            {
                await _pageObject.ClickButtonsAndMenuOptionsAsync(seatSelector);

                string goFurtherButton = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash[href='/Cart']:first-of-type";
                if (await _pageObject.HasElementAsync(goFurtherButton))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCart(string goFurther)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash[href='/Cart']:first-of-type";
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
