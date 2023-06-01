using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameVioti.GerenciadorDriver
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        private DriverFactory() { }

       // public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Chrome)
       // public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Firefox)
        public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Edge)
        {
            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions chromeOptions = new ChromeOptions();
                        // chromeOptions.AddArgument("--headless"); // Adicione esse argumento para executar em modo headless (sem abrir a janela do navegador)
                        driver = new ChromeDriver(chromeOptions);
                        break;

                    case BrowserType.Edge:
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;

                    case BrowserType.Firefox:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;

                    default:
                        throw new WebDriverException("Invalid browser type provided.");
                }

                driver.Manage().Window.Maximize();
            }

            return driver;
        }

        public static void KillDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }

    public enum BrowserType
    {
        Chrome,
        Edge,
        Firefox
    }
}
