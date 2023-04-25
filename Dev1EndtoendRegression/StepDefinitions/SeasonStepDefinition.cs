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

        [When(@"press the button '([^']*)' to the cart")]
        public async Task WhenPressTheButtonToTheCart(string goFurther)
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
            var page = _pageObject.Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await page.ClickAsync($"#signInWithBankId");
        }

        [When(@"press the button '([^']*)' to go further")]
        public async Task WhenPressTheButtonToGoFurtherAsync(string kPoint)
        {
            var page = _pageObject.Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await page.ClickAsync($"[data-testid='confirm-and-pay']");
        }

        [When(@"press the button '([^']*)' do choose the faster payment method")]
        public async Task WhenPressTheButtonDoChooseTheFasterPaymentMethodAsync(string p0)
        {
            var page = _pageObject.Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await page.ClickAsync($"[data-testid='SmoothCheckoutPopUp:enable']");
        }

        [Then(@"I get to the success page '([^']*)'")]
        public async Task ThenIGetToTheSuccessPageAsync(string successPage)
        {
            await Task.Delay(20000);

            await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess";
            var actualUrl = _pageObject.Page.Url;

            if (actualUrl.Contains(expectedUrl))
            {
                // Expected URL loaded directly, so no need to wait for Cart page
                Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            }
            else
            {
                var cartBetweenExpectedUrl = "https://web4.1.dev.tt.eu.axs.com/Cart";

                // Wait for Cart page to load
                while (actualUrl.Contains(cartBetweenExpectedUrl))
                {
                    // Handle unexpected URLs
                    if (!actualUrl.Contains(cartBetweenExpectedUrl))
                    {
                        Assert.Fail($"Unexpected URL: {actualUrl}");
                    }

                    await Task.Delay(20000);
                    actualUrl = _pageObject.Page.Url;
                }

                // Wait for KlarnaSuccess page to load
                while (!actualUrl.Contains(cartBetweenExpectedUrl))
                {
                    await Task.Delay(20000);
                    actualUrl = _pageObject.Page.Url;
                }

                // At this point, actualUrl contains expectedUrl
                Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            }






            //working sometimes
            //await _pageObject.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            //var finalExpected = "https://web4.1.dev.tt.eu.axs.com/Cart";
            //var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess";
            //var actualUrl = _pageObject.Page.Url;

            //Assert.IsTrue(actualUrl.Contains(finalExpected), $"Expected URL: {finalExpected}, Actual URL: {actualUrl}");
            //Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            //

            //var expectedText = "h1.role:heading, Ditt köp har genomförts!";
            //var actualText = await _pageObject.Page.TextContentAsync("body");
            //Assert.IsTrue(actualText.Contains(expectedText), $"Expected text: {expectedText}, Actual text: {actualText}");

            //var expectedText = "Ditt köp har genomförts!";
            //var selector = "h1[role='heading'][aria-level='1']";
            //var actualText = await _pageObject.Page.TextContentAsync(selector);
            //Assert.IsTrue(actualText.Contains(expectedText), $"Expected text: {expectedText}, Actual text: {actualText}");

            //var expectedText = "Ditt köp har genomförts!";
            //var selector = "h1[role='heading'][aria-level='1']";
            //await _pageObject.Page.WaitForSelectorAsync(selector);
            //var element = await _pageObject.Page.QuerySelectorAsync(selector);
            //var actualText = await element.TextContentAsync();
            //Assert.IsTrue(actualText.Contains(expectedText), $"Expected text: {expectedText}, Actual text: {actualText}");

            //var expectedText = "Ditt köp har genomförts!";
            //var selector = "h1[role='heading'][aria-level='1']";
            //await _pageObject.Page.WaitForSelectorAsync(selector);
            //var element = await _pageObject.Page.QuerySelectorAsync(selector);
            //string actualText = null;
            //while (string.IsNullOrEmpty(actualText))
            //{
            //    actualText = await element.TextContentAsync();
            //    await Task.Delay(1000); // wait for 1 second before trying again
            //}
            //Assert.IsTrue(actualText.Contains(expectedText), $"Expected text: {expectedText}, Actual text: {actualText}");

            //await Expected(_pageObject.Page.GetByRole(AriaRole.Heading, new() { Name = "Ditt köp har genomförts!" })).ToBeVisibleAsync();

            //var textInPage = await _pageObject();
            //textInPage.Should().Be("Ditt köp har genomförts!");



            //var successMessage = await _pageObject.GetSuccessPageAsync();
            //successMessage.Should().Be("Ditt köp har genomförts!");
        }
    }
}
