using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MantisTests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData acc)
        {
            OpenMainPage();
            OpenRegForm();
            System.Threading.Thread.Sleep(3000);
            FillRegForm(acc);
            SubmitRegistration();
            String url = GetConfirmationUrl(acc);
            FillPasswordForm(url, acc);
            SubmitPasswordForm();
        }

        private void OpenRegForm()
        {
            driver.FindElement(By.CssSelector("[href*='signup_page.php']")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillRegForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.14.0/login_page.php";
        }

        private String GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
           Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.ClassName("submit-button")).Click();

        }
    }
  }
