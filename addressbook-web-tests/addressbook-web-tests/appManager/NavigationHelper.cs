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
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenAddressBook()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "addressbook/")
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void GoToAddContactPage()
        {
            if (driver.Url == baseURL + "addressbook/edit.php"
               && IsElementPresent(By.Name("firstname")))
            {
                return;
            }
                driver.FindElement(By.LinkText("add new")).Click();            
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
