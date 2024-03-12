using FrameVioti.Elementos;
using FrameVioti.GerenciadorDriver;
using FrameVioti.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameVioti.Pages
{
    [Binding]
    public class LoginPage : LoginElementos
    {
        private BasePage bp = new BasePage();

        public LoginPage()
        {

            DriverFactory.GetDriver().Url = "https://www.saucedemo.com/";
            Thread.Sleep(2000);
        }

        public LoginPage UserLogin()
        {
            bp.LimparEPreencherCampo(GetYuser(), "performance_glitch_user");
            // DriverFactory.GetDriver().FindElement(GetYuser()).SendKeys("performance_glitch_user");
            return this;
        }

        public LoginPage Userpassword()
        {
            bp.LimparEPreencherCampo(GetPassword(), "secret_sauce");
            // DriverFactory.GetDriver().FindElement(GetPassword()).SendKeys("secret_sauce");
            return this;
        }

        public LoginPage UserWrongLogin()
        {
            bp.LimparEPreencherCampo(GetWrongYuser(), "usuarioInexistente");
            // DriverFactory.GetDriver().FindElement(GetWrongYuser()).SendKeys("usuarioInexistente");
            return this;
        }

        public LoginPage UserWrongpassword()
        {
            bp.LimparEPreencherCampo(GetWrongPassword(), "senhaInvalida");
            //  DriverFactory.GetDriver().FindElement(GetWrongPassword()).SendKeys("senhaInvalida");
            return this;
        }

        public LoginPage BotaoLogin()
        {
            bp.AguardarClickElemento(GetBotaoLogin()).Click();
            // DriverFactory.GetDriver().FindElement(GetBotaoLogin()).Click();
            return this;
        }


    }
}



