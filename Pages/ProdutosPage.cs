using FrameVioti.Elementos;
using FrameVioti.GerenciadorDriver;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameVioti.Pages
{
    [Binding]
    public class ProdutosPage : ProdutosElementos
    {


        public ProdutosPage FiltroSelecaoProduto()
        {
            Thread.Sleep(2000);
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetFiltroProdutos()) != null);
            DriverFactory.GetDriver().FindElement(GetFiltroProdutos()).Click();

            var wait1 = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetOpcaoZA()) != null);
            DriverFactory.GetDriver().FindElement(GetOpcaoZA()).Click();


            return this;
        }

        public ProdutosPage EscolhoProduto()
        {
            Thread.Sleep(2000);
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetProdutoTshirtRed()) != null);
            DriverFactory.GetDriver().FindElement(GetProdutoTshirtRed()).Click();

            return this;
        }

        public ProdutosPage ClicarCarrinho()
        {
            Thread.Sleep(2000);
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetCarrinhoCompras()) != null);
            DriverFactory.GetDriver().FindElement(GetCarrinhoCompras()).Click();

            return this;
        }

        public ProdutosPage ClicarCheckout()
        {
            Thread.Sleep(2000);
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetBtnCheckout()) != null);
            DriverFactory.GetDriver().FindElement(GetBtnCheckout()).Click();

            return this;
        }

        public ProdutosPage PreencheDados()
        {
            Thread.Sleep(2000);
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetFirstName()) != null);
            DriverFactory.GetDriver().FindElement(GetFirstName()).SendKeys("ViniTest");

            var wait1 = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetLastName()) != null);
            DriverFactory.GetDriver().FindElement(GetLastName()).SendKeys("LastName");

            var wait2 = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetZipCode()) != null);
            DriverFactory.GetDriver().FindElement(GetZipCode()).SendKeys("02641000");

            var wait3 = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetBtnContinue()) != null);
            DriverFactory.GetDriver().FindElement(GetBtnContinue()).Click();

            return this;
        }

        public ProdutosPage Finaliza()
        {
            Thread.Sleep(2000);
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetBtnFinish()) != null);
            DriverFactory.GetDriver().FindElement(GetBtnFinish()).Click();


            return this;
        }
    }
}


