using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
   public  class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            // group init
            GroupData changed = new GroupData("Changed");
            changed.Header = "12";
            changed.Footer = "FFF";

            app.Groups.Modify(1, changed);
            app.Auth.Logout();
        }
    }
}
