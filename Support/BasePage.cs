using System;
using FrameVioti.GerenciadorDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameVioti.Support
{
    public class BasePage
    {

        //########################### INICIO DO EXEMPLO DE INSERÇÃO ARQUIVOS #######################################
        public void LimparCampo(IWebElement campo)

        {

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)DriverFactory.GetDriver();

            jsExecutor.ExecuteScript("arguments[0].value = '';", campo);

        }



        public IWebElement AguardarElemento(By by)

        {

            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30));

            return wait.Until(d => d.FindElement(by));

        }



        public void LimparEPreencherCampo(By campoLocator, string valor)

        {

            IWebElement campo = AguardarElemento(campoLocator);

            LimparCampo(campo);

            campo.SendKeys(valor);

        }



        public IWebElement AguardarClickElemento(By by)

        {

            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30));

            return wait.Until(d => d.FindElement(by));

        }

        public void PreencherSeNecessario(By campoLocator, string valor)
        {
            IWebElement campo = AguardarElemento(campoLocator);
            string valorAtual = campo.GetAttribute("value");

            Console.WriteLine(valorAtual);

            if (string.IsNullOrEmpty(valorAtual))
            {
                LimparCampo(campo);
                campo.SendKeys(valor);
            }
        }



    }
}

