using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MantisTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if (isLoggedIn())
            {
                return;
            }
            else
            {
                Type(By.Name("username"), account.Name);
                driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                Type(By.Name("password"), account.Password);
                driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            }
        }

        public bool isLoggedIn()
        {
            return IsElementPresent(By.ClassName("user-info"));
        }
    }
}
