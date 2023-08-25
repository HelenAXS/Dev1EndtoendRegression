using BoDi;
using Dev1EndtoendRegression.Objects;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Dev1EndtoendRegression.Hooks
{
    [Binding]
    public sealed class EventHooks
    {

        [BeforeScenario]
        public async Task BeforeEventPurchaseFeatureScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 2000
            });

            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);

            var page = await browser.NewPageAsync();
            container.RegisterInstanceAs(page);

            var pageObject = new PageObject(page);
            container.RegisterInstanceAs(pageObject);
        }



        [AfterScenario]
        public async Task AfterEventPurchaseFeatureScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            playwright.Dispose();
        }
    }
}