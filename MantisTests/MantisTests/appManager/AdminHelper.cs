using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;

namespace MantisTests
{
    public class AdminHelper : HelperBase
    {
        private String baseUrl;
        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = 
                driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered.table-condensed.table-hover"))
                .FindElements(By.TagName("tr"));

            foreach (IWebElement row in rows.Skip(1))
            {               
                IWebElement link =  row.FindElement(By.TagName("a"));
                string name = link.Text;
                string h = link.GetAttribute("href");

                // цифра в конце
                Match m = Regex.Match(h, @"\d+$");
                string id = m.Value;

                // поиск почты
                IWebElement emilTd = row.FindElements(By.TagName("td"))[2];
                string email = emilTd.Text;

                accounts.Add(new AccountData
                { Name = name, Id = id, email = email });
            }
            driver.Quit();
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
           IWebDriver driver = OpenAppAndLogin(); 
           driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
           driver.FindElement(By.XPath("//input[@value='Удалить учетную запись']")).Click();
           driver.FindElement(By.XPath("//input[@value='Удалить учетную запись']")).Click();
            driver.Quit();
        }

        private IWebDriver OpenAppAndLogin()
        {
            // IWebDriver driver = new SimpleBrowserDriver();
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox ESR\firefox.exe";
            options.UseLegacyImplementation = true;
            options.AddArguments("--headless");
            driver = new FirefoxDriver(options);

            driver.Url = baseUrl + "/login_page.php";

            Type(By.Name("username"), "administrator");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Type(By.Name("password"), "root");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return driver;
        }
    }
}
