using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }        

        //удалить из общего списка
        public ContactHelper Remove(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            RemoveContact();

            return this;
        }

        public int CreateSomeContact()
        {
            ContactData contact = new ContactData("Test", "Remove");
            Create(contact);
            int index = 1;

            return index;
        }

        //проверка на пустой список контактов
        public bool IsContactListEmpty()
        {
            manager.Navigator.OpenHomePage();

            if (driver.FindElement(By.CssSelector("label")).Text == "Number of results: 0")
            {
                return true;
            }
            else return false;           
        }

        // удалить при редактировании
        public ContactHelper Delete(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact(index);
            DeleteContact();
            return this;
        }
        
        public ContactHelper Edit(int index, ContactData contact)
        {
            manager.Navigator.OpenHomePage();          
            EditContact(index);
            FillContactForm(contact);
            SubmitContactEdition();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);            
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactEdition()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }
    }
}
