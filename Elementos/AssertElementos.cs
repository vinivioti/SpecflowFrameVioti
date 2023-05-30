using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameVioti.Elementos
{
    public class AssertElementos
    {

        private By algoDeuErrado = By.XPath("//h3[contains(text(),'Epic sadface: Username and password do not match any user in this service')]");
        private By msgSucesso = By.XPath("//h2[@class='complete-header']");
        private By confirmarInicio = By.XPath("//div[contains(text(),'Swag Labs')]");

        public By GetAlgoDeuErrado() { return algoDeuErrado; }
        public By GetMsgSucesso() { return msgSucesso; }
        public By GetConfirmarInicio() { return confirmarInicio; }
    }
}
