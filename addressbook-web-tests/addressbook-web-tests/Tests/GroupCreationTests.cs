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
            // group init
            GroupData group = new GroupData("gr_name123");
            group.Header = "header123";
            group.Footer = "footer123";

            app.Groups.Create(group);

            app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            // group init
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}
