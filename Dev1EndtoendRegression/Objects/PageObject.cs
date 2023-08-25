using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task<bool> HasElementAsync(string availableSelector)
        {
            try
            {
                await Page.WaitForSelectorAsync(availableSelector);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
        public async Task KlarnaPaymentAsync(string email)
        {
            string selectorIframe = "#klarna-checkout-iframe";

            //Write the e-mail in Klarna's iframe's field
            string selectorFieldEmail = "#billing-email";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Task.Delay(2000);
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldEmail).FillAsync(email);



            //Write the postal in Klarna's iframe's field
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
            var bankIdPage = await Page.WaitForPopupAsync();
            await bankIdPage.WaitForLoadStateAsync();
            await bankIdPage.ClickAsync("#signInWithBankId"); 


            //Managing different flows of Klarna
            string selectorLoop = $"button[data-testid='confirm-and-pay']";
            if (selectorLoop != null)
            {
                //Confirmation of the payment
                await bankIdPage.ClickAsync(selectorLoop);
                //await bankIdPage.ClickAsync($"[data-testid='SmoothCheckoutPopUp:enable']");
            }
            else
            {
                var radio = await bankIdPage.QuerySelectorAsync("#pay_later-pay_later__radio-wrapper");
                await radio.ClickAsync();

                await bankIdPage.ClickAsync($"#pay_later-pay_later__radio-wrapper");

                await bankIdPage.ClickAsync($"button[data-testid='select-payment-category']");

                await bankIdPage.ClickAsync(selectorLoop);
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
            await Task.Delay(2000);
            await Page.WaitForSelectorAsync(selectorIframe);
            string post = "61135";
            await Page.FrameLocator(selectorIframe).Locator(selectorFieldPostal).FillAsync(post);
            await Task.Delay(2000);
            await Page.Keyboard.PressAsync("Tab");
            string selectorContinue = "#button-primary";
            await Page.FrameLocator(selectorIframe).Locator(selectorContinue).ClickAsync();

            //Press the button in the cart to confirm the purchase
            string selector = $"button[data-cid='button.buy_button']";
            await Page.WaitForSelectorAsync(selectorIframe);
            await Page.FrameLocator(selectorIframe).Locator(selector).ClickAsync();

            //Start pop-Up LOOP
            var bankIdPage = await Page.WaitForPopupAsync();

            //Press the BankId to continue
            await bankIdPage.ClickAsync("#signInWithBankId");

            //Managing different flows of Klarna
            string selectorLoop = $"button[data-testid='confirm-and-pay']";
            if (selectorLoop != null)
            {
                //Confirmation of the payment
                await bankIdPage.ClickAsync(selectorLoop);
                await bankIdPage.ClickAsync($"[data-testid='SmoothCheckoutPopUp:enable']");

            }
            else
            {

                var radio = await bankIdPage.QuerySelectorAsync("#pay_later-pay_later__radio-wrapper");
                await radio.ClickAsync();

                await bankIdPage.ClickAsync($"#pay_later-pay_later__radio-wrapper");

                await bankIdPage.ClickAsync($"button[data-testid='select-payment-category']");

                await bankIdPage.ClickAsync(selectorLoop);
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
    }
}
