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
    [Scope(Tag = "reservation")]
    internal class ReservationStepDefinition
    {
        private readonly PageObject _pageObject;

        public ReservationStepDefinition(PageObject pageObject)
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
        public async Task WhenIPressTheButtonAsync(string p0)
        {
            string selector = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=332&IsSeason=False']";
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

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCartAsync(string p0)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash:text('Gå vidare')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the menu '([^']*)' again")]
        public async Task WhenIPressTheMenuAgainAsync(string sÄSONGER)
        {
            string selector = $".nav-desktop a[href='/List/Seasons']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button '([^']*)' again")]
        public async Task WhenIPressTheButtonAgainAsync(string p0)
        {
            string selector = $"a.btn.tickets[href='/Tickets/ChooseTickets?Id=63&IsSeason=True']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I select a ticket type by pressing the button '([^']*)' once for one ticket again")]
        public async Task WhenISelectATicketTypeByPressingTheButtonOnceForOneTicketAgainAsync(string p0)
        {
            string selector = $"button:text('+')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press the button '([^']*)' to find the seats again")]
        public async Task WhenIPressTheButtonToFindTheSeatsAgainAsync(string p0)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets:text('Hitta 1 Biljett(er)')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"press the button '([^']*)' to the cart again")]
        public async Task WhenPressTheButtonToTheCartAgainAsync(string p0)
        {
            string selector = $"a.link-btn-regular.btn-find-tickets.btn-ripple.btn-jsSplash:text('Gå vidare')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }


        [When(@"I press the menu '([^']*)' one more time")]
        public async Task WhenIPressTheMenuOneMoreTimeAsync(string pRODUKTER)
        {
            string selector = $".nav-desktop a[href='/Products']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to buy a product")]
        public async Task WhenIPressToBuyAProductAsync(string kÖP)
        {
            string selector = $"button.modaltrigger[data-target='buyModal-357']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to keep buying")]
        public async Task WhenIPressToKeepBuyingAsync(string p0)
        {
            string selector = $"#buyModal-357 button[name='productsubmit']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to buy the pot this time")]
        public async Task WhenIPressToBuyThePotThisTimeAsync(string kÖP)
        {
            string selector = $"button.modaltrigger[data-target='buyModal-334']";
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

        [When(@"I press '([^']*)' to proceed to cart")]
        public async Task WhenIPressToProceedToCartAsync(string p0)
        {
            string selector = $"#buyModal-334 button[name='productsubmit']:text('Gå vidare')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"in the cart I press the button ""([^""]*)"" to reserve the purchase")]
        public async Task WhenInTheCartIPressTheButtonToReserveThePurchase(string reservera)
        {
            string selector = $"a.button[href='/Checkout/SetExternalPaytype?routeAction=Reservation']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I write the e-mail for login")]
        public async Task WhenIWriteTheE_MailForLoginAsync()
        {
            string selector = "#email";
            string email = "hgalan+automation@axs.com";
            await _pageObject.Page.Locator(selector).FillAsync(email);
        }

        [When(@"I write the password for login")]
        public async Task WhenIWriteThePasswordForLoginAsync()
        {
            string selector = "#password";
            string password = "hgalan@axs.com";
            await _pageObject.Page.Locator(selector).FillAsync(password);
        }

        [When(@"I press ""([^""]*)"" to confirm")]
        public async Task WhenIPressToConfirmAsync(string loggaIn)
        {
            string selector = $"input[type='submit'].link-btn-regular[value='Logga in']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I checkbox to accept the terms")]
        public async Task WhenICheckboxToAcceptTheTermsAsync()
        {
            string selector = $"input[type='checkbox']#terms[name='terms'][title='Terms and conditions'][required]";
            await _pageObject.Page.CheckAsync(selector);
        }

        [When(@"I get to the page with my information and press the button to confirm")]
        public async Task WhenIGetToThePageWithMyInformationAndPressTheButtonToConfirmAsync()
        {
            string selector = $"input[type='submit'].link-btn-regular[value='Spara uppgifter och slutför ordern']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I get to the success page of the reservation")]
        public async Task ThenIGetToTheSuccessPageOfTheReservationAsync()
        {
            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/ReservationSuccess";
            var actualUrl = _pageObject.Page.Url;

            Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }

        [When(@"I write the e-mail for my login")]
        public async Task WhenIWriteTheE_MailForMyLoginAsync()
        {
            string selector = "#email";
            string email = "hgalan+automation@axs.com";
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
        public async Task WhenIPressTheButtonToConfirmAsync(string p0)
        {
            string selector = $"button.form-primary-cta[type='submit']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I get to the main account page")]
        public async Task WhenIGetToTheMainAccountPageAsync()
        {
            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Account/Dashboard";
            var actualUrl = _pageObject.Page.Url;

            Assert.IsTrue(actualUrl.Equals(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
        }

        [When(@"I press the button ""([^""]*)"" to get to the reservation page")]
        public async Task WhenIPressTheButtonToGetToTheReservationPageAsync(string reservationer)
        {
            string selector = $"a.account-tab[href='Reservations']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"press the button ""([^""]*)"" to pick up the reservation order")]
        public async Task WhenPressTheButtonToPickUpTheReservationOrderAsync(string p0)
        {
            string selector = $"button.cta.acc-button.acc-button-release[name='mode'][value='1']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"confirm the picking to get to the cart")]
        public async Task WhenConfirmThePickingToGetToTheCartAsync()
        {
            string selector = $"button.link-btn-regular.acc-button-confirm-release.mb-5[name='mode'][value='1']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPageAsync()
        {
            await _pageObject.KlarnaPaymentFlowFromAccountAsync();
        }
    }
}
