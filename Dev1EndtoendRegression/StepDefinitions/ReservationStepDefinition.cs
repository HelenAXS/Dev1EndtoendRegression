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
            string email = "hgalan@axs.com";
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


    }
}
