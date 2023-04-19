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

        //public async Task<bool> IsElementVisibleAsync(IPage page, string selector)
        //{
        //    string jsExpression = $"!!document.querySelector('{selector}').offsetParent";
        //    bool isVisible = await page.EvaluateAsync<bool>(jsExpression);
        //    return isVisible;
        //}

        public Task<string> GetSuccessPageAsync() => Page.InnerTextAsync("#section-header__content");

    }
}
