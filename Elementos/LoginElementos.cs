using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameVioti.Elementos
{
    public class LoginElementos
    {
  
        //SAUCIDEMO

        private By yuser = By.XPath("//input[@id='user-name']");
        private By wrongYuser = By.XPath("//input[@id='user-name']");
        private By password = By.XPath("//input[@id='password']");
        private By botaoLogin = By.XPath("//input[@id='login-button']");
        private By wrongPassword = By.XPath("//input[@id='password']");
 
        public By GetYuser() { return yuser; }
        public By GetWrongYuser() { return wrongYuser; }
        public By GetPassword() { return password; }
        public By GetBotaoLogin() { return botaoLogin; }
        public By GetWrongPassword() { return wrongPassword; }
       

    }
}

