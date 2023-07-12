using FrameVioti.Elementos;
using FrameVioti.GerenciadorDriver;
using OpenQA.Selenium.Support.UI;
using Faker;
using Faker.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameVioti.Support;

namespace FrameVioti.Pages
{
    [Binding]
    public class ProdutosPage : ProdutosElementos
    {
        		
		  //########################### INICIO DO EXEMPLO DE INSERÇÃO ARQUIVOS #######################################

        private string ANEXO;

        //Exemplo para trabalhar com subida de arquivos na tela do DOM
        public ProdutosPage GerenciamentoArquivos()
        {
            //Para setar o caminho genérico para uma pasta (GerenciadorFiles) dentro do projeto mas fora da \bin\Debug
            string projetoPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
            string gerenciadorFilesPath = Path.Combine(projetoPath, "GerenciadorFiles");

            ANEXO = gerenciadorFilesPath;

            return this;

        }

        public ProdutosPage ExemploDeUsoArquivos()
        {
            //Exemplo de uso:
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(20));
            wait.Until((d) => d.FindElement(GetBtnCheckout()) != null);
            DriverFactory.GetDriver().FindElement(GetBtnCheckout()).SendKeys(Path.Combine(ANEXO, "ArquivoDesejado_xx-xx-2023.csv"));
            Console.WriteLine("Anexou com sucesso!!");

            return this;

        }
						//###### NÃO ESQUEÇA DE CRIAR A PASTA DESEJADA NO PROJETO !!!!!. #####
    //########################### FIM DO EXEMPLO ACIMA #######################################


			private PrintaTela print = new PrintaTela();

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
            DriverFactory.GetDriver().FindElement(GetFirstName()).SendKeys(Faker.Name.First());

            var wait1 = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetLastName()) != null);
            DriverFactory.GetDriver().FindElement(GetLastName()).SendKeys(Faker.Name.Middle());

            var wait2 = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(GetZipCode()) != null);
            DriverFactory.GetDriver().FindElement(GetZipCode()).SendKeys(Faker.Address.ZipCode());

            Thread.Sleep(1000);
            print.TakeScreenshot();

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


