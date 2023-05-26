using FrameVioti.Elementos;
using FrameVioti.GerenciadorDriver;
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


        public LoginPage()
        {

            DriverFactory.GetDriver().Url = "https://www.saucedemo.com/";
            Thread.Sleep(2000);
        }

        public LoginPage UserLogin()
        {
            DriverFactory.GetDriver().FindElement(GetYuser()).SendKeys("performance_glitch_user");
            return this;
        }

        public LoginPage Userpassword()
        {
            DriverFactory.GetDriver().FindElement(GetPassword()).SendKeys("secret_sauce");
            return this;
        }

        public LoginPage UserWrongLogin()
        {
            DriverFactory.GetDriver().FindElement(GetWrongYuser()).SendKeys("usuarioInexistente");
            return this;
        }
       
        public LoginPage UserWrongpassword()
        {
            DriverFactory.GetDriver().FindElement(GetWrongPassword()).SendKeys("senhaInvalida");
            return this;
        }

        public LoginPage BotaoLogin()
        {

           DriverFactory.GetDriver().FindElement(GetBotaoLogin()).Click();
            return this;
        }

         
    }
}



