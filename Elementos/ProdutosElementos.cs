using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameVioti.Elementos
{
    public class ProdutosElementos
    {

        private By filtroProdutos = By.CssSelector("#header_container > div.header_secondary_container > div > span > select");
        private By opcaoZA = By.XPath("//option[@value='za']");
        private By produtoTshirtRed = By.XPath("//button[@name='add-to-cart-test.allthethings()-t-shirt-(red)']");
        private By carrinhoCompras = By.XPath("//a[@class='shopping_cart_link']");
        private By btnCheckout = By.XPath("//button[@id='checkout']");
        private By firstName = By.XPath("//input[@id='first-name']");
        private By lastName = By.XPath("//input[@id='last-name']");
        private By zipCode = By.XPath("//input[@id='postal-code']");
        private By btnContinue = By.XPath("//input[@id='continue']");
        private By btnFinish = By.XPath("//button[@id='finish']");
        private By msgSucesso = By.XPath("//h2[@class='complete-header']");



        // COBRANÇACHIPS :::
        public By GetFiltroProdutos() { return filtroProdutos; }
        public By GetOpcaoZA() { return opcaoZA; }
        public By GetProdutoTshirtRed() { return produtoTshirtRed; }
        public By GetCarrinhoCompras() { return carrinhoCompras; }
        public By GetBtnCheckout() { return btnCheckout; }
        public By GetFirstName() { return firstName; }
        public By GetLastName() { return lastName; }
        public By GetZipCode() { return zipCode; }
        public By GetBtnContinue() { return btnContinue; }
        public By GetBtnFinish() { return btnFinish; }
        public By GetMsgSucesso() { return msgSucesso; }


    }


}


