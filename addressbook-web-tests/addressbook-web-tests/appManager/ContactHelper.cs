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
            manager.Navigator.OpenHomePage();

            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }


        public int CreateSomeContact()
        {
            ContactData contact = new ContactData("123", "Remove");
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

        private List<ContactData> contactCash = null;

        public List<ContactData> GetContactList()
        {

            if (contactCash == null)
            {
                contactCash = new List<ContactData>();

                List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.OpenHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                IWebElement fname;
                IWebElement lname;
                int i = 2;
                foreach (IWebElement element in elements)
                {
                    fname = element.FindElement(By.XPath("//tr[" + i + "]/td[2]"));
                    lname = element.FindElement(By.XPath("//tr[" + i + "]/td[3]"));
                    i++;
                    contactCash.Add(new ContactData(lname.Text, fname.Text) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")});
                }
            }

            return new List<ContactData> (contactCash);
        }

        // удалить при редактировании
        public ContactHelper Delete(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact(index);
            DeleteContact();
            manager.Navigator.OpenHomePage();

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
            contactCash = null;

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
            contactCash = null;
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            contactCash = null;
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
            contactCash = null;
            return this;
        }
    }
}
