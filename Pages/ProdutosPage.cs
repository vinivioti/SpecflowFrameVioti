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


        private PrintaTela print = new PrintaTela();
        private BasePage bp = new BasePage();


        public ProdutosPage FiltroSelecaoProduto()
        {
            Thread.Sleep(2000);
            bp.AguardarClickElemento(GetFiltroProdutos()).Click();

            bp.AguardarClickElemento(GetOpcaoZA()).Click();


            return this;
        }

        public ProdutosPage EscolhoProduto()
        {
            Thread.Sleep(2000);
            bp.AguardarClickElemento(GetProdutoTshirtRed()).Click();

            return this;
        }

        public ProdutosPage ClicarCarrinho()
        {
            Thread.Sleep(2000);
            bp.AguardarClickElemento(GetCarrinhoCompras()).Click();

            return this;
        }

        public ProdutosPage ClicarCheckout()
        {
            Thread.Sleep(2000);
            bp.AguardarClickElemento(GetBtnCheckout()).Click();

            return this;
        }

        public ProdutosPage PreencheDados()
        {
            Thread.Sleep(2000);
            bp.LimparEPreencherCampo(GetFirstName(), Faker.Name.First());

            bp.LimparEPreencherCampo(GetLastName(), Faker.Name.Middle() + Faker.Name.Last());

            bp.LimparEPreencherCampo(GetZipCode(), Faker.Address.ZipCode());

            Thread.Sleep(1000);
            print.TakeScreenshot();

            bp.AguardarClickElemento(GetBtnContinue()).Click();


            return this;
        }

        public ProdutosPage Finaliza()
        {
            Thread.Sleep(2000);
            bp.AguardarClickElemento(GetBtnFinish()).Click();

            return this;
        }
    }
}


