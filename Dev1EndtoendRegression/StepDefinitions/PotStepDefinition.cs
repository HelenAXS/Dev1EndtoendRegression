using Dev1EndtoendRegression.Objects;

namespace Dev1EndtoendRegression.StepDefinitions
{
    [Binding]
    [Scope(Tag = "pot")]
    internal class PotStepDefinition
    {
        private readonly PageObject _pageObject;

        public PotStepDefinition(PageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"I am in dev")]
        public async Task GivenIAmInDev()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"I press the menu '([^']*)'")]
        public async Task GivenIPressTheMenu(string pRODUKTER)
        {
            string selector = $".nav-desktop a[href='/Products']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [Given(@"I press the option '([^']*)'")]
        public async Task GivenIPressTheOption(string pOT)
        {
            string selector = "ul li a[href='/Products/Category/22']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to buy a pot")]
        public async Task WhenIPressToBuyAPotAsync(string kÖP)
        {
            string selector = $"button.modaltrigger[data-target='buyModal-334']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to keep buying")]
        public async Task WhenIPressToKeepBuyingAsync(string p0)
        {
            string selector = $"#buyModal-334 button[name='productsubmit']";
            await _pageObject.ClickButtonsAndMenuOptionsAsync(selector);
        }

        [When(@"I press '([^']*)' to buy a pot again")]
        public async Task WhenIPressToBuyAPotAgainAsync(string kÖP)
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

        [Then(@"I get to the whole Klarna flow until the succeed page")]
        public async Task ThenIGetToTheWholeKlarnaFlowUntilTheSucceedPageAsync()
        {
            string email = "hgalan+autotest3@axs.com";
            await _pageObject.KlarnaPaymentFlowFromAccountPotAsync(email);
        }

    }
}
