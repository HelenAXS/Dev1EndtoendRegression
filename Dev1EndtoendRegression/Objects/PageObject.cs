using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev1EndtoendRegression.Objects
{
    public class PageObject : ObjectsBase
    {
        public override string PagePath => "https://web4.1.dev.tt.eu.axs.com/";


        public override IPage Page { get; set; }

        public override IBrowser Browser => Page.Context.Browser;

        public PageObject(IPage page)
        {
            Page = page;
        }

        public async Task ClickButtonsAndMenuOptionsAsync(string selector)
        {
            var element = await Page.WaitForSelectorAsync(selector);
            await element.ClickAsync();
        }

        public async Task KlarnaPayment()
        {
            string selectorIframe = "#klarna-checkout-iframe";
            string selectorFieldEmail = "#billing-email";
            await Page.WaitForSelectorAsync(selectorIframe);
            string email = "hgalan@axs.com";
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldEmail).FillAsync(email);


            string selectorFieldPostal = "#billing-postal_code";


            await Page.WaitForSelectorAsync(selectorIframe);
            string post = "61138";
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldPostal).FillAsync(post);
            await Page.Keyboard.PressAsync("Tab");


            string selector = $"button:has-text('Betala köp')";
            string iFrameSelector = $"#klarna-checkout-iframe";

            await Page.WaitForSelectorAsync(iFrameSelector);
            await Page.FrameLocator(iFrameSelector).Locator(selector).ClickAsync();


            var pageBankId = Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await pageBankId.ClickAsync($"#signInWithBankId");


            var pageConfirm = Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await pageConfirm.ClickAsync($"[data-testid='confirm-and-pay']");


            var pageSmoth = Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await pageSmoth.ClickAsync($"[data-testid='SmoothCheckoutPopUp:enable']");


            await Task.Delay(20000);

            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess";
            var actualUrl = Page.Url;

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
                    actualUrl = Page.Url;
                }

                // Wait for KlarnaSuccess page to load
                while (!actualUrl.Contains(cartBetweenExpectedUrl))
                {
                    await Task.Delay(20000);
                    actualUrl = Page.Url;
                }

                // At this point, actualUrl contains expectedUrl
                Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            }
        }
    }
}
