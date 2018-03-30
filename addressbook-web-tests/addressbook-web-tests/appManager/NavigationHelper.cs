using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
             this.baseURL = baseURL;
         }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenAddressBook()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void OpenHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
