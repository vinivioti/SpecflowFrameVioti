using FrameVioti.Elementos;
using FrameVioti.GerenciadorDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameVioti.Pages
{
    [Binding]
    public class AssertPage : AssertElementos
    {
        public void VerificarMensagemDeErro()
        {
            string algoDeuErrado = DriverFactory.GetDriver().FindElement(GetAlgoDeuErrado()).Text;
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", algoDeuErrado);

            Console.WriteLine("Esperado:Epic sadface: Username and password do not match any user in this service" + algoDeuErrado);
        }

        public void VerificarMensagemSucesso()
        {
            string msgSucesso = DriverFactory.GetDriver().FindElement(GetMsgSucesso()).Text;
            Assert.AreEqual("Thank you for your order!", msgSucesso);

            Console.WriteLine("Esperado: Thank you for your order! e veio" + msgSucesso);
        }

        public void ConfirmarInicio()
        {
            string confirmarInicio = DriverFactory.GetDriver().FindElement(GetConfirmarInicio()).Text;
            Assert.AreEqual("Swag Labs", confirmarInicio);

            Console.WriteLine("Usuário Esperado: Swag Labs e veio " + confirmarInicio);
                       
        }

    }
}
