using Dev1EndtoendRegression.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    [Scope(Tag = "package")]
    internal class PackageStepDefinition
    {
        private readonly PageObject _pageObject;

        public PackageStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDevAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenuAsync(string mATCHER)
        {
            string selector = $".nav-desktop a[href='/List/Events']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button '([^']*)'")]
        public async Task WhenIPressTheButtonAsync(string kopBiljett)
        {
            string selector = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=359&IsSeason=False']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket")]
        public async Task WhenISelectATicketTypeByPressingTheButtonOnceForOneTicketAsync(string p0)
        {
            string selector = $"button:text('+')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }


        [When(@"I press the button '([^']*)' to find the seats")]
        public async Task WhenIPressTheButtonToFindTheSeatsAsync(string p0)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
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
            string sectionSelector = $"#svg g[data-id='F/1/27'][id='F-1-27']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(sectionSelector);
        }

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCartAsync(string p0)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash:text('Gå vidare')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPageAsync()
        {
            string email = "hgalan@axs.com";
            await _pageObject.KlarnaPaymentAsync(email);
        }

    }
}
