using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base (manager)
        {
        }

        public void Login(AccountData account)
        {
            if (isLoggedIn())
            {
                if (isLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            
           Type(By.Name("user"), account.Username);
           Type(By.Name("pass"), account.Password);
           driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            
        }

        public bool isLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool isLoggedIn(AccountData account)
        {
            return isLoggedIn()
                && GetLoggetUserName() == account.Username;                
        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
             
            return text.Substring(1, text.Length-2);
        }

        public void Logout()
        {

            if (isLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
