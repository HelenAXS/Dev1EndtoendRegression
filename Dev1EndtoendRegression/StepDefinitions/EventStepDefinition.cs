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

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCart(string goFurther)
        {
            goFurther = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash[href='/Cart']:first-of-type";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(goFurther);

            //string selector = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash:text('Gå vidare')";
            //bool isVisible = await _pageObject.IsElementVisibleAsync(_pageObject.Page, selector);

            //if (!string.IsNullOrEmpty(goFurther))
            //{
            //    if (isVisible)
            //    {
            //        string mapSelector = $"*[@id=\"ChooseSection-Component\"]";
            //        await _pageObject.ClickButtonsAndMenuOptionsAsync(mapSelector);

            //        string seatSelector = $"*[@id=\"ChooseSeats-Component\"]";
            //        await _pageObject.ClickButtonsAndMenuOptionsAsync(seatSelector);


            //        await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
            //    }
            //    else
            //    {
            //        await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
            //    }
            //}
        }

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPage()
        {
            string email = "hgalan@axs.com";
            await _pageObject.KlarnaPaymentAsync(email);
        }
    }
}
