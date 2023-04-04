using Microsoft.Playwright;

namespace Dev1EndtoendRegression.Objects
{
    public abstract class ObjectsBase
    {
        public abstract string PagePath { get; }
        public abstract IPage Page { get; set; }
        public abstract IBrowser Browser { get; }

        public async Task NavigateAsync()
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
        }
    }
}
