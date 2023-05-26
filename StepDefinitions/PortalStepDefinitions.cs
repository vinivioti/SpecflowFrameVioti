using FrameVioti.GerenciadorDriver;
using FrameVioti.Pages;
using FrameVioti.Support;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports.Gherkin.Model;
using System.Runtime.Intrinsics.X86;
using System.ComponentModel.DataAnnotations;
using FrameVioti.Elementos;
using FrameVioti.Pages;

namespace FrameVioti.StepDefinitions
{
    [Binding]
    public sealed class StepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private LoginPage loginPage = new LoginPage();
        private ProdutosPage prodPage = new ProdutosPage();
        private PrintaTela print = new PrintaTela();



        [Given(@"Que o usuario acesse o site")]
        public void GivenQueOUsuarioAcesseOsite()
        {

            loginPage = new LoginPage();

        }

        [When(@"utilizo uma credencial valida")]
        public void WhenUtilizoUmaCredencialValida()
        {
            loginPage.UserLogin();
            loginPage.Userpassword();
            loginPage.BotaoLogin();


        }

        [Then(@"o sistema loga corretamente sem falhas")]
        public void ThenOSistemaLogaCorretamenteSemFalhas()

        {

            Thread.Sleep(3000);

            string confirmarInicio = DriverFactory.GetDriver().FindElement(By.XPath("//div[contains(text(),'Swag Labs')]")).Text;
            Assert.AreEqual("Swag Labs", confirmarInicio);

            Console.WriteLine("Usuário Esperado: Swag Labs e veio " + confirmarInicio);

            print.TakeScreenshot();

            DriverFactory.KillDriver();
        }

        [When(@"utilizo uma credencial invalida password errado")]
        public void WhenUtilizoUmaCredencialInvalidaPasswordErrado()
        {
            loginPage.UserWrongLogin();
            loginPage.UserWrongpassword();
            loginPage.BotaoLogin();
        }



        [Then(@"o sistema nao loga e apresenta mensagem amigavel")]
        public void ThenOSistemaNaoLogaEApresentaMensagemAmigavel()
        {

            Thread.Sleep(2000);
            string algoDeuErrado = DriverFactory.GetDriver().FindElement(By.XPath("//h3[contains(text(),'Epic sadface: Username and password do not match any user in this service')]")).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", algoDeuErrado);

            Console.WriteLine("Esperado:Epic sadface: Username and password do not match any user in this service" + algoDeuErrado);

            print.TakeScreenshot();

            DriverFactory.KillDriver();
        }

        [When(@"ordeno o filtro por Z a A")]
        public void WhenOrdenoOFiltroPorZAA()
        {
            prodPage.FiltroSelecaoProduto();
        }

        [When(@"escolho um produto")]
        public void WhenEscolhoUmProduto()
        {
            prodPage.EscolhoProduto();
        }

        [When(@"clico no carrinho de compras")]
        public void WhenClicoNoCarrinhoDeCompras()
        {
            prodPage.ClicarCarrinho();
        }

        [When(@"clico no checkout")]
        public void WhenClicoNoCheckout()
        {
            prodPage.ClicarCheckout();
        }

        [When(@"preencho os dados de minhas informações continuando")]
        public void WhenPreenchoOsDadosDeMinhasInformacoesContinuando()
        {
            prodPage.PreencheDados();
        }

        [When(@"clico em Finish")]
        public void WhenClicoEmFinish()
        {
            prodPage.Finaliza();
        }

        [Then(@"o sistema apresenta mensagem Thank you for your order!")]
        public void ThenOSistemaApresentaMensagemThankYouForYourOrder()
        {
            Thread.Sleep(2000);
            string msgSucesso = DriverFactory.GetDriver().FindElement(By.XPath("//h2[@class='complete-header']")).Text;
            Assert.AreEqual("Thank you for your order!", msgSucesso);

            Console.WriteLine("Esperado: Thank you for your order! e veio" + msgSucesso);

            print.TakeScreenshot();

            DriverFactory.KillDriver();
        }




    }
}

