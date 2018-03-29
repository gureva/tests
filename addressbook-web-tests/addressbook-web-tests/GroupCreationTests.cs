using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            
            // group init
            GroupData group = new GroupData("gr_name123");
            group.Header = "header123";
            group.Footer = "footer123";

            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }                         
    }
}
