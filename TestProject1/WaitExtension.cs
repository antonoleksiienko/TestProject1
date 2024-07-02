using OpenQA.Selenium;
using System.Diagnostics;

namespace TestProject1
{
    public static class WaitExtension
    {
        public static IWebElement WaitForElementToBeVisible(this IWebDriver driver, Func<IWebDriver, IWebElement> elementGetter, uint timeoutInMilliseconds = 25000)
        {
            Stopwatch sw = new();
            sw.Start();
            IWebElement element = null;
            while (sw.ElapsedMilliseconds < timeoutInMilliseconds)
            {
                try
                {
                    element = elementGetter(driver);
                    if (element != null && element.Displayed)
                        break;

                    if (element != null && element.Displayed == false)
                        element = null;
                }
                catch
                {
                    // ignored
                }
            }

            sw.Stop();
            return element;
        }
    }
}
