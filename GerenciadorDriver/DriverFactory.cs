using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace FrameVioti.GerenciadorDriver
{
    public class DriverFactory
    {
        private static WebDriver driver;



        private DriverFactory() { }
        public static WebDriver GetDriver()
        {
            if (driver == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                ChromeOptions options = new ChromeOptions();
               // options.AddArgument("--headless"); // Adiciona o argumento para modo headless (sem abrir a tela)
                driver = new ChromeDriver(options);
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
}

