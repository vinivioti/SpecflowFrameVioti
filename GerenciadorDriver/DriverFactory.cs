using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameVioti.GerenciadorDriver
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        private DriverFactory() { }

        //public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Chrome)
        //  public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Edge)
        //  public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Firefox)
        //  public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Safari)
          public static IWebDriver GetDriver(BrowserType browserType = BrowserType.Opera)


        {
            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions chromeOptions = new ChromeOptions();
                        // chromeOptions.AddArgument("--headless"); // Adicione o argumento para o modo headless (sem abrir a tela)
                        driver = new ChromeDriver(chromeOptions);
                        break;

                    case BrowserType.Edge:
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        EdgeOptions edgeOptions = new EdgeOptions();
                        // edgeOptions.AddArgument("--headless"); // Adicione o argumento para o modo headless (sem abrir a tela)
                        driver = new EdgeDriver(edgeOptions);
                        break;

                    case BrowserType.Firefox:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                       // firefoxOptions.AddArgument("--headless"); // Adicione o argumento para o modo headless (sem abrir a tela)
                        driver = new FirefoxDriver(firefoxOptions);
                        break;

                    case BrowserType.Safari:
                       // new DriverManager().SetUpDriver(new SafariConfig()); -> Não existe essa opção .. estudar melhor isso.
                        driver = new SafariDriver();
                        break;


                 
                        
                    /*  
                     *  
                    //#### AJUSTAR NO FUTURO PARA O OPERAGX ###
                    
                      case BrowserType.Opera:
                          new DriverManager().SetUpDriver(new ChromeConfig()); // Usando o driver do Chrome para o Opera
                          ChromeOptions operaOptions = new ChromeOptions();
                          operaOptions.BinaryLocation = "C:\\Users\\viniv\\source\\PessoalSpec\\FrameViotiSpecflow\\bin\\Debug\\net6.0\\Opera"; // Especifique o caminho para o executável do Opera
                          //operaOptions.AddArgument("--headless"); // Adicione o argumento para o modo headless (sem abrir a tela)
                          driver = new ChromeDriver(operaOptions);
                          break;
                       
                    */


                    default:
                        // Caso o tipo de navegador não seja suportado, lançar uma exceção ou definir um comportamento padrão
                        throw new System.NotSupportedException($"Tipo de navegador '{browserType}' não suportado.");
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
        Firefox,
        Safari,
        Opera,
        IE
    }
}
