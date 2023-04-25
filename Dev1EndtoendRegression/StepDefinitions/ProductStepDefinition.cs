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
    [Scope(Tag = "product")]
    internal class ProductStepDefinition
    {
        private readonly PageObject _pageObject;

        public ProductStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDevAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenuAsync(string pRODUKTER)
        {
            string selector = $".nav-desktop a[href='/Products']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to buy a product")]
        public async Task WhenIPressToBuyAProductAsync(string kÖP)
        {
            string selector = $"button.modaltrigger[data-target='buyModal-210']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to keep buying")]
        public async Task WhenIPressToKeepBuyingAsync(string keepBuying)
        {
            string selector = $"#buyModal-210 button[name='productsubmit']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to buy a product again")]
        public async Task WhenIPressToBuyAProductAgainAsync(string kÖP)
        {
            string selector = $"button.modaltrigger[data-target='buyModal-274']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to proceed to cart")]
        public async Task WhenIPressToProceedToCartAsync(string goFurther)
        {
            string selector = $"#buyModal-274 button[name='productsubmit']:text('Gå vidare')";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }
        
        [When(@"write my e-mail")]
        public async Task WhenWriteMyE_Mail()
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
        public async Task WhenPressTheButtonToContinueKlarnaCheckoutAsync(string p0)
        {
            string selector = $"button:has-text('Betala köp')";
            string iFrameSelector = $"#klarna-checkout-iframe";

            await _pageObject.Page.WaitForSelectorAsync(iFrameSelector);
            await _pageObject.Page.FrameLocator(iFrameSelector).Locator(selector).ClickAsync();
        }

        [When(@"press the button '([^']*)' to finish the purchase")]
        public async Task WhenPressTheButtonToFinishThePurchaseAsync(string p0)
        {
            var page = _pageObject.Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await page.ClickAsync($"#signInWithBankId");
        }

        [When(@"press the button '([^']*)' to go further")]
        public async Task WhenPressTheButtonToGoFurtherAsync(string p0)
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
        public async Task ThenIGetToTheSuccessPageAsync(string p0)
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
        }

    }
}
