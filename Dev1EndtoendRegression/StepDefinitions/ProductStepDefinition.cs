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
            string selector = $"button.modaltrigger[data-target='buyModal-357']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to keep buying")]
        public async Task WhenIPressToKeepBuyingAsync(string keepBuying)
        {
            string selector = $"#buyModal-357 button[name='productsubmit']";
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

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPage()
        {
            string email = "hgalan@axs.com";
            await _pageObject.KlarnaPaymentAsync(email);
        }


    }
}
