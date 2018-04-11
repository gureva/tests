using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();

            return this;
        }

        public int CreateSomeGroup()
        {
            GroupData gr = new GroupData("Test");
            Create(gr);
            int index = 1;

            return index;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index);                    
            RemoveGroup();
            ReturnToGroupsPage();            

            return this;
        }

        public GroupHelper Modify(int index, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            
            SelectGroup(index);            
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        //проверка на пустой список контактов
        public bool IsGroupListEmpty()
        {
            manager.Navigator.GoToGroupsPage();
            if (IsElementPresent(By.XPath("(.//input[@name='selected[]'])[1]")))
            {
                return false;
            }
            else return true;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
    }
}
