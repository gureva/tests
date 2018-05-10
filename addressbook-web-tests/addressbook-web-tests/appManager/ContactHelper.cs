using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {}

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            SelectContactCbox(contact.Id);
            SelectGroupToAdd(group.Name);
            ComitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            SelectGroupFromDropDown(group.Name);
            SelectContactCbox(contact.Id);            
            ComitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void ComitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void ComitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupFromDropDown(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        

        public ContactData GetContactInfoFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            EditContact(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string addressSec = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string homeSec = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notesSec = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Company = company,
                Title = title,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                NickName = nickName,
                MiddleName = middleName,
                AddressSec = addressSec,
                NoteSec = notesSec,
                HomeSec = homeSec
            };
        }

        public ContactData GetContactInfoFromTable(int index)
        {
            manager.Navigator.OpenHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public string GetContactInfoFromView(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click(); ;

            string info = driver.FindElement(By.Id("content")).Text;

            return Regex.Replace(info, "[ \r\nH:M:P:F:W:]", "");
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

        public ContactHelper Remove(ContactData removed)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(removed.Id);
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
            if (GetNumberSearchResults() == 0)
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
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
            }
            return new List<ContactData>(contactCash);
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

        public ContactHelper Delete(ContactData deleted)
        {
            manager.Navigator.OpenHomePage();
            EditContact(deleted.Id);
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

        public ContactHelper Edit(ContactData modified, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            EditContact(modified.Id);
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

        public ContactHelper SelectContactCbox(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            // driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper EditContact(string id)
        {
            driver.FindElement(By.XPath("//a[contains(@href,'edit.php?id=" + id + "')]")).Click();
            return this;
        }

        public ContactHelper SubmitContactEdition()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCash = null;
            return this;
        }

        public int GetNumberSearchResults()
        {
            manager.Navigator.OpenHomePage();

            string text = driver.FindElement(By.CssSelector("label")).Text;
            Match m = new Regex(@"\d+").Match(text);

            return Int32.Parse(m.Value);
        }

        public void SearchContact(string text)
        {
            manager.Navigator.OpenHomePage();
            Type(By.Name("searchstring"), text);
        }

        public int GetRowsNumber()
         {
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            return elements.Count();
        }
    }
}
