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

        public async Task KlarnaPaymentAsync(string email)
        {

            //Opening the iFrame
            string selectorIframe = "#klarna-checkout-iframe";

            //Write the e-mail in Klarna field
            string selectorFieldEmail = "#billing-email";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Task.Delay(2000);
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldEmail).FillAsync(email);



            //Write the postal in KLarna field
            string selectorFieldPostal = "#billing-postal_code";
            await Page.WaitForSelectorAsync(selectorIframe);
            string post = "61138";
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldPostal).FillAsync(post);
            await Page.Keyboard.PressAsync("Tab");

            //Press the button in the cart to confirm the purchase
            string selectorBuyButton = $"button[data-cid='button.buy_button']";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Page.FrameLocator(selectorIframe).Locator(selectorBuyButton).ClickAsync();

            //Press the BankId to continue
            var pageBankId = Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            await pageBankId.ClickAsync("#signInWithBankId");

            //Managing different flows of Klarna
            string selectorLoop = $"button[data-testid='confirm-and-pay']";
            if (selectorLoop != null)
            {
                //Confirmation of the payment
                await pageBankId.ClickAsync(selectorLoop);
                await pageBankId.ClickAsync($"[data-testid='SmoothCheckoutPopUp:enable']");

            }
            else
            {

                var radio = await pageBankId.QuerySelectorAsync("#pay_later-pay_later__radio-wrapper");
                await radio.ClickAsync();

                await pageBankId.ClickAsync($"#pay_later-pay_later__radio-wrapper");

                await pageBankId.ClickAsync($"button[data-testid='select-payment-category']");

                await pageBankId.ClickAsync(selectorLoop);
            }


            //Checking the succeed page in dev1

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

                    await Task.Delay(5000);
                    actualUrl = Page.Url;
                }

                // At this point, actualUrl contains expectedUrl
                Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            }
        }

        public async Task KlarnaPaymentFlowFromAccountAsync()
        {

            //Opening the iFrame
            string selectorIframe = "#klarna-checkout-iframe";

            //Write the postal in KLarna field
            string selectorFieldPostal = "#billing-postal_code";
            await Page.WaitForSelectorAsync(selectorIframe);
            string post = "61138";
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldPostal).FillAsync(post);
            for (int i = 0; i < 12; i++)
            {
                await Page.Keyboard.PressAsync("Tab");
            }
            await Page.Keyboard.PressAsync("Enter");

            //Press the button in the cart to confirm the purchase
            string selector = $"button[data-cid='button.buy_button']";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Page.FrameLocator(selectorIframe).Locator(selector).ClickAsync();

            //Start pop-Up LOOP
            var pageBankId = Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            if (pageBankId != null)
            {
                //Press the BankId to continue
                await pageBankId.ClickAsync("#signInWithBankId");

                //Managing different flows of Klarna
                string selectorLoop = $"button[data-testid='confirm-and-pay']";
                if (selectorLoop != null)
                {
                    //Confirmation of the payment
                    await pageBankId.ClickAsync(selectorLoop);

                }
                else
                {

                    var radio = await pageBankId.QuerySelectorAsync("#pay_later-pay_later__radio-wrapper");
                    await radio.ClickAsync();

                    await pageBankId.ClickAsync($"#pay_later-pay_later__radio-wrapper");

                    await pageBankId.ClickAsync($"button[data-testid='select-payment-category']");

                    await pageBankId.ClickAsync(selectorLoop);
                }

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
            else
            {
                var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess";
                var actualUrl = Page.Url;

                // Expected URL loaded directly, so no need to wait for Cart page
                Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            }

        }


        public async Task KlarnaPaymentFlowFromAccountPotAsync(string email)
        {
            //Opening the iFrame
            string selectorIframe = "#klarna-checkout-iframe";

            //Write the e-mail in KLarna field
            string selectorFieldEmail = "#billing-email";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldEmail).FillAsync(email);

            //Write the postal-code in KLarna field
            string selectorFieldPostal = "#billing-postal_code";
            await Page.WaitForSelectorAsync(selectorIframe);
            string post = "61135";
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldPostal).FillAsync(post);
            for (int i = 0; i < 12; i++)
            {
                await Page.Keyboard.PressAsync("Tab");
            }
            await Page.Keyboard.PressAsync("Enter");

            //Press the button in the cart to confirm the purchase
            string selector = $"button[data-cid='button.buy_button']";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Page.FrameLocator(selectorIframe).Locator(selector).ClickAsync();


            //Start pop-Up LOOP
            var pageBankId = Page.Context.Pages.FirstOrDefault(x => x.Url.Contains("payments.playground.klarna.com"));
            if (pageBankId != null)
            {
                //Press the BankId to continue
                await pageBankId.ClickAsync("#signInWithBankId");

                //Managing different flows of Klarna
                string selectorLoop = $"button[data-testid='confirm-and-pay']";
                if (selectorLoop != null)
                {
                    //Confirmation of the payment
                    await pageBankId.ClickAsync(selectorLoop);

                }
                else
                {

                    var radio = await pageBankId.QuerySelectorAsync("#pay_later-pay_later__radio-wrapper");
                    await radio.ClickAsync();

                    await pageBankId.ClickAsync($"#pay_later-pay_later__radio-wrapper");

                    await pageBankId.ClickAsync($"button[data-testid='select-payment-category']");

                    await pageBankId.ClickAsync(selectorLoop);
                }

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
            else
            {
                var expectedUrl = "https://web4.1.dev.tt.eu.axs.com/Checkout/KlarnaSuccess";
                var actualUrl = Page.Url;

                // Expected URL loaded directly, so no need to wait for Cart page
                Assert.IsTrue(actualUrl.Contains(expectedUrl), $"Expected URL: {expectedUrl}, Actual URL: {actualUrl}");
            }

        }
    }
}
